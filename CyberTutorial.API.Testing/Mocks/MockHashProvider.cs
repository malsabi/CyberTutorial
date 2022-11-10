using Moq;
using CyberTutorial.Application.Common.Interfaces.Services;

namespace CyberTutorial.API.Testing.Mocks
{
    public class MockHashProvider
    {
        public static Mock<IHashProvider> GetHashProvider()
        {
            Mock<IHashProvider> mock = new Mock<IHashProvider>();
            
            mock.Setup(s => s.ApplyHash(It.IsAny<string>())).Returns((string password) =>
            {
                return password;
            });

            mock.Setup(s => s.VarifyHash(It.IsAny<string>(), It.IsAny<string>())).Returns((string password, string hash) =>
            {
                return password == hash;
            });

            return mock;
        }
    }
}