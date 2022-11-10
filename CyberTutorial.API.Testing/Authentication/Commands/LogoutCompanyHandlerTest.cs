using Moq;
using ErrorOr;
using Shouldly;
using MapsterMapper;
using CyberTutorial.API.Testing.Mocks;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Authentication.Commands.LogoutCompany;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.API.Testing.Authentication.Commands
{
    public class LogoutCompanyHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<ICompanyRepository> mockCompanyRepository;

        public LogoutCompanyHandlerTest()
        {
            mapper = new Mapper();
            mockCompanyRepository = MockCompanyRepository.GetCompanyRepository();
        }

        [Fact]
        public async void LogoutCompanyTest()
        {
            LogoutCompanyCommandHandler handler = new LogoutCompanyCommandHandler
            (
                mapper,
                mockCompanyRepository.Object
            );

            LogoutCompanyCommand command = new LogoutCompanyCommand()
            {
                CompanySessionId = "1",
                TimeCreated = "",
                ExpiryDate = "",
                Token = "",
                IsActive = false
            };

            ErrorOr<LogoutCompanyResult> result = await handler.Handle(command, CancellationToken.None);

            result.IsError.ShouldBeFalse(string.Format("Logout company operation should be successful but instead it returned [{0}].", result.FirstError.ToString()));
            result.Value.CompanyId.ShouldNotBeNull("Logout company operation succeeded but the company Id returned was empty.");
        }
    }
}