namespace CyberTutorial.Contracts.Models
{
    public class AttemptModel
    {
        public string AttemptId { get; set; }
        public string EmployeeId { get; set; }
        public string QuizId { get; set; }
        public string StartedAt { get; set; }
        public string CompletedAt { get; set; }
        public int Score { get; set; }
        public int TotalCorrectAnswers { get; set; }
        public int TotalIncorectAnswers { get; set; }
    }
}