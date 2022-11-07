using FluentValidation;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeDashboard
{
    public class GetEmployeeDashboardQueryValidator : AbstractValidator<GetEmployeeDashboardQuery>
    {
        public GetEmployeeDashboardQueryValidator()
        {
            RuleFor(v => v.EmployeeId).NotEmpty();
        }
    }
}