using ApplicationCore.Entities;
using ApplicationCore.Entities.CartAggregate;
using AutoMapper;
using WebApi.BrandEndpoint;
using WebApi.CartEndpoint;
using WebApi.ProductEndpoint;
using WebApi.ProductTypeEndpoint;

namespace WebApi
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductType, ProductTypeDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
            CreateMap<Brand, BrandDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Name));
            CreateMap<CartItem, CartItemDto>();
            CreateMap<Cart, CartDto>()                
                .ForMember(dto => dto.Items, options => options.MapFrom(src => src.Items));
        }
    }
}
