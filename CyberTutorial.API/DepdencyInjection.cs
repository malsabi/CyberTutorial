using CyberTutorial.API.Common.Errors;
using CyberTutorial.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CyberTutorial.API
{
    public static class DepdencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            //services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}