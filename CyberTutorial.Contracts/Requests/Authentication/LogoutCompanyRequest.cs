namespace CyberTutorial.Contracts.Requests.Authentication
{
    public class LogoutCompanyRequest
    {
        public string CompanySessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}