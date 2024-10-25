using App.API.Middlewares;
using App.Business.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace App.API
{
    public static class ApiDependencyInjection
    {

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SchemaFilter<EnumSchemaFilter>();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", builder =>
                {
                    builder.WithOrigins(
                        "https://apptech.edu.az",
                        "http://192.168.1.88:88",
                        "http://127.0.0.1:5500",
                        "http://localhost:5173",
                        "http://localhost:5076",
                        "https://auth.apptech.edu.az"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        public static void AddMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            builder.UseMiddleware<XSSProtectionMiddleware>();
        }
    }
}
//#region Jwt
//public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
//{
//    var secretKey = configuration.GetValue<string>("JwtConfiguration:SecretKey");
//    var issuer = configuration.GetValue<string>("JwtConfiguration:Issuer");
//    var audience = configuration.GetValue<string>("JwtConfiguration:Audience");

//    var key = Encoding.ASCII.GetBytes(secretKey);

//    services.AddAuthentication(opt =>
//    {
//        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    }).AddJwtBearer(opt =>
//    {
//        opt.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateIssuerSigningKey = true,
//            ValidateLifetime = true,
//            ValidIssuer = issuer,
//            ValidAudience = audience,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
//            LifetimeValidator = (notBefore, expires, tokenToValidate, tokenValidationParameters) =>
//            {
//                return expires != null && expires > DateTime.UtcNow;
//            }
//        };
//    });
//}

//#endregion