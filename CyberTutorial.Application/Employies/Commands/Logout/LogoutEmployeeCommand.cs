using ErrorOr;
using MediatR;
using CyberTutorial.Application.Employies.Common;

namespace CyberTutorial.Application.Employies.Commands.Logout
{
    public class LogoutEmployeeCommand : IRequest<ErrorOr<LogoutEmployeeResult>>
    {
        public string SessionId { get; set; }
        public string Token { get; set; }

    }
}