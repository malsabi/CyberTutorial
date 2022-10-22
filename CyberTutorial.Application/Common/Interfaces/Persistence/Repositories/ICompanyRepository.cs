using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface ICompanyRepository : IRepository
    {
        Task AddCompanyAsync(Company company);
        Task<ICollection<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(string companyId);
        Task<Company> GetCompanyByEmailAsync(string emailAddress);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(string companyId);
        Task DeleteCompanyAsync(Company company);
    }
}