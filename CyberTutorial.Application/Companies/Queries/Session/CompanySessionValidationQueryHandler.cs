using ErrorOr;
using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Queries.Session
{
    public class CompanySessionValidationQueryHandler : IRequestHandler<CompanySessionValidationQuery, ErrorOr<CompanySessionValidationResult>>
    {
        private readonly ICompanySessionRepository companySessionRepository;

        public CompanySessionValidationQueryHandler(ICompanySessionRepository companySessionRepository)
        {
            this.companySessionRepository = companySessionRepository;
        }

        public async Task<ErrorOr<CompanySessionValidationResult>> Handle(CompanySessionValidationQuery request, CancellationToken cancellationToken)
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

            if (DateTime.TryParse(session.ExpiryDate, out DateTime expiryDate))
            {
                if (expiryDate < DateTime.Now)
                {
                    return Errors.Company.SessionExpired;
                }
            }
            else
            {
                return Errors.Company.OperationFailed;
            }

            return new CompanySessionValidationResult() { IsValid = true };
        }
    }
}