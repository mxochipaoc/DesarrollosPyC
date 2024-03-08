using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Claveunidad : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_ClaveUnidad>
    {
        [DataMember]
        public virtual string Nombre { get; set; }
        [DataMember]
        public virtual string Simbolo { get; set; }
    }
}
