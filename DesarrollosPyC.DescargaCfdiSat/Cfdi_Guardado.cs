using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.DescargaCfdiSat
{
    /// <summary>
    /// Propiedades de Cfddi para su guardado
    /// </summary>
    public enum Cfdi_Guardado : short
    {
        RFC_Emisor,
        RFC_Receptor,
        Anhio,
        Mes,
        Folio_Serie,
        UUID
    }
}
