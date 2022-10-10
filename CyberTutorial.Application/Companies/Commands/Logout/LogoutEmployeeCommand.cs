using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Commands.Logout
{
    public class LogoutEmployeeCommand : IRequest<ErrorOr<LogoutResult>>
    {
        public string SessionId { get; set; }
        public string Token { get; set; }

    }
}