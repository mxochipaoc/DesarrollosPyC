using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Regimenfiscal : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_RegimenFiscal>
    {
        public virtual string Descripcion { get; set; }
        public virtual int Fisica { get; set; }
        public virtual int Moral { get; set; }
    }
}
