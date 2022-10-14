using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Authentication.Request;
using CyberTutorial.Contracts.Authentication.Response;
using CyberTutorial.Application.Authentication.Common;
using CyberTutorial.Application.Authentication.Queries;
using CyberTutorial.Contracts.Enums;

namespace CyberTutorial.API.Controllers
{
    [Route("Auth")]
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
    }
}