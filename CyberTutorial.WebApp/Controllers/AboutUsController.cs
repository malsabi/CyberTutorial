using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class AboutUsController : BaseController<AboutUsController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}