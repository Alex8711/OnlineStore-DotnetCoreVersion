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

        public Product GetProduct(Guid productId)
        {
            return _context.Products.Include(x=>x.ProductPictures).FirstOrDefault(x => x.Id == productId);
        }

        public IEnumerable<Product> GetProducts(string keyword)
        {
            IQueryable<Product> result = _context.Products.Include(x => x.ProductPictures);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result=result.Where(x => x.Title.Contains(keyword));
            }

            return result.ToList();
        }

        public IEnumerable<Product> GetProductsByIDList(IEnumerable<Guid> ids)
        {
            return _context.Products.Where(p => ids.Contains(p.Id)).ToList();
        }

        public bool ProductExists(Guid productId)
        {
            return _context.Products.Any(x => x.Id == productId);
        }

       public IEnumerable<ProductPicture> GetPicturesByProductId(Guid productId)
       {
           return _context.ProductPictures.Where(x => x.ProductId == productId).ToList();
       }

       public ProductPicture GetPicture(int pictureId)
       {
           return _context.ProductPictures.Where(x => x.Id == pictureId).FirstOrDefault();
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
        public bool Save()
       {
           return (_context.SaveChanges() >= 0);
       }

        
    }
}
