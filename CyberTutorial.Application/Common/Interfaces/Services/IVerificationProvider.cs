namespace CyberTutorial.Application.Common.Interfaces.Services
{
    public interface IVerificationProvider
    {
        Task<bool> SendCodeAsync(string emailAddress, string subject, string message);
        Task<bool> VerifyCodeAsync(string userCode, string code);
    }
}