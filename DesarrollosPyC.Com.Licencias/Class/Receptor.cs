using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Licencias.Class
{
    /// <summary>
    /// Propiedades del receptor de la licencia
    /// </summary>
    public class Receptor
    {
        public Guid Id { get; set; }

        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
