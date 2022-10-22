using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public CompanyRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddCompanyAsync(Company company)
        {
            await applicationDbContext.Companies.AddAsync(company);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task<ICollection<Company>> GetCompaniesAsync()
        {
            return await applicationDbContext.Companies
                .Include(company => company.Session)
                .Include(company => company.Employees)
                .ToListAsync();
        }
        
        public async Task<Company> GetCompanyByIdAsync(string companyId)
        {
            return await applicationDbContext.Companies
                .Include(company => company.Session)
                .Include(company => company.Employees)
                .FirstOrDefaultAsync(company => company.CompanyId == companyId);
        }

        public async Task<Company> GetCompanyByEmailAsync(string emailAddress)
        {
            return await applicationDbContext.Companies
                .Include(company => company.Session)
                .Include(company => company.Employees)
                .FirstOrDefaultAsync(company => company.EmailAddress == emailAddress);
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            applicationDbContext.Companies.Update(company);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteCompanyAsync(string companyId)
        {
            Company companyToDelete = await GetCompanyByIdAsync(companyId);
            await DeleteCompanyAsync(companyToDelete);
        }
        
        public async Task DeleteCompanyAsync(Company company)
        {
            applicationDbContext.Companies.Remove(company);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            applicationDbContext.Companies.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}