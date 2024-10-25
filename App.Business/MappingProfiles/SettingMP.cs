using App.Business.DTOs.SettingDTOs;
using App.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.MappingProfiles
{
    public class SettingMP : Profile
    {
        public SettingMP()
        {
            // Create Setting

            CreateMap<CreateSettingDTO, Setting>().ReverseMap();

            // Update Setting

            CreateMap<UpdateSettingDTO, Setting>().ReverseMap();
        }
    }
}
