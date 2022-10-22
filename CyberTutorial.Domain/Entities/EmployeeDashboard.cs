using System.ComponentModel.DataAnnotations.Schema;

namespace CyberTutorial.Domain.Entities
{
    public class EmployeeDashboard
    {
        [ForeignKey("Employee")]
        public string EmployeeDashboardId { get; set; }
        public int TotalCourses { get; set; }
        public int TotalQuizzes { get; set; }
        public int TotalPassed { get; set; }
        public int TotalFailed { get; set; }
        public virtual ICollection<TopEmployee> TopEmployees { get; set; }
        public virtual Employee Employee { get; set; }
    }
}