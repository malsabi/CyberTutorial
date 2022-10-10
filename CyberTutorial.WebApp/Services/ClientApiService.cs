using ErrorOr;
using System.Text.Json;
using System.Net.Http.Headers;
using CyberTutorial.Contracts.Errors;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Services
{
    public class ClientApiService : IClientApiService
    {
        private readonly IApiConfigService apiConfigService;

        public ClientApiService(IApiConfigService apiConfigService)
        {
            this.apiConfigService = apiConfigService;
        }
       
        public async Task<ErrorOr<TResponse>> GetAsync<TResponse>(string endpoint, string token = "")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConsts.Scheme, token);
                    }
                    client.BaseAddress = new Uri(apiConfigService.GetApiEndPoint());

                    HttpResponseMessage response = client.GetAsync(endpoint).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<TResponse>();
                    }
                    else
                    {
                        ProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                        return GetErrors(problemDetails);
                    }
                }
            }
            catch
            {
                return default;
            }
        }

        public async Task<ErrorOr<TResponse>> PostAsync<TRequest, TResponse>(TRequest data, string endpoint, string token = "")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ApiConsts.Scheme, token);
                    }
                    client.BaseAddress = new Uri(apiConfigService.GetApiEndPoint());

                    HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, data);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<TResponse>();
                    }
                    else
                    {
                        ProblemDetails problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                        return GetErrors(problemDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                return Error.Failure();
            }
        }

        private List<Error> GetErrors(ProblemDetails problemDetails)
        {
            List<ErrorWrapper> errorWrappers = ((JsonElement)problemDetails.Extensions["errors"]).Deserialize<List<ErrorWrapper>>();
            return ErrorWrapper.Convert(errorWrappers);
        }
    }
}