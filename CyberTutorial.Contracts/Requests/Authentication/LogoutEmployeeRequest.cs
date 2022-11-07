namespace CyberTutorial.Contracts.Requests.Authentication
{
    public class LogoutEmployeeRequest
    {
        public string EmployeeSessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}