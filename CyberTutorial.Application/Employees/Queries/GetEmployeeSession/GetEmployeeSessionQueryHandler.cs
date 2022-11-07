using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeSession
{
    public class GetEmployeeSessionQueryHandler : IRequestHandler<GetEmployeeSessionQuery, ErrorOr<GetEmployeeSessionResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeeSessionQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<GetEmployeeSessionResult>> Handle(GetEmployeeSessionQuery request, CancellationToken cancellationToken)
        {
            Employee employee = await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);
            if (employee == null)
            {
                return Errors.Employee.NotFound;
            }

            if (employee.Session == null)
            {
                return Errors.Employee.SessionNotFound;
            }

            return mapper.Map<GetEmployeeSessionResult>(employee.Session);
        }
    }
}