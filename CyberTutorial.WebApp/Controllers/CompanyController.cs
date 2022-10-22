using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class CompanyController : BaseController<CompanyController>
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return Json(await IdentityService.LogoutCompanyAsync());
        }
    }
}