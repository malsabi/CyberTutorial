using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Requests.Employee
{
    public class UpdateEmployeeRequest
    {
        public string EmployeeId { get; set; }
        public string CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}