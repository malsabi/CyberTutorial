using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Domain.Entities;
using CyberTutorial.Contracts.Models;
using CyberTutorial.Application.Employees.Common;
using CyberTutorial.Contracts.Common.Request.Logout;
using CyberTutorial.Contracts.Common.Response.Logout;
using CyberTutorial.Contracts.Employee.Response.Session;
using CyberTutorial.Application.Employees.Commands.Logout;
using CyberTutorial.Contracts.Employee.Response.Dashboard;
using CyberTutorial.Application.Employees.Queries.Session;
using CyberTutorial.Application.Employees.Queries.Dashboard;
using CyberTutorial.Application.Employees.Queries.GetEmployees;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public EmployeeController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            EmployeesQuery query = new EmployeesQuery();
            ErrorOr<EmployeesResult> result = await sender.Send(query);
            return result.Match(
                success => Ok(mapper.Map<GetEmployeeDashboardResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee(string employeeId)
        {
            return Ok("GET GetEmployee: " + employeeId);
        }

        [HttpPost("GetEmployeeBySessionId")]
        public async Task<IActionResult> GetEmployeeBySessionId(string sessionId)
        {
            return Ok("GET GetEmployeeBySessionId: " + sessionId);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(string employeeId, EmployeeModel employeeModel)
        {
            return Ok("PUT PutEmployee: " + employeeId);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(string employeeId)
        {
            return Ok("DELETE DeleteEmployee: " + employeeId);
        }

        [HttpGet("GetDashboard")]
        public async Task<IActionResult> GetDashboard(string employeeId)
        {
            EmployeeDashboardQuery command = new EmployeeDashboardQuery() { EmployeeId = employeeId };
            ErrorOr<EmployeeDashboardResult> result = await sender.Send(command);

            //Check if the map works on the collections (lists) inside the GetEmployeeDashboardResponse
            return result.Match(
                success => Ok(mapper.Map<GetEmployeeDashboardResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("IsSessionValid")]
        public async Task<IActionResult> IsSessionValid(string sessionId, string token)
        {
            EmployeeSessionValidationQuery command = new EmployeeSessionValidationQuery()
            {
                SessionId = sessionId,
                Token = token
            };
            ErrorOr<EmployeeSessionValidationResult> result = await sender.Send(command);

            return result.Match(
                success => Ok(mapper.Map<IsEmployeeSessionValidResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutRequest request)
        {
            LogoutEmployeeCommand command = mapper.Map<LogoutEmployeeCommand>(request);
            ErrorOr<LogoutEmployeeResult> result = await sender.Send(command);
            return result.Match(
                success => Ok(mapper.Map<LogoutResponse>(success)),
                error => Problem(error)
            );
        }
    }
}