using ErrorOr;
using MapsterMapper;
using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.Models.Common;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Employee;
using CyberTutorial.Contracts.Responses.Employee;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;
using CyberTutorial.WebApp.Common.Interfaces.Services.AppServices;

namespace CyberTutorial.WebApp.ViewModels
{
    public class EmployeeViewModel
    {
        private readonly IMapper mapper;
        private readonly ICookieService cookieService;
        private readonly IEmployeeService employeeService;

        public EmployeeViewModel(IMapper mapper, ICookieService cookieService, IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.cookieService = cookieService;
            this.employeeService = employeeService;
        }

        public async Task<ControllerResultModel> GetEmployeeAsync()
        {
            ControllerResultModel result;
            EmployeeSessionModel employeeSession = cookieService.GetDecrypted<EmployeeSessionModel>(AppConsts.EmployeeCookieId);

            if (employeeSession == null)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Employee session is null"
                };
            }
            else
            {
                employeeService.Token = employeeSession.Token;
                ErrorOr<GetEmployeeByIdResponse> response = await employeeService.GetEmployeeByIdAsync(employeeSession.EmployeeSessionId);
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
                    EmployeeDashboardModel employeeDashboard = response.Value.Employee.EmployeeDashboard;
                    employeeDashboard.TopEmployees = new List<TopEmployeeModel>();

                    ControllerResultModel getEmployyesResult = await GetEmployeesAsync();

                    if (getEmployyesResult.IsSuccess)
                    {
                        List<EmployeeModel> employees = (List<EmployeeModel>)getEmployyesResult.Data;
                        foreach (EmployeeModel employee in employees)
                        {
                            if (employee.CompanyId.Equals(response.Value.Employee.CompanyId))
                            {
                                employeeDashboard.TopEmployees.Add(employee.TopEmployee);
                            }
                        }
                    }

                    employeeDashboard.Courses = (List<CourseModel>)response.Value.Employee.Courses;

                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = "Get Employee response success",
                        Data = response.Value.Employee
                    };
                }
            }
            return result;
        }

        public async Task<ControllerResultModel> GetEmployeesAsync()
        {
            ControllerResultModel result;

            EmployeeSessionModel employeeSession = cookieService.GetDecrypted<EmployeeSessionModel>(AppConsts.EmployeeCookieId);

            if (employeeSession == null)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Employee session is null"
                };
            }
            else
            {
                employeeService.Token = employeeSession.Token;
                ErrorOr<GetEmployeesResponse> response = await employeeService.GetEmployeesAsync();
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
                        Message = "Get Employees response success",
                        Data = response.Value.Employees
                    };
                }
            }
            return result;
        }

        public async Task<ControllerResultModel> UpdateEmployeeAsync(EmployeeModel employee)
        {
            ControllerResultModel result;
            EmployeeSessionModel employeeSession = cookieService.GetDecrypted<EmployeeSessionModel>(AppConsts.EmployeeCookieId);

            if (employeeSession == null)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Employee session is null"
                };
            }
            else
            {
                employeeService.Token = employeeSession.Token;
                UpdateEmployeeRequest request = mapper.Map<UpdateEmployeeRequest>(employee);
                ErrorOr<UpdateEmployeeResponse> response = await employeeService.UpdateEmployeeAsync(employee.EmployeeId, request);
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
                        Message = "Employee data updated successfully.",
                        Data = response.Value.Employee
                    };
                }
            }
            return result;
        }
    }
}