using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Application.Employies.Common;
using CyberTutorial.Application.Employies.Commands.Logout;
using CyberTutorial.Contracts.Common.Request.Logout;
using CyberTutorial.Contracts.Common.Response.Logout;
using CyberTutorial.Contracts.Employee.Request.Session;
using CyberTutorial.Contracts.Employee.Response.Session;
using CyberTutorial.Application.Employies.Queries.Session;

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

        [HttpPost("IsSessionValid")]
        public async Task<IActionResult> IsSessionValid(IsEmployeeSessionValidRequest request)
        {
            EmployeeSessionValidationQuery command = mapper.Map<EmployeeSessionValidationQuery>(request);
            ErrorOr<EmployeeSessionValidationResult> result = await sender.Send(command);

            return result.Match(
                success => Ok(mapper.Map<IsEmployeeSessionValidResponse>(success)),
                error => Problem(error)
            );
        }
    }
}