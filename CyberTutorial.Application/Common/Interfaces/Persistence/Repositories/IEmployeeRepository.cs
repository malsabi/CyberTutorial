using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IEmployeeRepository : IRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task<ICollection<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(string employeeId);
        Task<Employee> GetEmployeeByEmailAsync(string emailAddress);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(string employeeId);
        Task DeleteEmployeeAsync(Employee employee);
    }
}