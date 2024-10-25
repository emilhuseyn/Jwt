using App.Business.DTOs.ContactUsDTOs;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.Entities;
using App.DAL.Handlers.Interfaces;
using App.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Abstractions
{
    public class ContactUsService : IContactUsService
    {
        protected readonly IContactUsRepository _contactUsRepository;
        protected readonly IContactUsHandler _contactUsHandler;
        protected readonly IMapper _mapper;

        public ContactUsService(IContactUsRepository ContactUsRepository, IMapper mapper, IConfiguration configuration, IContactUsHandler ContactUsHandler)
        {
            _contactUsRepository = ContactUsRepository;
            _mapper = mapper;
            _contactUsHandler = ContactUsHandler;
        }

        public async Task<IEnumerable<ContactUsDTO>> GetAllAsync()
        {
            var entities = (await _contactUsRepository.GetAllAsync(
                x => x.IsDeleted == false))
                .Select(e => new ContactUsDTO
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Email = e.Email,
                    Content = e.Content,
                    Message = e.Message,
                });

            return entities;
        }

        public async Task<ContactUsDTO> GetByIdAsync(GetByIdContactUsDTO dto)
        {
            var entity = _contactUsHandler.HandleEntityAsync(
                await _contactUsRepository.GetByIdAsync(x => x.Id == dto.Id));

            return new ContactUsDTO
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Content = entity.Content,
                Message = entity.Message,
            };
        }

        public async Task<ContactUsDTO> AddAsync(CreateContactUsDTO dto)
        {
            var entity = await _contactUsRepository.AddAsync(_mapper.Map<ContactUs>(dto));

            return new ContactUsDTO
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Content = entity.Content,
                Message = entity.Message,
            };
        }

        public async Task<ContactUsDTO> DeleteAsync(DeleteContactUsDTO dto)
        {
            var entity = await _contactUsRepository.DeleteAsync(
                  _contactUsHandler.HandleEntityAsync(
                await _contactUsRepository.GetByIdAsync(x => x.Id == dto.Id)));

            return new ContactUsDTO
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Content = entity.Content,
                Message = entity.Message,
            };
        }

        public async Task<ContactUsDTO> UpdateAsync(UpdateContactUsDTO dto)
        {
            var entity = await _contactUsRepository.UpdateAsync(_mapper.Map(dto,
                  _contactUsHandler.HandleEntityAsync(
                await _contactUsRepository.GetByIdAsync(x => x.Id == dto.Id))));

            return new ContactUsDTO
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Content = entity.Content,
                Message = entity.Message,
            };
        }
    }
}
