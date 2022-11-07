namespace CyberTutorial.WebApp.Common.Interfaces.Services.AppServices
{
    public interface ICryptographyService
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}