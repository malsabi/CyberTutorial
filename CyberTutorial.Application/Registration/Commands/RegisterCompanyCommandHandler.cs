using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Registration.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Registration.Commands
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, ErrorOr<RegisterResult>>
    {
        private readonly IMapper mapper;
        private readonly ICodeGenerator codeGenerator;
        private readonly IHashProvider hashProvider;
        private readonly ICompanyRepository companyRepository;

        public RegisterCompanyCommandHandler(IMapper mapper, ICodeGenerator codeGenerator, IHashProvider hashProvider, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.codeGenerator = codeGenerator;
            this.hashProvider = hashProvider;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<RegisterResult>> Handle(RegisterCompanyCommand command, CancellationToken cancellationToken)
        {
            Company company = await companyRepository.GetCompanyByEmailAsync(command.EmailAddress);

            if (company is not null)
            {
                return Errors.Company.DuplicateEmail;
            }

            Company companyToRegister = mapper.Map<Company>(command);

            companyToRegister.Id = codeGenerator.GenerateCode(4);
            companyToRegister.Password = hashProvider.ApplyHash(companyToRegister.Password);

            await companyRepository.AddCompanyAsync(companyToRegister);

            return new RegisterResult
            {
                Id = companyToRegister.Id
            };
        }
    }
}