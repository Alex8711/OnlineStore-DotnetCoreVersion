using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(string keyword);
        Product GetProduct(Guid productId);
        IEnumerable<Product> GetProductsByIDList(IEnumerable<Guid> ids);
        bool ProductExists(Guid productId);
        IEnumerable<ProductPicture>GetPicturesByProductId(Guid productId);
        ProductPicture GetPicture(int pictureId);
        void AddProduct(Product product);

        void AddProductPicture(Guid productId, ProductPicture productPicture);

        void DeleteProduct(Product product);
        void DeleteProducts(IEnumerable<Product> products);
        void DeleteProductPicture(ProductPicture picture);
        bool Save();
    }
}
