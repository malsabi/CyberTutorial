namespace CyberTutorial.Domain.Entities
{
    public class Quiz
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CourseId { get; set; }
        public int MaximumScore { get; set; }
        public int TotalQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime Duration { get; set; }
    }
}