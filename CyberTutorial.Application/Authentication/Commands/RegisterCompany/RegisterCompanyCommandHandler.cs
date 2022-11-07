using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Common.Consts;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Companies.Commands.AddCompany;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Authentication.Commands.RegisterCompany
{
    public class RegisterCompanyCommandHandler : IRequestHandler<RegisterCompanyCommand, ErrorOr<RegisterCompanyResult>>
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

        public async Task<ErrorOr<RegisterCompanyResult>> Handle(RegisterCompanyCommand command, CancellationToken cancellationToken)
        {
            AddCompanyCommandHandler handler = new AddCompanyCommandHandler(mapper, codeGenerator, hashProvider, companyRepository);
            ErrorOr<AddCompanyResult> result = await handler.Handle(mapper.Map<AddCompanyCommand>(command), cancellationToken);

            if (result.IsError)
            {
                return result.Errors;
            }
            else
            {
                string subject = Consts.Company.VerificationSubject;
                string message = string.Format(Consts.Company.VerificationCodeMessage, result.Value.CompanyId);

                if (!await verificationProvider.SendCodeAsync(command.EmailAddress, subject, message))
                {
                    return Errors.Company.OperationFailed;
                }
                return mapper.Map<RegisterCompanyResult>(result.Value);
            }

            //Company company = await companyRepository.GetCompanyByEmailAsync(command.EmailAddress);

            //if (company is not null)
            //{
            //    return Errors.Company.DuplicateEmail;
            //}

            //Company companyToRegister = mapper.Map<Company>(command);

            //companyToRegister.CompanyId = codeGenerator.GenerateCode(4);
            //companyToRegister.Password = hashProvider.ApplyHash(companyToRegister.Password);

            //companyToRegister.Session = new CompanySession()
            //{
            //    TimeCreated = DateTime.Now.ToString(),
            //    IsActive = false
            //};

            //string subject = Consts.Company.VerificationSubject;
            //string message = string.Format(Consts.Company.VerificationCodeMessage, companyToRegister.CompanyId);

            //if (!await verificationProvider.SendCodeAsync(companyToRegister.EmailAddress, subject, message))
            //{
            //    return Errors.Company.OperationFailed;
            //}

            //await companyRepository.AddCompanyAsync(companyToRegister);

            //return mapper.Map<RegisterCompanyResult>(companyToRegister);            
        }
    }
}