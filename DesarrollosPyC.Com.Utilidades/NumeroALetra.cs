using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades
{
    /// <summary>
    /// Convierte un nuemero a letra
    /// </summary>
    public static class NumeroALetra
    {
        /// <summary>
        /// Principal de conversiónd e numero a letra
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="superFijo">Superfijo</param>
        /// <returns>En letra</returns>
        public static string GeneraNumeroALetra(double numero, string superFijo)
        {
            // Lanzado de método recursivo
            long entero = (long)numero;
            double decimales = numero - (double)entero;

            string result = ALetra(entero);
            result = (result + " " + superFijo).Trim() + " " + Math.Round(decimales * 100) + "/100";
            return result;
        }

        /// <summary>
        /// Método recursivo de conversión de numero a letra
        /// </summary>
        /// <param name="entero">Número entero</param>
        /// <returns></returns>
        static string ALetra(long entero)
        {
            string result = "";

            if (entero == 0)
                result = "CERO";
            else if (entero == 1)
                result = "UNO";
            else if (entero == 2)
                result = "DOS";
            else if (entero == 3)
                result = "TRES";
            else if (entero == 4)
                result = "CUATRO";
            else if (entero == 5)
                result = "CINCO";
            else if (entero == 6)
                result = "SEIS";
            else if (entero == 7)
                result = "SIETE";
            else if (entero == 8)
                result = "OCHO";
            else if (entero == 9)
                result = "NUEVE";
            else if (entero == 10)
                result = "DIEZ";
            else if (entero == 11)
                result = "ONCE";
            else if (entero == 12)
                result = "DOCE";
            else if (entero == 13)
                result = "TRECE";
            else if (entero == 14)
                result = "CATORCE";
            else if (entero == 15)
                result = "QUINCE";
            else if (entero > 15 && entero < 20)
                result = "DIEZ " + ALetra(entero - 10);
            else if (entero == 20)
                result = "VEINTE";
            else if (entero > 20 && entero < 30)
                result = "VEINTI" + ALetra(entero - 20);
            else if (entero < 100)
            {
                long dif = 0;
                if (entero < 40)
                {
                    dif = entero - 30;
                    result = "TREINTA";
                }
                else if (entero < 50)
                {
                    dif = entero - 40;
                    result = "CUARENTA";
                }
                else if (entero < 60)
                {
                    dif = entero - 50;
                    result = "CINCUENTA";
                }
                else if (entero < 70)
                {
                    dif = entero - 60;
                    result = "SESENTA";
                }
                else if (entero < 80)
                {
                    dif = entero - 70;
                    result = "SETENTA";
                }
                else if (entero < 90)
                {
                    dif = entero - 80;
                    result = "OCHENTA";
                }
                else if (entero < 100)
                {
                    dif = entero - 90;
                    result = "NOVENTA";
                }

                if (dif > 0)
                    result = result + " Y " + ALetra(dif);
            }
            else if (entero == 100)
                result = "CIEN";
            else if (entero < 1000)
            {
                long centena = entero / 100;
                long dif = entero - (centena * 100);

                switch ((int)centena)
                {
                    case 1: result = "CIENTO";
                        break;
                    case 5: result = "QUINIENTOS";
                        break;
                    case 7: result = "SETECIENTOS";
                        break;
                    case 9: result = "NOVECIENTOS";
                        break;
                    default: result = ALetra(centena) + "CIENTOS";
                        break;
                }

                if (dif > 0)
                    result = result + " " + ALetra(dif);
            }
            else if (entero < 1000000)
            {
                long millar = entero / 1000;
                long dif = entero - (millar * 1000);

                if (millar == 1)
                    result = "UN MIL";
                else
                    result = ALetra(millar) + " MIL";

                if (dif > 0)
                    result = result + " " + ALetra(dif);
            }
            else if (entero < 100000000)
            {
                long millon = entero / 1000000;
                long dif = entero - (millon * 1000000);

                if (millon == 1)
                    result = "UN MILLON";
                else
                    result = ALetra(millon) + "MILLON";

                if (dif > 0)
                    result = result + " " + ALetra(dif);
            }

            return result;
        }
    }
}
