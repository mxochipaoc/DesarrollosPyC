using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Municipio : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Municipio>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        [DataMember]
        public virtual string IdEstado { get; set; }

        #region Manejo de id compuiesto
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as c_Municipio;
            if (t == null) return false;
            if (Id == t.Id
             && IdEstado == t.IdEstado)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ (Id ?? "").GetHashCode();
            hash = (hash * 397) ^ (IdEstado ?? "").GetHashCode();

            return hash;
        }
        #endregion
    }
}
