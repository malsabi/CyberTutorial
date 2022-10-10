using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class EmployeeController : BaseController<EmployeeController>
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            return Json(await IdentityService.LogoutEmployeeAsync());
        }
    }
}