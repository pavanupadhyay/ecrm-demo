using AutoMapper;
using ProductsAPI.Data.Entities;
using ProductsAPI.Services.Dto;

namespace ProductsAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductListDto, Product>().ReverseMap();

        }
    }
}
