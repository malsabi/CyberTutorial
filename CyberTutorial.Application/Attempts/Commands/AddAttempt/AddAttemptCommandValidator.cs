using FluentValidation;

namespace CyberTutorial.Application.Attempts.Commands.AddAttempt
{
    public class AddAttemptCommandxalidator : AbstractValidator<AddAttemptCommand>
    {
        public AddAttemptCommandxalidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty();
            RuleFor(x => x.QuizId)
                .NotEmpty();
            RuleFor(x => x.QuizName)
                .NotEmpty();
            RuleFor(x => x.StartedAt)
                .NotEmpty();
            RuleFor(x => x.CompletedAt)
                .NotEmpty();
            RuleFor(x => x.Score)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.TotalCorrectAnswers)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.TotalIncorrectAnswers)
                .GreaterThanOrEqualTo(0);
        }
    }
}