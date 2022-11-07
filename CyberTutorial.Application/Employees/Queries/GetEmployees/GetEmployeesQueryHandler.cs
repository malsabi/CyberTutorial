using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesResult>
    {
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<GetEmployeesResult> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            ICollection<Employee> employees = await employeeRepository.GetEmployeesAsync();
            return new GetEmployeesResult
            {
                Employees = employees
            };
        }
    }
}