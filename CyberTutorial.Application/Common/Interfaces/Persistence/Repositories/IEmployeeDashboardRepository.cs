using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IEmployeeDashboardRepository : IRepository
    {
        Task AddEmployeeDashboardAsync(EmployeeDashboard employeeDashboard);
        Task<List<EmployeeDashboard>> GetEmployeeDashboardsAsync();
        Task<EmployeeDashboard> GetEmployeeDashboardAsync(string employeeDashboardId);
        Task UpdateEmployeeDashboardAsync(EmployeeDashboard employeeDashboard);
        Task DeleteEmployeeDashboardAsync(string employeeDashboardId);
        Task DeleteEmployeeDashboardAsync(EmployeeDashboard employeeDashsboard);
    }
}