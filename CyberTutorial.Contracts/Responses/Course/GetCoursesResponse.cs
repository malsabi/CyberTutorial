using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.Course
{
    public class GetCoursesResponse
    {
        public ICollection<CourseModel> Courses { get; set; }
    }
}