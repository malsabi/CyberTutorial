using ErrorOr;
using MediatR;
using MapsterMapper;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Companies.Commands.DeleteCompany;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public CompanyController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Delete")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(string id)
        {
            DeleteCompanyCommand command = new DeleteCompanyCommand() {  Id = id };
            ErrorOr<DeleteCompanyResult> result = await sender.Send(command);

            return result.Match
            (
                (registerCompanyResult) => Ok(registerCompanyResult),
                (errors) => Problem(errors)
            );
        }
    }
}