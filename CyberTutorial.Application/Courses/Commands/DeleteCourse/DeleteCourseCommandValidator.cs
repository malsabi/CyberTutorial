using FluentValidation;

namespace CyberTutorial.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty();
        }
    }
}