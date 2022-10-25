using FluentValidation;

namespace CyberTutorial.Application.Employees.Queries.Dashboard
{
    public class EmployeeDashboardQueryValidator : AbstractValidator<EmployeeDashboardQuery>
    {
        public EmployeeDashboardQueryValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty();
        }
    }
}