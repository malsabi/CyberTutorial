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
            services.AddSwaggerGen(opts =>
            {
                opts.AddSecurityDefinition("Outh2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                opts.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}