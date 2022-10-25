using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Queries.GetCompanies
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, GetCompaniesResult>
    {
        private readonly ICompanyRepository companyRepository;

        public GetCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<GetCompaniesResult> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            ICollection<Company> companies = await companyRepository.GetCompaniesAsync();
            return new GetCompaniesResult
            {
                Companies = companies
            };
        }
    }
}