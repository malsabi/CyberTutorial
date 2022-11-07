using FluentValidation;

namespace CyberTutorial.Application.Attempts.Commands.DeleteAttempt
{
    public class DeleteAttemptCommandValidator : AbstractValidator<DeleteAttemptCommand>
    {
        public DeleteAttemptCommandValidator()
        {
            RuleFor(x => x.AttemptId)
                .NotEmpty();
        }
    }
}