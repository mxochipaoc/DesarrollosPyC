using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model {
    
    public class CPais {
        public virtual string Id { get; set; }
        public virtual string Clave { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string MaskCodigoPostal { get; set; }
        public virtual string MaskIdentidadTriburaria { get; set; }
        public virtual string ValidaIdentidadTriburaria { get; set; }
        public virtual string Agrupaciones { get; set; }
    }
}
