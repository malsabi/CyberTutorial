using FluentValidation;

namespace CyberTutorial.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty();

            RuleFor(x => x.CourseName)
                .NotEmpty();

            RuleFor(x => x.CourseDescription)
                .NotEmpty();

            RuleFor(x => x.CourseUrl)
                .NotEmpty();
        }
    }
}