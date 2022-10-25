using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Employee.Response.Dashboard
{
    public class GetEmployeeDashboardResponse
    {
        public int TotalCourses { get; set; }
        public string TotalCoursesLastModified { get; set; }
        public int TotalQuizzes { get; set; }
        public string TotalQuizzesLastModified { get; set; }
        public int PassedQuizzes{ get; set; }
        public string PassedQuizzesLastModified { get; set; }
        public int FailedQuizzes { get; set; }
        public string FailedQuizzesLastModified { get; set; }
        public ICollection<TopEmployeeModel> TopEmployees { get; set; }
        public ICollection<CourseModel> Courses { get; set; }
        public ICollection<QuizModel> Quizzes { get; set; }
    }
}