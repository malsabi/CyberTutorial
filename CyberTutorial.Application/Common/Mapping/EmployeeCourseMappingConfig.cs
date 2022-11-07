using Mapster;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.EmployeeCourses.Common;

namespace CyberTutorial.Application.Common.Mapping
{
    public class EmployeeCourseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, GetEmployeeCourseByIdResult>()
                  .Map(dest => dest.Course.CourseId, src => src.CourseId)
                  .Map(dest => dest.Course.CourseImage, src => src.CourseImage)
                  .Map(dest => dest.Course.CourseName, src => src.CourseName)
                  .Map(dest => dest.Course.CourseDescription, src => src.CourseDescription)
                  .Map(dest => dest.Course.CourseUrl, src => src.CourseUrl)
                  .Map(dest => dest.Course.Quizzes, src => src.Quizzes)
                  .Map(dest => dest.Course.Employees, src => src.Employees)
                  .MaxDepth(4);

            config.NewConfig<ICollection<Course>, GetEmployeeCoursesResult>()
                  .Map(dest => dest.Courses, src => src);
        }
    }
}