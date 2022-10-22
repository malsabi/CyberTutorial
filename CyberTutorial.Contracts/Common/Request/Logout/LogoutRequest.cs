namespace CyberTutorial.Contracts.Common.Request.Logout
{
    public class LogoutRequest
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}