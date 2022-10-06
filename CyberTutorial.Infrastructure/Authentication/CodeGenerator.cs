using System.Text;
using CyberTutorial.Application.Common.Interfaces.Authentication;

namespace CyberTutorial.Infrastructure.Authentication
{
    public class CodeGenerator : ICodeGenerator
    {
        private readonly Random random;

        public CodeGenerator()
        {
            random = new Random();
        }

        public string GenerateCode(int bucketLength)
        {
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
        }
    }
}