using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using Mapster;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ErrorOr<GetEmployeeByIdResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public GetEmployeeByIdQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<GetEmployeeByIdResult>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            Employee employee = await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

            if (employee == null)
            {
                return Errors.Company.NotFound;
            }

            return mapper.Map<GetEmployeeByIdResult>(employee);
        }
    }
}