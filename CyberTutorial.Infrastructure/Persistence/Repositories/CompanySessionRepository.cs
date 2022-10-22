using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
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

        public async Task AddCompanySessionAsync(CompanySession session)
        {
            await applicationDbContext.CompanySessions.AddAsync(session);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<CompanySession>> GetCompanySessionsAsync()
        {
            return await applicationDbContext.CompanySessions
                .Include(session => session.Company)
                .ToListAsync();
        }

        public async Task<CompanySession> GetCompanySessionByIdAsync(string companyId)
        {
            return await applicationDbContext.CompanySessions
                .Include(session => session.Company)
                .FirstOrDefaultAsync(session => session.CompanySessionId == companyId);
        }

        public async Task<CompanySession> GetCompanySessionByTokenAsync(string token)
        {
            return await applicationDbContext.CompanySessions
                .Include(session => session.Company)
                .FirstOrDefaultAsync(session => session.Token == token);
        }

        public async Task UpdateCompanySessionAsync(CompanySession session)
        {
            applicationDbContext.CompanySessions.Update(session);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteCompanySessionAsync(string companyId)
        {
            CompanySession sessionToDelete = await GetCompanySessionByIdAsync(companyId);
            await DeleteCompanySessionAsync(sessionToDelete);
        }

        public async Task DeleteCompanySessionAsync(CompanySession session)
        {
            applicationDbContext.CompanySessions.Remove(session);
            await applicationDbContext.SaveChangesAsync();
        }
        public async Task DeleteAllAsync()
        {
            applicationDbContext.CompanySessions.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}