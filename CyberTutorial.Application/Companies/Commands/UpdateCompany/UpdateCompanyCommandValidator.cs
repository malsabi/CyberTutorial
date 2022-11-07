using FluentValidation;

namespace CyberTutorial.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(command => command.CompanyId)
                .NotEmpty();

            RuleFor(command => command.TargetId)
                .NotEmpty();

            RuleFor(command => command.CompanyName)
              .NotEmpty()
              .MinimumLength(3)
              .MaximumLength(200);

            RuleFor(command => command.OwnerFirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(command => command.OwnerLastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(command => command.OwnerEmiratesId)
                .NotEmpty()
                .MinimumLength(18)
                .MaximumLength(18);

            RuleFor(command => command.PhoneNumber)
                .NotEmpty()
                .MinimumLength(9)
                .MaximumLength(10);

            RuleFor(command => command.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(command => command.State)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(command => command.Region)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(command => command.StreetAddress)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(200);

            RuleFor(command => command.Website)
                .NotEmpty()
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _));

            RuleFor(command => command.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(65);
        }
    }
}