using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.Models.Employee.Dashboard;

namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetEmployeeAsync();
        Task<object> UpdateEmployeeAsync(string employeeId, EmployeeModel employeeModel);
        Task<EmployeeDashboardModel> GetEmployeeDashboardAsync();
        Task<bool> IsEmployeeLoggedInAsync();
        Task<object> LogoutEmployeeAsync();
    }
}