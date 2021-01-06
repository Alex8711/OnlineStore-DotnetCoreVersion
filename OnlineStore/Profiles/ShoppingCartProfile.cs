using AutoMapper;
using OnlineStore.Dtos;
using OnlineStore.Models;

namespace OnlineStore.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<LineItem, LineItemDto>();
        }
    }
}