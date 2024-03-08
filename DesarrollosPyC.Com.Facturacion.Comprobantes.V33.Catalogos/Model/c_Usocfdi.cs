using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Usocfdi : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_UsoCFDI>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        [DataMember]
        public virtual int AplicaFisica { get; set; }
        [DataMember]
        public virtual int AplicaMoral { get; set; }
    }
}
