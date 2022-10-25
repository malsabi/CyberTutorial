using FluentValidation;

namespace CyberTutorial.Application.Companies.Queries.GetCompanySession
{
    public class GetCompanySessionQueryValidator : AbstractValidator<GetCompanySessionQuery>
    {
        public GetCompanySessionQueryValidator()
        {
            RuleFor(x => x.CompanyId)
                .NotEmpty();
        }
    }
}