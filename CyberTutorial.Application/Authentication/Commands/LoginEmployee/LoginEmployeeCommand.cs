using ErrorOr;
using MediatR;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Authentication.Commands.LoginEmployee
{
    public class LoginEmployeeCommand : IRequest<ErrorOr<LoginEmployeeResult>>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}