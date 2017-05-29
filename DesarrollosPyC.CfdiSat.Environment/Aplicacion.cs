using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.CfdiSat.Environment
{
    /// <summary>
    /// Variables státicas de la aplicación
    /// </summary>
    public static class Aplicacion
    {
        /// <summary>
        /// Directorio de licencias
        /// </summary>
        public static string DirectorioLicencias { get; set; }

        /// <summary>
        /// Licencias cargadas a sistema
        /// </summary>
        public static DesarrollosPyC.Com.Licencias.Class.Licencia[] Licencias { get; set; }
        
        /// <summary>
        /// Licencia de trabajo seleccionada
        /// </summary>
        public static DesarrollosPyC.Com.Licencias.Class.Licencia LicenciaSeleccionada { get; set; }
    }
}
