using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Licencias.Class
{
    /// <summary>
    /// Propiedaes de la entidad emisora
    /// </summary>
    public class EntidadEmisora
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public System.Drawing.Image Logo { get; set; }

        public EntidadEmisora AutorizadoPor { get; set; }
    }
}
