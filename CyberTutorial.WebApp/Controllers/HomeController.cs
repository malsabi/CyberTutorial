using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CyberTutorial.WebApp.ViewModels;
using CyberTutorial.WebApp.Controllers.BaseControllers;

namespace CyberTutorial.WebApp.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly HomeViewModel homeViewModel;

        public HomeController(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }
        
        public IActionResult Index()
        {
            return View(homeViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}