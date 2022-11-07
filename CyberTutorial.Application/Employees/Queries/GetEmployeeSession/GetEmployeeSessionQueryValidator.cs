using FluentValidation;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeSession
{
    public class GetEmployeeSessionQueryValidator : AbstractValidator<GetEmployeeSessionQuery>
    {
        public GetEmployeeSessionQueryValidator()
        {
            RuleFor(v => v.EmployeeId)
               .NotEmpty();
        }
    }
}