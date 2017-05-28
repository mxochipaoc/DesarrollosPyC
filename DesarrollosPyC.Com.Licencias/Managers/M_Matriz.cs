using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Licencias.Managers
{
    /// <summary>
    /// Generación de matrices de encriptado y desencriptado
    /// </summary>
    public static class M_Matriz
    {
        /// <summary>
        /// Genera matriz con valores aleatorios
        /// </summary>
        /// <returns>Matriz</returns>
        public static MathNet.Numerics.LinearAlgebra.Matrix<double> GeneraMatriz()
        {
            return MathNet.Numerics.LinearAlgebra.Matrix<double>.Build.Random(8, 8);
        }

        /// <summary>
        /// Genera una matriz resultante
        /// </summary>
        /// <param name="ma">Matriz de datos</param>
        /// <param name="mk">Matriz llave</param>
        /// <returns>Resultante</returns>
        public static MathNet.Numerics.LinearAlgebra.Matrix<double> GeneraMatrizResultante(MathNet.Numerics.LinearAlgebra.Matrix<double> ma, MathNet.Numerics.LinearAlgebra.Matrix<double> mk)
        {
            return MathNet.Numerics.LinearAlgebra.Matrix<double>.op_DotMultiply(ma, mk);
            //return ma.Multiply(mk);
        }

        /// <summary>
        /// Genera la matriz de datos original
        /// </summary>
        /// <param name="md">Matriz de datos</param>
        /// <param name="mk">MAtriz llave</param>
        /// <returns>Original</returns>
        public static MathNet.Numerics.LinearAlgebra.Matrix<double> GeneraMatrizOriginal(MathNet.Numerics.LinearAlgebra.Matrix<double> md, MathNet.Numerics.LinearAlgebra.Matrix<double> mk)
        {
            MathNet.Numerics.LinearAlgebra.Matrix<double> mi = mk.Inverse();
            return md.Multiply(mi);
        }
    }
}
