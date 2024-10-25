using App.Business.DTOs.CategoryDTOs;
using App.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.MappingProfiles
{
    public class CategoryMP : Profile
    {
        public CategoryMP()
        {
            // Create Category

            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            
            // Update Category

            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
}
