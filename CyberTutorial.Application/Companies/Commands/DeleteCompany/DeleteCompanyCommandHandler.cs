using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;


namespace CyberTutorial.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, ErrorOr<DeleteCompanyResult>>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public DeleteCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<DeleteCompanyResult>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = await companyRepository.GetCompanyByIdAsync(request.CompanyId);

            if (company is null)
            {
                return Errors.Company.NotFound;
            }

            await companyRepository.DeleteCompanyAsync(request.CompanyId);

            return mapper.Map<DeleteCompanyResult>(company);
        }
    }
}