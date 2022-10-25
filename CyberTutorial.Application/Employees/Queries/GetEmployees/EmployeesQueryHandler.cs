using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Queries.GetEmployees
{
    public class EmployeesQueryHandler : IRequestHandler<EmployeesQuery, ErrorOr<EmployeesResult>>
    {
        private IEmployeeRepository employeeRepository;

        public EmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<EmployeesResult>> Handle(EmployeesQuery request, CancellationToken cancellationToken)
        {
            ICollection<Employee> employees = await employeeRepository.GetEmployeesAsync();

            if (employees == null || employees.Count == 0)
            {
                return Errors.Employee.NoEmployeesFound;
            }
            else
            {
                return new EmployeesResult() { Employees = employees.ToList() };
            }
        }
    }
}