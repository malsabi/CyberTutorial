using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class EmployeeController : BaseController<EmployeeController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}