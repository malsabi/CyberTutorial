using CyberTutorial.Domain.Entities;
using CyberTutorial.Infrastructure.Persistence.Extensions;
using CyberTutorial.Application.Common.Interfaces.Persistence;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CyberTutorial.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IApplicationDbContext applicationDbContext;

        public EmployeeRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await applicationDbContext.Employees.AddAsync(employee);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Employee>> GetEmployeesAsync()
        {
            return await applicationDbContext.Employees
                .Include(employee => employee.Session)
                .Include(employee => employee.Company)
                .Include(employee => employee.Quizzes)
                .Include(employee => employee.Courses)
                .Include(employee => employee.EmployeeDashboard)
                .ToListAsync();
        }
        
        public async Task<Employee> GetEmployeeByIdAsync(string employeeId)
        {
            return await applicationDbContext.Employees
                .Include(employee => employee.Session)
                .Include(employee => employee.Company)
                .Include(employee => employee.Quizzes)
                .Include(employee => employee.Courses)
                .Include(employee => employee.EmployeeDashboard)
                .FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId);
        }
        
        public async Task<Employee> GetEmployeeByEmailAsync(string emailAddress)
        {
            return await applicationDbContext.Employees
                .Include(employee => employee.Session)
                .Include(employee => employee.Company)
                .Include(employee => employee.Quizzes)
                .Include(employee => employee.Courses)
                .Include(employee => employee.EmployeeDashboard)
                .FirstOrDefaultAsync(employee => employee.EmailAddress == emailAddress);
        }
     
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            applicationDbContext.Employees.Update(employee);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(string employeeId)
        {
            Employee employeeToDelete = await GetEmployeeByIdAsync(employeeId);
            await DeleteEmployeeAsync(employeeToDelete);
        }
        
        public async Task DeleteEmployeeAsync(Employee employee)
        {
            applicationDbContext.Employees.Remove(employee);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteAllAsync()
        {
            applicationDbContext.Employees.Clear();
            await applicationDbContext.SaveChangesAsync();
        }
    }
}