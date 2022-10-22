using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Controllers.BaseControllers;
using CyberTutorial.WebApp.Models.Employee.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class EmployeeController : BaseController<EmployeeController>
    {
        #region "Dashboard"
        [HttpGet]
        public IActionResult Index()
        {
            return View(new EmployeeDashboardModel());
        }
        #endregion

        #region "Courses"
        public IActionResult AllCourses()
        {
            return View(AppConsts.AllCoursesView);
        }

        public IActionResult TakenCourses()
        {
            return View(AppConsts.TakenCoursesView);
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

        public async Task<IActionResult> Logout()
        {
            return Json(await IdentityService.LogoutEmployeeAsync());
        }
        #endregion
    }
}