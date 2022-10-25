using CyberTutorial.Contracts.Models;

namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<CompanyModel> GetCompanyProfileAsync();
        Task<bool> IsCompanyLoggedInAsync();
        Task<object> LogoutCompanyAsync();
    }
}