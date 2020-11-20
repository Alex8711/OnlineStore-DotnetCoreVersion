using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Dtos;
using OnlineStore.Models;

namespace OnlineStore.Profiles
{
    public class ProductPictureProfile : Profile
    {
        public ProductPictureProfile()
        {
            CreateMap<ProductPicture, ProductPictureDto>();
            CreateMap<ProductPictureForCreationDto, ProductPicture>();
            CreateMap<ProductPicture, ProductPictureForCreationDto>();
        }

    }
}
