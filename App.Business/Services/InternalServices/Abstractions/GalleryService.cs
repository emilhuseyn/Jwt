using App.Business.DTOs.GalleryDTOs;
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
    public class GalleryService : IGalleryService
    {
        protected readonly IGalleryRepository _galleryRepository;
        protected readonly IGalleryHandler _galleryHandler;
        protected readonly IMapper _mapper;

        public GalleryService(IGalleryRepository GalleryRepository, IMapper mapper, IConfiguration configuration, IGalleryHandler GalleryHandler)
        {
            _galleryRepository = GalleryRepository;
            _mapper = mapper;
            _galleryHandler = GalleryHandler;
        }

        public async Task<IEnumerable<GalleryDTO>> GetAllAsync()
        {
            var entities = (await _galleryRepository.GetAllAsync(
                x => x.IsDeleted == false))
                .Select(e => new GalleryDTO
                {
                    Id = e.Id,
                    Image = e.ImageUrl
                });

            return entities;
        }

        public async Task<GalleryDTO> GetByIdAsync(GetByIdGalleryDTO dto)
        {
            var entity = _galleryHandler.HandleEntityAsync(
                await _galleryRepository.GetByIdAsync(x => x.Id == dto.Id));

            return new GalleryDTO
            {
                Id = entity.Id,
                Image = entity.ImageUrl
            };
        }

        public async Task<GalleryDTO> AddAsync(CreateGalleryDTO dto)
        {
            var entity = await _galleryRepository.AddAsync(_mapper.Map<Gallery>(dto));

            return new GalleryDTO
            {
                Id = entity.Id,
                Image = entity.ImageUrl
            };
        }

        public async Task<GalleryDTO> DeleteAsync(DeleteGalleryDTO dto)
        {
            var entity = await _galleryRepository.DeleteAsync(
                  _galleryHandler.HandleEntityAsync(
                await _galleryRepository.GetByIdAsync(x => x.Id == dto.Id)));

            return new GalleryDTO
            {
                Id = entity.Id,
                Image = entity.ImageUrl
            };
        }

        public async Task<GalleryDTO> UpdateAsync(UpdateGalleryDTO dto)
        {
            var entity = await _galleryRepository.UpdateAsync(_mapper.Map(dto,
                  _galleryHandler.HandleEntityAsync(
                await _galleryRepository.GetByIdAsync(x => x.Id == dto.Id))));

            return new GalleryDTO
            {
                Id = entity.Id,
                Image = entity.ImageUrl
            };
        }
    }
}
