using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Employees.Common
{
    public class EmployeeDashboardResult
    {
        public int TotalCourses { get; set; }
        public string TotalCoursesLastModified { get; set; }
        public int TotalQuizzes { get; set; }
        public string TotalQuizzesLastModified { get; set; }
        public int PassedQuizzes { get; set; }
        public string PassedQuizzesLastModified { get; set; }
        public int FailedQuizzes { get; set; }
        public string FailedQuizzesLastModified { get; set; }
        public ICollection<TopEmployee> TopEmployees { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}