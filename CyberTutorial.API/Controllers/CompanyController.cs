using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Requests.Company;
using CyberTutorial.Contracts.Responses.Company;
using CyberTutorial.Application.Companies.Common;
using CyberTutorial.Application.Companies.Commands.AddCompany;
using CyberTutorial.Application.Companies.Queries.GetCompanies;
using CyberTutorial.Application.Companies.Queries.GetCompanyById;
using CyberTutorial.Application.Companies.Commands.UpdateCompany;
using CyberTutorial.Application.Companies.Commands.DeleteCompany;
using CyberTutorial.Application.Companies.Queries.GetCompanyEmployees;
using CyberTutorial.Application.Companies.Queries.GetCompanySession;
using CyberTutorial.Application.Companies.Commands.UpdateCompanySession;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Company")]
    [AllowAnonymous]
    public class CompanyController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public CompanyController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCompany(AddCompanyRequest request)
        {
            AddCompanyCommand command = mapper.Map<AddCompanyCommand>(request);
            ErrorOr<AddCompanyResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<AddCompanyResponse>(success)),
                failure => Problem(failure)
            );
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetCompanies()
        {
            GetCompaniesQuery query = new GetCompaniesQuery();
            GetCompaniesResult result = await sender.Send(query);
            return Ok(mapper.Map<GetCompaniesResponse>(result));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetCompanyById(string companyId)
        {
            GetCompanyByIdQuery query = new GetCompanyByIdQuery()
            {
                CompanyId = companyId
            };
            ErrorOr<GetCompanyByIdResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetCompanyByIdResponse>(success)),
                failure => Problem(failure)
            );
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetCompanyEmployees(string companyId)
        {
            GetCompanyEmployeesQuery query = new GetCompanyEmployeesQuery()
            {
                CompanyId = companyId
            };
            ErrorOr<GetCompanyEmployeesResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetCompanyEmployeesResponse>(success)),
                failure => Problem(failure)
            );
        }

        [HttpGet("GetSession")]
        public async Task<IActionResult> GetCompanySession(string companyId)
        {
            GetCompanySessionQuery query = new GetCompanySessionQuery()
            {
                CompanyId = companyId
            };
            ErrorOr<GetCompanySessionResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetCompanySessionResponse>(success)),
                failure => Problem(failure)
            );
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCompany(string companyId, UpdateCompanyRequest request)
        {
            UpdateCompanyCommand command = mapper.Map<UpdateCompanyCommand>(request);
            command.TargetId = companyId;
            ErrorOr<UpdateCompanyResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateCompanyResponse>(success)),
                failure => Problem(failure)
            );
        }

        [HttpPost("UpdateSession")]
        public async Task<IActionResult> UpdateCompanySession(string companyId, UpdateCompanySessionRequest request)
        {
            UpdateCompanySessionCommand command = mapper.Map<UpdateCompanySessionCommand>(request);
            command.TargetId = companyId;
            ErrorOr<UpdateCompanySessionResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateCompanySessionResponse>(success)),
                failure => Problem(failure)
            );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCompany(string companyId)
        {
            DeleteCompanyCommand command = new DeleteCompanyCommand()
            {
                CompanyId = companyId
            };
            ErrorOr<DeleteCompanyResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<DeleteCompanyResponse>(success)),
                failure => Problem(failure)
            );
        }
    }
}