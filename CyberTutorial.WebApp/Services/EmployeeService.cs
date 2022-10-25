using ErrorOr;
using MapsterMapper;
using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Common.Request.Logout;
using CyberTutorial.Contracts.Common.Response.Logout;
using CyberTutorial.WebApp.Models.Employee.Dashboard;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using CyberTutorial.Contracts.Employee.Response.Session;
using CyberTutorial.Contracts.Employee.Response.Dashboard;
using CyberTutorial.Contracts.Authentication.Response.Login;

namespace CyberTutorial.WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly ICookieService cookieService;
        private readonly IClientApiService clientApiService;

        public EmployeeService(IMapper mapper, ICookieService cookieService, IClientApiService clientApiService)
        {
            this.mapper = mapper;
            this.cookieService = cookieService;
            this.clientApiService = clientApiService;
        }

        public async Task<EmployeeModel> GetEmployeeAsync()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            if (!await IsEmployeeLoggedInAsync())
            {
                LoginResponse loginResponse = cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId);
                ErrorOr<EmployeeModel> result = await clientApiService.GetAsync<EmployeeModel>
                (
                    ApiConsts.GetEmployeeBySessionId, 
                    loginResponse.Token, 
                    loginResponse.SessionId
                );
                if (!result.IsError)
                {
                    employeeModel = mapper.Map<EmployeeModel>(result.Value);
                }
            }
            return employeeModel;
        }

        public async Task<EmployeeDashboardModel> GetEmployeeDashboardAsync()
        {
            EmployeeDashboardModel employeeDashboard = new EmployeeDashboardModel();
            if (!await IsEmployeeLoggedInAsync())
            {
                LoginResponse loginResponse = cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId);
                EmployeeModel employee = await GetEmployeeAsync();
                ErrorOr<GetEmployeeDashboardResponse> result = await clientApiService.GetAsync<GetEmployeeDashboardResponse>
                (
                    ApiConsts.GetEmployeeDashboard,
                    loginResponse.Token,
                    employee.EmployeeId
                );
                if (!result.IsError)
                {
                    employeeDashboard.FillStatisticsValues(result.Value);
                    employeeDashboard.FillChartsValues(result.Value);
                    employeeDashboard.FillTablesValues(result.Value);
                }
            }
            return employeeDashboard;
        }

        public async Task<object> UpdateEmployeeAsync(string employeeId, EmployeeModel employeeModel)
        {
            if (employeeModel == null)
            {
                return new { IsError = true, Errors = new List<Error> { Error.Failure() } };
            }
            if (employeeId != employeeModel.EmployeeId)
            {
                return new { IsError = true, Errors = new List<Error> { Error.Conflict() } };
            }
            if (!await IsEmployeeLoggedInAsync())
            {
                return new { IsError = true, Errors = new List<Error> { Error.Failure("401", "UnAuthorized") } };
            }
            LoginResponse loginResponse = cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId);
            ErrorOr<EmployeeModel> result = await clientApiService.PutAsync<EmployeeModel, EmployeeModel>
            (
                employeeModel, 
                ApiConsts.UpdateEmployee, 
                loginResponse.Token, 
                employeeId
            );
            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }
            return new { result.IsError, result.Value };
        }

        public async Task<bool> IsEmployeeLoggedInAsync()
        {
            LoginResponse loginResponse = cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId);
            if (loginResponse == null)
            {
                return false;
            }
            ErrorOr<IsEmployeeSessionValidResponse> result = await clientApiService.GetAsync<IsEmployeeSessionValidResponse>
            (
                ApiConsts.IsSessionValidEmployee,
                loginResponse.Token, 
                loginResponse.SessionId,
                loginResponse.Token
            );
            if (result.IsError || !result.Value.IsValid)
            {
                cookieService.Remove(AppConsts.EmployeeCookieId);
                return false;
            }
            return true;
        }

        public async Task<object> LogoutEmployeeAsync()
        {
            LoginResponse loginData = cookieService.GetDecrypted<LoginResponse>(AppConsts.EmployeeCookieId);
            if (loginData == null)
            {
                return new { IsError = true, Errors = new List<Error> { Error.Failure("401", "UnAuthorized") } };
            }
            LogoutRequest request = mapper.Map<LogoutRequest>(loginData);
            ErrorOr<LogoutResponse> result = await clientApiService.PostAsync<LogoutRequest, LogoutResponse>
            (
                request, 
                ApiConsts.LogoutEmployee,
                request.Token
            );
            if (result.IsError)
            {
                return new { result.IsError, result.Errors };
            }
            cookieService.Remove(AppConsts.EmployeeCookieId);
            return new { result.IsError, result.Value.IsSuccess };
        }
    }
}