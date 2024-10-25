using App.Business.DTOs.TranslationDTOs;
using App.Business.Helpers;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.Entities.Commons;
using App.DAL.Handlers.Interfaces;
using App.DAL.Repositories.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.InternalServices.Abstractions
{
    public class TranslationService<T> : ITranslationService<T> where T : BaseEntity
    {
        protected readonly ITranslationRepository<T> _translationRepository;
        protected readonly ITranslationHandler<T> _translationHandler;
        protected readonly IMapper _mapper;

        public TranslationService(
            ITranslationRepository<T> translationRepository,
            IMapper mapper,
            ITranslationHandler<T> translationHandler)
        {
            _translationRepository = translationRepository;
            _translationHandler = translationHandler;
            _mapper = mapper;
        }

        public async Task<IQueryable<TranslationDTO<T>>> GetAllAsync()
        {
            var entities = (await _translationRepository.GetAllAsync(
                x => x.IsDeleted == false))
                .Select(e => new TranslationDTO<T>
                {
                    Id = e.Id,
                    EntityId = e.EntityId,
                    Title = e.Title,
                    Description = e.Description,
                    Language = e.Language.EnumToString(),
                });

            return entities.AsQueryable();
        }

        public async Task<TranslationDTO<T>> GetByIdAsync(GetByIdTranslationDTO dto)
        {
            var entity = _translationHandler.HandleEntityAsync(
                await _translationRepository.GetByIdAsync(x => x.Id == dto.Id));

            return new TranslationDTO<T>
            {
                Id = entity.Id,
                EntityId = entity.EntityId,
                Title = entity.Title,
                Description = entity.Description,
                Language = entity.Language.EnumToString(),
            };
        }

        public async Task<TranslationDTO<T>> AddAsync(CreateTranslationDTO<T> dto)
        {
            var entity = _mapper.Map<Translation<T>>(dto);
            entity = await _translationRepository.AddAsync(entity);

            return new TranslationDTO<T>
            {
                Id = entity.Id,
                EntityId = entity.EntityId,
                Title = entity.Title,
                Description = entity.Description,
                Language = entity.Language.EnumToString(),
            };
        }



        public async Task<TranslationDTO<T>> DeleteAsync(DeleteTranslationDTO dto)
        {
            var entity = await _translationRepository.DeleteAsync(
                _translationHandler.HandleEntityAsync(
                await _translationRepository.GetByIdAsync(x => x.Id == dto.Id)));

            return new TranslationDTO<T>
            {
                Id = entity.Id,
                EntityId = entity.EntityId,
                Title = entity.Title,
                Description = entity.Description,
                Language = entity.Language.EnumToString(),
            };
        }

        public async Task<TranslationDTO<T>> UpdateAsync(UpdateTranslationDTO<T> dto)
        {
            var entity = await _translationRepository.UpdateAsync(_mapper.Map(dto,
                _translationHandler.HandleEntityAsync(
                await _translationRepository.GetByIdAsync(x => x.Id == dto.Id))));

            return new TranslationDTO<T>
            {
                Id = entity.Id,
                EntityId = entity.EntityId,
                Title = entity.Title,
                Description = entity.Description,
                Language = entity.Language.EnumToString(),
            };
        }
    }
}
