using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model; 

namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model.Maps {
    
    
    public class CTipodecomprobanteMap : ClassMap<CTipodecomprobante> {
        
        public CTipodecomprobanteMap() {
			Table("c_TipoDeComprobante");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.ValorMin).Column("valor_min").Not.Nullable();
			Map(x => x.ValorMax).Column("valor_max").Not.Nullable();
        }
    }
}
