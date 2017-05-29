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
            
            // Conversión de datos a cadenas numericas en texto
            string ascii = licencia.A_Ascii.Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);
            string matrix = string.Empty;
            string resultRows = string.Empty;
            string senhueloResult = string.Empty;
            
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

            // Integración de matrz de encriptado
            licencia.M_Encriptado = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Random(n, n);
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    matrix = matrix + " " + licencia.M_Encriptado[r, c];
                }
                matrix = matrix + "\n";
            }
            matrix = matrix.Trim();

            // Paso de datos a matriz de encriptado
            int[] space = M_Ascii.ConvierteANumero(" ", licencia.A_Ascii);
            MathNet.Numerics.LinearAlgebra.Matrix<double> data = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Dense(n, n, (double)space[0]);
            for (int c = 0; c < line0.Length; c++)
                data[0, c] = (double)line0[c];
            for (int c = 0; c < line1.Length; c++)
                data[1, c] = (double)line1[c];
            for (int c = 0; c < line2.Length; c++)
                data[2, c] = (double)line2[c];
            for (int c = 0; c < line3.Length; c++)
                data[3, c] = (double)line3[c];
            for (int c = 0; c < line4.Length; c++)
                data[4, c] = (double)line4[c];
            for (int c = 0; c < line5.Length; c++)
                data[5, c] = (double)line5[c];
            for (int c = 0; c < line6.Length; c++)
                data[6, c] = (double)line6[c];
            for (int c = 0; c < line7.Length; c++)
                data[7, c] = (double)line7[c];
            
            // Encriptado y conversión a texto
            MathNet.Numerics.LinearAlgebra.Matrix<double> reult = data.Multiply(licencia.M_Encriptado);
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    resultRows = resultRows + " " + reult[r, c];
                }
                resultRows = resultRows + "\n";
            }
            resultRows = resultRows.Trim();

            // Señuelos de diccionarios
            string sen1 = M_Ascii.GeneraAlfabeto().Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);
            string sen2 = M_Ascii.GeneraAlfabeto().Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);
            string sen3 = M_Ascii.GeneraAlfabeto().Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);

            MathNet.Numerics.LinearAlgebra.Matrix<double> senhuelo = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Random(n, n);
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    senhueloResult = senhueloResult + " " + senhuelo[r, c];
                }
                senhueloResult = senhueloResult + "\n";
            }
            senhueloResult = senhueloResult.Trim();
            
            builder.AppendLine(sen1);
            builder.AppendLine(ascii);
            builder.AppendLine(sen2);
            builder.AppendLine(sen3);

            foreach (var l in matrix.Split(new char[] { '\n' }))
                builder.AppendLine(l.Trim());
            foreach (var l in senhueloResult.Split(new char[] { '\n' }))
                builder.AppendLine(l.Trim());
            foreach (var l in resultRows.Split(new char[] { '\n' }))
                builder.AppendLine(l.Trim());

            return builder;
        }

        /// <summary>
        /// Recupera los datos de la licencia encriptada
        /// </summary>
        /// <param name="lines">Lineas</param>
        /// <returns>Licencia</returns>
        public static Licencia GeneraLicenciaObj(string[] lines)
        {
            Licencia lic = new Licencia();

            // Recuperación de alfabeto
            List<int> alf = new List<int>();
            //for (int i = 0; i < lines[1].Length; i += 3)
            for (int i = 0; i < 765; i += 3)
                alf.Add(Convert.ToInt32(lines[1].Substring(i, 3)));
            lic.A_Ascii = M_Ascii.GeneraAlfabeto(alf.ToArray());
            int lgth = (lines.Length - 4) / 3;

            // Recuperación de llave de encriptado
            MathNet.Numerics.LinearAlgebra.Matrix<double> key = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Dense(lgth, lgth);
            for (int r = 0; r < lgth; r++)
            {
                string[] vals = lines[r + 4].Split(new char[] { ' ' });
                for (int c = 0; c < lgth; c++)
                {
                    key[r, c] = Convert.ToDouble(vals[c]);
                }
            }
            lic.M_Encriptado = key;

            // Recuperación de datos encriptados
            MathNet.Numerics.LinearAlgebra.Matrix<double> data = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Dense(lgth, lgth);
            for (int r = 0; r < lgth; r++)
            {
                string[] vals = lines[r + 4 + (lgth * 2)].Split(new char[] { ' ' });
                for (int c = 0; c < lgth; c++) 
                {
                    data[r, c] = Convert.ToDouble(vals[c]);
                }
            }

            // Recuperación de datos
            MathNet.Numerics.LinearAlgebra.Matrix<double> iKey = key.Inverse();
            MathNet.Numerics.LinearAlgebra.Matrix<double> rData = data.Multiply(iKey);
            
            lic.EmitidoPor = new EntidadEmisora();
            List<int> line0 = new List<int>();
            List<int> line1 = new List<int>();
            List<int> line2 = new List<int>();
            List<int> line3 = new List<int>();
            List<int> line4 = new List<int>();
            List<int> line5 = new List<int>();
            List<int> line6 = new List<int>();
            List<int> line7 = new List<int>();

            for (int c = 0; c < lgth; c++)
                line0.Add(Convert.ToInt32(rData[0, c]));
            for (int c = 0; c < lgth; c++)
                line1.Add(Convert.ToInt32(rData[1, c]));
            for (int c = 0; c < lgth; c++)
                line2.Add(Convert.ToInt32(rData[2, c]));
            for (int c = 0; c < lgth; c++)
                line3.Add(Convert.ToInt32(rData[3, c]));
            for (int c = 0; c < lgth; c++)
                line4.Add(Convert.ToInt32(rData[4, c]));
            for (int c = 0; c < lgth; c++)
                line5.Add(Convert.ToInt32(rData[5, c]));
            for (int c = 0; c < lgth; c++)
                line6.Add(Convert.ToInt32(rData[6, c]));
            for (int c = 0; c < lgth; c++)
                line7.Add(Convert.ToInt32(rData[7, c]));

            lic.EmitidoPor = new EntidadEmisora();
            lic.Receptor = new Receptor();

            lic.EmitidoPor.Nombre = M_Ascii.ConvierteATexto(line0.ToArray(), lic.A_Ascii);
            lic.A_Licencia = M_Ascii.ConvierteATexto(line1.ToArray(), lic.A_Ascii)
                .Split(new char[] { ',' }).Select(i => (_Aplicacion_Liencia)System.Enum.Parse(typeof(_Aplicacion_Liencia), i)).ToArray();
            lic.Receptor.Rfc = M_Ascii.ConvierteATexto(line2.ToArray(), lic.A_Ascii);
            lic.Receptor.RazonSocial = M_Ascii.ConvierteATexto(line3.ToArray(), lic.A_Ascii);
            lic.FechaEmision = Convert.ToDateTime(M_Ascii.ConvierteATexto(line4.ToArray(), lic.A_Ascii));
            lic.FechaVigencia = Convert.ToDateTime(M_Ascii.ConvierteATexto(line5.ToArray(), lic.A_Ascii));
            string fechaCarga = M_Ascii.ConvierteATexto(line6.ToArray(), lic.A_Ascii);
            if (!string.IsNullOrWhiteSpace(fechaCarga))
                lic.FechaCargaEnSistema = Convert.ToDateTime(fechaCarga);
            lic.DiasOcupado = Convert.ToInt32(M_Ascii.ConvierteATexto(line7.ToArray(), lic.A_Ascii));

            return lic;
        }
    }
}
