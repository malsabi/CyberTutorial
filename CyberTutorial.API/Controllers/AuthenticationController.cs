using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Contracts.Requests.Authentication;
using CyberTutorial.Contracts.Responses.Authentication;
using CyberTutorial.Application.Authentication.Commands.LoginCompany;
using CyberTutorial.Application.Authentication.Commands.LoginEmployee;
using CyberTutorial.Application.Authentication.Commands.LogoutCompany;
using CyberTutorial.Application.Authentication.Commands.LogoutEmployee;
using CyberTutorial.Application.Authentication.Commands.RegisterCompany;
using CyberTutorial.Application.Authentication.Commands.RegisterEmployee;

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

        [HttpPost("Login/Company")]
        public async Task<IActionResult> Login(LoginCompanyRequest request)
        {
            LoginCompanyCommand loginCompanyQuery = mapper.Map<LoginCompanyCommand>(request);
            ErrorOr<LoginCompanyResult> result = await sender.Send(loginCompanyQuery);
            return result.Match
            (
               success => Ok(mapper.Map<LoginCompanyResponse>(success)),
               errors => Problem(errors)
            );
        }

        [HttpPost("Login/Employee")]
        public async Task<IActionResult> Login(LoginEmployeeRequest request)
        {
            LoginEmployeeCommand loginEmployeeQuery = mapper.Map<LoginEmployeeCommand>(request);
            ErrorOr<LoginEmployeeResult> result = await sender.Send(loginEmployeeQuery);

            return result.Match
            (
               success => Ok(mapper.Map<LoginEmployeeResponse>(success)),
               errors => Problem(errors)
            );
        }

        [HttpPost("Register/Company")]
        public async Task<IActionResult> Register(RegisterCompanyRequest request)
        {
            RegisterCompanyCommand command = mapper.Map<RegisterCompanyCommand>(request);
            ErrorOr<RegisterCompanyResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<RegisterCompanyResponse>(success)),
                errors => Problem(errors)
            );
        }

        [HttpPost("Register/Employee")]
        public async Task<IActionResult> Register(RegisterEmployeeRequest request)
        {
            RegisterEmployeeCommand command = mapper.Map<RegisterEmployeeCommand>(request);
            ErrorOr<RegisterEmployeeResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<RegisterEmployeeResponse>(success)),
                errors => Problem(errors)
            );
        }

        [HttpPost("Logout/Company")]
        public async Task<IActionResult> Logout(LogoutCompanyRequest request)
        {
            LogoutCompanyCommand command = mapper.Map<LogoutCompanyCommand>(request);
            ErrorOr<LogoutCompanyResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<LogoutCompanyResponse>(success)),
                errors => Problem(errors)
            );
        }

        [HttpPost("Logout/Employee")]
        public async Task<IActionResult> Logout(LogoutEmployeeRequest request)
        {
            LogoutEmployeeCommand command = mapper.Map<LogoutEmployeeCommand>(request);
            ErrorOr<LogoutEmployeeResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<LogoutEmployeeResponse>(success)),
                errors => Problem(errors)
            );
        }
    }
}