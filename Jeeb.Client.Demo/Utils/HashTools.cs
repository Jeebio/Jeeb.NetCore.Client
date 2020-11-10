using System.Security.Cryptography;
using System.Text;

namespace Jeeb.Client.Demo.Utils
{
    public static class HashTools
    {
        public static string Sha1Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using SHA1Managed hash = new SHA1Managed();
            var data = hash.ComputeHash(bytes);
            return data.ToHex();
        }

        public static string Sha256Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using SHA256Managed hash = new SHA256Managed();
            var data = hash.ComputeHash(bytes);
            return data.ToHex();
        }
    }
}