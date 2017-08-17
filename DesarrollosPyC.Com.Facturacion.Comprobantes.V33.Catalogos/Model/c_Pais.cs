using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Pais : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.c_Pais>
    {
        public virtual string Descripcion { get; set; }
        public virtual string MaskCodigoPostal { get; set; }
        public virtual string MaskIdentidadTriburaria { get; set; }
        public virtual string ValidaIdentidadTriburaria { get; set; }
        public virtual string Agrupaciones { get; set; }
    }
}
