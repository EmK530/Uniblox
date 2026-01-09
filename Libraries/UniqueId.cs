using System;
using System.Text;

namespace Libraries
{
    public static class UniqueId
    {
        private static readonly Random _rng = new Random();
        private const string hexChars = "0123456789abcdef";

        public static string Create()
        {
            var sb = new StringBuilder(32);
            for (int i = 0; i < 32; i++)
            {
                int index = _rng.Next(16);
                sb.Append(hexChars[index]);
            }
            return sb.ToString();
        }
    }
}