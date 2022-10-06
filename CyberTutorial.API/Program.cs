using CyberTutorial.Application;
using CyberTutorial.Infrastructure;

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