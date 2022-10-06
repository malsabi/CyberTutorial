namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface IIdentityService
    {
        bool IsEmployeeLoggedIn();

        bool IsCompanyLoggedIn();
    }
}