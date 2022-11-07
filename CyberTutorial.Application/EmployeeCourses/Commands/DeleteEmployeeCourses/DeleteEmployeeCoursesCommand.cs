using ErrorOr;
using MediatR;
using CyberTutorial.Application.EmployeeCourses.Common;

namespace CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourses
{
    public class DeleteEmployeeCoursesCommand : IRequest<ErrorOr<DeleteEmployeeCoursesResult>>
    {
        public string EmployeeId { get; set; }
    }
}