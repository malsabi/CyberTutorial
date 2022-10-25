using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Commands.LogoutCompany
{
    public class LogoutCompanyCommandHandler : IRequestHandler<LogoutCompanyCommand, ErrorOr<LogoutCompanyResult>>
    {
        private readonly ICompanySessionRepository companySessionRepository;

        public LogoutCompanyCommandHandler(ICompanySessionRepository companySessionRepository)
        {
            this.companySessionRepository = companySessionRepository;
        }

        public async Task<ErrorOr<LogoutCompanyResult>> Handle(LogoutCompanyCommand request, CancellationToken cancellationToken)
        {
            if (await companySessionRepository.GetCompanySessionByIdAsync(request.SessionId) is not CompanySession session)
            {
                return Errors.Company.SessionNotFound;
            }
            if (session.Company == null)
            {
                return Errors.Company.NotFound;
            }
            if (session.Token != request.Token)
            {
                return Errors.Company.InvalidSessionToken;
            }

            session.ExpiryDate = string.Empty;
            session.Token = string.Empty;
            session.IsActive = false;

            await companySessionRepository.UpdateCompanySessionAsync(session);

            return new LogoutCompanyResult() { IsSuccess = true };
        }
    }
}