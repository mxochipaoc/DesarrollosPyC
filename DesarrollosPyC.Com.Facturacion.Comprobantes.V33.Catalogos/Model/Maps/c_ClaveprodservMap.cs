using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_ClaveprodservMap : ClassMap<c_Claveprodserv> {
        
        public c_ClaveprodservMap() {
			Table("c_ClaveProdServ");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.IvaTrasladado).Column("iva_trasladado").Not.Nullable();
			Map(x => x.IepsTrasladado).Column("ieps_trasladado").Not.Nullable();
			Map(x => x.Complemento).Column("complemento").Not.Nullable();
            Map(x => x.PalabrasSimilares).Column("palabras_similares");
        }
    }
}
