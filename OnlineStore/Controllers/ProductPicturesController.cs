using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public IActionResult GetPicturesListForProduct(Guid productId)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound("Product Not Exists");
            }

            var picturesFromRepo = _productRepository.GetPicturesByProductId(productId);
            if (picturesFromRepo == null || picturesFromRepo.Count() <= 0)
            {
                return NotFound("Pictures Not Exist");
            }

            return Ok(_mapper.Map<IEnumerable<ProductPictureDto>>(picturesFromRepo));
        }

        [HttpGet("{pictureId}",Name = "GetPicture")]
        public IActionResult GetPicture(Guid productId, int pictureId)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound("Product Not Exists");
            }

            var pictureFromRepo = _productRepository.GetPicture(pictureId);
            if (pictureFromRepo == null)
            {
                return NotFound("Picture Not Exists");
            }

            return Ok(_mapper.Map<ProductPictureDto>(pictureFromRepo));
        }

        [HttpPost]
        public IActionResult CreateProductPicture([FromRoute] Guid productId,[FromBody] ProductPictureForCreationDto productPictureForCreationDto)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound("Product Not Exists");
            }

            var pictureModel = _mapper.Map<ProductPicture>(productPictureForCreationDto);
            _productRepository.AddProductPicture(productId, pictureModel);
            _productRepository.Save();
            var pictureToReturn = _mapper.Map<ProductPictureDto>(pictureModel);
            return CreatedAtRoute(
                "GetPicture", new {productId = pictureModel.ProductId, pictureId = pictureModel.Id},pictureToReturn
            );
        }
    }
    
}
