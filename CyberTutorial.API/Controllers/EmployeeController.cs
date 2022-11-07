using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Requests.Employee;
using CyberTutorial.Contracts.Responses.Employee;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Application.Employees.Commands.AddEmployee;
using CyberTutorial.Application.Employees.Commands.UpdateEmployee;
using CyberTutorial.Application.Employees.Commands.UpdateEmployeeSession;
using CyberTutorial.Application.Employees.Commands.UpdateEmployeeDashboard;
using CyberTutorial.Application.Employees.Queries.GetEmployees;
using CyberTutorial.Application.Employees.Queries.GetEmployeById;
using CyberTutorial.Application.Employees.Queries.GetEmployeeSession;
using CyberTutorial.Application.Employees.Queries.GetEmployeeCompany;
using CyberTutorial.Application.Employees.Queries.GetEmployeeDashboard;
using CyberTutorial.Application.Employees.Commands.DeleteEmployee;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Employee")]
    [AllowAnonymous]
    public class EmployeeController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public EmployeeController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest request)
        {
            AddEmployeeCommand command = mapper.Map<AddEmployeeCommand>(request);
            ErrorOr<AddEmployeeResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<AddEmployeeResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllEmployees()
        {
            GetEmployeesResult result = await sender.Send(new GetEmployeesQuery());
            return Ok(mapper.Map<GetEmployeesResponse>(result));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetEmployeeById(string employeeId)
        {
            GetEmployeeByIdQuery query = new GetEmployeeByIdQuery()
            {
                EmployeeId = employeeId
            };
            ErrorOr<GetEmployeeByIdResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetEmployeeByIdResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetCompany")]
        public async Task<IActionResult> GetEmployeeCompany(string employeeId)
        {
            GetEmployeeCompanyQuery query = new GetEmployeeCompanyQuery()
            {
                EmployeeId = employeeId
            };
            ErrorOr<GetEmployeeCompanyResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetEmployeeCompanyResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetSession")]
        public async Task<IActionResult> GetEmployeeSession(string employeeId)
        {
            GetEmployeeSessionQuery query = new GetEmployeeSessionQuery()
            {
                EmployeeId = employeeId
            };
            ErrorOr<GetEmployeeSessionResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetEmployeeSessionResponse>(success)),
                error => Problem(error)
            );
        }

     
        [HttpGet("GetDashboard")]
        public async Task<IActionResult> GetEmployeeDashboardById(string employeeId)
        {
            GetEmployeeDashboardQuery query = new GetEmployeeDashboardQuery()
            {
                EmployeeId = employeeId
            };
            ErrorOr<GetEmployeeDashboardResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetEmployeeDashboardResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee(string employeeId, UpdateEmployeeRequest request)
        {
            UpdateEmployeeCommand command = mapper.Map<UpdateEmployeeCommand>(request);
            command.TargetId = employeeId;
            ErrorOr<UpdateEmployeeResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateEmployeeResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPut("UpdateDashboard")]
        public async Task<IActionResult> UpdateEmployeeDashboard(string employeeId, UpdateEmployeeDashboardRequest request)
        {
            UpdateEmployeeDashboardCommand command = mapper.Map<UpdateEmployeeDashboardCommand>(request);
            command.TargetId = employeeId;
            ErrorOr<UpdateEmployeeDashboardResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateEmployeeDashboardResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPut("UpdateSession")]
        public async Task<IActionResult> UpdateEmployeeSession(string employeeId, UpdateEmployeeSessionRequest request)
        {
            UpdateEmployeeSessionCommand command = mapper.Map<UpdateEmployeeSessionCommand>(request);
            command.TargetId = employeeId;
            ErrorOr<UpdateEmployeeSessionResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateEmployeeSessionResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployee(string employeeId)
        {
            DeleteEmployeeCommand command = new DeleteEmployeeCommand()
            {
                EmployeeId = employeeId
            };
            ErrorOr<DeleteEmployeeResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<DeleteEmployeeResponse>(success)),
                error => Problem(error)
            );
        }
    }
}