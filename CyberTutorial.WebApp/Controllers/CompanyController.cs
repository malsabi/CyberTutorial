using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class CompanyController : BaseController<CompanyController>
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (IdentityService.IsCompanyLoggedIn())
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return Json(await IdentityService.LogoutCompanyAsync());
        }
    }
}