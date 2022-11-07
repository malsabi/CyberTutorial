using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployeeSession
{
    public class UpdateEmployeeSessionCommandHandler : IRequestHandler<UpdateEmployeeSessionCommand, ErrorOr<UpdateEmployeeSessionResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public UpdateEmployeeSessionCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<UpdateEmployeeSessionResult>> Handle(UpdateEmployeeSessionCommand request, CancellationToken cancellationToken)
        {
            if (request.TargetId != request.EmployeeSessionId)
            {
                return Errors.Employee.OperationFailed;
            }

            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeSessionId) is not Employee employee)
            {
                return Errors.Employee.SessionNotFound;
            }

            if (employee.Session == null)
            {
                return Errors.Employee.SessionNotFound;
            }

            employee.Session.TimeCreated = request.TimeCreated;
            employee.Session.ExpiryDate = request.ExpiryDate;
            employee.Session.Token = request.Token;
            employee.Session.IsActive = request.IsActive;

            await employeeRepository.UpdateEmployeeAsync(employee);

            return mapper.Map<UpdateEmployeeSessionResult>(employee.Session);
        }
    }
}