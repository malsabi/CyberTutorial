using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Requests.Quiz;
using CyberTutorial.Contracts.Responses.Quiz;
using CyberTutorial.Application.Quizzes.Common;
using CyberTutorial.Application.Quizzes.Commands.AddQuiz;
using CyberTutorial.Application.Quizzes.Queries.GetQuizzes;
using CyberTutorial.Application.Quizzes.Queries.GetQuizById;
using CyberTutorial.Application.Quizzes.Commands.DeleteQuiz;
using CyberTutorial.Application.Quizzes.Commands.UpdateQuiz;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class QuizController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;
        
        public QuizController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddQuiz(AddQuizRequest request)
        {
            AddQuizCommand command = mapper.Map<AddQuizCommand>(request);
            ErrorOr<AddQuizResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<AddQuizResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllQuizzes()
        {
            GetQuizzesResult result = await sender.Send(new GetQuizzesQuery());
            return Ok(mapper.Map<GetQuizzesResponse>(result));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetQuizById(string quizId)
        {
            GetQuizByIdQuery query = new GetQuizByIdQuery()
            {
                QuizId = quizId
            };
            ErrorOr<GetQuizByIdResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetQuizByIdResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateQuiz(string quizId, UpdateQuizRequest request)
        {
            UpdateQuizCommand command = mapper.Map<UpdateQuizCommand>(request);
            command.TargetId = quizId;
            ErrorOr<UpdateQuizResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateQuizResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteQuiz(string quizId)
        {
            DeleteQuizCommand command = new DeleteQuizCommand()
            {
                QuizId = quizId
            };
            ErrorOr<DeleteQuizResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<DeleteQuizResponse>(success)),
                error => Problem(error)
            );
        }
    }
}