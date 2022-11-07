using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;


namespace CyberTutorial.Application.Employees.Queries.GetEmployeeDashboard
{
    public class GetEmployeeDashboardQueryHandler : IRequestHandler<GetEmployeeDashboardQuery, ErrorOr<GetEmployeeDashboardResult>>
    {
        private IMapper mapper;
        private IEmployeeRepository employeeRepository;

        public GetEmployeeDashboardQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<GetEmployeeDashboardResult>> Handle(GetEmployeeDashboardQuery request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
            }

            if (employee.EmployeeDashboard == null)
            {
                return Errors.Employee.NoDashboardFound;
            }

            return mapper.Map<GetEmployeeDashboardResult>(employee.EmployeeDashboard);
        }
    }
}