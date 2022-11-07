using FluentValidation;

namespace CyberTutorial.Application.Attempts.Commands.AddAttempt
{
    public class AddAttemptCommandValidator : AbstractValidator<AddAttemptCommand>
    {
        public AddAttemptCommandValidator()
        {
            RuleFor(v => v.EmployeeId)
                .NotEmpty();
            RuleFor(v => v.QuizId)
                .NotEmpty();
            RuleFor(v => v.StartedAt)
                .NotEmpty();
            RuleFor(v => v.CompletedAt)
                .NotEmpty();
            RuleFor(v => v.IsStarted)
                .NotEmpty();
            RuleFor(v => v.IsCompleted)
                .NotEmpty();
            RuleFor(v => v.Score)
                .GreaterThanOrEqualTo(0);
            RuleFor(v => v.TotalCorrectAnswers)
                .GreaterThanOrEqualTo(0);
            RuleFor(v => v.TotalIncorectAnswers)
                .GreaterThanOrEqualTo(0);
        }
    }
}