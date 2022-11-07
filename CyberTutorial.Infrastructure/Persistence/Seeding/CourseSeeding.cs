using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Infrastructure.Persistence.Seeding
{
    public static class CourseSeeding
    {
        public static List<Course> Courses()
        {
            return new List<Course>()
            {
                new Course()
                {
                   CourseId = Guid.NewGuid().ToString(),
                   CourseImage = "",
                   CourseName = "Cloud security",
                   CourseDescription = "A collection of procedures and technology designed to address external and internal threats to business security",
                   CourseUrl = ""
                },
            };
        }
    }
}