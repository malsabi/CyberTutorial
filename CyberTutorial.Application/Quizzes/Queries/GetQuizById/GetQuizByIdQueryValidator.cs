using FluentValidation;

namespace CyberTutorial.Application.Quizzes.Queries.GetQuizById
{
    public class GetQuizByIdQueryValidator : AbstractValidator<GetQuizByIdQuery>
    {
        public GetQuizByIdQueryValidator()
        {
            RuleFor(v => v.QuizId)
                .NotEmpty();
        }
    }
}