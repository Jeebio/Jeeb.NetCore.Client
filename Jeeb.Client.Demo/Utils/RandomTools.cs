using System;
using System.Security.Cryptography;
using System.Text;

namespace Jeeb.Client.Demo.Utils
{
    public static class RandomTools
    {
        private static readonly char[] Chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % Chars.Length;

                result.Append(Chars[idx]);
            }

            return result.ToString();
        }
    }
}