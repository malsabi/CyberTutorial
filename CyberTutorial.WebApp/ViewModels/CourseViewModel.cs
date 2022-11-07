using ErrorOr;
using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.Models.Common;
using CyberTutorial.Contracts.Responses.Course;
using CyberTutorial.Contracts.Responses.EmployeeCourse;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.ViewModels
{
    public class CourseViewModel
    {
        private readonly ICourseService courseService;
        private readonly IEmployeeCourseService employeeCourseService;
        private readonly EmployeeViewModel employeeViewModel;

        public CourseViewModel(ICourseService courseService, IEmployeeCourseService employeeCourseService, EmployeeViewModel employeeViewModel)
        {
            this.courseService = courseService;
            this.employeeCourseService = employeeCourseService;
            this.employeeViewModel = employeeViewModel;
        }

        public async Task<ControllerResultModel> GetCoursesAsync()
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                EmployeeModel employee = (EmployeeModel)employeeResult.Data;
                courseService.Token = employee.Session.Token;
                ErrorOr<GetCoursesResponse> response = await courseService.GetCoursesAsync();
                if (response.IsError)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = false,
                        Message = response.FirstError.Description,
                        Data = response
                    };
                }
                else
                {
                    List<CourseModel> courses = (List<CourseModel>)response.Value.Courses;
                    foreach (CourseModel course in employee.Courses)
                    {
                        CourseModel courseToRemove = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                        if (courseToRemove != null)
                        {
                            courses.Remove(courseToRemove);
                        }
                    }
                    result = new ControllerResultModel()
                    {
                        IsSuccess = true,
                        Message = "Courses retrieved successfully.",
                        Data = courses
                    };
                }
            }
            return result;
        }

        public async Task<ControllerResultModel> GetTakenCoursesAsync()
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = true,
                    Message = "Taken courses retrieved successfully.",
                    Data = ((EmployeeModel)employeeResult.Data).Courses
                };
            }
            return result;
        }

        public async Task<ControllerResultModel> ApplyCourseAsync(string courseId)
        {
            ControllerResultModel result;
            ControllerResultModel employeeResult = await employeeViewModel.GetEmployeeAsync();
            if (!employeeResult.IsSuccess)
            {
                result = new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = employeeResult.Message,
                    Data = employeeResult.Data
                };
            }
            else
            {
                EmployeeModel employee = (EmployeeModel)employeeResult.Data;
                courseService.Token = employee.Session.Token;
                ErrorOr<GetCourseByIdResponse> response = await courseService.GetCourseByIdAsync(courseId);
                if (response.IsError)
                {
                    result = new ControllerResultModel()
                    {
                        IsSuccess = false,
                        Message = response.FirstError.Description,
                        Data = response
                    };
                }
                else
                {
                    CourseModel course = response.Value.Course;
                    employeeCourseService.Token = employee.Session.Token;
                    ErrorOr<AddEmployeeCourseResponse> employeeCourseResponse = await employeeCourseService.AddEmployeeCourseAsync(employee.EmployeeId, course.CourseId);
                    if (employeeCourseResponse.IsError)
                    {
                        result = new ControllerResultModel()
                        {
                            IsSuccess = false,
                            Message = employeeCourseResponse.FirstError.Description,
                            Data = employeeCourseResponse
                        };
                    }
                    else
                    {
                        result = new ControllerResultModel()
                        {
                            IsSuccess = true,
                            Message = "Employee course added successfully.",
                            Data = employeeCourseResponse.Value.CourseId
                        };
                    }
                }
            }
            return result;
        }
    }
}