using FluentValidation;

namespace CyberTutorial.Application.Companies.Queries.Session
{
    public class CompanySessionValidationQueryValidator : AbstractValidator<CompanySessionValidationQuery>
    {
        public CompanySessionValidationQueryValidator()
        {
            RuleFor(x => x.SessionId).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}