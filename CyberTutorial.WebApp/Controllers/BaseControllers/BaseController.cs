using CyberTutorial.WebApp.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers.BaseControllers
{
    public class BaseController<T> : Controller where T : BaseController<T>
    {
        protected ILogger<T> Logger =>
            HttpContext.RequestServices.GetRequiredService<ILogger<T>>();

        protected IIdentityService IdentityService =>
            HttpContext.RequestServices.GetRequiredService<IIdentityService>();
    }
}