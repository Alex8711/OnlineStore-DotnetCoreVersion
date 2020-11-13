using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        Product IProductRepository.GetProduct(Guid productId)
        {
            return _context.Products.FirstOrDefault(x => x.Id == productId);
        }

        IEnumerable<Product> IProductRepository.GetProducts()
        {
            return _context.Products;
        }
    }
}
