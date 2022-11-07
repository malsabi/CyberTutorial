using FluentValidation;

namespace CyberTutorial.Application.Authentication.Commands.LogoutCompany
{
    public class LogoutCompanyCommandValidator : AbstractValidator<LogoutCompanyCommand>
    {
        public LogoutCompanyCommandValidator()
        {
            RuleFor(x => x.CompanySessionId)
                .NotEmpty();
        }
    }
}