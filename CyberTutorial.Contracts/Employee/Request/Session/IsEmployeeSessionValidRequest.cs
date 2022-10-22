namespace CyberTutorial.Contracts.Employee.Request.Session
{
    public class IsEmployeeSessionValidRequest
    {
        public string SessionId { get; set; }
        public string Token { get; set; }
    }
}