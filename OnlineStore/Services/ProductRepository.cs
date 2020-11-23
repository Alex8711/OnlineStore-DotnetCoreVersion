using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Database;

namespace OnlineStore.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await _context.Products.Include(x=>x.ProductPictures).FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string keyword)
        {
            IQueryable<Product> result = _context.Products.Include(x => x.ProductPictures);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result=result.Where(x => x.Title.Contains(keyword));
            }

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByIDListAsync(IEnumerable<Guid> ids)
        {
            return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<bool>  ProductExistsAsync(Guid productId)
        {
            return await _context.Products.AnyAsync(x => x.Id == productId);
        }

       public async Task<IEnumerable<ProductPicture>>  GetPicturesByProductIdAsync(Guid productId)
       {
           return await _context.ProductPictures.Where(x => x.ProductId == productId).ToListAsync();
       }

       public async Task<ProductPicture>  GetPictureAsync(int pictureId)
       {
           return await _context.ProductPictures.Where(x => x.Id == pictureId).FirstOrDefaultAsync();
       }

       public void AddProduct(Product product)
       {
           if (product == null)
           {
               throw new ArgumentNullException(nameof(product));
           }

           _context.Products.Add(product);
           //_context.SaveChanges();
       }

       public void AddProductPicture(Guid productId, ProductPicture productPicture)
       {
           if (productId == Guid.Empty)
           {
               throw new ArgumentNullException(nameof(productId));
           }

           if (productPicture == null)
           {
               throw new ArgumentNullException(nameof(productPicture));
           }

           productPicture.ProductId = productId;
           _context.ProductPictures.Add(productPicture);
       }

       public void DeleteProduct(Product product)
       {
           _context.Products.Remove(product);
       }

       public void DeleteProductPicture(ProductPicture productPicture)
       {
           _context.ProductPictures.Remove(productPicture);
       }

       public void DeleteProducts(IEnumerable<Product> products)
       {
            _context.Products.RemoveRange(products);
       }
        public async Task<bool> SaveAsync()
       {
           return (await _context.SaveChangesAsync() >= 0);
       }

        
    }
}
