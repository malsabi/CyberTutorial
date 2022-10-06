using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface ICookieService
    {
        void SetController(Controller controller);
        void Set<T>(string key, T value);
        T Get<T>(string key);
        void Remove(string key);
    }
}