using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    [ApiController]
    public class ProductPicturesController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
    }
    //public 
}
