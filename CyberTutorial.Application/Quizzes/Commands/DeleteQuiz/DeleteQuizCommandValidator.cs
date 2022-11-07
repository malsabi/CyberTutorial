using FluentValidation;

namespace CyberTutorial.Application.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommandValidator : AbstractValidator<DeleteQuizCommand>
    {
        public DeleteQuizCommandValidator()
        {
            RuleFor(x => x.QuizId)
                .NotEmpty();
        }
    }
}