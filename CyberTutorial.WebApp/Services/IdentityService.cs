using CyberTutorial.Contracts.Authentication.Response;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services;

namespace CyberTutorial.WebApp.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ICookieService cookieService;
        
        public IdentityService(ICookieService cookieService)
        {
            this.cookieService = cookieService;
        }

        public bool IsCompanyLoggedIn()
        {
            return cookieService.Get<LoginResponse>(AppConsts.CompanyCookieId) != null;
        }

        public bool IsEmployeeLoggedIn()
        {
            return cookieService.Get<LoginResponse>(AppConsts.EmployeeCookieId) != null;
        }
    }
}