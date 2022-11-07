using MediatR;
using CyberTutorial.Application.Courses.Common;

namespace CyberTutorial.Application.Courses.Queries.GetCourses
{
    public class GetCoursesQuery : IRequest<GetCoursesResult>
    {
    }
}