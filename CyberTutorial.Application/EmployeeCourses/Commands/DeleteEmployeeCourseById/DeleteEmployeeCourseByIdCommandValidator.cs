using FluentValidation;

namespace CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourseById
{
    public class DeleteEmployeeCourseByIdCommandValidator : AbstractValidator<DeleteEmployeeCourseByIdCommand>
    {
        public DeleteEmployeeCourseByIdCommandValidator()
        {
            RuleFor(v => v.EmployeeId)
                .NotEmpty();
            RuleFor(v => v.CourseId)
                .NotEmpty();
        }
    }
}