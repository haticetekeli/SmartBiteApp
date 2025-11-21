using System.Security.Cryptography;

namespace SmartBite.Core.Helpers.Utils
{
    public static class PasswordManager
    {
        private const int WorkFactor = 12; // BCrypt için güvenli bir work factor

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
