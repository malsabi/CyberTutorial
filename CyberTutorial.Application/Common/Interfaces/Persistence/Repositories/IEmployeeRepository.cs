using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<Employee> GetEmployeeByEmailAsync(string emailAddress);
        Task<List<Employee>> GetEmployeesAsync();
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(string id);
    }
}