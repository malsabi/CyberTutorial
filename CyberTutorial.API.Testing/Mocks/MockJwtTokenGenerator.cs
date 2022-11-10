using Moq;
using System.Text;
using System.Text.Json;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Common.Interfaces.Authentication;

namespace CyberTutorial.API.Testing.Mocks
{
    public static class MockJwtTokenGenerator
    {
        public static Mock<IJwtTokenGenerator> GetJwtTokenGenerator()
        {
            Mock<IJwtTokenGenerator> mock = new Mock<IJwtTokenGenerator>();

            mock.Setup(s => s.GenerateToken(It.IsAny<Company>())).Returns((Company company) =>
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(company)));
            });

            mock.Setup(s => s.GenerateToken(It.IsAny<Employee>())).Returns((Employee employee) =>
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(employee)));
            });

            mock.Setup(s => s.GenerateToken(It.IsAny<Employee>())).Returns((Administrator administrator) =>
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(administrator)));
            });

            return mock;
        }
    }
}