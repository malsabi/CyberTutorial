using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Queries.GetCompanySession
{
    public class GetCompanySessionQuery : IRequest<ErrorOr<GetCompanySessionResult>>
    {
        public string CompanyId { get; set; }
    }
}