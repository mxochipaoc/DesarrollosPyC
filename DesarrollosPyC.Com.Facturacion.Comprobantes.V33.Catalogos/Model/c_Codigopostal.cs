using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Codigopostal : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_CodigoPostal>
    {
        [DataMember]
        public virtual string IdEstado { get; set; }
        [DataMember]
        public virtual string IdMunicipio { get; set; }
        [DataMember]
        public virtual string IdLocalidad { get; set; }

        // Propiedades llenadas manualmente
        [DataMember]
        public virtual c_Municipio Municipio { get; set; }
        [DataMember]
        public virtual c_Localidad Localidad { get; set; }
        [DataMember]
        public virtual c_Colonia[] Colonias { get; set; }
    }
}
