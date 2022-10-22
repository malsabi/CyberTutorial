using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IEmployeeSessionRepository : IRepository
    {
        Task AddEmployeeSessionAsync(EmployeeSession session);
        Task<ICollection<EmployeeSession>> GetEmployeeSessionsAsync();
        Task<EmployeeSession> GetEmployeeSessionByIdAsync(string employeeId);
        Task<EmployeeSession> GetEmployeeSessionByTokenAsync(string token);
        Task UpdateEmployeeSessionAsync(EmployeeSession session);
        Task DeleteEmployeeSessionAsync(string employeeId);
        Task DeleteEmployeeSessionAsync(EmployeeSession session);
    }
}