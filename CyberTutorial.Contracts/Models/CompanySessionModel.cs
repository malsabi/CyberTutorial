namespace CyberTutorial.Contracts.Models
{
    public class CompanySessionModel
    {
        public string CompanySessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}