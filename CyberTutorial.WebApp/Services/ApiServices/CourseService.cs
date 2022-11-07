using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Course;
using CyberTutorial.Contracts.Responses.Course;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class CourseService : ICourseService
    {
        private readonly IClientApiService clientApiService;

        public string Token { get; set; }
        
        public CourseService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<AddCourseResponse>> AddCourseAsync(AddCourseRequest request)
        {
            return await clientApiService.PostAsync<AddCourseRequest, AddCourseResponse>(request, ApiConsts.Course.Add, Token);
        }

        public async Task<ErrorOr<GetCoursesResponse>> GetCoursesAsync()
        {
            return await clientApiService.GetAsync<GetCoursesResponse>(ApiConsts.Course.GetAll, Token);
        }

        public async Task<ErrorOr<GetCourseByIdResponse>> GetCourseByIdAsync(string courseId)
        {
            return await clientApiService.GetAsync<GetCourseByIdResponse>(ApiConsts.Course.Get, Token, courseId);
        }

        public async Task<ErrorOr<UpdateCourseResponse>> UpdateCourseAsync(string courseId, UpdateCourseRequest request)
        {
            return await clientApiService.PutAsync<UpdateCourseRequest, UpdateCourseResponse>(request, ApiConsts.Course.Update, Token, courseId);
        }

        public async Task<ErrorOr<DeleteCourseResponse>> DeleteCourseAsync(string courseId)
        {
            return await clientApiService.DeleteAsync<DeleteCourseResponse>(ApiConsts.Course.Delete, Token, courseId);
        }
    }
}