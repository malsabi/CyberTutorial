using ErrorOr;
using CyberTutorial.Contracts.Requests.Company;
using CyberTutorial.Contracts.Responses.Company;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface ICompanyService
    {
        public string Token { get; set; }
        public Task<ErrorOr<AddCompanyResponse>> AddCompanyAsync(AddCompanyRequest request);
        public Task<ErrorOr<GetCompaniesResponse>> GetCompaniesAsync();
        public Task<ErrorOr<GetCompanyByIdResponse>> GetCompanyByIdAsync(string companyId);
        public Task<ErrorOr<GetCompanyEmployeesResponse>> GetCompanyEmployeesAsync(string companyId);
        public Task<ErrorOr<GetCompanySessionResponse>> GetCompanySessionAsync(string companyId);
        public Task<ErrorOr<UpdateCompanyResponse>> UpdateCompanyAsync(string companyId, UpdateCompanyRequest request);
        public Task<ErrorOr<UpdateCompanySessionResponse>> UpdateCompanySessionAsync(string companyId, UpdateCompanySessionRequest request);
        public Task<ErrorOr<DeleteCompanyResponse>> DeleteCompanyAsync(string companyId);
    }
}