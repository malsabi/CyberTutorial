using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using CyberTutorial.Application.Common.Mapping;
using CyberTutorial.Application.Common.Behaviors;

namespace CyberTutorial.Application
{
    public static class DepdencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DepdencyInjection).Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMappings();

            return services;
        }
    }
}