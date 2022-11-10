using ErrorOr;
using CyberTutorial.Contracts.Requests.Employee;
using CyberTutorial.Contracts.Responses.Employee;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IEmployeeService
    {
        public string Token { get; set; }

        public Task<ErrorOr<AddEmployeeResponse>> AddEmployeeAsync(AddEmployeeRequest request);
        public Task<ErrorOr<GetEmployeesResponse>> GetEmployeesAsync();
        public Task<ErrorOr<GetEmployeeByIdResponse>> GetEmployeeByIdAsync(string employeeId);
        public Task<ErrorOr<GetEmployeeCompanyResponse>> GetEmployeeCompanyAsync(string employeeId);
        public Task<ErrorOr<GetEmployeeSessionResponse>> GetEmployeeSessionAsync(string employeeId);
        public Task<ErrorOr<GetEmployeeDashboardResponse>> GetEmployeeDashboardAsync(string employeeId);
        public Task<ErrorOr<UpdateEmployeeResponse>> UpdateEmployeeAsync(string employeeId, UpdateEmployeeRequest request);
        public Task<ErrorOr<UpdateEmployeeSessionResponse>> UpdateEmployeeSessionAsync(string employeeId, UpdateEmployeeSessionRequest request);
        public Task<ErrorOr<UpdateEmployeeDashboardResponse>> UpdateEmployeeDashboardAsync(string employeeId, UpdateEmployeeDashboardRequest request);
        public Task<ErrorOr<DeleteEmployeeResponse>> DeleteEmployeeAsync(string employeeId);
    }
}