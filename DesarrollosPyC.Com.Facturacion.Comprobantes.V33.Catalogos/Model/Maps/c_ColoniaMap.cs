using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_ColoniaMap : ClassMap<c_Colonia> {
        
        public c_ColoniaMap() {
			Table("c_Colonia");
			LazyLoad();

            CompositeId()
                .KeyProperty(k => k.Id, "id")
                .KeyProperty(k => k.IdCodigoPostal, "id_codigo_postal");
            
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
        }
    }
}
