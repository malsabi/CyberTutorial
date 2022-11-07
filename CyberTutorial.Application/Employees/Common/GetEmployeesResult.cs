using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Employees.Common
{
    public class GetEmployeesResult
    {
        public ICollection<Employee> Employees { get; set; }
    }
}