using CyberTutorial.Domain.Entities;

namespace CyberTutorial.Application.Companies.Common
{
    public class GetCompaniesResult
    {
        public ICollection<Company> Companies { get; set; }
    }
}