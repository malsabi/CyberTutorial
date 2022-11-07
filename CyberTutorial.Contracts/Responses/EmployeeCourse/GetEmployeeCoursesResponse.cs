using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.EmployeeCourse
{
    public class GetEmployeeCoursesResponse
    {
        public ICollection<CourseModel> Courses { get; set; }
    }
}