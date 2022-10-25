using CyberTutorial.Contracts.Models;
using CyberTutorial.Contracts.Employee.Response.Dashboard;

namespace CyberTutorial.WebApp.Models.Employee.Dashboard
{
    public class EmployeeDashboardModel
    {
        public int TotalCourses { get; set; }
        public string TotalCoursesLastModified { get; set; }
        public int TotalQuizzes { get; set; }
        public string TotalQuizzesLastModified { get; set; }
        public int PassedQuizzes { get; set; }
        public string PassedQuizzesLastModified { get; set; }
        public int FailedQuizzes { get; set; }
        public string FailedQuizzesLastModified { get; set; }
        public EmployeePerformanceModel EmployeePerformance { get; set; }
        public EmployeeFinalResultModel EmployeeFinalResultModel { get; set; }
        public List<TopEmployeeModel> TopEmployees { get; set; }

        public EmployeeDashboardModel()
        {
            EmployeePerformance = new EmployeePerformanceModel();
            EmployeeFinalResultModel = new EmployeeFinalResultModel();
            TopEmployees = new List<TopEmployeeModel>();
        }

        public void FillStatisticsValues(GetEmployeeDashboardResponse response)
        {
            TotalCourses = response.TotalCourses;
            TotalCoursesLastModified = response.TotalCoursesLastModified;
            TotalQuizzes = response.TotalQuizzes;
            TotalQuizzesLastModified = response.TotalQuizzesLastModified;
            PassedQuizzes = response.PassedQuizzes;
            PassedQuizzesLastModified = response.PassedQuizzesLastModified;
            FailedQuizzes = response.FailedQuizzes;
            FailedQuizzesLastModified = response.FailedQuizzesLastModified;
        }

        public void FillChartsValues(GetEmployeeDashboardResponse response)
        {
            EmployeePerformance.FillValues(response);
            EmployeeFinalResultModel.FillValues(response);
        }

        public void FillTablesValues(GetEmployeeDashboardResponse response)
        {
            foreach (TopEmployeeModel topEmployee in response.TopEmployees)
            {
                TopEmployees.Add(topEmployee);
            }
        }

        private void AddRandomData()
        {
            EmployeePerformance = new EmployeePerformanceModel()
            {
                MaximumQuizzes = 15,
                MaximumScore = 10,
                Labels = new List<string>()
                {
                   "Social Engineering",
                   "Public Network",
                   "Public Wi-Fi",
                   "Man in the Middle",
                   "Phishing Attack"
                },
                Datasets = new List<Common.ChartDatasetModel<int>>()
                {
                    new Common.ChartDatasetModel<int>()
                    {
                        Label = "Quiz 1",
                        BackgroundColor = new List<string>()
                        {
                            "rgb(255, 99, 132)"
                        },
                        Data = new List<int>()
                        {
                            10,
                            5,
                            8,
                            9,
                            3
                        },
                        BorderWidth = 0
                    },
                    new Common.ChartDatasetModel<int>()
                    {
                        Label = "Quiz 2",
                        BackgroundColor = new List<string>()
                        {
                            "rgb(54, 162, 235)"
                        },
                        Data = new List<int>()
                        {
                            3,
                            9,
                            8,
                            5,
                            10
                        },
                        BorderWidth = 0
                    },
                    new Common.ChartDatasetModel<int>()
                    {
                        Label = "Quiz 3",
                        BackgroundColor = new List<string>()
                        {
                            "rgb(75, 192, 192)"
                        },
                        Data = new List<int>()
                        {
                            6,
                            7,
                            4,
                            3,
                            8
                        },
                        BorderWidth = 0
                    }
                }
            };
            EmployeeFinalResultModel = new EmployeeFinalResultModel()
            {
                Labels = new List<string>()
                {
                   "Social Engineering",
                   "Public Network",
                   "Public Wi-Fi",
                   "Man in the Middle",
                   "Phishing Attack"
                },
                Datasets = new List<Common.ChartDatasetModel<int>>()
                {
                    new Common.ChartDatasetModel<int>()
                    {
                        Label = "Social Engineering",
                        BackgroundColor = new List<string>()
                        {
                            "rgb(44, 229, 116)",
                            "rgb(205, 240, 58)",
                            "rgb(255, 229, 0)",
                            "rgb(255, 150, 0)",
                            "rgb(255, 57, 36)",
                        },
                        Data = new List<int>()
                        {
                            10,
                            8,
                            5,
                            4,
                            2
                        },
                        BorderWidth = 0
                    }
                }
            };
            TopEmployees = new List<TopEmployeeModel>()
            {
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
                new TopEmployeeModel(),
            };
        }
    }
}