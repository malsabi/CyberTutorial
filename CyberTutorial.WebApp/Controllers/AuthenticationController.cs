using Microsoft.AspNetCore.Mvc;
using CyberTutorial.WebApp.Models;
using CyberTutorial.Contracts.Enums;
using CyberTutorial.Contracts.Models;
using CyberTutorial.WebApp.ViewModels;
using CyberTutorial.WebApp.Controllers.BaseControllers;

namespace CyberTutorial.WebApp.Controllers
{
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        private readonly AuthenticationViewModel viewModel;

        public AuthenticationController(AuthenticationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public async Task<ActionResult> RegisterCompany(RegisterCompanyModel registerCompanyModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Invalid register company form data.",
                    Data = registerCompanyModel
                });
            }
            return Json(await viewModel.RegisterCompanyAsync(registerCompanyModel));
        }

        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeModel registerEmployeeModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Invalid register employee form data.",
                    Data = registerEmployeeModel
                });
            }
            return Json(await viewModel.RegisterEmployeeAsync(registerEmployeeModel));
        }

        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Invalid login form data.",
                    Data = loginModel
                });
            }
            if (loginModel.AccountType.Equals(AccountType.Company))
            {
                return Json(await viewModel.LoginCompanyAsync(loginModel.EmailAddress, loginModel.Password));
            }
            else if (loginModel.AccountType.Equals(AccountType.Employee))
            {
                return Json(await viewModel.LoginEmployeeAsync(loginModel.EmailAddress, loginModel.Password));
            }
            else
            {
                return Json(new ControllerResultModel()
                {
                    IsSuccess = false,
                    Message = "Invalid account type.",
                    Data = loginModel
                });
            }
        }

        public async Task<ActionResult> LogoutCompany()
        {
            return Json(await viewModel.LogoutCompanyAsync());
        }

        public async Task<ActionResult> LogoutEmployee()
        {
            return Json(await viewModel.LogoutEmployeeAsync());
        }
    }
}