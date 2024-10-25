using AutoMapper;
using App.Business.DTOs.ProductDTOs;
using App.Core.Entities;
using App.Business.MappingProfiles.Commons;

namespace App.Business.MappingProfiles
{
    public class ProductMP : Profile
    {
        public ProductMP()
        {
             CreateMap<CreateProductDTO, Product>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                //.AfterMap<CustomMappingAction<CreateProductDTO, Product>>()
                .ReverseMap();  

             CreateMap<UpdateProductDTO, Product>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                //.AfterMap<CustomMappingAction<UpdateProductDTO, Product>>()
                .ReverseMap();  
        }
    }
}
