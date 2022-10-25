using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, ErrorOr<UpdateCompanyResult>>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;
        
        public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<UpdateCompanyResult>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request.TargetId != request.CompanyId)
            {
                return Errors.Company.OperationFailed;
            }

            if (await companyRepository.GetCompanyByIdAsync(request.CompanyId) is not Company company)
            {
                return Errors.Company.NotFound;
            }

            company.CompanyName = request.CompanyName;
            company.OwnerFirstName = request.OwnerFirstName;
            company.OwnerLastName = request.OwnerLastName;
            company.OwnerEmiratesId = request.OwnerEmiratesId;
            company.PhoneNumber = request.PhoneNumber;
            company.EmailAddress = request.EmailAddress;
            company.State = request.State;
            company.Region = request.Region;
            company.StreetAddress = request.StreetAddress;
            company.Website = request.Website;
            company.CompanyDescription = request.CompanyDescription;
            company.Password = request.Password;

            await companyRepository.UpdateCompanyAsync(company);

            return mapper.Map<UpdateCompanyResult>(company);
        }
    }
}