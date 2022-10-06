using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CyberTutorial.Application.Common.Mapping
{
    public static class DepdencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}