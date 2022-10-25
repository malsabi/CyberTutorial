using CyberTutorial.Contracts.Employee.Response.Dashboard;
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

        public void FillValues(GetEmployeeDashboardResponse response)
        {
            Random rnd = new Random();
            Labels = response.Quizzes.Select(x => x.Title).Distinct().ToList();
            List<int> quizThreeMarks = response.Quizzes.Where(x => x.TotalAttempts == 3).Select(x => x.Score).ToList();
            List<string> colors = new List<string>();
            foreach (string label in Labels)
            {
                colors.Add($"rgb({rnd.Next(0, 255)}, {rnd.Next(0, 255)}, {rnd.Next(0, 255)})");
            }
            Datasets = new List<ChartDatasetModel<int>>()
            {
                new ChartDatasetModel<int>()
                {
                    Label = "Final Result",
                    Data = quizThreeMarks,
                    BackgroundColor = colors,
                    BorderWidth = 1
                }
            };
        }
    }
}