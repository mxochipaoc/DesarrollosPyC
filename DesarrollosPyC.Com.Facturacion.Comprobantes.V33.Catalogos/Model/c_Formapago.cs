using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model {

    [DataContract]
    public class c_Formapago : BaseEntidadExt<DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos.c_FormaPago>
    {
        [DataMember]
        public virtual string Descripcion { get; set; }
        
        public virtual int Bancalizado { get; set; }
        public virtual int NoOperacion { get; set; }
        public virtual int RfcOrdenante { get; set; }
        public virtual int CuentaOrdenante { get; set; }
        public virtual string MaskCuentaOrdenante { get; set; }
        public virtual int RfcBeneficiario { get; set; }
        public virtual int CuentaBeneficiario { get; set; }
        public virtual string MaskCuentaBeneficiario { get; set; }
        public virtual int CadenaPago { get; set; }
        public virtual int BancoExtranjero { get; set; }
    }
}
