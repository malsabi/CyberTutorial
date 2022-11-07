using ErrorOr;
using MediatR;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CyberTutorial.Contracts.Responses.EmployeeCourse;
using CyberTutorial.Application.EmployeeCourses.Common;
using CyberTutorial.Application.EmployeeCourses.Commands.AddEmployeeCourse;
using CyberTutorial.Application.EmployeeCourses.Queries.GetEmployeeCourses;
using CyberTutorial.Application.EmployeeCourses.Queries.GetEmployeeCourseById;
using CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourses;
using CyberTutorial.Application.EmployeeCourses.Commands.DeleteEmployeeCourseById;

namespace CyberTutorial.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class EmployeeCourseController : ApiController
    {
        private readonly ISender sender;
        private readonly IMapper mapper;

        public EmployeeCourseController(ISender sender, IMapper mapper)
        {
            this.sender = sender;
            this.mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddEmployeeCourse(string employeeId, string courseId)
        {
            AddEmployeeCourseCommand command = new AddEmployeeCourseCommand()
            {
                EmployeeId = employeeId,
                CourseId = courseId
            };
            ErrorOr<AddEmployeeCourseResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<AddEmployeeCourseResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEmployeeCourses(string employeeId)
        {
            GetEmployeeCoursesQuery query = new GetEmployeeCoursesQuery()
            {
                EmployeeId = employeeId
            };
            ErrorOr<GetEmployeeCoursesResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetEmployeeCoursesResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetEmployeeCourseById(string employeeId, string courseId)
        {
            GetEmployeeCourseByIdQuery query = new GetEmployeeCourseByIdQuery()
            {
                EmployeeId = employeeId,
                CourseId = courseId
            };
            ErrorOr<GetEmployeeCourseByIdResult> result = await sender.Send(query);
            return result.Match
            (
                success => Ok(mapper.Map<GetEmployeeCourseByIdResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteEmployeeCourses(string employeeId)
        {
            DeleteEmployeeCoursesCommand command = new DeleteEmployeeCoursesCommand()
            {
                EmployeeId = employeeId
            };
            ErrorOr<DeleteEmployeeCoursesResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<DeleteEmployeeCoursesResponse>(success)),
                error => Problem(error)
            );
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployeeCourseById(string employeeId, string courseId)
        {
            DeleteEmployeeCourseByIdCommand command = new DeleteEmployeeCourseByIdCommand()
            {
                EmployeeId = employeeId,
                CourseId = courseId
            };
            ErrorOr<DeleteEmployeeCourseByIdResult> result = await sender.Send(command);
            return result.Match
            (
                success => Ok(mapper.Map<DeleteEmployeeCourseByIdResponse>(success)),
                error => Problem(error)
            );
        }
    }
}