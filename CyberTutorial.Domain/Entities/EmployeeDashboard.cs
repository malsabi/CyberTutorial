using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberTutorial.Domain.Entities
{
    public class EmployeeDashboard
    {
        [ForeignKey("Employee")]
        public string EmployeeDashboardId { get; set; }
        public int TotalCourses { get; set; }
        public string TotalCoursesLastModified { get; set; }
        public int TotalQuizzes { get; set; }
        public string TotalQuizzesLastModified { get; set; }
        public int TotalPassed { get; set; }
        public string TotalPassedLastModified { get; set; }
        public int TotalFailed { get; set; }
        public string TotalFailedLastModified { get; set; }
        [Required]
        public Employee Employee { get; set; }
    }
}