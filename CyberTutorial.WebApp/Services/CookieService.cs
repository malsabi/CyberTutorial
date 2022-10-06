using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CyberTutorial.WebApp.Services
{
    public class CookieService : ICookieService
    {
        private readonly ISerializationService serializationService;

        private Controller controller;

        public CookieService(ISerializationService serializationService)
        {
            this.serializationService = serializationService;
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public T Get<T>(string key)
        {
            if (controller != null)
            {
                string value = controller.Request.Cookies[key];
                if (value != null)
                {
                    return serializationService.Deserialize<T>(value);
                }
            }
            return default; 
        }

        public void Remove(string key)
        {
            if (controller != null)
            {
                controller.Response.Cookies.Delete(key);
            }
        }

        public void Set<T>(string key, T value)
        {
            if (controller != null)
            {
                controller.Response.Cookies.Append(key, serializationService.Serialize(value), new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(AppConsts.CookieExpirationDays),
                    HttpOnly = false,
                    IsEssential = true
                });
            }
        }
    }
}