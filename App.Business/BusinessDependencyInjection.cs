using App.Business.DTOs.Commons;
using App.Business.Helpers;
using App.Business.MappingProfiles;
using App.Business.MappingProfiles.Commons;
using App.Business.Services.ExternalServices.Abstractions;
using App.Business.Services.ExternalServices.Interfaces;
using App.Business.Services.InternalServices.Abstractions;
using App.Business.Services.InternalServices.Interfaces;
using App.Business.Validators.Commons;
using App.Core.Entities;
using App.Core.Entities.Commons;
using App.Shared.Implementations;
using App.Shared.Interfaces;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Business
{
    public static class BusinessDependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddServices();
            services.RegisterAutoMapper();
            services.AddControllers(options =>
            {
                options.Conventions.Add(new PluralizedRouteConvention());
                options.ModelValidatorProviders.Clear();
            })
           .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BaseEntityValidator<BaseEntityDTO>>())
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
           });

            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            // Internal Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IProductTranslationService, ProductTranslationService>();
            services.AddScoped<ICategoryTranslationService, CategoryTranslationService>();
            services.AddScoped(typeof(ITranslationService<>), typeof(TranslationService<>));

            // External Services 
            services.AddScoped<IFileManagerService, FileManagerService>();
            services.AddScoped<IMailService, MailService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddTransient(typeof(CustomMappingAction<,>));
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(TranslationProfile<Category>));
                cfg.AddProfile(typeof(TranslationProfile<Product>));
            });
            services.AddAutoMapper(typeof(BusinessDependencyInjection).Assembly);
         }
    }
}
