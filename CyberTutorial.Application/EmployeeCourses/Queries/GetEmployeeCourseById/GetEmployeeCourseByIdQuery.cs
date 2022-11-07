using ErrorOr;
using MediatR;
using CyberTutorial.Application.EmployeeCourses.Common;

namespace CyberTutorial.Application.EmployeeCourses.Queries.GetEmployeeCourseById
{
    public class GetEmployeeCourseByIdQuery : IRequest<ErrorOr<GetEmployeeCourseByIdResult>>
    {
        public string EmployeeId { get; set; }
        public string CourseId { get; set; }
    }
}