using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Authentication;
using CyberTutorial.Contracts.Responses.Authentication;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClientApiService clientApiService;

        public AuthenticationService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<RegisterCompanyResponse>> RegisterCompanyAsync(RegisterCompanyRequest request)
        {
            return await clientApiService.PostAsync<RegisterCompanyRequest,RegisterCompanyResponse>(request, ApiConsts.Authentication.RegisterCompany);
        }

        public async Task<ErrorOr<RegisterEmployeeResponse>> RegisterEmployeeAsync(RegisterEmployeeRequest request)
        {
            return await clientApiService.PostAsync<RegisterEmployeeRequest, RegisterEmployeeResponse>(request, ApiConsts.Authentication.RegisterEmployee);
        }
        
        public async Task<ErrorOr<LoginCompanyResponse>> LoginCompanyAsync(LoginCompanyRequest request)
        {
            return await clientApiService.PostAsync<LoginCompanyRequest, LoginCompanyResponse>(request, ApiConsts.Authentication.LoginCompany);
        }

        public async Task<ErrorOr<LoginEmployeeResponse>> LoginEmployeeAsync(LoginEmployeeRequest request)
        {
            return await clientApiService.PostAsync<LoginEmployeeRequest, LoginEmployeeResponse>(request, ApiConsts.Authentication.LoginEmployee);
        }

        public async Task<ErrorOr<LogoutCompanyResponse>> LogoutCompanyAsync(LogoutCompanyRequest request)
        {
            return await clientApiService.PostAsync<LogoutCompanyRequest, LogoutCompanyResponse>(request, ApiConsts.Authentication.LogoutCompany);
        }

        public async Task<ErrorOr<LogoutEmployeeResponse>> LogoutEmployeeAsync(LogoutEmployeeRequest request)
        {
            return await clientApiService.PostAsync<LogoutEmployeeRequest, LogoutEmployeeResponse>(request, ApiConsts.Authentication.LogoutEmployee);
        }
    }
}