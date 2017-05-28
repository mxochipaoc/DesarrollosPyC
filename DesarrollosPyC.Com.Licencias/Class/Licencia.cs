using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Licencias.Class
{
    /// <summary>
    /// Propiedades de las licencias
    /// </summary>
    public class Licencia
    {
        public Guid Id { get; set; }

        public Receptor Receptor { get; set; }
        public EntidadEmisora EmitidoPor { get; set; }

        public DateTime FechaEmision { get; set; }
        public DateTime FechaVigencia { get; set; }
        public DateTime? FechaCargaEnSistema { get; set; }
        public int DiasOcupado { get; set; }
        public _Aplicacion_Liencia[] A_Licencia { get; set; }
        public Licencia LicenciaAnterior { get; set; }

        public Dictionary<int, char> A_Ascii { get; set; }
        public MathNet.Numerics.LinearAlgebra.Matrix<double> M_Encriptado { get; set; }
    }
}
