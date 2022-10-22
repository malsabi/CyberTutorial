using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Contracts.Enums;
using CyberTutorial.Application.Authentication.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Application.Authentication.Queries.Login;
using CyberTutorial.Application.Authentication.Commands;
using CyberTutorial.Contracts.Authentication.Response.Login;
using CyberTutorial.Contracts.Authentication.Request.Login;
using CyberTutorial.Contracts.Authentication.Request.Registration;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public AuthenticationController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request.AccountType.Equals(AccountType.Company))
            {
                LoginCompanyQuery loginCompanyQuery = mapper.Map<LoginCompanyQuery>(request);
                ErrorOr<LoginResult> result = await sender.Send(loginCompanyQuery);

                return result.Match
                (
                   (authenticationResult) => Ok(mapper.Map<LoginResponse>(authenticationResult)),
                   (errors) => Problem(errors)
                );
            }
            else
            {
                LoginEmployeeQuery loginEmployeeQuery = mapper.Map<LoginEmployeeQuery>(request);
                ErrorOr<LoginResult> result = await sender.Send(loginEmployeeQuery);

                return result.Match
                (
                   (authenticationResult) => Ok(mapper.Map<LoginResponse>(authenticationResult)),
                   (errors) => Problem(errors)
                );
            }
        }

        [HttpPost("Register/Company")]
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

        [HttpPost("Register/Employee")]
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