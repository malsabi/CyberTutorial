using System.ComponentModel.DataAnnotations.Schema;

namespace CyberTutorial.Domain.Entities
{
    public class CompanySession
    {
        [ForeignKey("Company")]
        public string CompanySessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public virtual Company Company { get; set; }
    }
}