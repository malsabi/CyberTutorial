using CyberTutorial.WebApp.Models.Common;

namespace CyberTutorial.WebApp.Models.Employee.Dashboard
{
    public class EmployeePerformanceModel
    {
        public int MaximumQuizzes { get; set; }
        public int MaximumScore { get; set; }
        public List<string> Labels { get; set; }
        public List<ChartDatasetModel<int>> Datasets { get; set; }

        public EmployeePerformanceModel()
        {
            Labels = new List<string>();
            Datasets = new List<ChartDatasetModel<int>>();
        }
    }
}