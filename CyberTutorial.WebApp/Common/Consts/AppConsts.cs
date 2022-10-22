using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Common.Consts
{
    public class AppConsts
    {
        #region "ROLES"
        public const string Admin = "Admin";
        public const string Company = "Company";
        public const string Employee = "Employee";
        #endregion

        #region "COOKIES"
        public const int CookieExpirationDays = 30;
        public const string CompanyCookieId = "COMPANY_COOKIE";
        public const string EmployeeCookieId = "EMPLOYEE_COOKIE";
        #endregion

        #region "SERVICES"
        public const string AESKey = "AES:Key";
        public const string AESInitializationVector = "AES:InitializationVector";
        #endregion

        #region "Views"
        #region "Employee:Courses"
        public const string AllCoursesView = "~/Views/Employee/Courses/AllCourses.cshtml";
        public const string TakenCoursesView = "~/Views/Employee/Courses/TakenCourses.cshtml";
        #endregion

        #region "Employee:Quizzes"
        public const string AllQuizzesView = "~/Views/Employee/Quizzes/AllQuizzes.cshtml";
        public const string AttemptedQuizzesView = "~/Views/Employee/Quizzes/AttemptedQuizzes.cshtml";
        #endregion

        #region "Employee:Account"
        public const string ProfileView = "~/Views/Employee/Account/Profile.cshtml";
        public const string SettingsView = "~/Views/Employee/Account/Settings.cshtml";
        #endregion

        #region "Emploee:Library"
        public const string LibraryView = "~/Views/Employee/Library/Index.cshtml";
        #endregion
        #endregion
    }
}