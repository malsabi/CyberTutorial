using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, ErrorOr<GetCompanyByIdResult>>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public GetCompanyByIdQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<GetCompanyByIdResult>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            Company company = await companyRepository.GetCompanyByIdAsync(request.CompanyId);

            if (company == null)
            {
                return Errors.Company.NotFound;
            }

            return mapper.Map<GetCompanyByIdResult>(company);
        }
    }
}