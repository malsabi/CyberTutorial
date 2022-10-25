using CyberTutorial.Contracts.Models;

namespace CyberTutorial.Contracts.Responses.Company
{
    public class GetCompaniesResponse
    {
        public ICollection<CompanyModel> Companies { get; set; }
    }
}