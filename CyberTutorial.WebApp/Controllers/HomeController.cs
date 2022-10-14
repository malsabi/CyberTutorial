using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using CyberTutorial.WebApp.Models;
using CyberTutorial.WebApp.ViewModels;
using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            if (IdentityService.IsCompanyLoggedIn())
            {
                return RedirectToAction("Index", "Company");
            }
            else if (IdentityService.IsEmployeeLoggedIn())
            {
                return RedirectToAction("Index", "Employee");
            }
            return View(viewModel);
        }

        public async Task<ActionResult> Authentication(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Validation = "Login form is invalid." });
            }
            return Json(await IdentityService.AuthenticateAsync(loginModel));
        }

        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            ValidationContext companyValidationContext = new ValidationContext(registerModel.RegisterCompanyModel);
            bool isCompanyValid = Validator.TryValidateObject(registerModel.RegisterCompanyModel, companyValidationContext, null, true);

            if (isCompanyValid)
            {
                return Json(await IdentityService.RegisterCompanyAsync(registerModel.RegisterCompanyModel));
            }

            ValidationContext employeeValidationContext = new ValidationContext(registerModel.RegisterEmployeeModel);
            bool isEmployeeValid = Validator.TryValidateObject(registerModel.RegisterEmployeeModel, employeeValidationContext, null, true);

            if (isEmployeeValid)
            {
                return Json(await IdentityService.RegisterEmployeeAsync(registerModel.RegisterEmployeeModel));
            }

            return Json(new { Validation = "Register form is invalid." });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}