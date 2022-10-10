using CyberTutorial.WebApp.Common.Interfaces.Services;
using System.Text.Json;

namespace CyberTutorial.WebApp.Services
{
    public class SerializationService : ISerializationService
    {
        public string Serialize(object obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch
            {
                return string.Empty;
            }
        }
        
        public T Deserialize<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions() {});
            }
            catch
            {
                return default;
            }
        }
    }
}