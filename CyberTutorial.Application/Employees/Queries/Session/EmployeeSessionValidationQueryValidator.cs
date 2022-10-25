using FluentValidation;

namespace CyberTutorial.Application.Employees.Queries.Session
{
    public class EmployeeSessionValidationQueryValidator : AbstractValidator<EmployeeSessionValidationQuery>
    {
        public EmployeeSessionValidationQueryValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}