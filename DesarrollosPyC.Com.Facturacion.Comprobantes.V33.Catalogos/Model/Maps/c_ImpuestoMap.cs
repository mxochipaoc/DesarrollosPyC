using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_ImpuestoMap : ClassMap<c_Impuesto> {
        
        public c_ImpuestoMap() {
			Table("c_Impuesto");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.Retencion).Column("retencion").Not.Nullable();
			Map(x => x.Traslado).Column("traslado").Not.Nullable();
			Map(x => x.Tipo).Column("tipo").Not.Nullable();
			Map(x => x.IdEstado).Column("id_estado");
        }
    }
}
