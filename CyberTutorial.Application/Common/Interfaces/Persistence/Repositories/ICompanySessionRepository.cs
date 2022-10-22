using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface ICompanySessionRepository : IRepository
    {
        Task AddCompanySessionAsync(CompanySession session);
        Task<ICollection<CompanySession>> GetCompanySessionsAsync();
        Task<CompanySession> GetCompanySessionByIdAsync(string companyId);
        Task<CompanySession> GetCompanySessionByTokenAsync(string token);
        Task UpdateCompanySessionAsync(CompanySession session);
        Task DeleteCompanySessionAsync(string companyId);
        Task DeleteCompanySessionAsync(CompanySession session);
    }
}