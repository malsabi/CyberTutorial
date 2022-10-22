using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class PricingController : BaseController<PricingController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}