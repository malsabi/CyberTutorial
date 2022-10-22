namespace CyberTutorial.WebApp.Models.Common
{
    public class ChartDatasetModel<T>
    {
        public string Label { get; set; }
        public List<T> Data { get; set; }
        public List<string> BackgroundColor { get; set; }
        public int BorderWidth { get; set; }
    }
}