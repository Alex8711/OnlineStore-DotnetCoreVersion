using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Dtos;
using OnlineStore.Helper;
using OnlineStore.Models;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    [ApiController]
    [Route("api/shoppingCart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor,IProductRepository productRepository,IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetShoppingCart()
        {
            // get user
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // get shoppingCart by userId
            var shoppingCart = await _productRepository.GetShoppingCartByUserId(userId);

            return Ok(_mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        [HttpPost("items")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> AddShoppingCartItem([FromBody] AddShoppingCartItemDto addShoppingCartItemDto)
        {
            // get user
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // get shoppingCart by userId
            var shoppingCart = await _productRepository.GetShoppingCartByUserId(userId);

            //create lineItem
            var product = await _productRepository.GetProductAsync(addShoppingCartItemDto.ProductId);
            if (product == null)
            {
                return NotFound("product is not existed");
            }

            var lineItem = new LineItem()
            {
                ProductId = addShoppingCartItemDto.ProductId,
                ShoppingCartId = shoppingCart.Id,
                OriginalPrice = product.OriginalPrice,
                DiscountPercentage = product.DiscountPercentage
            };
            //add lineItem and save it in the database
            await _productRepository.AddShoppingCartItem(lineItem);
            await _productRepository.SaveAsync();

            return Ok(_mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        [HttpDelete("items/{itemId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> DeleteShoppingCartItem([FromRoute] int itemId)
        {
            // get lineitem
            var lineItem = await _productRepository.GetShoppingCartItemByItemId(itemId);
            if (lineItem == null)
            {
                return NotFound("can not find the item in shopping cart");
            }
            _productRepository.DeleteShoppingCartItem(lineItem);
            await _productRepository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("items/({itemIDs})")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> RemoveShoppingCartItems([ModelBinder(BinderType = typeof(ArrayModelBinder))]
            [FromRoute] IEnumerable<int> itemIDs)
        {
            var lineItems = await _productRepository
                .GetShoppingCartsByIdListAsync(itemIDs);
            _productRepository.DeleteShoppingCartItems(lineItems);
            await _productRepository.SaveAsync();
            return NoContent();
        }
    }
}