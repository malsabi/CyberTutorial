namespace CyberTutorial.Contracts.Requests.Attempt
{
    public class AddAttemptRequest
    {
        public string EmployeeId { get; set; }
        public string QuizId { get; set; }
        public string StartedAt { get; set; }
        public string CompletedAt { get; set; }
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public int TotalCorrectAnswers { get; set; }
        public int TotalIncorectAnswers { get; set; }
    }
}