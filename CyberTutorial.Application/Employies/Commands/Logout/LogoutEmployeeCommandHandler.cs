using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Employies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Employies.Commands.Logout
{
    public class LogoutEmployeeCommandHandler : IRequestHandler<LogoutEmployeeCommand, ErrorOr<LogoutEmployeeResult>>
    {
        private readonly IEmployeeSessionRepository employeeSessionRepository;

        public LogoutEmployeeCommandHandler(IEmployeeSessionRepository employeeSessionRepository)
        {
            this.employeeSessionRepository = employeeSessionRepository;
        }

        public async Task<ErrorOr<LogoutEmployeeResult>> Handle(LogoutEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (await employeeSessionRepository.GetEmployeeSessionByIdAsync(request.SessionId) is not EmployeeSession session)
            {
                return Errors.Employee.SessionNotFound;
            }
            if (session.Employee == null)
            {
                return Errors.Employee.NotFound;
            }
            if (session.Token != request.Token)
            {
                return Errors.Employee.InvalidSessionToken;
            }

            session.ExpiryDate = string.Empty;
            session.Token = string.Empty;
            session.IsActive = false;

            await employeeSessionRepository.UpdateEmployeeSessionAsync(session);

            return new LogoutEmployeeResult() { IsSuccess = true };
        }
    }
}