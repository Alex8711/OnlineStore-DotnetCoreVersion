using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(string keyword);
        Task<Product> GetProductAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductsByIDListAsync(IEnumerable<Guid> ids);
        Task<bool> ProductExistsAsync(Guid productId);
        Task<IEnumerable<ProductPicture>> GetPicturesByProductIdAsync(Guid productId);
        Task<ProductPicture> GetPictureAsync(int pictureId);
        void AddProduct(Product product);

        void AddProductPicture(Guid productId, ProductPicture productPicture);

        void DeleteProduct(Product product);
        void DeleteProducts(IEnumerable<Product> products);
        void DeleteProductPicture(ProductPicture picture);
        Task<bool> SaveAsync();
    }
}
