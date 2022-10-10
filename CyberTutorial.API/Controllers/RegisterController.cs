using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Contracts.Registration.Request;
using CyberTutorial.Application.Registration.Common;
using CyberTutorial.Application.Registration.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class RegisterController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public RegisterController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Company")]
        public async Task<IActionResult> Register(RegisterCompanyRequest request)
        {
            RegisterCompanyCommand command = mapper.Map<RegisterCompanyCommand>(request);
            ErrorOr<RegisterResult> result = await sender.Send(command);

            return result.Match
            (
                (registerResult) => Ok(registerResult),
                (errors) => Problem(errors)
            );
        }

        [HttpPost("Employee")]
        public async Task<IActionResult> Register(RegisterEmployeeRequest request)
        {
            RegisterEmployeeCommand command = mapper.Map<RegisterEmployeeCommand>(request);
            ErrorOr<RegisterResult> result = await sender.Send(command);

            return result.Match
            (
                (registerResult) => Ok(registerResult),
                (errors) => Problem(errors)
            );
        }
    }
}