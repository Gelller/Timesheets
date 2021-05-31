using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Timesheets.Data;
using Timesheets.Data.Ef;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Implementation;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;
using FluentValidation;
using Timesheets.Infrastructure.Validation;
using Timesheets.Domain.Aggregates.InvoiceAggregate;
using Timesheets.Domain.Aggregates.SheetAgrregate;
using Timesheets.Models;

namespace Timesheets.Infrastructure.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TimesheetDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("PostgreConnectionString"),
                    b => b.MigrationsAssembly("Timesheets"));
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtAccessOptions>(configuration.GetSection("Authentication:JwtAccessOptions"));

            var jwtSettings = new JwtOptions();
            configuration.Bind("Authentication:JwtAccessOptions", jwtSettings);

            services.AddTransient<ILoginManager, LoginManager>();

            services
                .AddAuthentication(
                    x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = jwtSettings.GetTokenValidationParameters();
                });
        }

        public static void ConfigureDomainManagers(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IUsersManager, UsersManager>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<ISheetManager, SheetManager>();
            services.AddScoped<IContractManager, ContractManager>();
            services.AddScoped<IInvoiceManager, InvoiceManager>();

        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<ISheetRepo, SheetRepo>();
            services.AddScoped<IContractRepo, ContractRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            services.AddScoped<IRefreshTokenRepo, RefreshTokenRepo>();

            services.AddScoped<ISheetAggregateRepo>();
            services.AddScoped<IInvoiceAggregateRepo>();
            services.AddScoped<InvoiceAggregate>();
            services.AddScoped<SheetAggregate>();
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureBackendSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Timesheets", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference(){Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SheetDto>, SheetDtoValidator>();
            services.AddTransient<IValidator<UserDto>, UserDtoValidation>();
            services.AddTransient<IValidator<InvoiceDto>, InvoiceDtoValidator>();
            services.AddTransient<IValidator<EmployeeDto>, EmployeeDtoValidation>();
        }
    }
}
