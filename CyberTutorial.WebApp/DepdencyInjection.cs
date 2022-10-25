using CyberTutorial.WebApp.Services;
using CyberTutorial.WebApp.Common.Mapping;
using CyberTutorial.WebApp.Common.Interfaces.Services;

namespace CyberTutorial.WebApp
{
    public static class DepdencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddHttpContextAccessor();
            services.AddMappings();
            services.AddSingleton<IApiConfigService, ApiConfigService>();
            services.AddSingleton<IClientApiService, ClientApiService>();
            services.AddSingleton<ISerializationService, SerializationService>();
            services.AddSingleton<ICookieService, CookieService>();
            services.AddSingleton<ICryptographyService, CryptographyService>();
            
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}