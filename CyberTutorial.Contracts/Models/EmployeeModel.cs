namespace CyberTutorial.Contracts.Models
{
    public class EmployeeModel
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
        public TopEmployeeModel TopEmployee { get; set; }
        public EmployeeDashboardModel EmployeeDashboard { get; set; }
        public ICollection<CourseModel> Courses { get; set; }
        public ICollection<AttemptModel> Attempts { get; set; }
        public EmployeeSessionModel Session { get; set; }
    }
}