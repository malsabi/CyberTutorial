using System.Net.Http.Headers;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services;

namespace CyberTutorial.WebApp.Services
{
    public class ClientApiService : IClientApiService
    {
        public IApiConfigService ApiConfigService { get; }
        
        public ClientApiService(IApiConfigService apiConfigService)
        {
            ApiConfigService = apiConfigService;
        }
       
        public Task<TResponse> GetAsync<TResponse>(string endpoint, string token = "")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConsts.Scheme, token);
                    }
                    
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(ApiConfigService.GetApiEndPoint());

                    HttpResponseMessage response = client.GetAsync(endpoint).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadFromJsonAsync<TResponse>();
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch
            {
                return default;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest data, string endpoint, string token = "")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConsts.Scheme, token);
                    }

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(ApiConfigService.GetApiEndPoint());

                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(endpoint, data);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return await responseMessage.Content.ReadFromJsonAsync<TResponse>();
                    }
                    else
                    {
                        return default;
                    }
                }
            }
            catch
            {
                return default;
            }
        }
    }
}