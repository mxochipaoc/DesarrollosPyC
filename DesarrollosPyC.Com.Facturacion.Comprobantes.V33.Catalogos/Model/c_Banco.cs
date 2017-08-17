using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model
{
    
    public class c_Banco : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.c_Banco>
    {
        public virtual string Descripcion { get; set; }
        public virtual string NombreRazonSocial { get; set; }
    }
}
