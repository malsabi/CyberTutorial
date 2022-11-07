using FluentValidation;

namespace CyberTutorial.Application.Authentication.Commands.LoginEmployee
{
    public class LoginEmployeeCommandValidator : AbstractValidator<LoginEmployeeCommand>
    {
        public LoginEmployeeCommandValidator()
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