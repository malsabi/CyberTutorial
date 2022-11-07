using FluentValidation;

namespace CyberTutorial.Application.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryValidator : AbstractValidator<GetCourseByIdQuery>
    {
        public GetCourseByIdQueryValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty();
        }
    }
}