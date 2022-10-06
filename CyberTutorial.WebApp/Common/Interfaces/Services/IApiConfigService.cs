namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface IApiConfigService
    {
        string GetApiEndPoint();

        void SetApiEndPoint(string apiEndPoint);
    }
}