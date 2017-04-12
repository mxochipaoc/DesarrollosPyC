using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades
{
    /// <summary>
    /// Manejo de cadenas de caracteres
    /// </summary>
    public static class Cadenas
    {
        /// <summary>
        /// Texto a MD5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToMD5(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString().ToLower();
        }
    }
}
