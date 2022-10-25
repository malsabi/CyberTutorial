namespace CyberTutorial.Contracts.Models
{
    public class TopEmployeeModel
    {
        public string TopEmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalQuizzes { get; set; }
        public int AverageScore { get; set; }
    }
}