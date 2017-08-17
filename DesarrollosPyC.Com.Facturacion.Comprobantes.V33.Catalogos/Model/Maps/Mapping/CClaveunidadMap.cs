using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model; 

namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model.Maps {
    
    
    public class CClaveunidadMap : ClassMap<CClaveunidad> {
        
        public CClaveunidadMap() {
			Table("c_ClaveUnidad");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Nombre).Column("nombre").Not.Nullable();
			Map(x => x.Simbolo).Column("simbolo").Not.Nullable();
        }
    }
}
