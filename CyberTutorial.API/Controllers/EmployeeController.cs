using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Contracts.Company.Request.Logout;
using CyberTutorial.Application.Companies.Commands.Logout;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
            ErrorOr<LogoutResult> result = await sender.Send(command);
            return result.Match(
                success => Ok(success),
                error => Problem(error)
            );
        }
    }
}