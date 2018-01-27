using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Codigopostal : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_CodigoPostal>
    {
        public virtual string IdEstado { get; set; }
        public virtual string IdMunicipio { get; set; }
        public virtual string IdLocalidad { get; set; }
    }
}
