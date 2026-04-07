using System.Security.Cryptography;
using System.Text;

namespace RepairFlow.Models
{
  
    public static class PasswordHelper
    {
        public static string Hash(string password)
        {
            using var sha = SHA256.Create();
            byte[] bytes  = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();
        }
        public static bool Verify(string inputPassword, string storedHash)
            => Hash(inputPassword) == storedHash;
    }
}
