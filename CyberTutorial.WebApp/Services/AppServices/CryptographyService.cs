using System.Text;
using System.Security.Cryptography;
using CyberTutorial.WebApp.Common.Consts;
using CyberTutorial.WebApp.Common.Interfaces.Services.AppServices;

namespace CyberTutorial.WebApp.Services.AppServices
{
    public class CryptographyService : ICryptographyService
    {
        private readonly IConfiguration configuration;

        public CryptographyService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Encrypt(string plainText)
        {
            string key = configuration[AppConsts.AESKey];
            string initializationVector = configuration[AppConsts.AESInitializationVector];

            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(initializationVector))
            {
                return string.Empty;
            }

            byte[] encryptedBytes = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetBytes(key);
                aesAlg.IV = GetBytes(initializationVector);
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string cipherText)
        {
            string key = configuration[AppConsts.AESKey];
            string initializationVector = configuration[AppConsts.AESInitializationVector];

            if (string.IsNullOrEmpty(cipherText))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(initializationVector))
            {
                return string.Empty;
            }

            string plaintext = string.Empty;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetBytes(key);
                aesAlg.IV = GetBytes(initializationVector);
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        private byte[] GetBytes(string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }
    }
}