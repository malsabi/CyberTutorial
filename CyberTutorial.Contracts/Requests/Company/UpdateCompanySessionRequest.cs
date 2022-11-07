namespace CyberTutorial.Contracts.Requests.Company
{
    public class UpdateCompanySessionRequest
    {
        public string CompanySessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}