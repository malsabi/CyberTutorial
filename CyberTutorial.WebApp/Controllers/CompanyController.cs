﻿using CyberTutorial.WebApp.Controllers.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Controllers
{
    public class CompanyController : BaseController<CompanyController>
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            return null;
        }
    }
}