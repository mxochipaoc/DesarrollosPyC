using DesarrollosPyC.Com.Licencias.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Licencias.Managers
{
    /// <summary>
    /// Cifrado y desifrado de licencias
    /// </summary>
    public static class M_Licencia
    {
        /// <summary>
        /// Genera licencia en formato archivo
        /// </summary>
        /// <param name="licencia">Licencia</param>
        /// <returns>Lineas cifradas para archivo</returns>
        public static StringBuilder GeneraLicenciaFile(Licencia licencia)
        {
            StringBuilder builder = new StringBuilder();

            // Integración de alfabeto
            licencia.A_Ascii = M_Ascii.GeneraAlfabeto();
            // Integración de matrz de encriptado
            licencia.M_Encriptado = M_Matriz.GeneraMatriz();

            // Conversión de datos a cadenas numericas en texto
            string ascii = licencia.A_Ascii.Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);
            string matrix = string.Empty;
            string resultRows = string.Empty;
            string senhueloResult = string.Empty;
            int cnt = 0;
            for (int c = 0; c < 8; c++)
            {
                for (int r = 0; r < 8; r++)
                {
                    cnt++;
                    matrix = matrix + " " + licencia.M_Encriptado[r, c];
                    if (cnt == 32)
                    {
                        matrix = matrix + "\n";
                        cnt = 0;
                    }
                }
            }
            matrix = matrix.Trim();

            // Lineas de datos a encriptar
            int[] line0 = M_Ascii.ConvierteANumero(licencia.EmitidoPor.Nombre, licencia.A_Ascii);
            int[] line1 = M_Ascii.ConvierteANumero(licencia.A_Licencia.Select(i=>i.ToString()).Aggregate((a, b)=>a+","+b), licencia.A_Ascii);
            int[] line2 = M_Ascii.ConvierteANumero(licencia.Receptor.Rfc, licencia.A_Ascii);
            int[] line3 = M_Ascii.ConvierteANumero(licencia.Receptor.RazonSocial, licencia.A_Ascii);
            int[] line4 = M_Ascii.ConvierteANumero(licencia.FechaEmision.ToShortDateString(), licencia.A_Ascii);
            int[] line5 = M_Ascii.ConvierteANumero(licencia.FechaVigencia.ToShortDateString(), licencia.A_Ascii);
            int[] line6 = M_Ascii.ConvierteANumero(licencia.FechaCargaEnSistema != null ? licencia.FechaCargaEnSistema.Value.ToShortDateString() : "", licencia.A_Ascii);
            int[] line7 = M_Ascii.ConvierteANumero(licencia.DiasOcupado.ToString(), licencia.A_Ascii);

            // Determinación de longitud máxima
            int n = 0;
            if (line0.Length > n)
                n = line0.Length;
            if (line1.Length > n)
                n = line1.Length;
            if (line2.Length > n)
                n = line2.Length;
            if (line3.Length > n)
                n = line3.Length;
            if (line4.Length > n)
                n = line4.Length;
            if (line5.Length > n)
                n = line5.Length;
            if (line6.Length > n)
                n = line6.Length;
            if (line7.Length > n)
                n = line7.Length;

            // Paso de datos a matriz de encriptado
            MathNet.Numerics.LinearAlgebra.Matrix<double> data = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Dense(8, n, 0);
            for (int c = 0; c < line0.Length; c++)
                data[0, c] = line0[c];
            for (int c = 0; c < line1.Length; c++)
                data[0, c] = line1[c];
            for (int c = 0; c < line2.Length; c++)
                data[0, c] = line2[c];
            for (int c = 0; c < line3.Length; c++)
                data[0, c] = line3[c];
            for (int c = 0; c < line4.Length; c++)
                data[0, c] = line4[c];
            for (int c = 0; c < line5.Length; c++)
                data[0, c] = line5[c];
            for (int c = 0; c < line5.Length; c++)
                data[0, c] = line5[c];
            for (int c = 0; c < line6.Length; c++)
                data[0, c] = line6[c];
            for (int c = 0; c < line7.Length; c++)
                data[0, c] = line7[c];

            // Encriptado y conversión a texto
            MathNet.Numerics.LinearAlgebra.Matrix<double> reult = M_Matriz.GeneraMatrizResultante(data, licencia.M_Encriptado);
            cnt = 0;
            for (int c = 0; c < 8; c++)
            {
                for (int r = 0; r < 8; r++)
                {
                    cnt++;
                    resultRows = resultRows + " " + reult[r, c];
                    if (cnt == 32)
                    {
                        resultRows = matrix + "\n";
                        cnt = 0;
                    }
                }
            }
            resultRows = resultRows.Trim();

            // Señuelos de diccionarios
            string sen1 = M_Ascii.GeneraAlfabeto().Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);
            string sen2 = M_Ascii.GeneraAlfabeto().Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);
            string sen3 = M_Ascii.GeneraAlfabeto().Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);

            MathNet.Numerics.LinearAlgebra.Matrix<double> senhuelo = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Random(8, 8);
            cnt = 0;
            for (int c = 0; c < 8; c++)
            {
                for (int r = 0; r < 8; r++)
                {
                    cnt++;
                    senhueloResult = senhueloResult + " " + reult[r, c];
                    if (cnt == 32)
                    {
                        senhueloResult = matrix + "\n";
                        cnt = 0;
                    }
                }
            }
            senhueloResult = senhueloResult.Trim();

            foreach (var l in sen1.Split(new char[] { '\n' }))
                builder.AppendLine(l);
            foreach (var l in ascii.Split(new char[] { '\n' }))
                builder.AppendLine(ascii);
            foreach (var l in sen2.Split(new char[] { '\n' }))
                builder.AppendLine(sen2);
            foreach (var l in sen3.Split(new char[] { '\n' }))
                builder.AppendLine(sen3);
            foreach (var l in matrix.Split(new char[] { '\n' }))
                builder.AppendLine(matrix);
            foreach (var l in senhueloResult.Split(new char[] { '\n' }))
                builder.AppendLine(senhueloResult);
            foreach (var l in resultRows.Split(new char[] { '\n' }))
                builder.AppendLine(resultRows);

            return builder;
        }
    }
}
