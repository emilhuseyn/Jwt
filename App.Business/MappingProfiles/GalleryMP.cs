using App.Business.DTOs.GalleryDTOs;
using App.Business.MappingProfiles.Commons;
using App.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Business.MappingProfiles
{
    public class GalleryMP : Profile
    {
        public GalleryMP()
        {
            // Create Gallery

            CreateMap<CreateGalleryDTO, Gallery>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                .AfterMap<CustomMappingAction<CreateGalleryDTO, Gallery>>()
                .ReverseMap();
 
            // Update Gallery

            CreateMap<UpdateGalleryDTO, Gallery>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
                .AfterMap<CustomMappingAction<UpdateGalleryDTO, Gallery>>()
                .ReverseMap();
         }
    }
}
