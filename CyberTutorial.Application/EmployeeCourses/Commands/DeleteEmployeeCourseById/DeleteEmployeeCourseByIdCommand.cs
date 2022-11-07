using ErrorOr;
using MediatR;
using CyberTutorial.Application.EmployeeCourses.Common;

namespace CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourseById
{
    public class DeleteEmployeeCourseByIdCommand : IRequest<ErrorOr<DeleteEmployeeCourseByIdResult>>
    {
        public string EmployeeId { get; set; }
        public string CourseId { get; set; }
    }
}