using Mapster;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Courses.Common;

namespace CyberTutorial.Application.Common.Mapping
{
    public class CourseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, GetCourseByIdResult>()
                  .Map(dest => dest.Course.CourseId, src => src.CourseId)
                  .Map(dest => dest.Course.CourseImage, src => src.CourseImage)
                  .Map(dest => dest.Course.CourseName, src => src.CourseName)
                  .Map(dest => dest.Course.CourseDescription, src => src.CourseDescription)
                  .Map(dest => dest.Course.CourseUrl, src => src.CourseUrl)
                  .Map(dest => dest.Course.Quizzes, src => src.Quizzes)
                  .MaxDepth(4);

            config.NewConfig<Course, UpdateCourseResult>()
                 .Map(dest => dest.Course.CourseId, src => src.CourseId)
                 .Map(dest => dest.Course.CourseImage, src => src.CourseImage)
                 .Map(dest => dest.Course.CourseName, src => src.CourseName)
                 .Map(dest => dest.Course.CourseDescription, src => src.CourseDescription)
                 .Map(dest => dest.Course.CourseUrl, src => src.CourseUrl)
                 .Map(dest => dest.Course.Quizzes, src => src.Quizzes)
                 .MaxDepth(4);
        }
    }
}