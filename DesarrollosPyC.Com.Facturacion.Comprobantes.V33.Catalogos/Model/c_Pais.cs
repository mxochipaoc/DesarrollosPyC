using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Pais : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Pais>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        
        public virtual string MaskCodigoPostal { get; set; }
        public virtual string MaskIdentidadTriburaria { get; set; }
        public virtual string ValidaIdentidadTriburaria { get; set; }
        public virtual string Agrupaciones { get; set; }
    }
}
