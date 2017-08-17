using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_RiesgopuestoMap : ClassMap<c_Riesgopuesto> {
        
        public c_RiesgopuestoMap() {
			Table("c_RiesgoPuesto");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
        }
    }
}
