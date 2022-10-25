namespace CyberTutorial.Contracts.Models
{
    public class EmployeeSessionModel
    {
        public string EmployeeSessionId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}