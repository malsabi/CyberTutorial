using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Queries
{
    public class LoginCompanyQueryHandler : IRequestHandler<LoginCompanyQuery, ErrorOr<LoginResult>>
    {
        private readonly IMapper mapper;
        private readonly IHashProvider hashProvider;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanySessionRepository companySessionRepository;

        public LoginCompanyQueryHandler(IMapper mapper, IHashProvider hashProvider, IJwtTokenGenerator jwtTokenGenerator, 
            ICompanyRepository companyRepository, ICompanySessionRepository companySessionRepository)
        {
            this.mapper = mapper;
            this.hashProvider = hashProvider;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.companyRepository = companyRepository;
            this.companySessionRepository = companySessionRepository;
        }

        public async Task<ErrorOr<LoginResult>> Handle(LoginCompanyQuery command, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByEmailAsync(command.EmailAddress) is not Company company)
            {
                return Errors.Authentication.DoesNotExists;
            }

            if (!hashProvider.VarifyHash(company.Password, command.Password))
            {
                return Errors.Authentication.InvalidPassword;
            }

            if (await companySessionRepository.GetCompanySessionByCompanyIdAsync(company.Id) is CompanySession existingCompanySession)
            {
                await companySessionRepository.DeleteCompanySessionAsync(existingCompanySession);
            }

            CompanySession companySession = new CompanySession()
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = company.Id,
                TimeCreated = DateTime.Now.ToString(),
                ExpiryDate = DateTime.Now.AddDays(30).ToString(),
                Token = jwtTokenGenerator.GenerateToken(company),
                IsActive = true
            };

            await companySessionRepository.CreateCompanySessionAsync(companySession);

            return new LoginResult()
            {
                SessionId = companySession.Id,
                Token = companySession.Token
            };
        }
    }
}