using MapsterMapper;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CyberTutorial.WebApp.Controllers.BaseControllers
{
    public class BaseController<T> : Controller where T : BaseController<T>
    {
        protected ILogger<T> Logger =>
            HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
        protected IClientApiService ClientApiService =>
            HttpContext.RequestServices.GetRequiredService<IClientApiService>();
        protected IMapper Mapper => 
            HttpContext.RequestServices.GetRequiredService<IMapper>();
        protected ICookieService CookieService =>
            HttpContext.RequestServices.GetRequiredService<ICookieService>();
        protected IIdentityService IdentityService =>
            HttpContext.RequestServices.GetRequiredService<IIdentityService>();

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            CookieService.SetController(context.Controller as Controller);
            return base.OnActionExecutionAsync(context, next);
        }
    }
}