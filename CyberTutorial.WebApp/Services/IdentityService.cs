using ErrorOr;
using MapsterMapper;
using CyberTutorial.Contracts.Enums;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Models.Common;
using CyberTutorial.WebApp.Models.Company.Register;
using CyberTutorial.WebApp.Models.Employee.Register;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using CyberTutorial.Contracts.Authentication.Request.Login;
using CyberTutorial.Contracts.Authentication.Response.Login;
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