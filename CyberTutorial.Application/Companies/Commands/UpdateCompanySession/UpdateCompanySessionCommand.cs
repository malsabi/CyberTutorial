using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Commands.UpdateCompanySession
{
    public class UpdateCompanySessionCommand : IRequest<ErrorOr<UpdateCompanySessionResult>>
    {
        public string TargetId { get; set; }
        public string CompanySessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}