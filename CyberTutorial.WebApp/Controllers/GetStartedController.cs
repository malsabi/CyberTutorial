using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class GetStartedController : BaseController<GetStartedController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}