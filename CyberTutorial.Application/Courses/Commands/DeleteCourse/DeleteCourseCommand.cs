using ErrorOr;
using MediatR;
using CyberTutorial.Application.Courses.Common;

namespace CyberTutorial.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest<ErrorOr<DeleteCourseResult>>
    {
        public string CourseId { get; set; }
    }
}