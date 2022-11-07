using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services.AppServices;

namespace CyberTutorial.WebApp.Services.AppServices
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISerializationService serializationService;
        private readonly ICryptographyService cryptographyService;

        public CookieService(IHttpContextAccessor httpContextAccessor, ISerializationService serializationService, ICryptographyService cryptographyService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.serializationService = serializationService;
            this.cryptographyService = cryptographyService;
        }

        public T Get<T>(string key)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                string value = httpContextAccessor.HttpContext.Request.Cookies[key];
                if (value != null)
                {
                    return serializationService.Deserialize<T>(value);
                }
            }
            return default;
        }

        public T GetDecrypted<T>(string key)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                string value = httpContextAccessor.HttpContext.Request.Cookies[key];
                if (value != null)
                {
                    string decryptedValue = cryptographyService.Decrypt(value);
                    if (string.IsNullOrEmpty(decryptedValue))
                    {
                        return default;
                    }
                    return serializationService.Deserialize<T>(decryptedValue);
                }
            }
            return default;
        }

        public void Remove(string key)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
            }
        }

        public void Set<T>(string key, T value)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                httpContextAccessor.HttpContext.Response.Cookies.Append(key, serializationService.Serialize(value), new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(AppConsts.CookieExpirationDays),
                    HttpOnly = false,
                    IsEssential = true
                });
            }
        }

        public void SetEncrypted<T>(string key, T value)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                string jsonContent = serializationService.Serialize(value);
                string encryptedValue = cryptographyService.Encrypt(jsonContent);
                httpContextAccessor.HttpContext.Response.Cookies.Append(key, encryptedValue, new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(AppConsts.CookieExpirationDays),
                    HttpOnly = false,
                    IsEssential = true
                });
            }
        }
    }
}