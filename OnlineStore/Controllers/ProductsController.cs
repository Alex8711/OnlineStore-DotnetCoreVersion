using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Dtos;
using OnlineStore.Helper;
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
        public async Task<IActionResult> GetProducts([FromQuery] ProductResourceParameters parameters)
        {
            var productsFromRepo = await _productRepository.GetProductsAsync(parameters.Keyword);
            if (productsFromRepo == null || productsFromRepo.Count() <= 0)
            {
                return NotFound("No Products");
            }
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);
            return Ok(productsDto);
        }

        [HttpGet("{productId:Guid}",Name= "GetProductById")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var productFromRepo = await _productRepository.GetProductAsync(productId);
            if (productFromRepo == null)
            {
                return NotFound($"No Product with Id-{productId}");
            }

            var productDto = _mapper.Map<ProductDto>(productFromRepo);
            return Ok(productDto);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productForCreationDto)
        {
            var productModel = _mapper.Map<Product>(productForCreationDto);
            _productRepository.AddProduct(productModel);
            await _productRepository.SaveAsync();
            var productToReturn = _mapper.Map<ProductDto>(productModel);
            return CreatedAtRoute("GetProductById", new {productId = productToReturn.Id}, productToReturn);
        }

        [HttpPut("{productId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct( [FromRoute]Guid productId,[FromBody] ProductForUpdateDto productForUpdateDto )
        {
            if (! await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound("Product Not Exists");
            }

            var productFromRepo = await _productRepository.GetProductAsync(productId);
            //1. to dto
            //2. update dto
            //3. to model
            _mapper.Map(productForUpdateDto, productFromRepo);
            await _productRepository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{productId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PartiallyUpdateProduct([FromRoute] Guid productId,[FromBody] JsonPatchDocument<ProductForUpdateDto> patchDocument)
        {
            if (! await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound("Product Not Exists");
            }

           var productFromRepo= await _productRepository.GetProductAsync(productId);
           var productToPatch = _mapper.Map<ProductForUpdateDto>(productFromRepo);
           patchDocument.ApplyTo(productToPatch,ModelState);
           if (!TryValidateModel(productToPatch))
           {
               return ValidationProblem(ModelState);
           }
           _mapper.Map(productToPatch, productFromRepo);
           await _productRepository.SaveAsync();
           return NoContent();
        }

        [HttpDelete("{productId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            if (!await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound("Product Not Exists");
            }

            var product = await _productRepository.GetProductAsync(productId);
            _productRepository.DeleteProduct(product);
            await _productRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("({productIDs})")]
        public async Task<IActionResult> DeleteByIDs([ModelBinder(BinderType = typeof(ArrayModelBinder))][FromRoute] IEnumerable<Guid> productIDs)
        {
            if (productIDs == null)
            {
                return BadRequest();
            }

            var productsFromRepo = await _productRepository.GetProductsByIDListAsync(productIDs);
            _productRepository.DeleteProducts(productsFromRepo);
            await _productRepository.SaveAsync();
            return NoContent();
        }
    }
}
