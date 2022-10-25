using CyberTutorial.WebApp.Models.Common;
using CyberTutorial.WebApp.Models.Company.Register;
using CyberTutorial.WebApp.Models.Employee.Register;

namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<object> AuthenticateAsync(LoginModel loginModel);
        Task<object> RegisterCompanyAsync(RegisterCompanyModel registerCompanyModel);
        Task<object> RegisterEmployeeAsync(RegisterEmployeeModel registerEmployeeModel);
    }
}