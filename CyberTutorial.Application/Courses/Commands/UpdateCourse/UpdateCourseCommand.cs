using ErrorOr;
using MediatR;
using CyberTutorial.Application.Courses.Common;

namespace CyberTutorial.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<ErrorOr<UpdateCourseResult>>
    {
        public string TargetId { get; set; }
        public string CourseId { get; set; }
        public string CourseImage { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseUrl { get; set; }
    }
}