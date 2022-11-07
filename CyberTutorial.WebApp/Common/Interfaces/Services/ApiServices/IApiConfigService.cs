namespace CyberTutorial.WebApp.Common.Interfaces.Services.ApiServices
{
    public interface IApiConfigService
    {
        string GetApiEndPoint();

        void SetApiEndPoint(string apiEndPoint);
    }
}