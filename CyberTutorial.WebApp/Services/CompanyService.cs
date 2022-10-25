using ErrorOr;
using MapsterMapper;
using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Common.Request.Logout;
using CyberTutorial.Contracts.Common.Response.Logout;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using CyberTutorial.Contracts.Company.Response.Session;
using CyberTutorial.Contracts.Authentication.Response.Login;

namespace CyberTutorial.WebApp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper mapper;
        private readonly ICookieService cookieService;
        private readonly IClientApiService clientApiService;

        public CompanyService(IMapper mapper, ICookieService cookieService, IClientApiService clientApiService)
        {
            this.mapper = mapper;
            this.cookieService = cookieService;
            this.clientApiService = clientApiService;
        }

        public async Task<CompanyModel> GetCompanyProfileAsync()
        {
            CompanyModel companyProfile = new CompanyModel();
            if (await IsCompanyLoggedInAsync())
            {
            }
            return companyProfile;
        }

        public async Task<bool> IsCompanyLoggedInAsync()
        {
            LoginResponse loginResponse = cookieService.GetDecrypted<LoginResponse>(AppConsts.CompanyCookieId);

            if (loginResponse == null)
            {
                return false;
            }

            //IsCompanySessionValidRequest request = new IsCompanySessionValidRequest()
            //{
            //    SessionId = loginResponse.SessionId,
            //    Token = loginResponse.Token
            //};

            //ErrorOr<IsCompanySessionValidResponse> result = await clientApiService.PostAsync<IsCompanySessionValidRequest, IsCompanySessionValidResponse>(request, ApiConsts.IsSessionValidCompany, request.Token);

            //if (result.IsError || !result.Value.IsValid)
            //{
            //    cookieService.Remove(AppConsts.CompanyCookieId);
            //    return false;
            //}
            return true;
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
    }
}