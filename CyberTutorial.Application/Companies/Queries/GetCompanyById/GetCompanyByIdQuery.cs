using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery : IRequest<ErrorOr<GetCompanyByIdResult>>
    {
        public string CompanyId { get; set; }
    }
}