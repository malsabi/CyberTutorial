using FluentValidation;

namespace CyberTutorial.Application.Quizzes.Commands.AddQuiz
{
    public class AddQuizCommandValidator : AbstractValidator<AddQuizCommand>
    {
        public AddQuizCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty();
            RuleFor(v => v.Description)
                .NotEmpty();
            RuleFor(v => v.MaximumScore)
                .GreaterThanOrEqualTo(0);
            RuleFor(v => v.TotalQuestions)
                .GreaterThanOrEqualTo(0);
            RuleFor(v => v.Duration)
                .NotEmpty();
            RuleFor(v => v.CourseId)
                .NotEmpty();
            RuleFor(v => v.Questions)
                .NotEmpty();
        }
    }
}