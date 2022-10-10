namespace CyberTutorial.Contracts.Company.Request.Logout
{
    public class LogoutRequest
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}