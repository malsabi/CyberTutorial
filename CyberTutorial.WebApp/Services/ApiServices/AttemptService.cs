using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Attempt;
using CyberTutorial.Contracts.Responses.Attempt;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class AttemptService : IAttemptService
    {
        private readonly IClientApiService clientApiService;

        public string Token { get; set; }

        public AttemptService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<AddAttemptResponse>> AddAttemptAsync(AddAttemptRequest request)
        {
            return await clientApiService.PostAsync<AddAttemptRequest, AddAttemptResponse>(request, ApiConsts.Attempt.Add, Token);
        }

        public async Task<ErrorOr<GetAttemptsResponse>> GetAttemptsAsync()
        {
            return await clientApiService.GetAsync<GetAttemptsResponse>(ApiConsts.Attempt.GetAll, Token);
        }

        public async Task<ErrorOr<GetAttemptByIdResponse>> GetAttemptByIdAsync(string attemptId)
        {
            return await clientApiService.GetAsync<GetAttemptByIdResponse>(ApiConsts.Attempt.Get, Token, attemptId);
        }

        public async Task<ErrorOr<UpdateAttemptResponse>> UpdateAttemptAsync(string attemptId, UpdateAttemptRequest request)
        {
            return await clientApiService.PutAsync<UpdateAttemptRequest, UpdateAttemptResponse>(request, ApiConsts.Attempt.Update, Token, attemptId);
        }

        public async Task<ErrorOr<DeleteAttemptResponse>> DeleteAttemptAsync(string attemptId)
        {
            return await clientApiService.DeleteAsync<DeleteAttemptResponse>(ApiConsts.Attempt.Delete, Token, attemptId);
        }
    }
}