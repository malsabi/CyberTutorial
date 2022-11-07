using FluentValidation;

namespace CyberTutorial.Application.Courses.Commands.AddCourse
{
    public class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
    {
        public AddCourseCommandValidator()
        {
            RuleFor(x => x.CourseImage)
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