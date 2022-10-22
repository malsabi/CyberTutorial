namespace CyberTutorial.Contracts.Company.Response.Session
{
    public class IsCompanySessionValidResponse
    {
        public bool IsValid { get; set; }
        public string NewToken { get; set; }
    }
}