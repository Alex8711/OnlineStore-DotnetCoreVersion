using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var productsFromRepo = _productRepository.GetProducts();
            if (productsFromRepo == null || productsFromRepo.Count() <= 0)
            {
                return NotFound("No Products");
            }
            return Ok(productsFromRepo);
        }

        [HttpGet("{productId:Guid}")]
        public IActionResult GetProductById(Guid productId)
        {
            var productFromRepo = _productRepository.GetProduct(productId);
            if (productFromRepo == null)
            {
                return NotFound($"No Product with Id-{productId}");
            }
           return Ok(productFromRepo);
        }
    }
}
