using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services;

namespace CyberTutorial.WebApp.Services
{
    public class ApiConfigService : IApiConfigService
    {
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;

        public ApiConfigService(IWebHostEnvironment environment, IConfiguration configuration)
        {
            this.environment = environment;
            this.configuration = configuration;
        }

        public string GetApiEndPoint()
        {
            return environment.IsDevelopment() ? configuration[ApiConsts.LocalEndPoint] : configuration[ApiConsts.WebEndPoint];
        }

        public void SetApiEndPoint(string apiEndPoint)
        {
            if (environment.IsDevelopment())
            {
                configuration[ApiConsts.LocalEndPoint] = apiEndPoint;
            }
            else
            {
                configuration[ApiConsts.WebEndPoint] = apiEndPoint;
            }
        }
    }
}