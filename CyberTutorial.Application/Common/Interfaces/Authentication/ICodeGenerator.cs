namespace CyberTutorial.Application.Common.Interfaces.Authentication
{
    public interface ICodeGenerator
    {
        string GenerateCode(int bucketLength);
    }
}