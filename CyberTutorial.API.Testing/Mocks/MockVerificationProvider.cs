using Moq;
using CyberTutorial.Application.Common.Interfaces.Services;

namespace CyberTutorial.API.Testing.Mocks
{
    public static class MockVerificationProvider
    {
        public static Mock<IVerificationProvider> GetVerificationProvider()
        {
            Mock<IVerificationProvider> mock = new Mock<IVerificationProvider>();
            mock.Setup(x => x.SendCodeAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
            mock.Setup(x => x.VerifyCodeAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((string s1, string s2) => 
            {
                return s1 == s2;
            });
            return mock;
        }
    }
}