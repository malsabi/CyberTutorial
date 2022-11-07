using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.Employee
{
    public class GetEmployeesResponse
    {
        public ICollection<EmployeeModel> Employees { get; set; }
    }
}