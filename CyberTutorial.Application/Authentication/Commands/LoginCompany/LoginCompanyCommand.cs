using ErrorOr;
using MediatR;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Authentication.Commands.LoginCompany
{
    public class LoginCompanyCommand : IRequest<ErrorOr<LoginCompanyResult>>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}