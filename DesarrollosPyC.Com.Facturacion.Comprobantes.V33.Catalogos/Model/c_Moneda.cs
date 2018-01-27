using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {
    
    public class c_Moneda : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_Moneda>
    {
        public virtual string Descripcion { get; set; }
        public virtual int Numerices { get; set; }
        public virtual double PVariacion { get; set; }
    }
}
