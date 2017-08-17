using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_UsocfdiMap : ClassMap<c_Usocfdi> {
        
        public c_UsocfdiMap() {
			Table("c_UsoCFDI");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.AplicaFisica).Column("aplica_fisica").Not.Nullable();
			Map(x => x.AplicaMoral).Column("aplica_moral").Not.Nullable();
        }
    }
}
