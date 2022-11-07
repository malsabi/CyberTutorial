using FluentValidation;

namespace CyberTutorial.Application.Companies.Commands.UpdateCompanySession
{
    public class UpdateCompanySessionCommandValidator : AbstractValidator<UpdateCompanySessionCommand>
    {
        public UpdateCompanySessionCommandValidator()
        {
            RuleFor(x => x.TargetId)
                .NotEmpty();
            RuleFor(x => x.CompanySessionId)
                .NotEmpty();
            RuleFor(x => x.TimeCreated)
                .NotEmpty();
            RuleFor(x => x.ExpiryDate)
                .NotEmpty();
            RuleFor(x => x.Token)
                .NotEmpty();
        }
    }
}