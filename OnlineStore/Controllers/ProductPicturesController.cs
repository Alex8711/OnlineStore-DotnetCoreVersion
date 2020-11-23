using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Dtos;
using OnlineStore.Models;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    [Route("api/products/{productId}/pictures")]
    [ApiController]
    public class ProductPicturesController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductPicturesController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetPicturesListForProduct(Guid productId)
        {
            if (! await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound("Product Not Exists");
            }

            var picturesFromRepo = await _productRepository.GetPicturesByProductIdAsync(productId);
            if (picturesFromRepo == null || picturesFromRepo.Count() <= 0)
            {
                return NotFound("Pictures Not Exist");
            }

            return Ok(_mapper.Map<IEnumerable<ProductPictureDto>>(picturesFromRepo));
        }

        [HttpGet("{pictureId}",Name = "GetPicture")]
        public async Task<IActionResult> GetPicture(Guid productId, int pictureId)
        {
            if (! await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound("Product Not Exists");
            }

            var pictureFromRepo =await _productRepository.GetPictureAsync(pictureId);
            if (pictureFromRepo == null)
            {
                return NotFound("Picture Not Exists");
            }

            return Ok(_mapper.Map<ProductPictureDto>(pictureFromRepo));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProductPicture([FromRoute] Guid productId,[FromBody] ProductPictureForCreationDto productPictureForCreationDto)
        {
            if (! await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound("Product Not Exists");
            }

            var pictureModel = _mapper.Map<ProductPicture>(productPictureForCreationDto);
            _productRepository.AddProductPicture(productId, pictureModel);
            await _productRepository.SaveAsync();
            var pictureToReturn = _mapper.Map<ProductPictureDto>(pictureModel);
            return CreatedAtRoute(
                "GetPicture", new {productId = pictureModel.ProductId, pictureId = pictureModel.Id},pictureToReturn
            );
        }

        [HttpDelete("{pictureId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePicture([FromRoute] Guid productId,[FromRoute] int pictureId)
        {
            if (!await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound("Product Not Exists");
            }

           var picture = await _productRepository.GetPictureAsync(pictureId);
           _productRepository.DeleteProductPicture(picture);
           await _productRepository.SaveAsync();
           return NoContent();
        }
    }
    
}
