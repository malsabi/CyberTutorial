using ErrorOr;
using MediatR;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Authentication.Commands.LogoutCompany
{
    public class LogoutCompanyCommand : IRequest<ErrorOr<LogoutCompanyResult>>
    {
        public string CompanySessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}