using FluentValidation;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeeCompany
{
    public class GetEmployeeCompanyQueryValidator : AbstractValidator<GetEmployeeCompanyQuery>
    {
        public GetEmployeeCompanyQueryValidator()
        {
            RuleFor(v => v.EmployeeId)
                .NotEmpty();
        }
    }
}