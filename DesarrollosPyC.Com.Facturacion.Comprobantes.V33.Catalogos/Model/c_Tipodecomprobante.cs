using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Tipodecomprobante : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_TipoDeComprobante>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        [DataMember]
        public virtual double ValorMin { get; set; }
        [DataMember]
        public virtual double ValorMax { get; set; }
    }
}
