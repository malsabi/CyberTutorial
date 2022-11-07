using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Requests.Course;
using CyberTutorial.Contracts.Responses.Course;
using CyberTutorial.Application.Courses.Common;
using CyberTutorial.Application.Courses.Commands.AddCourse;
using CyberTutorial.Application.Courses.Queries.GetCourses;
using CyberTutorial.Application.Courses.Queries.GetCourseById;
using CyberTutorial.Application.Courses.Commands.UpdateCourse;
using CyberTutorial.Application.Courses.Commands.DeleteCourse;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Employee")]
    [AllowAnonymous]
    public class CourseController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public CourseController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCourse(AddCourseRequest request)
        {
            AddCourseCommand command = mapper.Map<AddCourseCommand>(request);
            ErrorOr<AddCourseResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<AddCourseResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCourses()
        {
            GetCoursesResult result = await sender.Send(new GetCoursesQuery());
            return Ok(mapper.Map<GetCoursesResponse>(result));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetCourseById(string courseId)
        {
            GetCourseByIdQuery query = new GetCourseByIdQuery()
            {
                CourseId = courseId
            };
            ErrorOr<GetCourseByIdResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetCourseByIdResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCourse(string courseId, UpdateCourseRequest request)
        {
            UpdateCourseCommand command = mapper.Map<UpdateCourseCommand>(request);
            command.TargetId = courseId;
            ErrorOr<UpdateCourseResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<UpdateCourseResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCourse(string courseId)
        {
            DeleteCourseCommand command = new DeleteCourseCommand()
            {
                CourseId = courseId
            };
            ErrorOr<DeleteCourseResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<DeleteCourseResponse>(success)),
                error => Problem(error)
            );
        }
    }
}