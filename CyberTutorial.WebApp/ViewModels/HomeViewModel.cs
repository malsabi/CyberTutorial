using CyberTutorial.WebApp.Models;

namespace CyberTutorial.WebApp.ViewModels
{
    public class HomeViewModel
    {
        public AppRecordsModel AppRecordsModel { get; set; }

        public HomeViewModel()
        {
            AppRecordsModel = new AppRecordsModel();
        }
    }
}