using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Companies.Commands.AddCompany
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, ErrorOr<AddCompanyResult>>
    {
        private readonly IMapper mapper;
        private readonly ICodeGenerator codeGenerator;
        private readonly IHashProvider hashProvider;
        private readonly ICompanyRepository companyRepository;

        public AddCompanyCommandHandler(IMapper mapper, ICodeGenerator codeGenerator, IHashProvider hashProvider, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.codeGenerator = codeGenerator;
            this.hashProvider = hashProvider;
            this.companyRepository = companyRepository;
        }

        public async Task<ErrorOr<AddCompanyResult>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            if (await companyRepository.GetCompanyByEmailAsync(request.EmailAddress) is not null)
            {
                return Errors.Company.DuplicateEmail;
            }
            Company company = mapper.Map<Company>(request);

            company.CompanyId = codeGenerator.GenerateCode(4);
            company.Password = hashProvider.ApplyHash(company.Password);

            company.Session = new CompanySession()
            {
                TimeCreated = DateTime.Now.ToString(),
                IsActive = false
            };

            await companyRepository.AddCompanyAsync(company);

            return new AddCompanyResult()
            {
                CompanyId = company.CompanyId
            };
        }
    }
}