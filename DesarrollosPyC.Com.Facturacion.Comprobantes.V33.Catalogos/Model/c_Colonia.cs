using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Colonia : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Colonia>
    {
        public virtual string Descripcion { get; set; }
        public virtual string IdCodigoPostal { get; set; }
    }
}
