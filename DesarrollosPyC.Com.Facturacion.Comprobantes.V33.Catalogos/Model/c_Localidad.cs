using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Localidad : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Localidad>
    {
        public virtual string Descripcion { get; set; }
        public virtual string IdEstado { get; set; }
    }
}
