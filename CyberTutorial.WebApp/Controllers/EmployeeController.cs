using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using CyberTutorial.WebApp.ViewModels;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Models.Common;
using CyberTutorial.WebApp.Controllers.BaseControllers;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;
using CyberTutorial.WebApp.Services.ApiServices;

namespace CyberTutorial.WebApp.Controllers
{
    public class EmployeeController : BaseController<EmployeeController>
    {
        private readonly EmployeeViewModel employeeViewModel;
        private readonly CourseViewModel courseViewModel;
        private readonly IDocumentService documentService;

        public EmployeeController(EmployeeViewModel employeeViewModel, CourseViewModel courseViewModel, IDocumentService documentService)
        {
            this.employeeViewModel = employeeViewModel;
            this.courseViewModel = courseViewModel;
            this.documentService = documentService;
        }

        #region "Dashboard"
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ControllerResultModel result = await employeeViewModel.GetEmployeeAsync();
            if (result.IsSuccess)
            {
                return View(result.Data);
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
            //ErrorOr<string> response = await documentService.DownloadDocumentAsync("95c7fc5f-df8a-44f8-a941-faf338d2b15f");

            ControllerResultModel result = await courseViewModel.ApplyCourseAsync(courseId);
            if (result.IsSuccess)
            {
                return Json(result);
            }
            return Unauthorized();
        }
        #endregion

        #region "Quizzes"
        public IActionResult AllQuizzes()
        {
            return View(AppConsts.AllQuizzesView);
        }

        public IActionResult AttemptedQuizzes()
        {
            return View(AppConsts.AttemptedQuizzesView);
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