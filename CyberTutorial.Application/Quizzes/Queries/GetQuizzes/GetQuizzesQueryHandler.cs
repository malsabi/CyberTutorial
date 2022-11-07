using MediatR;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Application.Quizzes.Common;
using CyberTutorial.Application.Common.Interfaces.Persistence.Repositories;

namespace CyberTutorial.Application.Quizzes.Queries.GetQuizzes
{
    public class GetQuizzesQueryHandler : IRequestHandler<GetQuizzesQuery, GetQuizzesResult>
    {
        private readonly IQuizRepository quizRepository;

        public GetQuizzesQueryHandler(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        public async Task<GetQuizzesResult> Handle(GetQuizzesQuery request, CancellationToken cancellationToken)
        {
            ICollection<Quiz> quizzes = await quizRepository.GetQuizzesAsync();
            return new GetQuizzesResult
            {
                Quizzes = quizzes
            };
        }
    }
}