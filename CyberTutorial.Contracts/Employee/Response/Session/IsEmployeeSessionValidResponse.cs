﻿namespace CyberTutorial.Contracts.Employee.Response.Session
{
    public class IsEmployeeSessionValidResponse
    {
        public bool IsValid { get; set; }
        public string NewToken { get; set; }
    }
}