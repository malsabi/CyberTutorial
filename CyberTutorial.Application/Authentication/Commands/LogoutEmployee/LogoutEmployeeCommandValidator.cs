using FluentValidation;

namespace CyberTutorial.Application.Authentication.Commands.LogoutEmployee
{
    public class LogoutEmployeeCommandValidator : AbstractValidator<LogoutEmployeeCommand>
    {
        public LogoutEmployeeCommandValidator()
        {
            RuleFor(v => v.EmployeeSessionId)
                .NotEmpty();
        }
    }
}