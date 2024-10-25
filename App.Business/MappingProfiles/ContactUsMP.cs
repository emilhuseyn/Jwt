using App.Business.DTOs.ContactUsDTOs;
using App.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.MappingProfiles
{
    public class ContactUsMP : Profile
    {
        public ContactUsMP()
        {
            // Create ContactUs

            CreateMap<CreateContactUsDTO, ContactUs>().ReverseMap();

            // Update ContactUs

            CreateMap<UpdateContactUsDTO, ContactUs>().ReverseMap();
        }
    }
}
