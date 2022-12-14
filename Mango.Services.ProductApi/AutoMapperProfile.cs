using AutoMapper;
using Mango.Services.ProductApi.Dtos;
using Mango.Services.ProductApi.Dtos.ProductDtos;
using Mango.Services.ProductApi.Models;

namespace Mango.Services.ProductApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ResponseDto>();
            CreateMap<ResponseDto, Product>();
        }
    }
}
