using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<GetCompaniesResult>
    {
    }
}