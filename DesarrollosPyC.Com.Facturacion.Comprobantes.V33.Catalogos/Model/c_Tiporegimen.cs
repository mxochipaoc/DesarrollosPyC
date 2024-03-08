using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Tiporegimen : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.c_TipoRegimen>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
    }
}
