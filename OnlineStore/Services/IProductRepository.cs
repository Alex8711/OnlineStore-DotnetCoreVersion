using System;
using System.Collections;
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
        Task<ShoppingCart> GetShoppingCartByUserId(string userId);
        Task CreateShoppingCart(ShoppingCart shoppingCart);
        Task AddShoppingCartItem(LineItem lineItem);
        Task<LineItem> GetShoppingCartItemByItemId(int lineItemId);
        void DeleteShoppingCartItem(LineItem lineItem);
        
        Task<IEnumerable<LineItem>> GetShoppingCartsByIdListAsync(IEnumerable<int> ids);
        void DeleteShoppingCartItems(IEnumerable<LineItem> lineItems);
        Task<bool> SaveAsync();
    }
}
