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

        public async Task DeleteCompanyAsync(string id)
        {
            Company companyToDelete = await applicationDbContext.Companies.FirstOrDefaultAsync(company => company.Id == id);
            applicationDbContext.Companies.Remove(companyToDelete);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Company> GetCompanyByEmailAsync(string emailAddress)
        {
            Company company = await applicationDbContext.Companies.FirstOrDefaultAsync(company => company.EmailAddress == emailAddress);
            return company;
        }

        public async Task<Company> GetCompanyByIdAsync(string id)
        {
            Company company = await applicationDbContext.Companies.FirstOrDefaultAsync(company => company.Id == id);
            return company;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await applicationDbContext.Companies.ToListAsync();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            applicationDbContext.Companies.Update(company);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            applicationDbContext.Companies.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}