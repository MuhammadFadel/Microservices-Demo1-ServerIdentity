using AutoMapper;
using Demo1Api.DTOs;
using Demo1Api.Models;

namespace Demo1Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDetailedDto>(); 
            CreateMap<ProductDetailedDto, Product>();

            CreateMap<Product, ProductListDto>();
            CreateMap<ProductListDto, Product>();

            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
