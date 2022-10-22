using System.ComponentModel.DataAnnotations.Schema;

namespace CyberTutorial.Domain.Entities
{
    public class EmployeeSession
    {
        [ForeignKey("Employee")]
        public string EmployeeSessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public virtual Employee Employee { get; set; }
    }
}