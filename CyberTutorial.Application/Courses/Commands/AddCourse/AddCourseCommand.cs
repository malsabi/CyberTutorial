using ErrorOr;
using MediatR;
using CyberTutorial.Application.Courses.Common;

namespace CyberTutorial.Application.Courses.Commands.AddCourse
{
    public class AddCourseCommand : IRequest<ErrorOr<AddCourseResult>>
    {
        public string CourseImage { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseUrl { get; set; }
    }
}