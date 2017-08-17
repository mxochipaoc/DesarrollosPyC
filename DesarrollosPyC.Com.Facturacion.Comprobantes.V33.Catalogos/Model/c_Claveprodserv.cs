using System;
using System.Text;
using System.Collections.Generic;


namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    public class c_Claveprodserv : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.c_ClaveProdServ>
    {
        public virtual string Descripcion { get; set; }
        public virtual int IvaTrasladado { get; set; }
        public virtual int IepsTrasladado { get; set; }
        public virtual int Complemento { get; set; }
    }
}
