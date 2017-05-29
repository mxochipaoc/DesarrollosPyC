using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Licencias.Managers
{
    /// <summary>
    /// Clase manejadora de los caracteres ascii re ordenados
    /// </summary>
    public static class M_Ascii
    {
        /// <summary>
        /// Genera la lista de identificadores y caracteres aleatorios
        /// </summary>
        /// <returns>Diccionario</returns>
        public static Dictionary<int, char> GeneraAlfabeto()
        {
            Dictionary<int, char> result = new Dictionary<int, char>();
            System.Random rand = new Random();
            int r = 0;
            for (int c = 0; c < 255; c++)
            {
                do
                {
                    r = rand.Next(0, 999);
                } while (result.ContainsKey(r));
                
                result.Add(r, (char)c);
            }

            return result;
        }

        /// <summary>
        /// Genera alfabeto a partir de modelo propuesto
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static Dictionary<int, char> GeneraAlfabeto(int[] dic)
        {
            Dictionary<int, char> result = new Dictionary<int, char>();
            for (int i = 0; i < 255; i++)
            {
                result.Add(dic[i], (char)i);
            }

            return result;
        }

        /// <summary>
        /// Convierte llave a valor y valor a llave
        /// </summary>
        /// <param name="dic">Diccionario original</param>
        /// <returns>Diccionario resultante</returns>
        static Dictionary<char, int> InvierteAlfabeto(Dictionary<int, char> dic)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (var k in dic)
                result.Add(k.Value, k.Key);

            return result;
        }

        /// <summary>
        /// Genera arreglo numérico de cadena de texto
        /// </summary>
        /// <param name="cadena">Cadena a convertir</param>
        /// <param name="dic">Alfabeto</param>
        /// <returns>Arreglo convertido</returns>
        public static int[] ConvierteANumero(string cadena, Dictionary<int, char> dic)
        {
            int[] result = new int[cadena.Length];
            Dictionary<char, int> _dic = InvierteAlfabeto(dic);
            for (int i = 0; i < cadena.Length; i++)
            {
                result[i] = _dic[cadena[i]];
            }

            return result;
        }

        /// <summary>
        /// Convierte un arreglo numerico a su valor en cadena de texto
        /// </summary>
        /// <param name="arreglo">Arreglo</param>
        /// <param name="dic">Alfabeto</param>
        /// <returns>Cadena</returns>
        public static string ConvierteATexto(int[] arreglo, int[] dic)
        {
            StringBuilder result = new StringBuilder();
            Dictionary<int, char> _dic = GeneraAlfabeto(dic);
            for (int i = 0; i < arreglo.Length; i++)
            {
                result.Append(_dic[arreglo[i]]);
            }

            return result.ToString().Trim();
        }

        /// <summary>
        /// Convierte un arreglo numerico a su valor en cadena de texto
        /// </summary>
        /// <param name="arreglo">Arreglo</param>
        /// <param name="dic">Alfabeto</param>
        /// <returns>Cadena</returns>
        public static string ConvierteATexto(int[] arreglo, Dictionary<int, char> dic)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < arreglo.Length; i++)
            {
                result.Append(dic[arreglo[i]]);
            }

            return result.ToString().Trim();
        }
    }
}
