using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.Session
{
    public class EmployeeSessionValidationCommandHandler : IRequestHandler<EmployeeSessionValidationQuery, ErrorOr<EmployeeSessionValidationResult>>
    {
        private readonly IEmployeeSessionRepository employeeSessionRepository;

        public EmployeeSessionValidationCommandHandler(IEmployeeSessionRepository employeeSessionRepository)
        {
            this.employeeSessionRepository = employeeSessionRepository;
        }

        public async Task<ErrorOr<EmployeeSessionValidationResult>> Handle(EmployeeSessionValidationQuery request, CancellationToken cancellationToken)
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

            if (DateTime.TryParse(session.ExpiryDate, out DateTime expiryDate))
            {
                if (expiryDate < DateTime.Now)
                {
                    return Errors.Employee.SessionExpired;
                }
            }
            else
            {
                return Errors.Employee.OperationFailed;
            }

            return new EmployeeSessionValidationResult() { IsValid = true };
        }
    }
}