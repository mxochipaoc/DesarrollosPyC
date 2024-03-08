using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model
{
    [DataContract]
    public class BaseEntidad
    {
        [DataMember]
        public virtual string Id { get; set; }
    }
}
