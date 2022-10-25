using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Companies.Common
{
    public class GetCompanyEmployeesResult
    {
        public ICollection<Employee> Employees { get; set; }
    }
}