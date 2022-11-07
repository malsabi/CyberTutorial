using ErrorOr;
using CyberTutorial.Contracts.Responses.EmployeeCourse;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IEmployeeCourseService
    {
        public string Token { get; set; }

        public Task<ErrorOr<AddEmployeeCourseResponse>> AddEmployeeCourseAsync(string employeeId, string courseId);
        public Task<ErrorOr<GetEmployeeCoursesResponse>> GetEmployeeCoursesAsync(string employeeId);
        public Task<ErrorOr<GetEmployeeCourseByIdResponse>> GetEmployeeCourseByIdAsync(string employeeId, string courseId);
        public Task<ErrorOr<DeleteEmployeeCoursesResponse>> DeleteEmployeeCoursesAsync(string employeeId);
        public Task<ErrorOr<DeleteEmployeeCourseByIdResponse>> DeleteEmployeeCourseByIdAsync(string employeeId, string coursesId);
    }
}