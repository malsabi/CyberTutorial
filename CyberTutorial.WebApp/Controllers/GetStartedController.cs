using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class GetStartedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}