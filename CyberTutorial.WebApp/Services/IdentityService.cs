using ErrorOr;
using MapsterMapper;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using CyberTutorial.Contracts.Enums;
using CyberTutorial.Contracts.Company.Request.Session;
using CyberTutorial.Contracts.Company.Response.Session;
using CyberTutorial.Contracts.Employee.Response.Session;
using CyberTutorial.Contracts.Employee.Request.Session;
using CyberTutorial.Contracts.Common.Request.Logout;
using CyberTutorial.Contracts.Common.Response.Logout;
using CyberTutorial.WebApp.Models.Common;
using CyberTutorial.WebApp.Models.Employee.Register;
using CyberTutorial.WebApp.Models.Company.Register;
using CyberTutorial.Contracts.Authentication.Response.Login;
using CyberTutorial.Contracts.Authentication.Request.Login;
using CyberTutorial.Contracts.Authentication.Request.Registration;
using CyberTutorial.Contracts.Authentication.Response.Registration;

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

        public async Task<bool> IsCompanyLoggedIn()
        {
            LoginResponse loginResponse = cookieService.GetDecrypted<LoginResponse>(AppConsts.CompanyCookieId);
            
            if (loginResponse == null)
            {
                return false;
            }

            IsCompanySessionValidRequest request = new IsCompanySessionValidRequest()
            {
                SessionId = loginResponse.SessionId,
                Token = loginResponse.Token
            };

            ErrorOr<IsCompanySessionValidResponse> result = await clientApiService.PostAsync<IsCompanySessionValidRequest, IsCompanySessionValidResponse>(request, ApiConsts.IsSessionValidCompany, request.Token);

            if (result.IsError || !result.Value.IsValid)
            {
                cookieService.Remove(AppConsts.CompanyCookieId);
                return false;
            }
            if (!string.IsNullOrEmpty(result.Value.NewToken))
            {
                loginResponse.Token = result.Value.NewToken;
                cookieService.SetEncrypted(AppConsts.CompanyCookieId, loginResponse);
            }
            return true;
        }

        public async Task<bool> IsEmployeeLoggedIn()
        {
            LoginResponse loginResponse = cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId);

            if (loginResponse == null)
            {
                return false;
            }

            IsEmployeeSessionValidRequest request = new IsEmployeeSessionValidRequest()
            {
                SessionId = loginResponse.SessionId,
                Token = loginResponse.Token
            };

            ErrorOr<IsEmployeeSessionValidResponse> result = await clientApiService.PostAsync<IsEmployeeSessionValidRequest, IsEmployeeSessionValidResponse>(request, ApiConsts.IsSessionValidEmployee, request.Token);
            
            if (result.IsError || !result.Value.IsValid)
            {
                cookieService.Remove(AppConsts.EmployeeCookieId);
                return false;
            }
            if (!string.IsNullOrEmpty(result.Value.NewToken))
            {
                loginResponse.Token = result.Value.NewToken;
                cookieService.SetEncrypted(AppConsts.EmployeeCookieId, loginResponse);
            }
            return true;
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
            request.EmployeeId = Guid.NewGuid().ToString();
            ErrorOr<RegisterResponse> result = await clientApiService.PostAsync<RegisterEmployeeRequest, RegisterResponse>(request, ApiConsts.RegisterEmployee);

            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }
            return new { result.IsError, result.Value };
        }
    }
}