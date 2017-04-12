using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades
{
    /// <summary>
    /// Clase utilitaria de manejo de archivos
    /// </summary>
    public static class Archivos
    {
        /// <summary>
        /// Convierte un archivo a base 64
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <returns></returns>
        public static string ArchivoToB64(string archivo)
        {
            if (System.IO.File.Exists(archivo))
            {
                byte[] file = System.IO.File.ReadAllBytes(archivo);
                return Convert.ToBase64String(file);
            }
            return string.Empty;
        }
        /// <summary>
        /// Convierte una cadena en base 64 a archivo
        /// </summary>
        /// <param name="b64">Base 64</param>
        /// <param name="ruta">Ruta</param>
        /// <returns>Ruta de archivo guardado</returns>
        public static string Base64ToArchivo(string b64, string ruta)
        {
            byte[] file = Convert.FromBase64String(b64);
            System.IO.File.WriteAllBytes(ruta, file);
            return ruta;
        }
        /// <summary>
        /// Convierte una cadena en b64 a imagen
        /// </summary>
        /// <param name="b64"></param>
        /// <returns></returns>
        public static System.Drawing.Image ObtenImagenByB64(string b64)
        {
            if (string.IsNullOrEmpty(b64))
                return null;
            using (System.IO.Stream stream = new System.IO.MemoryStream())
            {
                byte[] file = Convert.FromBase64String(b64);
                stream.Write(file, 0, file.Length);
                stream.Position = 0;

                return System.Drawing.Bitmap.FromStream(stream);
            }
        }
        /// <summary>
        /// REcupera la base 64 de una imagen
        /// </summary>
        /// <param name="image">Imagen</param>
        /// <returns></returns>
        public static string ImagenToB64(System.Drawing.Image image)
        {
            byte[] bytearray;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                bytearray = ms.ToArray();
            }
            return Convert.ToBase64String(bytearray);
        }
    }
}
