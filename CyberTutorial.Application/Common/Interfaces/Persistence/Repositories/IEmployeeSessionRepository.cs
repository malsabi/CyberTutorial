using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IEmployeeSessionRepository
    {
        Task CreateEmployeeSessionAsync(EmployeeSession employeeSession);
        Task<EmployeeSession> GetEmployeeSessionByTokenAsync(string token);
        Task<EmployeeSession> GetEmployeeSessionBySessionIdAsync(string sessionId);
        Task<EmployeeSession> GetEmployeeSessionByEmployeeIdAsync(string employeeId);
        Task UpdateEmployeeSessionAsync(EmployeeSession employeeSession);
        Task DeleteEmployeeSessionAsync(EmployeeSession employeeSession);
    }
}