using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model {
    
    public class CImpuesto {
        public virtual string Id { get; set; }
        public virtual string Clave { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int Retencion { get; set; }
        public virtual int Traslado { get; set; }
        public virtual int Tipo { get; set; }
        public virtual string IdEstado { get; set; }
    }
}
