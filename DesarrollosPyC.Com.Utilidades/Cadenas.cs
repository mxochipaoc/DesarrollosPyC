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
        /// Texto a B64
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToB64(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            byte[] bytestext = ASCIIEncoding.ASCII.GetBytes(text);
            string b64 = Convert.ToBase64String(bytestext);
            return b64;
        }
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

        /// <summary>
        /// Texto a SHA1
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSHA1(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hash = sha1.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString().ToLower();
        }

        /// <summary>
        /// Texto a SHA256
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSHA256(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hash = sha256.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString().ToLower();
        }

        /// <summary>
        /// Calcula el checksum de una cadena de texto
        /// </summary>
        /// <param name="data">Cadena</param>
        /// <returns>Cehcksum</returns>
        public static string GetChecksum(string data)
        {
            byte[] bytesdata = Encoding.ASCII.GetBytes(data);
            int checksum = 0;
            foreach (byte b in bytesdata)
            {
                checksum += b;
            }

            checksum &= 0xff;
            return checksum.ToString("X2");
        }
    }
}
