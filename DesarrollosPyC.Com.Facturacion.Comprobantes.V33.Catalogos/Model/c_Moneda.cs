using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Moneda : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Moneda>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        [DataMember]
        public virtual int Numerices { get; set; }
        [DataMember]
        public virtual double PVariacion { get; set; }
    }
}
