using FluentValidation;

namespace CyberTutorial.Application.EmployeeCourses.Queries.GetEmployeeCourseById
{
    public class GetEmployeeCourseByIdQueryValidator : AbstractValidator<GetEmployeeCourseByIdQuery>
    {
        public GetEmployeeCourseByIdQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty();
            RuleFor(x => x.CourseId)
                .NotEmpty();
        }
    }
}