using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Queries.GetCompanyEmployees
{
    public class GetCompanyEmployeesQuery : IRequest<ErrorOr<GetCompanyEmployeesResult>>
    {
        public string CompanyId { get; set; }
    }
}