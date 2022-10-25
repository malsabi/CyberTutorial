using CyberTutorial.WebApp.Models.Common;
using CyberTutorial.Contracts.Employee.Response.Dashboard;

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

        public void FillValues(GetEmployeeDashboardResponse response)
        {
            MaximumQuizzes = response.Quizzes.Count;
            MaximumScore = response.Quizzes.Max(x => x.MaximumScore);
            Labels = response.Quizzes.Select(x => x.Title).Distinct().ToList();

            List<int> quizOneMarks = response.Quizzes.Where(x => x.TotalAttempts == 1).Select(x => x.Score).ToList();
            List<int> quizTwoMarks = response.Quizzes.Where(x => x.TotalAttempts == 2).Select(x => x.Score).ToList();
            List<int> quizThreeMarks = response.Quizzes.Where(x => x.TotalAttempts == 3).Select(x => x.Score).ToList();
            
            Datasets = new List<ChartDatasetModel<int>>()
            {
                new ChartDatasetModel<int>()
                {
                    Label = "Quiz 1",
                    Data = quizOneMarks,
                    BackgroundColor = new List<string>()
                    {
                        "rgb(255, 99, 132)",
                    },
                    BorderWidth = 1
                },
                new ChartDatasetModel<int>()
                {
                    Label = "Quiz 2",
                    Data = quizTwoMarks,
                    BackgroundColor = new List<string>()
                    {
                        "rgb(54, 162, 235)",
                    },
                    BorderWidth = 1
                },
                new ChartDatasetModel<int>()
                {
                    Label = "Quiz 3",
                    Data = quizThreeMarks,
                    BackgroundColor = new List<string>()
                    {
                        "rgb(75, 192, 192)",
                    },
                    BorderWidth = 1
                }
            };
        }
    }
}