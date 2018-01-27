using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_MunicipioMap : ClassMap<c_Municipio> {
        
        public c_MunicipioMap() {
			Table("c_Municipio");
			LazyLoad();

            CompositeId()
                .KeyProperty(k => k.Clave, "id")
                .KeyProperty(k => k.IdEstado, "id_estado");

            Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
        }
    }
}
