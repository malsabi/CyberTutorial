using FluentValidation;

namespace CyberTutorial.Application.Authentication.Queries.Login
{
    public class LoginEmployeeQueryValidator : AbstractValidator<LoginEmployeeQuery>
    {
        public LoginEmployeeQueryValidator()
        {
            RuleFor(query => query.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(query => query.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(50);
        }
    }
}