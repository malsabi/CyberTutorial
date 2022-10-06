namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface IClientApiService
    {
        IApiConfigService ApiConfigService { get; }
        Task<TResponse> GetAsync<TResponse>(string endpoint, string token = "");
        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest data, string endpoint, string token = "");
    }
}