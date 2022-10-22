using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Consts;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;
using CyberTutorial.Application.Authentication.Common;

namespace CyberTutorial.Application.Authentication.Commands
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, ErrorOr<RegisterResult>>
    {
        private readonly IMapper mapper;
        private readonly ICodeGenerator codeGenerator;
        private readonly IHashProvider hashProvider;
        private readonly ICompanyRepository companyRepository;
        private readonly IVerificationProvider verificationProvider;

        public RegisterCompanyCommandHandler(IMapper mapper, ICodeGenerator codeGenerator, IHashProvider hashProvider, ICompanyRepository companyRepository, IVerificationProvider verificationProvider)
        {
            this.mapper = mapper;
            this.codeGenerator = codeGenerator;
            this.hashProvider = hashProvider;
            this.companyRepository = companyRepository;
            this.verificationProvider = verificationProvider;
        }

        public async Task<ErrorOr<RegisterResult>> Handle(RegisterCompanyCommand command, CancellationToken cancellationToken)
        {
            Company company = await companyRepository.GetCompanyByEmailAsync(command.EmailAddress);

            if (company is not null)
            {
                return Errors.Company.DuplicateEmail;
            }

            Company companyToRegister = mapper.Map<Company>(command);

            companyToRegister.CompanyId = codeGenerator.GenerateCode(4);
            companyToRegister.Password = hashProvider.ApplyHash(companyToRegister.Password);

            string subject = Consts.Company.VerificationSubject;
            string message = string.Format(Consts.Company.VerificationCodeMessage, companyToRegister.CompanyId);
           
            if (!await verificationProvider.SendCodeAsync(companyToRegister.EmailAddress, subject, message))
            {
                return Errors.Company.OperationFailed;
            }

            await companyRepository.AddCompanyAsync(companyToRegister);

            return new RegisterResult
            {
                EmployeeId = companyToRegister.CompanyId
            };
        }
    }
}