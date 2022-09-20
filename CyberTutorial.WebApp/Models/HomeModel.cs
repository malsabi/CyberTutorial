namespace CyberTutorial.WebApp.Models
{
    public class HomeModel
    {
        public int Clients { get; set; }
        public int Support { get; set; }
        public int Workers { get; set; }

        //Default Constructor
        public HomeModel()
        {
            //Initializing
            Clients = 600;
            Support = 182;
            Workers = 50;
        }
    }
}