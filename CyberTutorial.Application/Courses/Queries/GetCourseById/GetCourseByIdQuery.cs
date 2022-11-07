using ErrorOr;
using MediatR;
using CyberTutorial.Application.Courses.Common;

namespace CyberTutorial.Application.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<ErrorOr<GetCourseByIdResult>>
    {
        public string CourseId { get; set; }
    }
}