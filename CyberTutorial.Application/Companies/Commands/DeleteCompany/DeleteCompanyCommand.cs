using ErrorOr;
using MediatR;
using CyberTutorial.Application.Companies.Common;

namespace CyberTutorial.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<ErrorOr<DeleteCompanyResult>>
    {
        public string CompanyId { get; set; }
    }
}