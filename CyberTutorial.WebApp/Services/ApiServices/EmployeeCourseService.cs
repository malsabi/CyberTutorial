using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Responses.EmployeeCourse;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class EmployeeCourseService : IEmployeeCourseService
    {
        private readonly IClientApiService clientApiService;

        public string Token { get; set; }

        public EmployeeCourseService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<AddEmployeeCourseResponse>> AddEmployeeCourseAsync(string employeeId, string courseId)
        {
            return await clientApiService.PostAsync<AddEmployeeCourseResponse>(ApiConsts.EmployeeCourse.Add, Token, employeeId, courseId);
        }

        public async Task<ErrorOr<GetEmployeeCoursesResponse>> GetEmployeeCoursesAsync(string employeeId)
        {
            return await clientApiService.GetAsync<GetEmployeeCoursesResponse>(ApiConsts.EmployeeCourse.GetAll, Token, employeeId);
        }

        public async Task<ErrorOr<GetEmployeeCourseByIdResponse>> GetEmployeeCourseByIdAsync(string employeeId, string courseId)
        {
            return await clientApiService.GetAsync<GetEmployeeCourseByIdResponse>(ApiConsts.EmployeeCourse.Get, Token, employeeId, courseId);
        }

        public async Task<ErrorOr<DeleteEmployeeCoursesResponse>> DeleteEmployeeCoursesAsync(string employeeId)
        {
            return await clientApiService.DeleteAsync<DeleteEmployeeCoursesResponse>(ApiConsts.EmployeeCourse.DeleteAll, Token, employeeId);
        }

        public async Task<ErrorOr<DeleteEmployeeCourseByIdResponse>> DeleteEmployeeCourseByIdAsync(string employeeId, string coursesId)
        {
            return await clientApiService.DeleteAsync<DeleteEmployeeCourseByIdResponse>(ApiConsts.EmployeeCourse.Delete, Token, employeeId, coursesId);
        }
    }
}