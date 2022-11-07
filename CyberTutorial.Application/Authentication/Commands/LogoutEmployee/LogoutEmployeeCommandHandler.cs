using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Commands.LogoutEmployee
{
    public class LogoutEmployeeCommandHandler : IRequestHandler<LogoutEmployeeCommand, ErrorOr<LogoutEmployeeResult>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public LogoutEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public async Task<ErrorOr<LogoutEmployeeResult>> Handle(LogoutEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await employeeRepository.GetEmployeeByIdAsync(request.EmployeeSessionId) is not Employee employee)
            {
                return Errors.Employee.NotFound;
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

            return mapper.Map<LogoutEmployeeResult>(employee);
        }
    }
}