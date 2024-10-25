using App.Business.DTOs.CategoryDTOs;
using App.Business.Helpers;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.Entities;
using App.Core.Enums;
using App.DAL.Handlers.Interfaces;
using App.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace App.Business.Services.InternalServices.Abstractions
{
    public class CategoryService : ICategoryService
    {
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly ICategoryHandler _categoryHandler;
        protected readonly IHttpContextAccessor _http;
        protected readonly IMapper _mapper;

        public CategoryService(ICategoryRepository CategoryRepository, IMapper mapper, IConfiguration configuration, ICategoryHandler CategoryHandler, IHttpContextAccessor http)
        {
            _categoryRepository = CategoryRepository;
            _mapper = mapper;
            _categoryHandler = CategoryHandler;
            _http = http;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

            var entities = (await _categoryRepository.GetAllAsync(
                x => x.IsDeleted == false,
                x => x.Translations,
                x => x.SubCategories))
                .Where(e => e.ParentCategoryId == null)
                .Select(e => new CategoryDTO
                {
                    Id = e.Id,
                    Title = e.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Title)
                        .FirstOrDefault(),
                    Description = e.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Description)
                        .FirstOrDefault(),
                    SubCategories = e.SubCategories != null
                        ? e.SubCategories
                            .Where(sc => !sc.IsDeleted)
                            .Select(sc => new CategoryDTO
                            {
                                Id = sc.Id,
                                Title = sc.Translations
                                    .Where(t => t.Language == language && !t.IsDeleted)
                                    .Select(t => t.Title)
                                    .FirstOrDefault(),
                                Description = sc.Translations
                                    .Where(t => t.Language == language && !t.IsDeleted)
                                    .Select(t => t.Description)
                                    .FirstOrDefault()
                            }).ToList()
                        : null
                });

            return entities;
        }


        public async Task<CategoryDTO> GetByIdAsync(GetByIdCategoryDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

            var entity = await _categoryRepository.GetByIdAsync(x => x.Id == dto.Id, x => x.SubCategories, x => x.Translations);
            var handledEntity = _categoryHandler.HandleEntityAsync(entity);

            return new CategoryDTO
            {
                Id = handledEntity.Id,
                Title = handledEntity.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Title)
                        .FirstOrDefault(),
                Description = handledEntity.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Description)
                        .FirstOrDefault(),
                SubCategories = handledEntity.SubCategories
                    .Where(sc => !sc.IsDeleted)
                    .Select(sc => new CategoryDTO
                    {
                        Id = sc.Id,
                    })
            };
        }
        public async Task<CategoryDTO> AddAsync(CreateCategoryDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

             var entity = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(entity);

             entity = await _categoryRepository.GetByIdAsync(
                x => x.Id == entity.Id,
                x => x.Translations       
            );

             return new CategoryDTO
            {
                Id = entity.Id,
                Title = entity.Translations
                    .Where(t => t.Language == language && !t.IsDeleted)
                    .Select(t => t.Title)
                    .FirstOrDefault(),
                Description = entity.Translations
                    .Where(t => t.Language == language && !t.IsDeleted)
                    .Select(t => t.Description)
                    .FirstOrDefault(),
            };
        }


        public async Task<CategoryDTO> DeleteAsync(DeleteCategoryDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

             var entity = await _categoryRepository.GetByIdAsync(x => x.Id == dto.Id,x=>x.SubCategories,x=>x.Translations);
             
             var handledEntity = _categoryHandler.HandleEntityAsync(entity);
            var deletedEntity = await _categoryRepository.DeleteAsync(handledEntity);

             return new CategoryDTO
            {
                Id = deletedEntity.Id,
                Title = deletedEntity.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Title)
                        .FirstOrDefault(),
                Description = deletedEntity.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Description)
                        .FirstOrDefault(),
                SubCategories = deletedEntity.SubCategories != null
                    ? deletedEntity.SubCategories
                        .Where(sc => !sc.IsDeleted)
                        .Select(sc => new CategoryDTO
                        {
                            Id = sc.Id,
                        }).ToList()
                    : null
            };
        }




        public async Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

             var existingEntity = await _categoryRepository.GetByIdAsync(x => x.Id == dto.Id, x => x.SubCategories, x => x.Translations);
            

             var handledEntity = _categoryHandler.HandleEntityAsync(existingEntity);
            var updatedEntity = await _categoryRepository.UpdateAsync(_mapper.Map(dto, handledEntity));

             return new CategoryDTO
            {
                Id = updatedEntity.Id,
                Title = updatedEntity.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Title)
                        .FirstOrDefault(),
                Description = updatedEntity.Translations
                        .Where(t => t.Language == language && !t.IsDeleted)
                        .Select(t => t.Description)
                        .FirstOrDefault(),
            };
        }

    }
}
