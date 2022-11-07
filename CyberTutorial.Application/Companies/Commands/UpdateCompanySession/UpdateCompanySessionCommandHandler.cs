using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Commands.UpdateCompanySession
{
    public class UpdateCompanySessionCommandHandler : IRequestHandler<UpdateCompanySessionCommand, ErrorOr<UpdateCompanySessionResult>>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public UpdateCompanySessionCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<UpdateCompanySessionResult>> Handle(UpdateCompanySessionCommand request, CancellationToken cancellationToken)
        {
            if (request.TargetId != request.CompanySessionId)
            {
                return Errors.Company.OperationFailed;
            }

            if (await companyRepository.GetCompanyByIdAsync(request.CompanySessionId) is not Company company)
            {
                return Errors.Company.SessionNotFound;
            }
            
            if (company.Session == null)
            {
                return Errors.Company.SessionNotFound;
            }

            company.Session.TimeCreated = request.TimeCreated;
            company.Session.ExpiryDate = request.ExpiryDate;
            company.Session.Token = request.Token;
            company.Session.IsActive = request.IsActive;

            await companyRepository.UpdateCompanyAsync(company);

            return mapper.Map<UpdateCompanySessionResult>(company.Session);
        }
    }
}