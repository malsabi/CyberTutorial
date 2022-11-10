using Moq;
using ErrorOr;
using Shouldly;
using MapsterMapper;
using CyberTutorial.API.Testing.Mocks;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Authentication.Commands.RegisterCompany;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.API.Testing.Authentication.Commands
{
    public class RegisterCompanyHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<ICodeGenerator> mockCodeGenerator;
        private readonly Mock<IHashProvider> mockHashProvider;
        private readonly Mock<ICompanyRepository> mockCompanyRepository;
        private readonly Mock<IVerificationProvider> mockVerificationProvider;
     
        public RegisterCompanyHandlerTest()
        {
            mapper = new Mapper();
            mockCodeGenerator = MockCodeGenerator.GetCodeGenerator();
            mockHashProvider = MockHashProvider.GetHashProvider();
            mockCompanyRepository = MockCompanyRepository.GetCompanyRepository();
            mockVerificationProvider = MockVerificationProvider.GetVerificationProvider();
        }

        [Fact]
        public async void RegisterCompanyTest()
        {
            RegisterCompanyCommandHandler handler = new RegisterCompanyCommandHandler
            (
                mapper, 
                mockCodeGenerator.Object, 
                mockHashProvider.Object,
                mockCompanyRepository.Object, 
                mockVerificationProvider.Object
            );

            RegisterCompanyCommand command = new RegisterCompanyCommand()
            {
                CompanyName = "CyberTutorial",
                OwnerFirstName = "Hind",
                OwnerLastName = "Mariam",
                OwnerEmiratesId = "333-4422-3334445-0",
                PhoneNumber = "0501231234",
                EmailAddress = "HindMariam@gmail.com",
                State = "Dubai",
                Region = "Dubai",
                StreetAddress = "Dubai Silicon Oasis",
                Website = "https://cyber-tutorials.com",
                CompanyDescription = "Digital cyber security awareness.",
                Password = "123321"
            };

            ErrorOr<RegisterCompanyResult> result = await handler.Handle(command, CancellationToken.None);

            result.IsError.ShouldBeFalse(string.Format("Register company operation should be successful but instead it returned [{0}]", result.FirstError.ToString()));
            result.Value.CompanyId.ShouldNotBeNull("Register company operation succeeded but the company Id returned was empty.");
        }
    }
}