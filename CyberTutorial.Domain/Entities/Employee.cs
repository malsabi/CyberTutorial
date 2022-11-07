using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.Domain.Entities
{
    public class Employee
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
        [Required]
        public Company Company { get; set; }
        public TopEmployee TopEmployee { get; set; }
        public EmployeeDashboard EmployeeDashboard { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
        public EmployeeSession Session { get; set; }
    }
}