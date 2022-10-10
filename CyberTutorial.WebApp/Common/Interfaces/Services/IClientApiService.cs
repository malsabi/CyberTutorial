using ErrorOr;

namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface IClientApiService
    {
        Task<ErrorOr<TResponse>> GetAsync<TResponse>(string endpoint, string token = "");
        Task<ErrorOr<TResponse>> PostAsync<TRequest, TResponse>(TRequest data, string endpoint, string token = "");
    }
}