using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Commands.Logout
{
    public class LogoutCompanyCommandHandler : IRequestHandler<LogoutCompanyCommand, ErrorOr<LogoutResult>>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanySessionRepository companySessionRepository;

        public LogoutCompanyCommandHandler(ICompanyRepository companyRepository, ICompanySessionRepository companySessionRepository)
        {
            this.companyRepository = companyRepository;
            this.companySessionRepository = companySessionRepository;
        }

        public async Task<ErrorOr<LogoutResult>> Handle(LogoutCompanyCommand request, CancellationToken cancellationToken)
        {
            if (await companySessionRepository.GetCompanySessionBySessionIdAsync(request.SessionId) is not CompanySession session)
            {
                return Errors.Company.SessionNotFound;
            }
            
            if (session.Token != request.Token)
            {
                return Errors.Company.InvalidSessionToken;
            }

            if (await companyRepository.GetCompanyByIdAsync(session.CompanyId) is null)
            {
                return Errors.Company.NotFound;
            }

            await companySessionRepository.DeleteCompanySessionAsync(session);
            return new LogoutResult() { IsSuccess = true };
        }
    }
}