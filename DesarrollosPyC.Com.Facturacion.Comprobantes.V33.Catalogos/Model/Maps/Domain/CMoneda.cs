using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model {
    
    public class CMoneda {
        public virtual string Id { get; set; }
        public virtual string Clave { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int Numerices { get; set; }
        public virtual double PVariacion { get; set; }
    }
}
