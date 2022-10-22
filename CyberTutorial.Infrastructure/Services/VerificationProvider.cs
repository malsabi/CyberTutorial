using System.Net.Mail;
using CyberTutorial.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace CyberTutorial.Infrastructure.Services
{
    public class VerificationProvider : IVerificationProvider
    {
        private readonly VerificationSettings verificationSettings;

        public VerificationProvider(IOptions<VerificationSettings> verificationSettings)
        {
            this.verificationSettings = verificationSettings.Value;
        }

        public async Task<bool> SendCodeAsync(string emailAddress, string subject, string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage(verificationSettings.EmailAddress, emailAddress, subject, message);
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(verificationSettings.EmailAddress, verificationSettings.Password)
                };
                await client.SendMailAsync(mailMessage);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Task<bool> VerifyCodeAsync(string userCode, string code)
        {
            return Task.FromResult(userCode == code);
        }
    }
}