namespace CyberTutorial.Contracts.Requests.Company
{
    public class LogoutCompanyRequest
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}