using FluentValidation;

namespace CyberTutorial.Application.Employees.Queries.GetEmployeById
{
    public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty();
        }
    }
}