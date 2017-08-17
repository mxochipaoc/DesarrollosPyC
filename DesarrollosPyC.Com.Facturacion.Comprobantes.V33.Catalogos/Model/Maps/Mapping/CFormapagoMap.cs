using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model; 

namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model.Maps {
    
    
    public class CFormapagoMap : ClassMap<CFormapago> {
        
        public CFormapagoMap() {
			Table("c_FormaPago");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.Bancalizado).Column("bancalizado").Not.Nullable();
			Map(x => x.NoOperacion).Column("no_operacion").Not.Nullable();
			Map(x => x.RfcOrdenante).Column("rfc_ordenante").Not.Nullable();
			Map(x => x.CuentaOrdenante).Column("cuenta_ordenante").Not.Nullable();
			Map(x => x.MaskCuentaOrdenante).Column("mask_cuenta_ordenante").Not.Nullable();
			Map(x => x.RfcBeneficiario).Column("rfc_beneficiario").Not.Nullable();
			Map(x => x.CuentaBeneficiario).Column("cuenta_beneficiario").Not.Nullable();
			Map(x => x.MaskCuentaBeneficiario).Column("mask_cuenta_beneficiario").Not.Nullable();
			Map(x => x.CadenaPago).Column("cadena_pago").Not.Nullable();
			Map(x => x.BancoExtranjero).Column("banco_extranjero").Not.Nullable();
        }
    }
}
