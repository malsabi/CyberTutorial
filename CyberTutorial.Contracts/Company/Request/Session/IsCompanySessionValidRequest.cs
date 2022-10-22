namespace CyberTutorial.Contracts.Company.Request.Session
{
    public class IsCompanySessionValidRequest
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}