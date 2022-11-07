using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Quizzes.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, ErrorOr<DeleteQuizResult>>
    {
        private readonly IMapper mapper;
        private readonly IQuizRepository quizRepository;

        public DeleteQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            this.quizRepository = quizRepository;
            this.mapper = mapper;
        }

        public async Task<ErrorOr<DeleteQuizResult>> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            if (await quizRepository.GetQuizByIdAsync(request.QuizId) is not Quiz quiz)
            {
                return Errors.Quiz.QuizNotFound;
            }

            await quizRepository.DeleteQuizAsync(quiz);

            return mapper.Map<DeleteQuizResult>(quiz);
        }
    }
}