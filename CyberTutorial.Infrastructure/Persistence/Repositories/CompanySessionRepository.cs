using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class CompanySessionRepository : ICompanySessionRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public CompanySessionRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task CreateCompanySessionAsync(CompanySession companySession)
        {
            await applicationDbContext.CompanySessions.AddAsync(companySession);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteCompanySessionAsync(CompanySession companySession)
        {
            applicationDbContext.CompanySessions.Remove(companySession);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<CompanySession> GetCompanySessionByCompanyIdAsync(string companyId)
        {
            CompanySession companySession = await applicationDbContext.CompanySessions.FirstOrDefaultAsync(session => session.CompanyId == companyId);
            return companySession;
        }

        public async Task<CompanySession> GetCompanySessionBySessionIdAsync(string sessionId)
        {
            CompanySession companySession = await applicationDbContext.CompanySessions.FirstOrDefaultAsync(session => session.Id == sessionId);
            return companySession;
        }

        public async Task<CompanySession> GetCompanySessionByTokenAsync(string token)
        {
            CompanySession companySession = await applicationDbContext.CompanySessions.FirstOrDefaultAsync(session => session.Token == token);
            return companySession;
        }

        public async Task UpdateCompanySessionAsync(CompanySession companySession)
        {
            applicationDbContext.CompanySessions.Update(companySession);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}