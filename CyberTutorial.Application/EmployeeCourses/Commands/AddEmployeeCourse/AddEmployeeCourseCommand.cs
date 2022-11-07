using ErrorOr;
using MediatR;
using CyberTutorial.Application.EmployeeCourses.Common;

namespace CyberTutorial.Application.EmployeeCourses.Commands.AddEmployeeCourse
{
    public class AddEmployeeCourseCommand : IRequest<ErrorOr<AddEmployeeCourseResult>>
    {
        public string EmployeeId { get; set; }
        public string CourseId { get; set; }
    }
}