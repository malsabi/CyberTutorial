using FluentValidation;

namespace CyberTutorial.Application.Authentication.Commands.LoginCompany
{
    public class LoginCompanyCommandValidator : AbstractValidator<LoginCompanyCommand>
    {
        public LoginCompanyCommandValidator()
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