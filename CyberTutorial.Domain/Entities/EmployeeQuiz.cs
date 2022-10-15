namespace CyberTutorial.Domain.Entities
{
    public class EmployeeQuiz
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string QuizId { get; set; }
        public int Score { get; set; }
        public int NumberOfAttempts { get; set; }
    }
}