using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Companies.Commands.Logout;
using CyberTutorial.Contracts.Common.Request.Logout;
using CyberTutorial.Contracts.Common.Response.Logout;
using CyberTutorial.Contracts.Company.Request.Session;
using CyberTutorial.Contracts.Company.Response.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Application.Companies.Queries.Session;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Company")]
    public class CompanyController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public CompanyController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutRequest request)
        {
            LogoutCompanyCommand command = mapper.Map<LogoutCompanyCommand>(request);
            ErrorOr<LogoutCompanyResult> result = await sender.Send(command);
            return result.Match(
                success => Ok(mapper.Map<LogoutResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPost("IsSessionValid")]
        public async Task<IActionResult> IsSessionValid(IsCompanySessionValidRequest request)
        {
            CompanySessionValidationQuery command = mapper.Map<CompanySessionValidationQuery>(request);
            ErrorOr<CompanySessionValidationResult> result = await sender.Send(command);

            return result.Match(
                success => Ok(mapper.Map<IsCompanySessionValidResponse>(success)),
                error => Problem(error)
            );
        }
    }
}