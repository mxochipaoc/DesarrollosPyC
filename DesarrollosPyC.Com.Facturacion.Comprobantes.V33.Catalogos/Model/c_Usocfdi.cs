using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    public class c_Usocfdi : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_UsoCFDI>
    {
        public virtual string Descripcion { get; set; }
        public virtual int AplicaFisica { get; set; }
        public virtual int AplicaMoral { get; set; }
    }
}
