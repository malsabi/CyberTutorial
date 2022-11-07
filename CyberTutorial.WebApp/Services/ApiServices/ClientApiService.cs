using ErrorOr;
using System.Text.Json;
using System.Net.Http.Headers;
using CyberTutorial.Contracts.Errors;
using CyberTutorial.WebApp.Common.Consts;
using Microsoft.AspNetCore.Mvc;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class ClientApiService : IClientApiService
    {
        private readonly IApiConfigService apiConfigService;

        public ClientApiService(IApiConfigService apiConfigService)
        {
            this.apiConfigService = apiConfigService;
        }

        public async Task<ErrorOr<TResponse>> GetAsync<TResponse>(string endpoint, string token = "", params string[] args)
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

                    HttpResponseMessage response = await client.GetAsync(string.Format(endpoint, args));
                    if (response.IsSuccessStatusCode)
                    {
                        if (typeof(TResponse) == typeof(string))
                        {
                            return (TResponse)Convert.ChangeType(await response.Content.ReadAsStringAsync(), typeof(TResponse));
                        }
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

        public async Task<ErrorOr<TResponse>> PostAsync<TResponse>(string endpoint, string token = "", params string[] args)
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

                    HttpResponseMessage response = await client.PostAsync(string.Format(endpoint, args), null);

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

        public async Task<ErrorOr<TResponse>> PutAsync<TRequest, TResponse>(TRequest data, string endpoint, string token = "", params string[] args)
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

                    HttpResponseMessage response = await client.PutAsJsonAsync(string.Format(endpoint, args), data);
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

        public async Task<ErrorOr<TResponse>> DeleteAsync<TResponse>(string endpoint, string token = "", params string[] args)
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

                    HttpResponseMessage response = await client.DeleteAsync(string.Format(endpoint, args));
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