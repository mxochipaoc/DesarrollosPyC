using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Colonia : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Colonia>
    {
        public virtual string Descripcion { get; set; }
        public virtual string IdCodigoPostal { get; set; }

        #region Manejo de id compuiesto
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as c_Colonia;
            if (t == null) return false;
            if (Id == t.Id
             && IdCodigoPostal == t.IdCodigoPostal)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ (Id ?? "").GetHashCode();
            hash = (hash * 397) ^ (IdCodigoPostal ?? "").GetHashCode();

            return hash;
        }
        #endregion
    }
}
