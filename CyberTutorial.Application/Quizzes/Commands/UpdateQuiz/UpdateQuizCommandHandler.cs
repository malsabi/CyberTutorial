using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Quizzes.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Quizzes.Commands.UpdateQuiz
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, ErrorOr<UpdateQuizResult>>
    {
        private readonly IMapper mapper;
        private readonly IQuizRepository quizRepository;
        private readonly ICourseRepository courseRepository;

        public UpdateQuizCommandHandler(IMapper mapper, IQuizRepository quizRepository, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.quizRepository = quizRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<UpdateQuizResult>> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            if (request.TargetId != request.QuizId)
            {
                return Errors.Quiz.OperationFailed;
            }

            if (await courseRepository.GetCourseByIdAsync(request.CourseId) is null)
            {
                return Errors.Course.NotFound;
            }

            if (await quizRepository.GetQuizByIdAsync(request.QuizId) is not Quiz quiz)
            {
                return Errors.Quiz.QuizNotFound;
            }

            quiz.Title = request.Title;
            quiz.Description = request.Description;
            quiz.MaximumScore = request.MaximumScore;
            quiz.TotalQuestions = request.TotalQuestions;
            quiz.Duration = request.Duration;
            quiz.CourseId = request.CourseId;
            quiz.Questions = request.Questions;

            await quizRepository.UpdateQuizAsync(quiz);

            return mapper.Map<UpdateQuizResult>(quiz);
        }
    }
}