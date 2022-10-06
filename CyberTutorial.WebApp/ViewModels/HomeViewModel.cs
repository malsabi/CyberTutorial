using CyberTutorial.WebApp.Models;

namespace CyberTutorial.WebApp.ViewModels
{
    public class HomeViewModel
    {
        public AppRecordsModel AppRecordsModel { get; set; }
        public LoginModel LoginModel { get; set; }
        public RegisterModel RegisterModel { get; set; }

        public HomeViewModel()
        {
            AppRecordsModel = new AppRecordsModel();
            LoginModel = new LoginModel();
            RegisterModel = new RegisterModel();
        }
    }
}