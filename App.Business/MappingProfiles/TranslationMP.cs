using AutoMapper;
using App.Business.DTOs.TranslationDTOs;
using App.Core.Entities.Commons;

namespace App.Business.MappingProfiles
{
    public class TranslationProfile<T> : Profile where T : BaseEntity
    {
        public TranslationProfile()
        {
            CreateMap<CreateTranslationDTO<T>, Translation<T>>()
                .ForMember(dest => dest.Entity, opt => opt.Ignore())
                .ForMember(dest => dest.EntityId, opt => opt.MapFrom(src => src.EntityId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language));
        }
    }
}
