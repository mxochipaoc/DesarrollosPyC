using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_MonedaMap : ClassMap<c_Moneda> {
        
        public c_MonedaMap() {
			Table("c_Moneda");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.Numerices).Column("numerices").Not.Nullable();
			Map(x => x.PVariacion).Column("p_variacion").Not.Nullable();
        }
    }
}
