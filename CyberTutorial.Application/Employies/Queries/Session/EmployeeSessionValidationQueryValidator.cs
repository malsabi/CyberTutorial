using FluentValidation;

namespace CyberTutorial.Application.Employies.Queries.Session
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