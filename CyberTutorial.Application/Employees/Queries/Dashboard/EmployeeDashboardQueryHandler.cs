using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.Dashboard
{
    public class EmployeeDashboardQueryHandler : IRequestHandler<EmployeeDashboardQuery, ErrorOr<EmployeeDashboardResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeDashboardQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<EmployeeDashboardResult>> Handle(EmployeeDashboardQuery request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
            }

            if (employee.EmployeeDashboard == null)
            {
                return Errors.Employee.OperationFailed;
            }

            EmployeeDashboardResult employeeDashboardResult = mapper.Map<EmployeeDashboardResult>(employee.EmployeeDashboard);

            employeeDashboardResult.TopEmployees = employee.Company.Employees.Select(e => e.TopEmployee).ToList();
            employeeDashboardResult.Courses = employee.Courses;
            employeeDashboardResult.Quizzes = employee.Quizzes;
            return employeeDashboardResult;
        }
    }
}