using Microsoft.AspNetCore.Mvc;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;
using CyberTutorial.WebApp.Common.Interfaces.Services.AppServices;

namespace CyberTutorial.WebApp.Controllers.BaseControllers
{
    public class BaseController<T> : Controller where T : BaseController<T>
    {
        #region "APP Services"
        protected ILogger<T> Logger =>
            HttpContext.RequestServices.GetRequiredService<ILogger<T>>();

        protected ICookieService CookieService =>
            HttpContext.RequestServices.GetRequiredService<ICookieService>();

        protected ISerializationService SerializationService =>
            HttpContext.RequestServices.GetRequiredService<ISerializationService>();

        protected ICryptographyService CryptographyService =>
            HttpContext.RequestServices.GetRequiredService<ICryptographyService>();
        #endregion

        #region "API Services"
        protected IAuthenticationService AuthenticationService =>
            HttpContext.RequestServices.GetRequiredService<IAuthenticationService>();

        protected ICompanyService CompanyService =>
            HttpContext.RequestServices.GetRequiredService<ICompanyService>();

        protected IEmployeeService EmployeeService =>
            HttpContext.RequestServices.GetRequiredService<IEmployeeService>();

        protected IEmployeeCourseService EmployeeCourseService =>
            HttpContext.RequestServices.GetRequiredService<IEmployeeCourseService>();

        protected ICourseService CourseService =>
            HttpContext.RequestServices.GetRequiredService<ICourseService>();

        protected IQuizService QuizService =>
            HttpContext.RequestServices.GetRequiredService<IQuizService>();

        protected IAttemptService AttemptService =>
            HttpContext.RequestServices.GetRequiredService<IAttemptService>();
        #endregion

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (EmployeeService.IsEmployeeLoggedInAsync().Result)
        //    {
        //        if (IsControllerNotValid(context, true, false))
        //        {
        //            context.Result = new RedirectResult(Url.Action("Index", "Employee"));
        //            return;
        //        }
        //    }
        //    else if (CompanyService.IsCompanyLoggedInAsync().Result)
        //    {
        //        if (IsControllerNotValid(context, false, true))
        //        {
        //            context.Result = new RedirectResult(Url.Action("Index", "Company"));
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (IsControllerNotValid(context) == false)
        //        {
        //            context.Result = new RedirectResult(Url.Action("Index", "Home"));
        //            return;
        //        }
        //    }
        //    base.OnActionExecuting(context);
        //}

        //private bool IsControllerNotValid(ActionExecutingContext context, bool includeCompany = false, bool includeEmployee = false)
        //{
        //    bool condition = context.Controller is HomeController
        //        || context.Controller is AboutUsController
        //        || context.Controller is PricingController
        //        || context.Controller is GetStartedController
        //        || context.Controller is ContactController
        //        || context.Controller is FAQController;

        //    if (includeCompany)
        //    {
        //        condition = condition || context.Controller is CompanyController;
        //    }

        //    if (includeEmployee)
        //    {
        //        condition = condition || context.Controller is EmployeeController;
        //    }
        //    return condition;
        //}
    }
}