using ErrorOr;
using CyberTutorial.Contracts.Requests.Authentication;
using CyberTutorial.Contracts.Responses.Authentication;

namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IAuthenticationService
    {
        Task<ErrorOr<RegisterCompanyResponse>> RegisterCompanyAsync(RegisterCompanyRequest request);
        Task<ErrorOr<RegisterEmployeeResponse>> RegisterEmployeeAsync(RegisterEmployeeRequest request);
        Task<ErrorOr<LoginCompanyResponse>> LoginCompanyAsync(LoginCompanyRequest request);
        Task<ErrorOr<LoginEmployeeResponse>> LoginEmployeeAsync(LoginEmployeeRequest request);
        Task<ErrorOr<LogoutCompanyResponse>> LogoutCompanyAsync(LogoutCompanyRequest request);
        Task<ErrorOr<LogoutEmployeeResponse>> LogoutEmployeeAsync(LogoutEmployeeRequest request);
    }
}