using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.EmployeeCourses.Common
{
    public class GetEmployeeCoursesResult
    {
        public ICollection<Course> Courses { get; set; }
    }
}