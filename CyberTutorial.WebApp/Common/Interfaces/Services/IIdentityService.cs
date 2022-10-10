using CyberTutorial.WebApp.Models;

namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface IIdentityService
    {
        bool IsEmployeeLoggedIn();

        bool IsCompanyLoggedIn();

        Task<object> AuthenticateAsync(LoginModel loginModel);

        Task<object> RegisterCompanyAsync(RegisterCompanyModel registerCompanyModel);
        
        Task<object> RegisterEmployeeAsync(RegisterEmployeeModel registerEmployeeModel);
        
        Task<object> LogoutCompanyAsync();

        Task<object> LogoutEmployeeAsync();
    }
}