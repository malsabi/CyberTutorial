using FluentValidation;
namespace CyberTutorial.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty();
        }
    }
}