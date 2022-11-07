using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeCompany
{
    public class GetEmployeeCompanyQueryHandler : IRequestHandler<GetEmployeeCompanyQuery, ErrorOr<GetEmployeeCompanyResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeeCompanyQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<GetEmployeeCompanyResult>> Handle(GetEmployeeCompanyQuery request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
            }

            if (employee.Company == null)
            {
                return Errors.Employee.OperationFailed;
            }

            return mapper.Map<GetEmployeeCompanyResult>(employee.Company);
        }
    }
}