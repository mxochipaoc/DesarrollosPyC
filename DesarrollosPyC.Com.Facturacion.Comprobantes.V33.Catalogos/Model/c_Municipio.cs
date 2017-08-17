using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Municipio : BaseEntidad {
        public virtual string Clave { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string IdEstado { get; set; }
    }
}
