using Moq;
using System.Text;
using CyberTutorial.Application.Common.Interfaces.Authentication;

namespace CyberTutorial.API.Testing.Mocks
{
    public static class MockCodeGenerator
    {
        public static Mock<ICodeGenerator> GetCodeGenerator()
        {
            Mock<ICodeGenerator> mock = new Mock<ICodeGenerator>();

            mock.Setup(x => x.GenerateCode(It.IsAny<int>())).Returns((int bucketLength) => 
            {
                Random random = new Random();
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < 3; i++)
                {
                    string code = string.Empty;
                    for (int j = 0; j < bucketLength; j++)
                    {
                        code += random.Next(0, 9);
                    }
                    stringBuilder.Append(code);
                    stringBuilder.Append("-");
                }
                return stringBuilder.ToString().TrimEnd('-');
            });
            return mock;
        }
    }
}