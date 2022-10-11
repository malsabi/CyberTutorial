using CyberTutorial.Infrastructure.Services;
using CyberTutorial.Infrastructure.Persistence;
using CyberTutorial.Infrastructure.Authentication;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Infrastructure.Persistence.Repositories;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CyberTutorial.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuth(configuration);
            
            services.AddDbContext<ApplicationDbContext>(
                o => o.UseSqlServer(configuration.GetConnectionString("DB_CONNECTION_STRING"), 
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IHashProvider, HashProvider>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICompanySessionRepository, CompanySessionRepository>();
            services.AddScoped<IEmployeeSessionRepository, EmployeeSessionRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            JwtSettings jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<ICodeGenerator, CodeGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}