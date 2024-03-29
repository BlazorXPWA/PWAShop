﻿namespace ProPWAShop.Web.Server.Infrastructure.Extensions
{
    using System.Linq;
    using System.Text;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    using ProPWAShop.Services.Common;
    using Data;
    using Data.Contracts;
    using Data.Models;
    using Data.Seed;
    using Filters;
    using Models;
    using Services;

    using static Data.ModelConstants.Identity;
    using ProPWAShop.Services.Confirm;

    public static class ServiceCollectionExtensions
    {
        public static ApplicationSettings GetApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(ApplicationSettings));
            services.Configure<ApplicationSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<ApplicationSettings>();
        }

        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<ProPWAShopDbContext>(options => options
                    .UseSqlServer(configuration.GetDefaultConnectionString()))
                .AddTransient<IInitialData, CityData>()
                .AddTransient<IInitialData, DeliveryData>()
                .AddTransient<IInitialData, CategoriesData>()
                .AddTransient<IInitialData, ProductsData>()
                .AddTransient<IInitializer, ProPWAShopDbInitializer>();

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<ProPWAShopUser, ProPWAShopRole>(options =>
                {
                    //options.User.AllowedUserNameCharacters = "whatever";
                    options.User.AllowedUserNameCharacters += "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ -";
                    options.Password.RequiredLength = MinPasswordLength;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ProPWAShopDbContext>();

            return services;
        }  
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IConfirmService, ConfirmService>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            ApplicationSettings applicationSettings)
        {
            var key = Encoding.ASCII.GetBytes(applicationSettings.Secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddHttpContextAccessor();
            //services.AddScoped<ICurrentUserService, CurrentUserService>();
            //services.AddScoped<IConfirmService, ConfirmService>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var serviceInterfaceType = typeof(IService);
            var singletonServiceInterfaceType = typeof(ISingletonService);
            var scopedServiceInterfaceType = typeof(IScopedService);

            var types = serviceInterfaceType
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (serviceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (singletonServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else if (scopedServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }

            return services;
        }

        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services
                .AddControllers(options => options
                      .Filters
                      .Add<ModelOrNotFoundActionFilter>());

            services.AddRazorPages();

            return services;
        }
    }
}
