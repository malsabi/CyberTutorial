using FluentValidation;

namespace CyberTutorial.Application.Employees.Commands.Logout
{
    public class LogoutEmployeeCommandValidator : AbstractValidator<LogoutEmployeeCommand>
    {
        public LogoutEmployeeCommandValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}