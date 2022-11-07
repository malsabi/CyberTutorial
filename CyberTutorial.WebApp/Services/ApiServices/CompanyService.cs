using ErrorOr;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.Contracts.Requests.Company;
using CyberTutorial.Contracts.Responses.Company;
using CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices;

namespace CyberTutorial.WebApp.Services.ApiServices
{
    public class CompanyService : ICompanyService
    {
        private readonly IClientApiService clientApiService;

        public string Token { get; set; }

        public CompanyService(IClientApiService clientApiService)
        {
            this.clientApiService = clientApiService;
        }

        public async Task<ErrorOr<AddCompanyResponse>> AddCompanyAsync(AddCompanyRequest request)
        {
            return await clientApiService.PostAsync<AddCompanyRequest, AddCompanyResponse>(request, ApiConsts.Company.Add, Token);
        }

        public async Task<ErrorOr<GetCompaniesResponse>> GetCompaniesAsync()
        {
            return await clientApiService.GetAsync<GetCompaniesResponse>(ApiConsts.Company.GetAll, Token);
        }

        public async Task<ErrorOr<GetCompanyByIdResponse>> GetCompanyByIdAsync(string companyId)
        {
            return await clientApiService.GetAsync<GetCompanyByIdResponse>(ApiConsts.Company.Get, Token, companyId);
        }

        public async Task<ErrorOr<GetCompanyEmployeesResponse>> GetCompanyEmployeesAsync(string companyId)
        {
            return await clientApiService.GetAsync<GetCompanyEmployeesResponse>(ApiConsts.Company.GetAllEmployees, Token, companyId);
        }

        public async Task<ErrorOr<GetCompanySessionResponse>> GetCompanySessionAsync(string companyId)
        {
            return await clientApiService.GetAsync<GetCompanySessionResponse>(ApiConsts.Company.GetSession, Token, companyId);
        }

        public async Task<ErrorOr<UpdateCompanyResponse>> UpdateCompanyAsync(string companyId, UpdateCompanyRequest request)
        {
            return await clientApiService.PutAsync<UpdateCompanyRequest, UpdateCompanyResponse>(request, ApiConsts.Company.Update, Token, companyId);
        }

        public async Task<ErrorOr<UpdateCompanySessionResponse>> UpdateCompanySessionAsync(string companyId, UpdateCompanySessionRequest request)
        {
            return await clientApiService.PutAsync<UpdateCompanySessionRequest, UpdateCompanySessionResponse>(request, ApiConsts.Company.UpdateSession, Token, companyId);
        }

        public async Task<ErrorOr<DeleteCompanyResponse>> DeleteCompanyAsync(string companyId)
        {
            return await clientApiService.DeleteAsync<DeleteCompanyResponse>(ApiConsts.Company.Delete, Token, companyId);
        }
    }
}