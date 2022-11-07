using ErrorOr;
using MediatR;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Authentication.Commands.LogoutEmployee
{
    public class LogoutEmployeeCommand : IRequest<ErrorOr<LogoutEmployeeResult>>
    {
        public string EmployeeSessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}