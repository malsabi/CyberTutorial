using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface ICompanySessionRepository
    {
        Task CreateCompanySessionAsync(CompanySession companySession);
        Task<CompanySession> GetCompanySessionByTokenAsync(string token);
        Task<CompanySession> GetCompanySessionBySessionIdAsync(string sessionId);
        Task<CompanySession> GetCompanySessionByCompanyIdAsync(string companyId);
        Task UpdateCompanySessionAsync(CompanySession companySession);
        Task DeleteCompanySessionAsync(CompanySession companySession);
    }
}