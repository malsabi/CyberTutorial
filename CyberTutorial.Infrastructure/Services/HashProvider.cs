using System.Text;
using System.Security.Cryptography;
using CyberTutorial.Application.Common.Interfaces.Services;

namespace CyberTutorial.Infrastructure.Services
{
    public class HashProvider : IHashProvider
    {
        public string ApplyHash(string value)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(value));
                return BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
            }
        }

        public bool VarifyHash(string hash, string value)
        {
            return ApplyHash(value) == hash;
        }
    }
}