using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model; 

namespace DesarrollosPyC.DesarrollosPyC.Com.Facturacion.Comprobantes.V3.Catalogos.Model.Maps {
    
    
    public class CMunicipioMap : ClassMap<CMunicipio> {
        
        public CMunicipioMap() {
			Table("c_Municipio");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.IdEstado).Column("id_estado").Not.Nullable();
        }
    }
}
