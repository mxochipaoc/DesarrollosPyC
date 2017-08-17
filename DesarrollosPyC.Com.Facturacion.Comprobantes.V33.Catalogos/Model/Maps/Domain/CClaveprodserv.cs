using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model {
    
    public class CClaveprodserv {
        public virtual string Id { get; set; }
        public virtual string Clave { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int IvaTrasladado { get; set; }
        public virtual int IepsTrasladado { get; set; }
        public virtual int Complemento { get; set; }
    }
}
