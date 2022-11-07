using CyberTutorial.WebApp.ViewModels;
using CyberTutorial.WebApp.Common.Mapping;
using CyberTutorial.WebApp.Services.ApiServices;
using CyberTutorial.WebApp.Services.AppServices;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;
using CyberTutorial.WebApp.Common.Interfaces.Services.AppServices;

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

            //App Services
            services.AddSingleton<ISerializationService, SerializationService>();
            services.AddSingleton<ICookieService, CookieService>();
            services.AddSingleton<ICryptographyService, CryptographyService>();

            //Api Services
            services.AddSingleton<IApiConfigService, ApiConfigService>();
            services.AddSingleton<IClientApiService, ClientApiService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeCourseService, EmployeeCourseService>();
            services.AddScoped<IAttemptService, AttemptService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IAttemptService, AttemptService>();
            services.AddScoped<IDocumentService, DocumentService>();

            //View Models
            services.AddScoped(typeof(HomeViewModel));
            services.AddScoped(typeof(AuthenticationViewModel));
            services.AddScoped(typeof(EmployeeViewModel));
            services.AddScoped(typeof(CourseViewModel));
            return services;
        }
    }
}