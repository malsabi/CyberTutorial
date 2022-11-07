using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.Authentication
{
    public class LoginEmployeeResponse
    {
        public EmployeeSessionModel Session { get; set; }
    }
}