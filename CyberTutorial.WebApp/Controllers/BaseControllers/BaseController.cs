using CyberTutorial.WebApp.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CyberTutorial.WebApp.Controllers.BaseControllers
{
    public class BaseController<T> : Controller where T : BaseController<T>
    {
        protected ILogger<T> Logger =>
            HttpContext.RequestServices.GetRequiredService<ILogger<T>>();

        protected IIdentityService IdentityService =>
            HttpContext.RequestServices.GetRequiredService<IIdentityService>();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (IdentityService.IsEmployeeLoggedIn().Result)
            {
                if (IsControllerNotValid(context, true, false))
                {
                    context.Result = new RedirectResult(Url.Action("Index", "Employee"));
                    return;
                }
            }
            else if (IdentityService.IsCompanyLoggedIn().Result)
            {
                if (IsControllerNotValid(context, false, true))
                {
                    context.Result = new RedirectResult(Url.Action("Index", "Company"));
                    return;
                }
            }
            else
            {
                if (IsControllerNotValid(context) == false)
                {
                    context.Result = new RedirectResult(Url.Action("Index", "Home"));
                    return;
                }
            }
            base.OnActionExecuting(context);
        }

        private bool IsControllerNotValid(ActionExecutingContext context, bool includeCompany = false, bool includeEmployee = false)
        {
            bool condition = context.Controller is HomeController
                || context.Controller is AboutUsController
                || context.Controller is PricingController
                || context.Controller is GetStartedController
                || context.Controller is ContactController
                || context.Controller is FAQController;

            if (includeCompany)
            {
                condition = condition || context.Controller is CompanyController;
            }

            if (includeEmployee)
            {
                condition = condition || context.Controller is EmployeeController;
            }
            return condition;
        }
    }
}