using App.Business.DTOs.ProductDTOs;
using App.Business.Helpers;
using App.Business.Services.ExternalServices.Interfaces;
using App.Business.Services.InternalServices.Interfaces;
using App.Core.Entities;
using App.Core.Entities.Identity;
using App.Core.Enums;
using App.DAL.Handlers.Interfaces;
using App.DAL.Repositories.Interfaces;
using App.Shared.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace App.Business.Services.InternalServices.Abstractions
{
    public class ProductService : IProductService
    {
        protected readonly ISubstrictionRepository _substrictionRepository;
        protected readonly IProductRepository _productRepository;
        protected readonly IProductHandler _productHandler;
        protected readonly UserManager<User> _userManager;
        protected readonly IClaimService _claimService;
        protected readonly IHttpContextAccessor _http;
        protected readonly IMailService _mailService;
        protected readonly IMapper _mapper;

        public ProductService(IProductRepository ProductRepository, IMapper mapper, IConfiguration configuration, IProductHandler ProductHandler, IHttpContextAccessor http, IMailService mailService, ISubstrictionRepository restrictionRepository, IClaimService claimService, UserManager<User> userManager)
        {
            _productRepository = ProductRepository;
            _mapper = mapper;
            _productHandler = ProductHandler;
            _http = http;
            _mailService = mailService;
            _substrictionRepository = restrictionRepository;
            _claimService = claimService;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

            var entities = (await _productRepository.GetAllAsync(
                x => !x.IsDeleted,
                x => x.Category

                ))      
                
                .Select(e => new ProductDTO
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
                    ImageUrl = e.ImageUrl,
                    Price = e.Price,
                    CategoryId = e.CategoryId,
                });

            return entities;
        }

        public async Task<ProductDTO> GetByIdAsync(GetByIdProductDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

            var entity = _productHandler.HandleEntityAsync(
                await _productRepository.GetByIdAsync(x => x.Id == dto.Id));

            return new ProductDTO
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
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
                CategoryId = entity.CategoryId,
            };
        }
         
        public async Task<ProductDTO> AddAsync(CreateProductDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());
            var emails = await _substrictionRepository.GetAllAsync(x => x.IsDeleted == false);
            if (emails.Count() > 0)
            {
                foreach (var mail in emails)
                {
                    await _mailService.SendSubscriptionService(mail.Email);
                }
            }
            var entity = _mapper.Map<Product>(dto);
            entity.ImageUrl = "Testing";
            entity = await _productRepository.AddAsync(entity);
            entity = await _productRepository.GetByIdAsync(x => x.Id == entity.Id, x => x.Translations);
            return new ProductDTO
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
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
                CategoryId = entity.CategoryId,

            };
        }

        public async Task<ProductDTO> DeleteAsync(DeleteProductDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

             var entity = await _productRepository.GetByIdAsync(x => x.Id == dto.Id, x => x.Translations);
            if (entity == null)
            {
                throw new Exception("Product not found");
            }

            var deletedEntity = await _productRepository.DeleteAsync(entity);

             return new ProductDTO
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
                ImageUrl = deletedEntity.ImageUrl,
                Price = deletedEntity.Price,
                CategoryId = deletedEntity.CategoryId,
            };
        }


        public async Task<ProductDTO> UpdateAsync(UpdateProductDTO dto)
        {
            var language = LanguageChanger.Change(new LanguageCatcher(_http).GetLanguage());

             var existingEntity = await _productRepository.GetByIdAsync(x => x.Id == dto.Id, x => x.Translations);
            if (existingEntity == null)
            {
                throw new Exception("Product not found");
            }

             _mapper.Map(dto, existingEntity);
            var updatedEntity = await _productRepository.UpdateAsync(existingEntity);

             return new ProductDTO
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
                ImageUrl = updatedEntity.ImageUrl,
                Price = updatedEntity.Price,
                CategoryId = updatedEntity.CategoryId,
            };
        }

    }
}
