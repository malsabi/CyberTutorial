using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Common.Interfaces.Services
{
    public interface ICookieService
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
        void SetEncrypted<T>(string key, T value);
        T GetDecrypted<T>(string key);
        void Remove(string key);
    }
}