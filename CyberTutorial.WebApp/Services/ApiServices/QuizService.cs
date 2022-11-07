using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Quiz;
using CyberTutorial.Contracts.Responses.Quiz;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class QuizService : IQuizService
    {
        private readonly IClientApiService clientApiService;

        public string Token { get; set; }
        
        public QuizService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<AddQuizResponse>> AddQuizAsync(AddQuizRequest request)
        {
            return await clientApiService.PostAsync<AddQuizRequest, AddQuizResponse>(request, ApiConsts.Quiz.Add, Token);
        }

        public async Task<ErrorOr<GetQuizzesResponse>> GetQuizzesAsync()
        {
            return await clientApiService.GetAsync<GetQuizzesResponse>(ApiConsts.Quiz.GetAll, Token);
        }

        public async Task<ErrorOr<GetQuizByIdResponse>> GetQuizAsync(string quizId)
        {
            return await clientApiService.GetAsync<GetQuizByIdResponse>(ApiConsts.Quiz.Get, Token, quizId);
        }

        public async Task<ErrorOr<UpdateQuizResponse>> UpdateQuizAsync(string quizId, UpdateQuizRequest request)
        {
            return await clientApiService.PutAsync<UpdateQuizRequest, UpdateQuizResponse>(request, ApiConsts.Quiz.Update, Token, quizId);
        }

        public async Task<ErrorOr<DeleteQuizResponse>> DeleteQuizAsync(string quizId)
        {
            return await clientApiService.DeleteAsync<DeleteQuizResponse>(ApiConsts.Quiz.Delete, Token, quizId);
        }
    }
}