using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.Company
{
    public class GetCompanyEmployeesResponse
    {
        public ICollection<EmployeeModel> Employees { get; set; }
    }
}