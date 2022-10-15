using System.ComponentModel.DataAnnotations;

namespace CyberTutorial.Domain.Entities
{
    public class Question
    {
        public string Id { get; set; }
        public string QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Answer> Answers { get; set; }
    }
}