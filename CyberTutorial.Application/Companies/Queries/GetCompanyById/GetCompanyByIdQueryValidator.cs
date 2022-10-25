using FluentValidation;

namespace CyberTutorial.Application.Companies.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryValidator : AbstractValidator<GetCompanyByIdQuery>
    {
        public GetCompanyByIdQueryValidator()
        {
            RuleFor(v => v.CompanyId)
                .NotEmpty();
        }
    }
}