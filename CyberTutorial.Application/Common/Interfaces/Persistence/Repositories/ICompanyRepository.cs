using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface ICompanyRepository
    {
        Task AddCompanyAsync(Company company);
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(string id);
        Task<Company> GetCompanyByEmailAsync(string emailAddress);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(string id);
        Task DeleteAllAsync();
    }
}