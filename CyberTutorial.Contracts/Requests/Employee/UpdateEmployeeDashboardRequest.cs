namespace CyberTutorial.Contracts.Requests.Employee
{
    public class UpdateEmployeeDashboardRequest
    {
        public string EmployeeDashboardId { get; set; }
        public int TotalCourses { get; set; }
        public string TotalCoursesLastModified { get; set; }
        public int TotalQuizzes { get; set; }
        public string TotalQuizzesLastModified { get; set; }
        public int TotalPassed { get; set; }
        public string TotalPassedLastModified { get; set; }
        public int TotalFailed { get; set; }
        public string TotalFailedLastModified { get; set; }
    }
}