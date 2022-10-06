namespace CyberTutorial.Application.Common.Interfaces.Services
{
    public interface IHashProvider
    {
        string ApplyHash(string value);

        bool VarifyHash(string value, string hash);
    }
}