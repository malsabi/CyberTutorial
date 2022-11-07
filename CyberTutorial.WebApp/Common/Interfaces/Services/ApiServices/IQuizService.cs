using ErrorOr;
using CyberTutorial.Contracts.Requests.Quiz;
using CyberTutorial.Contracts.Responses.Quiz;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IQuizService
    {
        public string Token { get; set; }
        public Task<ErrorOr<AddQuizResponse>> AddQuizAsync(AddQuizRequest request);
        public Task<ErrorOr<GetQuizzesResponse>> GetQuizzesAsync();
        public Task<ErrorOr<GetQuizByIdResponse>> GetQuizAsync(string quizId);
        public Task<ErrorOr<UpdateQuizResponse>> UpdateQuizAsync(string quizId, UpdateQuizRequest request);
        public Task<ErrorOr<DeleteQuizResponse>> DeleteQuizAsync(string quizId);
    }
}