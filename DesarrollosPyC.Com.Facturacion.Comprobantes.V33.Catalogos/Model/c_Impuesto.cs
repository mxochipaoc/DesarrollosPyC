using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Impuesto : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Impuesto>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        [DataMember]
        public virtual int Retencion { get; set; }
        [DataMember]
        public virtual int Traslado { get; set; }
        [DataMember]
        public virtual int Tipo { get; set; }
        [DataMember]
        public virtual string IdEstado { get; set; }
    }
}
