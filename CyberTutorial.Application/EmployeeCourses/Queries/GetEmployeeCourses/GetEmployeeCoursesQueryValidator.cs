using FluentValidation;

namespace CyberTutorial.Application.EmployeeCourses.Queries.GetEmployeeCourses
{
    public class GetEmployeeCoursesQueryValidator : AbstractValidator<GetEmployeeCoursesQuery>
    {
        public GetEmployeeCoursesQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty();
        }
    }
}