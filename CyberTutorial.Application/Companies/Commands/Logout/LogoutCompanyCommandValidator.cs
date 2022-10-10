using FluentValidation;

namespace CyberTutorial.Application.Companies.Commands.Logout
{
    public class LogoutCompanyCommandValidator : AbstractValidator<LogoutCompanyCommand>
    {
        public LogoutCompanyCommandValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}