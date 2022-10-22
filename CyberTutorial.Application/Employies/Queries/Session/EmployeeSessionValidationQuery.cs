using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employies.Common;

namespace CyberTutorial.Application.Employies.Queries.Session
{
    public class EmployeeSessionValidationQuery : IRequest<ErrorOr<EmployeeSessionValidationResult>>
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}