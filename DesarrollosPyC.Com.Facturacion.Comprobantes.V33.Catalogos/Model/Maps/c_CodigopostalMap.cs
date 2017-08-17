using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_CodigopostalMap : ClassMap<c_Codigopostal> {
        
        public c_CodigopostalMap() {
			Table("c_CodigoPostal");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.IdEstado).Column("id_estado").Not.Nullable();
			Map(x => x.IdMunicipio).Column("id_municipio");
			Map(x => x.IdLocalidad).Column("id_localidad");
        }
    }
}
