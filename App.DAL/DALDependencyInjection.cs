using App.Core.Entities;
using App.Core.Entities.Identity;
using App.DAL.Handlers.Implementations;
using App.DAL.Handlers.Interfaces;
using App.DAL.Presistence;
using App.DAL.Repositories.Implementations;
using App.DAL.Repositories.Interfaces;
using App.Shared.Implementations;
using App.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL
{
    public static class DALDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddRepositories();
            services.AddHandlers();
            return services;
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // SQL Database 
            var connectionString = Environment.GetEnvironmentVariable("CloudConnection")
                                         ?? configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)),
                mySqlOptions => mySqlOptions.EnableStringComparisonTranslations()));
        }

        private static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<ISubstrictionRepository, SubstrictionRepository>();
            services.AddScoped(typeof(ITranslationRepository<>), typeof(TranslationRepository<>));
        }
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddScoped<IProductHandler, ProductHandler>();
            services.AddScoped<ISettingHandler, SettingHandler>();
            services.AddScoped<IGalleryHandler, GalleryHandler>();
            services.AddScoped<ICategoryHandler, CategoryHandler>();
            services.AddScoped<IContactUsHandler, ContactUsHandler>();
            services.AddScoped<IProductTranslationHandler, ProductTranslationHandler>();
            services.AddScoped<ICategoryTranslationHandler, CategoryTranslationHandler>();
            services.AddScoped(typeof(ITranslationHandler<>), typeof(TranslationHandler<>));
        }
    }
}
