using System.Security.Cryptography;
using System.Text;

namespace Food_Journal.Shared.Helpers
{
    public static class CryptoHelper
    {
        /// <summary>
        /// Salts and hashes a password to be used to store on the server.
        /// </summary>
        /// <param name="password">The unencrypted password to hash</param>
        /// <returns>Returns a salted + hashed password string</returns>
        public static string HashPassword(string password)
        {
            var saltedPassword = _SaltPassword(password);
            var sha1 = SHA1CryptoServiceProvider.Create();
            var bytePassword = new UTF8Encoding().GetBytes(saltedPassword);
            var hashBytes = sha1.ComputeHash(bytePassword);

            // https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
            var hashedPassword = new StringBuilder();
            foreach (var hashByte in hashBytes)
            {
                hashedPassword.Append(hashByte.ToString("x2"));
            }

            return hashedPassword.ToString();
        }

        static string _SaltPassword(string password)
        {
            return $"S95-{password}.FOOD.{password[0]}/a9";
        }
    }
}
