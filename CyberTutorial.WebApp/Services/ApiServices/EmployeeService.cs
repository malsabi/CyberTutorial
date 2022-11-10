using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Employee;
using CyberTutorial.Contracts.Responses.Employee;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IClientApiService clientApiService;

        public string Token { get; set; }

        public EmployeeService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<AddEmployeeResponse>> AddEmployeeAsync(AddEmployeeRequest request)
        {
            return await clientApiService.PostAsync<AddEmployeeRequest, AddEmployeeResponse>(request, ApiConsts.Employee.Add, Token);
        }

        public async Task<ErrorOr<GetEmployeesResponse>> GetEmployeesAsync()
        {
            return await clientApiService.GetAsync<GetEmployeesResponse>(ApiConsts.Employee.GetAll, Token);
        }

        public async Task<ErrorOr<GetEmployeeByIdResponse>> GetEmployeeByIdAsync(string employeeId)
        {
            return await clientApiService.GetAsync<GetEmployeeByIdResponse>(ApiConsts.Employee.Get, Token, employeeId);
        }

        public async Task<ErrorOr<GetEmployeeCompanyResponse>> GetEmployeeCompanyAsync(string employeeId)
        {
            return await clientApiService.GetAsync<GetEmployeeCompanyResponse>(ApiConsts.Employee.GetCompany, Token, employeeId);
        }

        public async Task<ErrorOr<GetEmployeeSessionResponse>> GetEmployeeSessionAsync(string employeeId)
        {
            return await clientApiService.GetAsync<GetEmployeeSessionResponse>(ApiConsts.Employee.GetSession, Token, employeeId);
        }

        public async Task<ErrorOr<GetEmployeeDashboardResponse>> GetEmployeeDashboardAsync(string employeeId)
        {
            return await clientApiService.GetAsync<GetEmployeeDashboardResponse>(ApiConsts.Employee.GetDashboard, Token, employeeId);
        }

        public async Task<ErrorOr<UpdateEmployeeResponse>> UpdateEmployeeAsync(string employeeId, UpdateEmployeeRequest request)
        {
            return await clientApiService.PutAsync<UpdateEmployeeRequest, UpdateEmployeeResponse>(request, ApiConsts.Employee.Update, Token, employeeId);
        }

        public async Task<ErrorOr<UpdateEmployeeSessionResponse>> UpdateEmployeeSessionAsync(string employeeId, UpdateEmployeeSessionRequest request)
        {
            return await clientApiService.PutAsync<UpdateEmployeeSessionRequest, UpdateEmployeeSessionResponse>(request, ApiConsts.Employee.UpdateSession, Token, employeeId);
        }

        public async Task<ErrorOr<UpdateEmployeeDashboardResponse>> UpdateEmployeeDashboardAsync(string employeeId, UpdateEmployeeDashboardRequest request)
        {
            return await clientApiService.PutAsync<UpdateEmployeeDashboardRequest, UpdateEmployeeDashboardResponse>(request, ApiConsts.Employee.UpdateDashboard, Token, employeeId);
        }

        public async Task<ErrorOr<DeleteEmployeeResponse>> DeleteEmployeeAsync(string employeeId)
        {
            return await clientApiService.DeleteAsync<DeleteEmployeeResponse>(ApiConsts.Employee.Delete, Token, employeeId);
        }
    }
}