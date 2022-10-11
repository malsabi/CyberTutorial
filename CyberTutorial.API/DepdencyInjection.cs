using CyberTutorial.API.Common.Errors;
using CyberTutorial.API.Common.Mapping;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Swashbuckle.AspNetCore.Filters;

namespace CyberTutorial.API
{
    public static class DepdencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(config =>
            {
                ////Name the security scheme
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }

                            },
                            new List<string>()
                        }
                    });
            });
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}