using CyberTutorial.WebApp.Models.Common;

namespace CyberTutorial.WebApp.Models.Employee.Dashboard
{
    public class EmployeeFinalResultModel
    {
        public List<string> Labels { get; set; }
        public List<ChartDatasetModel<int>> Datasets { get; set; }

        public EmployeeFinalResultModel()
        {
            Labels = new List<string>();
            Datasets = new List<ChartDatasetModel<int>>();
        }
    }
}