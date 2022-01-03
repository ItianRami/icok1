using icok1.Domain.Entities;
using icok1.Domain.Settings;
using icok1.Persistence;
using icok1.Service.Contract;
using icok1.Service.Implementation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace icok1.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
             IConfiguration configuration, IConfigurationRoot configRoot)
        {
            //serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            //       options.UseSqlServer(configuration.GetConnectionString("IcokConn") ?? configRoot["ConnectionStrings:IcokConn"]
            //    , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        }

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new CustomerProfile());
            //});
            //IMapper mapper = mappingConfig.CreateMapper();
            //serviceCollection.AddSingleton(mapper);
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            //serviceCollection.AddScoped<ICosmosDbServiceT<Product>, ProductCosmosDbService>();
            //serviceCollection.AddScoped<ICosmosDbServiceT<Order>, OrderCosmosDbService>();
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTimeService, DateTimeService>();
            //serviceCollection.AddTransient<IAccountService, AccountService>();
            //serviceCollection.AddTransient<ICosmosDbServiceT<Order>, OrderCosmosDbService>();
            //serviceCollection.AddTransient<ICosmosDbServiceT<Product>, ProductCosmosDbService>();
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "ICOK WebAPI",
                        Version = "1",
                        Description = "Through this portal you can access all exposed APIs",
                        Contact = new OpenApiContact()
                        {
                            Email = "itian.remo@gmail.com",
                            Name = "Rami Mohsen",
                            Url = new Uri("https://github.com/ItianRami/")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });

        }

        public static void AddMailSetting(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }

        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson();
        }

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

        //public static void AddHealthCheck(this IServiceCollection serviceCollection, AppSettings appSettings, IConfiguration configuration)
        //{
        //    serviceCollection.AddHealthChecks()
        //        .AddDbContextCheck<ApplicationDbContext>(name: "Application DB Context", failureStatus: HealthStatus.Degraded)
        //        .AddUrlGroup(new Uri(appSettings.ApplicationDetail.ContactWebsite), name: "My personal website", failureStatus: HealthStatus.Degraded)
        //        .AddSqlServer(configuration.GetConnectionString("IcokConn"));

        //    serviceCollection.AddHealthChecksUI(setupSettings: setup =>
        //    {
        //        setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
        //    }).AddInMemoryStorage();
        //}

    }
}
