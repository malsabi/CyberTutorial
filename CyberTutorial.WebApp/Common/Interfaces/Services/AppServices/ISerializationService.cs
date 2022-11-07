namespace CyberTutorial.WebApp.Common.Interfaces.Services.AppServices
{
    public interface ISerializationService
    {
        string Serialize(object obj);
        T Deserialize<T>(string json);
    }
}