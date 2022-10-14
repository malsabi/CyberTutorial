using ErrorOr;
using MapsterMapper;
using CyberTutorial.WebApp.Models;
using CyberTutorial.Contracts.Enums;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Registration.Request;
using CyberTutorial.Contracts.Registration.Response;
using CyberTutorial.Contracts.Authentication.Request;
using CyberTutorial.Contracts.Authentication.Response;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using CyberTutorial.Contracts.Company.Request.Logout;
using CyberTutorial.Contracts.Company.Response.Logout;

namespace CyberTutorial.WebApp.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IMapper mapper;
        private readonly ICookieService cookieService;
        private readonly IClientApiService clientApiService;

        public IdentityService(IMapper mapper, ICookieService cookieService, IClientApiService clientApiService)
        {
            this.mapper = mapper;
            this.cookieService = cookieService;
            this.clientApiService = clientApiService;
        }

        public bool IsCompanyLoggedIn()
        {
            return cookieService.GetDecrypted<LoginResponse>(AppConsts.CompanyCookieId) != null;
        }

        public bool IsEmployeeLoggedIn()
        {
            return cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId) != null;
        }

        public async Task<object> AuthenticateAsync(LoginModel loginModel)
        {
            LoginRequest request = mapper.Map<LoginRequest>(loginModel);

            ErrorOr<LoginResponse> result = await clientApiService.PostAsync<LoginRequest, LoginResponse>(request, ApiConsts.Login);

            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }

            if (loginModel.AccountType.Equals(AccountType.Company))
            {
                cookieService.SetEncrypted(AppConsts.CompanyCookieId, result.Value);
            }
            else
            {
                cookieService.SetEncrypted(AppConsts.EmployeeCookieId, result.Value);
            }

            return new { result.IsError, AccountType = loginModel.AccountType.ToString() };
        }

        public async Task<object> LogoutCompanyAsync()
        {
            LoginResponse loginData = cookieService.GetDecrypted<LoginResponse>(AppConsts.CompanyCookieId);

            if (loginData == null)
            {
                return new { IsError = true, Errors = new List<Error> { Error.Failure("401", "UnAuthorized") } };
            }

            LogoutRequest request = mapper.Map<LogoutRequest>(loginData);
            ErrorOr<LogoutResponse> result = await clientApiService.PostAsync<LogoutRequest, LogoutResponse>(request, ApiConsts.LogoutCompany, request.Token);
            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }
            cookieService.Remove(AppConsts.CompanyCookieId);
            return new { result.IsError, result.Value.IsSuccess };
        }

        public async Task<object> LogoutEmployeeAsync()
        {
            LoginResponse loginData = cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId);

            if (loginData == null)
            {
                return new { IsError = true, Errors = new List<Error> { Error.Failure("401", "UnAuthorized") } };
            }

            LogoutRequest request = mapper.Map<LogoutRequest>(loginData);
            ErrorOr<LogoutResponse> result = await clientApiService.PostAsync<LogoutRequest, LogoutResponse>(request, ApiConsts.LogoutEmployee, request.Token);
            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }
            cookieService.Remove(AppConsts.EmployeeCookieId);
            return new { result.IsError, result.Value.IsSuccess };
        }

        public async Task<object> RegisterCompanyAsync(RegisterCompanyModel registerCompanyModel)
        {
            RegisterCompanyRequest request = mapper.Map<RegisterCompanyRequest>(registerCompanyModel);
            ErrorOr<RegisterResponse> result = await clientApiService.PostAsync<RegisterCompanyRequest, RegisterResponse>(request, ApiConsts.RegisterCompany);

            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }
            return new { result.IsError, result.Value };
        }

        public async Task<object> RegisterEmployeeAsync(RegisterEmployeeModel registerEmployeeModel)
        {
            RegisterEmployeeRequest request = mapper.Map<RegisterEmployeeRequest>(registerEmployeeModel);
            request.Id = Guid.NewGuid().ToString();
            ErrorOr<RegisterResponse> result = await clientApiService.PostAsync<RegisterEmployeeRequest, RegisterResponse>(request, ApiConsts.RegisterEmployee);

            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }
            return new { result.IsError, result.Value };
        }
    }
}