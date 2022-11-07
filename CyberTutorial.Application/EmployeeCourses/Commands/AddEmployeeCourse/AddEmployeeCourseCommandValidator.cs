using FluentValidation;

namespace CyberTutorial.Application.EmployeeCourses.Commands.AddEmployeeCourse
{
    public class AddEmployeeCourseCommandValidator : AbstractValidator<AddEmployeeCourseCommand>
    {
        public AddEmployeeCourseCommandValidator()
        {
            RuleFor(v => v.EmployeeId)
                .NotEmpty();
            RuleFor(v => v.CourseId)
                .NotEmpty();
        }
    }
}