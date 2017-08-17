using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Impuesto : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.c_Impuesto>
    {
        public virtual string Descripcion { get; set; }
        public virtual int Retencion { get; set; }
        public virtual int Traslado { get; set; }
        public virtual int Tipo { get; set; }
        public virtual string IdEstado { get; set; }
    }
}