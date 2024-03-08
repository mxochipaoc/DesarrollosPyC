using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model
{
    [DataContract]
    public class BaseEntidadExt<TEnum> : BaseEntidad where TEnum : struct
    {
        [DataMember]
        public virtual string Clave { get; set; }

        /// <summary>
        /// Recupera el valor desde el catálogo de CFDi
        /// </summary>
        /// <returns>Valor en catálogo</returns>
        public virtual TEnum Get_EnumElement()
        {
            TEnum value;
            System.Enum.TryParse<TEnum>(Id, out value);
            return value;
        }
    }
}
