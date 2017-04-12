using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Controles
{
    /// <summary>
    /// Mestra el estatus del progreso del método de carga
    /// </summary>
    /// <param name="estatus"></param>
    public delegate void BarraProgresoMuestraEstatus(string estatus);

    /// <summary>
    /// Método de carga de datos
    /// </summary>
    /// <param name="estatusProceso">Estatus del proceso de carga</param>
    /// <returns>Datos recuperados</returns>
    public delegate object BarraProgresoMetodoCarga(BarraProgresoMuestraEstatus estatusProceso);
}
