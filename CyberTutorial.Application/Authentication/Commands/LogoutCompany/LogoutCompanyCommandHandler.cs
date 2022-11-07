using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Commands.LogoutCompany
{
    public class LogoutCompanyCommandHandler : IRequestHandler<LogoutCompanyCommand, ErrorOr<LogoutCompanyResult>>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public LogoutCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }
        
        public async Task<ErrorOr<LogoutCompanyResult>> Handle(LogoutCompanyCommand request, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByIdAsync(request.CompanySessionId) is not Company company)
            {
                return Errors.Company.NotFound;
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

            return mapper.Map<LogoutCompanyResult>(company);
        }
    }
}