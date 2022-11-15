using ErrorOr;
using MapsterMapper;
using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Authentication;
using CyberTutorial.Contracts.Responses.Authentication;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;
using CyberTutorial.WebApp.Common.Interfaces.Services.AppServices;
using CyberTutorial.WebApp.Models;

namespace CyberTutorial.WebApp.ViewModels
{
    public class AuthenticationViewModel
    {
        private readonly IMapper mapper;
        private readonly ICookieService cookieService;
        private readonly IAuthenticationService authenticationService;

        public AuthenticationViewModel(IMapper mapper, ICookieService cookieService, IAuthenticationService authenticationService)
        {
            this.mapper = mapper;
            this.cookieService = cookieService;
            this.authenticationService = authenticationService;
        }

        public async Task<ControllerResultModel> RegisterCompanyAsync(RegisterCompanyModel registerCompanyModel)
        {
            ControllerResultModel result;
            RegisterCompanyRequest request = mapper.Map<RegisterCompanyRequest>(registerCompanyModel);
            ErrorOr<RegisterCompanyResponse> response = await authenticationService.RegisterCompanyAsync(request);
            if (response.IsError)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = response.FirstError.Description,
                    Data = response
                };
            }
            else
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = true,
                    Message = "Company registration success.",
                    Data = response
                };
            }
            return result;
        }

        public async Task<ControllerResultModel> RegisterEmployeeAsync(RegisterEmployeeModel registerEmployeeModel)
        {
            ControllerResultModel result;
            RegisterEmployeeRequest request = mapper.Map<RegisterEmployeeRequest>(registerEmployeeModel);
            ErrorOr<RegisterEmployeeResponse> response = await authenticationService.RegisterEmployeeAsync(request);
            if (response.IsError)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = response.FirstError.Description,
                    Data = response
                };
            }
            else
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = true,
                    Message = "Employee registration success.",
                    Data = response
                };
            }
            return result;
        }

        public async Task<ControllerResultModel> LoginCompanyAsync(string emailAddress, string password)
        {
            ControllerResultModel result;
            LoginCompanyRequest request = new LoginCompanyRequest()
            {
                EmailAddress = emailAddress,
                Password = password
            };
            ErrorOr<LoginCompanyResponse> response = await authenticationService.LoginCompanyAsync(request);
            if (response.IsError)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = response.FirstError.Description,
                    Data = response
                };
            }
            else
            {
                cookieService.SetEncrypted(AppConsts.CompanyCookieId, response.Value.Session);
                result = new ControllerResultModel()
                {
                    IsSuccess = true,
                    Message = "Company login success.",
                    Data = response,
                    Metadata = new List<string>()
                    {
                        "CompanyAccess"
                    }
                };
            }
            return result;
        }

        public async Task<ControllerResultModel> LoginEmployeeAsync(string emailAddress, string password)
        {
            ControllerResultModel result;
            LoginEmployeeRequest request = new LoginEmployeeRequest()
            {
                EmailAddress = emailAddress,
                Password = password
            };
            ErrorOr<LoginEmployeeResponse> response = await authenticationService.LoginEmployeeAsync(request);
            if (response.IsError)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = response.FirstError.Description,
                    Data = response
                };
            }
            else
            {
                cookieService.SetEncrypted(AppConsts.EmployeeCookieId, response.Value.Session);
                result = new ControllerResultModel()
                {
                    IsSuccess = true,
                    Message = "Employee login success.",
                    Data = response,
                    Metadata = new List<string>()
                    {
                        "EmployeeAccess"
                    }
                };
            }
            return result;
        }

        public async Task<ControllerResultModel> LogoutCompanyAsync()
        {
            ControllerResultModel result;
            CompanySessionModel session = cookieService.GetDecrypted<CompanySessionModel>(AppConsts.CompanyCookieId);
            if (session == null)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Company session not found.",
                    Data = null
                };
            }
            else
            {
                session.ExpiryDate = "";
                session.Token = "";
                session.IsActive = false;

                LogoutCompanyRequest request = mapper.Map<LogoutCompanyRequest>(session);
                ErrorOr<LogoutCompanyResponse> response = await authenticationService.LogoutCompanyAsync(request);
                if (response.IsError)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = false,
                        Message = response.FirstError.Description,
                        Data = response
                    };
                }
                else
                {
                    cookieService.Remove(AppConsts.CompanyCookieId);
                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = "Company logout success.",
                        Data = response
                    };
                }
            }
            return result;
        }

        public async Task<ControllerResultModel> LogoutEmployeeAsync()
        {
            ControllerResultModel result;
            EmployeeSessionModel session = cookieService.GetDecrypted<EmployeeSessionModel>(AppConsts.EmployeeCookieId);
            if (session == null)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Employee session not found.",
                    Data = null
                };
            }
            else
            {
                session.ExpiryDate = "";
                session.Token = "";
                session.IsActive = false;
                
                LogoutEmployeeRequest request = mapper.Map<LogoutEmployeeRequest>(session);
                ErrorOr<LogoutEmployeeResponse> response = await authenticationService.LogoutEmployeeAsync(request);
                if (response.IsError)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = false,
                        Message = response.FirstError.Description,
                        Data = response
                    };
                }
                else
                {
                    cookieService.Remove(AppConsts.EmployeeCookieId);
                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = "Employee logout success.",
                        Data = response
                    };
                }
            }
            return result;
        }
    }
}