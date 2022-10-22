using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Queries.Session
{
    public class CompanySessionValidationQuery : IRequest<ErrorOr<CompanySessionValidationResult>>
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}