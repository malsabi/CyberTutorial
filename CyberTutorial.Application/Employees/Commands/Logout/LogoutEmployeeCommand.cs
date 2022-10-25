using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employees.Common;

namespace CyberTutorial.Application.Employees.Commands.Logout
{
    public class LogoutEmployeeCommand : IRequest<ErrorOr<LogoutEmployeeResult>>
    {
        public string SessionId { get; set; }
        public string Token { get; set; }

    }
}