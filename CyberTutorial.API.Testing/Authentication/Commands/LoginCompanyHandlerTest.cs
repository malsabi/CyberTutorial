using Moq;
using ErrorOr;
using Shouldly;
using MapsterMapper;
using CyberTutorial.API.Testing.Mocks;
using CyberTutorial.API.Testing.Mappings;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Common.Interfaces.Services;
using CyberTutorial.Application.Common.Interfaces.Authentication;
using CyberTutorial.Application.Authentication.Commands.LoginCompany;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.API.Testing.Authentication.Commands
{
    public class LoginCompanyHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IHashProvider> mockHashProvider;
        private readonly Mock<IJwtTokenGenerator> mockJwtTokenGenerator;
        private readonly Mock<ICompanyRepository> mockCompanyRepository;

        public LoginCompanyHandlerTest()
        {
            mapper = new Mapper(LoginCompanyConfigMapping.GetConfig());
            mockHashProvider = MockHashProvider.GetHashProvider();
            mockJwtTokenGenerator = MockJwtTokenGenerator.GetJwtTokenGenerator();
            mockCompanyRepository = MockCompanyRepository.GetCompanyRepository();
        }

        [Fact]
        public async void LoginCompanyTest()
        {
            LoginCompanyCommandHandler handler = new LoginCompanyCommandHandler
            (
                mapper,
                mockHashProvider.Object,
                mockJwtTokenGenerator.Object,
                mockCompanyRepository.Object
            );

            LoginCompanyCommand command = new LoginCompanyCommand()
            {
                EmailAddress = "JohnDoe@gmail.com",
                Password = "123321"
            };

            ErrorOr<LoginCompanyResult> result = await handler.Handle(command, CancellationToken.None);

            result.IsError.ShouldBeFalse(string.Format("Login company operation should be successful but instead it returned [{0}].", result.FirstError.ToString()));
            result.Value.Session.ShouldNotBeNull("Login company operation success but should return a valid session.");
        }
    }
}