using ErrorOr;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IClientApiService
    {
        Task<ErrorOr<TResponse>> GetAsync<TResponse>(string endpoint, string token = "", params string[] args);
        Task<ErrorOr<TResponse>> PostAsync<TRequest, TResponse>(TRequest data, string endpoint, string token = "");
        Task<ErrorOr<TResponse>> PostAsync<TResponse>(string endpoint, string token = "", params string[] args);
        Task<ErrorOr<TResponse>> PutAsync<TRequest, TResponse>(TRequest data, string endpoint, string token = "", params string[] args);
        Task<ErrorOr<TResponse>> DeleteAsync<TResponse>(string endpoint, string token = "", params string[] args);
    }
}