using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class ContactController : BaseController<ContactController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}