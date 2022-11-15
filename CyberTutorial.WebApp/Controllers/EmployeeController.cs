using Microsoft.AspNetCore.Mvc;
using CyberTutorial.WebApp.Models;
using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.ViewModels;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Controllers.BaseControllers;
using ErrorOr;

namespace CyberTutorial.WebApp.Controllers
{
    public class EmployeeController : BaseController<EmployeeController>
    {
        private readonly EmployeeViewModel employeeViewModel;
        private readonly CourseViewModel courseViewModel;
        private readonly QuizViewModel quizViewModel;

        public EmployeeController(EmployeeViewModel employeeViewModel, CourseViewModel courseViewModel, QuizViewModel quizViewModel)
        {
            this.employeeViewModel = employeeViewModel;
            this.courseViewModel = courseViewModel;
            this.quizViewModel = quizViewModel;
        }

        #region "Dashboard"
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ControllerResultModel result = await employeeViewModel.GetEmployeeAsync();
            if (result.IsSuccess)
            {
                EmployeeModel employee = (EmployeeModel)result.Data;
                ViewData["EmployeeName"] = string.Format("{0} {1}", employee.FirstName, employee.LastName);
                return View(employee);
            }
            return Unauthorized();
        }
        #endregion

        #region "Courses"
        public async Task<IActionResult> AllCourses()
        {
            ControllerResultModel result = await courseViewModel.GetCoursesAsync();
            if (result.IsSuccess)
            {
                return View(AppConsts.AllCoursesView, result.Data);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> TakenCourses()
        {
            ControllerResultModel result = await courseViewModel.GetTakenCoursesAsync();
            if (result.IsSuccess)
            {
                return View(AppConsts.TakenCoursesView, result.Data);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> ApplyCourse(string courseId)
        {
            ControllerResultModel result = await courseViewModel.ApplyCourseAsync(courseId);
            if (result.IsSuccess)
            {
                return Json(result);
            }
            return Unauthorized();
        }
        #endregion

        #region "Quizzes"
        public async Task<IActionResult> AllQuizzes()
        {
            ControllerResultModel result = await quizViewModel.GetQuizzesAsync();
            if (result.IsSuccess)
            {
                return View(AppConsts.AllQuizzesView, result.Data);
            }
            return Unauthorized();
        }
        
        public async Task<IActionResult> ViewMarks(string quizId)
        {
            ControllerResultModel result = await quizViewModel.GetQuizMarksAsync(quizId);
            if (result.IsSuccess)
            {
                return Json(result);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> CanAttemptQuiz(string quizId)
        {
            ControllerResultModel result = await quizViewModel.CanAttemptQuizAsync(quizId);
            if (result.IsSuccess)
            {
                return Json(result);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> StartQuiz(string quizId)
        {
            ControllerResultModel canAttemptQuizResult = await quizViewModel.CanAttemptQuizAsync(quizId);
            if (canAttemptQuizResult.IsSuccess && ((int)canAttemptQuizResult.Data) < 300)
            {
                ControllerResultModel startQuizResult = await quizViewModel.StartQuizAsync(quizId);
                if (startQuizResult.IsSuccess)
                {
                    return View(AppConsts.QuizView, startQuizResult.Data);
                }
            }
            return Unauthorized();
        }

        public async Task<IActionResult> AttemptedQuizzes()
        {
            ControllerResultModel result = await quizViewModel.GetAttemptedQuizzesAsync();
            if (result.IsSuccess)
            {
                return View(AppConsts.AttemptedQuizzesView, result.Data);
            }
            return Unauthorized();
        }
        #endregion

        #region "Library"
        public IActionResult Library()
        {
            return View(AppConsts.LibraryView);
        }
        #endregion

        #region "Account"
        public IActionResult Profile()
        {
            return View(AppConsts.ProfileView);
        }

        public IActionResult Settings()
        {
            return View(AppConsts.SettingsView);
        }
        #endregion
    }
}