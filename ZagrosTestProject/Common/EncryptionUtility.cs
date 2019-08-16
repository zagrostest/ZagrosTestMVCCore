using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZagrosTestProject.Common
{
    public static class EncryptionUtility
    {
        public static string HashSHA256(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
