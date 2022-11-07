using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Domain.Common.Errors;
using CyberTutorial.Application.Quizzes.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Quizzes.Queries.GetQuizById
{
    public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, ErrorOr<GetQuizByIdResult>>
    {
        private readonly IMapper mapper;
        private readonly IQuizRepository quizRepository;

        public GetQuizByIdQueryHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            this.quizRepository = quizRepository;
            this.mapper = mapper;
        }

        public async Task<ErrorOr<GetQuizByIdResult>> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            if (await quizRepository.GetQuizByIdAsync(request.QuizId) is not Quiz quiz)
            {
                return Errors.Quiz.QuizNotFound;
            }
            return mapper.Map<GetQuizByIdResult>(quiz);
        }
    }
}