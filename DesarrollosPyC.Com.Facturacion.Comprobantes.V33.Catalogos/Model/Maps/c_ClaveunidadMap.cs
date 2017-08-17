using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_ClaveunidadMap : ClassMap<c_Claveunidad> {
        
        public c_ClaveunidadMap() {
			Table("c_ClaveUnidad");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Nombre).Column("nombre").Not.Nullable();
			Map(x => x.Simbolo).Column("simbolo").Not.Nullable();
        }
    }
}
