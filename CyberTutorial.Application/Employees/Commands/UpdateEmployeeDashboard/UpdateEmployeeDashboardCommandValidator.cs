using FluentValidation;

namespace CyberTutorial.Application.Employees.Commands.UpdateEmployeeDashboard
{
    public class UpdateEmployeeDashboardCommandValidator : AbstractValidator<UpdateEmployeeDashboardCommand>
    {
        public UpdateEmployeeDashboardCommandValidator()
        {
            RuleFor(v => v.TargetId)
                .NotEmpty();

            RuleFor(v => v.EmployeeDashboardId)
                .NotEmpty();

            RuleFor(v => v.TotalCourses)
                .GreaterThanOrEqualTo(0);

            RuleFor(v => v.TotalCoursesLastModified)
                .NotEmpty();

            RuleFor(v => v.TotalQuizzes)
                .GreaterThanOrEqualTo(0);

            RuleFor(v => v.TotalQuizzesLastModified)
                .NotEmpty();

            RuleFor(v => v.TotalPassed)
                .GreaterThanOrEqualTo(0);

            RuleFor(v => v.TotalPassedLastModified)
                .NotEmpty();

            RuleFor(v => v.TotalFailed)
                .GreaterThanOrEqualTo(0);

            RuleFor(v => v.TotalFailedLastModified)
                .NotEmpty();
        }
    }
}
