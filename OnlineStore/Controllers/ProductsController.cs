using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Dtos;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var productsFromRepo = _productRepository.GetProducts();
            if (productsFromRepo == null || productsFromRepo.Count() <= 0)
            {
                return NotFound("No Products");
            }

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);
            return Ok(productsDto);
        }

        [HttpGet("{productId:Guid}")]
        public IActionResult GetProductById(Guid productId)
        {
            var productFromRepo = _productRepository.GetProduct(productId);
            if (productFromRepo == null)
            {
                return NotFound($"No Product with Id-{productId}");
            }

            var productDto = _mapper.Map<ProductDto>(productFromRepo);
            return Ok(productDto);
        }
    }
}
