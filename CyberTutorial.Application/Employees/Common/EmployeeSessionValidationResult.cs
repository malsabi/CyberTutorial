namespace CyberTutorial.Application.Employees.Common
{
    public class EmployeeSessionValidationResult
    {
        public bool IsValid { get; set; }
        public string NewToken { get; set; }
    }
}