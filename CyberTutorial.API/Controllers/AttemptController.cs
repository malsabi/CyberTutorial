using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Requests.Attempt;
using CyberTutorial.Contracts.Responses.Attempt;
using CyberTutorial.Application.Attempts.Common;
using CyberTutorial.Application.Attempts.Commands.AddAttempt;
using CyberTutorial.Application.Attempts.Queries.GetAttempts;
using CyberTutorial.Application.Attempts.Queries.GetAttemptById;
using CyberTutorial.Application.Attempts.Commands.UpdateAttempt;
using CyberTutorial.Application.Attempts.Commands.DeleteAttempt;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AttemptController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public AttemptController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAttempt(AddAttemptRequest request)
        {
            AddAttemptCommand command = mapper.Map<AddAttemptCommand>(request);
            ErrorOr<AddAttemptResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<AddAttemptResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAttempts()
        {
            GetAttemptsResult result = await sender.Send(new GetAttemptsQuery());
            return Ok(mapper.Map<GetAttemptsResponse>(result));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAttemptById(string attemptId)
        {
            GetAttemptByIdQuery query = new GetAttemptByIdQuery()
            {
                AttemptId = attemptId
            };
            ErrorOr<GetAttemptByIdResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetAttemptByIdResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAttempt(string attemptId, UpdateAttemptRequest request)
        {
            UpdateAttemptCommand command = mapper.Map<UpdateAttemptCommand>(request);
            command.TargetId = attemptId;
            ErrorOr<UpdateAttemptResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateAttemptResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAttempt(string attemptId)
        {
            DeleteAttemptCommand command = new DeleteAttemptCommand()
            {
                AttemptId = attemptId
            };
            ErrorOr<DeleteAttemptResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<DeleteAttemptResponse>(success)),
                error => Problem(error)
            );
        }
    }
}