using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class FAQController : BaseController<FAQController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}