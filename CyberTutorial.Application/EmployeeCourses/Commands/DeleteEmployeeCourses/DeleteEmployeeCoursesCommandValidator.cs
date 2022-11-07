using FluentValidation;

namespace CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourses
{
    public class DeleteEmployeeCoursesCommandValidator : AbstractValidator<DeleteEmployeeCoursesCommand>
    {
        public DeleteEmployeeCoursesCommandValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty();
        }
    }
}