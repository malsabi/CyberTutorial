using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberTutorial.Domain.Entities
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string EmployeeDashboardId { get; set; }
        [Required]
        public virtual Company Company { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual EmployeeSession Session { get; set; }
        public virtual EmployeeDashboard EmployeeDashboard { get; set; }
    }
}