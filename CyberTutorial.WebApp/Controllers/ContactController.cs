using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class ContactController : BaseController<ContactController>
    {
        public IActionResult Index()
        {
            if (IdentityService.IsCompanyLoggedIn())
            {
                return RedirectToAction("Index", "Company");
            }
            else if (IdentityService.IsEmployeeLoggedIn())
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}