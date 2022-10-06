using CyberTutorial.Domain.Entities;
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

        public async Task<Employee> GetEmployeeByEmailAsync(string emailAddress)
        {
            Employee employee = await applicationDbContext.Employees.FirstOrDefaultAsync(employee => employee.EmailAddress == emailAddress);
            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            Employee employee = await applicationDbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
            return employee;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await applicationDbContext.Employees.ToListAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            applicationDbContext.Employees.Update(employee);
            await applicationDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteEmployeeAsync(string id)
        {
            Employee employeeToDelete = await applicationDbContext.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
            applicationDbContext.Employees.Remove(employeeToDelete);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}