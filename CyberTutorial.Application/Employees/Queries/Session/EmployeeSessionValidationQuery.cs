using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Queries.Session
{
    public class EmployeeSessionValidationQuery : IRequest<ErrorOr<EmployeeSessionValidationResult>>
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}