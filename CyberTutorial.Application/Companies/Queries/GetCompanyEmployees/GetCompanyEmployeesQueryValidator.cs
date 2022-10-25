using FluentValidation;

namespace CyberTutorial.Application.Companies.Queries.GetCompanyEmployees
{
    public class GetCompanyEmployeesQueryValidator : AbstractValidator<GetCompanyEmployeesQuery>
    {
        public GetCompanyEmployeesQueryValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty();
        }
    }
}