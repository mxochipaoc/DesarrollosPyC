using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Estado : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Estado>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        [DataMember]
        public virtual string IdPais { get; set; }
    }
}
