namespace CyberTutorial.WebApp.Models
{
    public class AppRecordsModel
    {
        public int Clients { get; set; }
        public int Support { get; set; }
        public int Workers { get; set; }

        public AppRecordsModel()
        {
            Clients = 600;
            Support = 182;
            Workers = 50;
        }
    }
}