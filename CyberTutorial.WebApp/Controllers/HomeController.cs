using System.Diagnostics;
using CyberTutorial.WebApp.Models;
using CyberTutorial.Contracts.Enums;
using CyberTutorial.WebApp.ViewModels;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Authentication.Request;
using CyberTutorial.Contracts.Authentication.Response;
using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            if (IdentityService.IsEmployeeLoggedIn())
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
            
            LoginRequest request = Mapper.Map<LoginRequest>(loginModel);

            LoginResponse response = await ClientApiService.PostAsync<LoginRequest, LoginResponse>(request, ApiConsts.Authentication);

            if (response == null)
            {
                return Json(new { Error = "Invalid Credentials." });
            }

            if (loginModel.AccountType.Equals(AccountType.Company))
            {
                CookieService.Set(AppConsts.CompanyCookieId, response);
            }
            else
            {
                CookieService.Set(AppConsts.EmployeeCookieId, response);
            }

            return Json(new { Success = "Login Successful." });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}