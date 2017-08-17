using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Tipodecomprobante : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.c_TipoDeComprobante>
    {
        public virtual string Descripcion { get; set; }
        public virtual double ValorMin { get; set; }
        public virtual double ValorMax { get; set; }
    }
}
