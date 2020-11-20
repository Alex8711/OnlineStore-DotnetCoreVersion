using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Dtos;
using OnlineStore.Models;
using OnlineStore.ResourceParameters;
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
        [HttpHead] 
        public IActionResult GetProducts([FromQuery] ProductResourceParameters parameters)
        {
            var productsFromRepo = _productRepository.GetProducts(parameters.Keyword);
            if (productsFromRepo == null || productsFromRepo.Count() <= 0)
            {
                return NotFound("No Products");
            }

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);
            return Ok(productsDto);
        }

        [HttpGet("{productId:Guid}",Name= "GetProductById")]
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

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreationDto productForCreationDto)
        {
            var productModel = _mapper.Map<Product>(productForCreationDto);
            _productRepository.AddProduct(productModel);
            _productRepository.Save();
            var productToReturn = _mapper.Map<ProductDto>(productModel);
            return CreatedAtRoute("GetProductById", new {productId = productToReturn.Id}, productToReturn);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct( [FromRoute]Guid productId,[FromBody] ProductForUpdateDto productForUpdateDto )
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound("Product Not Exists");
            }

            var productFromRepo = _productRepository.GetProduct(productId);
            //1. to dto
            //2. update dto
            //3. to model
            _mapper.Map(productForUpdateDto, productFromRepo);
            _productRepository.Save();
            return NoContent();
        }

        [HttpPatch("{productId}")]
        public IActionResult PartiallyUpdateProduct([FromRoute] Guid productId,[FromBody] JsonPatchDocument<ProductForUpdateDto> patchDocument)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound("Product Not Exists");
            }

           var productFromRepo= _productRepository.GetProduct(productId);
           var productToPatch = _mapper.Map<ProductForUpdateDto>(productFromRepo);
           patchDocument.ApplyTo(productToPatch,ModelState);
           if (!TryValidateModel(productToPatch))
           {
               return ValidationProblem(ModelState);
           }
           _mapper.Map(productToPatch, productFromRepo);
           _productRepository.Save();
           return NoContent();
        }
    }
}
