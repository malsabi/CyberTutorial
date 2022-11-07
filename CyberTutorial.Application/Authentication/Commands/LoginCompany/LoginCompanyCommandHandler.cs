using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Commands.LoginCompany
{
    public class LoginCompanyCommandHandler : IRequestHandler<LoginCompanyCommand, ErrorOr<LoginCompanyResult>>
    {
        private readonly IMapper mapper;
        private readonly IHashProvider hashProvider;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly ICompanyRepository companyRepository;

        public LoginCompanyCommandHandler(IMapper mapper, IHashProvider hashProvider, IJwtTokenGenerator jwtTokenGenerator, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.hashProvider = hashProvider;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<LoginCompanyResult>> Handle(LoginCompanyCommand command, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByEmailAsync(command.EmailAddress) is not Company company)
            {
                return Errors.Authentication.DoesNotExists;
            }

            if (!hashProvider.VarifyHash(company.Password, command.Password))
            {
                return Errors.Authentication.InvalidPassword;
            }

            if (company.Session == null)
            {
                return Errors.Authentication.OperationFailed;
            }

            company.Session.ExpiryDate = DateTime.Now.AddDays(30).ToString();
            company.Session.Token = jwtTokenGenerator.GenerateToken(company);
            company.Session.IsActive = true;

            await companyRepository.UpdateCompanyAsync(company);

            return mapper.Map<LoginCompanyResult>(company.Session);
        }
    }
}