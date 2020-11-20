using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Dtos;
using OnlineStore.Models;

namespace OnlineStore.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Price,
                opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPercentage ?? 1)));
            CreateMap<ProductForCreationDto, Product>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductForUpdateDto, Product>();

            CreateMap<Product, ProductForUpdateDto>();
        }
    }
}
