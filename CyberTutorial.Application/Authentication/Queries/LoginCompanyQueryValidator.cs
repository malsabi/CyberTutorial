using FluentValidation;

namespace CyberTutorial.Application.Authentication.Queries
{
    public class LoginCompanyQueryValidator : AbstractValidator<LoginCompanyQuery>
    {
        public LoginCompanyQueryValidator()
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