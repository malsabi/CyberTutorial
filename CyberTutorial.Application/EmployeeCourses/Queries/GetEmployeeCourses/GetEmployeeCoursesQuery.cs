using ErrorOr;
using MediatR;
using CyberTutorial.Application.EmployeeCourses.Common;

namespace CyberTutorial.Application.EmployeeCourses.Queries.GetEmployeeCourses
{
    public class GetEmployeeCoursesQuery : IRequest<ErrorOr<GetEmployeeCoursesResult>>
    {
        public string EmployeeId { get; set; }
    }
}