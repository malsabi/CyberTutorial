﻿namespace CyberTutorial.Domain.Entities
{
    public class EmployeeSession
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string TimeCreated { get; set; }
        public string ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}