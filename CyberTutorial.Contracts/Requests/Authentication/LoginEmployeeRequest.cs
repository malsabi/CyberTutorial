namespace CyberTutorial.Contracts.Requests.Authentication
{
    public class LoginEmployeeRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}