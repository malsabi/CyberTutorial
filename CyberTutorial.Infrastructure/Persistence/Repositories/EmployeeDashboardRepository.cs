using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class EmployeeDashboardRepository : IEmployeeDashboardRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public EmployeeDashboardRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddEmployeeDashboardAsync(EmployeeDashboard employeeDashboard)
        {
            await applicationDbContext.EmployeeDashboards.AddAsync(employeeDashboard);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeDashboard>> GetEmployeeDashboardsAsync()
        {
            return await applicationDbContext.EmployeeDashboards
                .Include(employeeDashboard => employeeDashboard.TopEmployees)
                .Include(employeeDashboard => employeeDashboard.Employee)
                .ToListAsync();
        }

        public async Task<EmployeeDashboard> GetEmployeeDashboardAsync(string employeeDashboardId)
        {
            return await applicationDbContext.EmployeeDashboards
                .Include(employeeDashboard => employeeDashboard.TopEmployees)
                .Include(employeeDashboard => employeeDashboard.Employee)
                .FirstOrDefaultAsync(employeeDashboard => employeeDashboard.EmployeeDashboardId == employeeDashboardId);
        }

        public async Task UpdateEmployeeDashboardAsync(EmployeeDashboard employeeDashboard)
        {
            applicationDbContext.EmployeeDashboards.Update(employeeDashboard);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeDashboardAsync(string employeeDashboardId)
        {
            EmployeeDashboard employeeDashboardToDelete = await GetEmployeeDashboardAsync(employeeDashboardId);
            await DeleteEmployeeDashboardAsync(employeeDashboardToDelete);
        }

        public async Task DeleteEmployeeDashboardAsync(EmployeeDashboard employeeDashboard)
        {
            applicationDbContext.EmployeeDashboards.Remove(employeeDashboard);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            applicationDbContext.EmployeeDashboards.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}