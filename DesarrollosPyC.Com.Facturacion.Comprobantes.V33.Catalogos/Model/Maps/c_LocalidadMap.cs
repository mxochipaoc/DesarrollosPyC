using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_LocalidadMap : ClassMap<c_Localidad> {
        
        public c_LocalidadMap() {
			Table("c_Localidad");
			LazyLoad();

            CompositeId()
                .KeyProperty(k => k.Clave, "id")
                .KeyProperty(k => k.IdEstado, "id_estado");

            Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
        }
    }
}
