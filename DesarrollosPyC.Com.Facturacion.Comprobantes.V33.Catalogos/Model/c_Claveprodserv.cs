using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Claveprodserv : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_ClaveProdServ>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        [DataMember]
        public virtual int IvaTrasladado { get; set; }
        [DataMember]
        public virtual int IepsTrasladado { get; set; }
        [DataMember]
        public virtual int Complemento { get; set; }
        [DataMember]
        public virtual string PalabrasSimilares { get; set; }
    }
}
