using ErrorOr;
using CyberTutorial.Contracts.Requests.Attempt;
using CyberTutorial.Contracts.Responses.Attempt;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IAttemptService
    {
        public string Token { get; set; }
        public Task<ErrorOr<AddAttemptResponse>> AddAttemptAsync(AddAttemptRequest request);
        public Task<ErrorOr<GetAttemptsResponse>> GetAttemptsAsync();
        public Task<ErrorOr<GetAttemptByIdResponse>> GetAttemptByIdAsync(string attemptId);
        public Task<ErrorOr<UpdateAttemptResponse>> UpdateAttemptAsync(string attemptId, UpdateAttemptRequest request);
        public Task<ErrorOr<DeleteAttemptResponse>> DeleteAttemptAsync(string attemptId);
    }
}