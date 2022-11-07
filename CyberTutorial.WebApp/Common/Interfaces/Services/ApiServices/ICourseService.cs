using ErrorOr;
using CyberTutorial.Contracts.Requests.Course;
using CyberTutorial.Contracts.Responses.Course;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface ICourseService
    {
        public string Token { get; set; }
        public Task<ErrorOr<AddCourseResponse>> AddCourseAsync(AddCourseRequest request);
        public Task<ErrorOr<GetCoursesResponse>> GetCoursesAsync();
        public Task<ErrorOr<GetCourseByIdResponse>> GetCourseByIdAsync(string courseId);
        public Task<ErrorOr<UpdateCourseResponse>> UpdateCourseAsync(string courseId, UpdateCourseRequest request);
        public Task<ErrorOr<DeleteCourseResponse>> DeleteCourseAsync(string courseId);
    }
}