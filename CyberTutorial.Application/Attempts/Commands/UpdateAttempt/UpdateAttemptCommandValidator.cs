using FluentValidation;

namespace CyberTutorial.Application.Attempts.Commands.UpdateAttempt
{
    public class UpdateAttemptCommandValidator : AbstractValidator<UpdateAttemptCommand>
    {
        public UpdateAttemptCommandValidator()
        {
            RuleFor(x => x.TargetId)
                .NotEmpty();
            RuleFor(x => x.AttemptId)
                .NotEmpty();
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