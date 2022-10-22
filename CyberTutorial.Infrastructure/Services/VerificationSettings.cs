namespace CyberTutorial.Infrastructure.Services
{
    public class VerificationSettings
    {
        public const string SectionName = "VerificationSettings";
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}