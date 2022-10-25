using System.ComponentModel.DataAnnotations.Schema;

namespace CyberTutorial.Domain.Entities
{
    public class TopEmployee
    {
        [ForeignKey("Employee")]
        public string TopEmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalQuizzes { get; set; }
        public int AverageScore { get; set; }
        public Employee Employee { get; set; }
    }
}