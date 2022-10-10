using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Commands.Logout
{
    public class LogoutEmployeeCommandHandler : IRequestHandler<LogoutEmployeeCommand, ErrorOr<LogoutResult>>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeSessionRepository employeeSessionRepository;

        public LogoutEmployeeCommandHandler(IEmployeeRepository employeeRepository, IEmployeeSessionRepository employeeSessionRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeSessionRepository = employeeSessionRepository;
        }

        public async Task<ErrorOr<LogoutResult>> Handle(LogoutEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await employeeSessionRepository.GetEmployeeSessionBySessionIdAsync(request.SessionId) is not EmployeeSession session)
            {
                return Errors.Employee.SessionNotFound;
            }

            if (session.Token != request.Token)
            {
                return Errors.Employee.InvalidSessionToken;
            }

            if (await employeeRepository.GetEmployeeByIdAsync(session.EmployeeId) is null)
            {
                return Errors.Employee.NotFound;
            }

            await employeeSessionRepository.DeleteEmployeeSessionAsync(session);
            return new LogoutResult() { IsSuccess = true };
        }
    }
}