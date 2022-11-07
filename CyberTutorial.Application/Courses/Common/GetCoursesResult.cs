using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Courses.Common
{
    public class GetCoursesResult
    {
        public ICollection<Course> Courses { get; set; }
    }
}