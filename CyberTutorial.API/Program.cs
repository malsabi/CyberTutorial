using CyberTutorial.Application;
using CyberTutorial.Infrastructure;
using CyberTutorial.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services
                    .AddPresentation()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);
            }
            
            var app = builder.Build();
            {
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cyber-Tutorials API");
                    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });

                using (IServiceScope scope = app.Services.CreateScope())
                {
                    ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    //context.Database.EnsureDeleted();
                    context.Database.Migrate();
                    //context.Database.EnsureCreated();
                    ApplicationDbContextInitializer.Seed(context);
                }

                app.UseExceptionHandler("/error");
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseHttpsRedirection();
                app.MapControllers();
                app.Run();
            }
        }
    }
}