using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Queries.GetCompanySession
{
    public class GetCompanySessionQueryHandler : IRequestHandler<GetCompanySessionQuery, ErrorOr<GetCompanySessionResult>>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public GetCompanySessionQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<GetCompanySessionResult>> Handle(GetCompanySessionQuery request, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByIdAsync(request.CompanyId) is not Company company)
            {
                return Errors.Company.NotFound;
            }

            if (company.Session == null)
            {
                return Errors.Company.SessionNotFound;
            }

            return new GetCompanySessionResult()
            {
                Session = company.Session
            };
        }
    }
}