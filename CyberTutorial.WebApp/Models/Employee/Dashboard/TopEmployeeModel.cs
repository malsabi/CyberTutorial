namespace CyberTutorial.WebApp.Models.Employee.Dashboard
{
    public class TopEmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalQuizzes { get; set; }
        public int AverageScore { get; set; }

        public TopEmployeeModel()
        {
            FirstName = "Mohammed";
            LastName = "Ahmed";
            TotalQuizzes = 0;
            AverageScore = 0;
        }
    }
}