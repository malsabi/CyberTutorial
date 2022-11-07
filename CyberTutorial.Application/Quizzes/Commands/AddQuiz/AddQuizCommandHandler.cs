using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Quizzes.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Quizzes.Commands.AddQuiz
{
    public class AddQuizCommandHandler : IRequestHandler<AddQuizCommand, ErrorOr<AddQuizResult>>
    {
        private readonly IMapper mapper;
        private readonly IQuizRepository quizRepository;
        private readonly ICourseRepository courseRepository;

        public AddQuizCommandHandler(IMapper mapper, IQuizRepository quizRepository, ICourseRepository courseRepository)
        {
            this.mapper = mapper;
            this.quizRepository = quizRepository;
            this.courseRepository = courseRepository;
        }

        public async Task<ErrorOr<AddQuizResult>> Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {
            if (await quizRepository.GetQuizByTitleAsync(request.Title) is not null)
            {
                return Errors.Quiz.DuplicateQuiz;
            }

            if (await courseRepository.GetCourseByIdAsync(request.CourseId) is null)
            {
                return Errors.Course.NotFound;
            }

            Quiz quiz = mapper.Map<Quiz>(request);
            quiz.QuizId = Guid.NewGuid().ToString();

            await quizRepository.AddQuizAsync(quiz);

            return mapper.Map<AddQuizResult>(quiz);
        }
    }
}