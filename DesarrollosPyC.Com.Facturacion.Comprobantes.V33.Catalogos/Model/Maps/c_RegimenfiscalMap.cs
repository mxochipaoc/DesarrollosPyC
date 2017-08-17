using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_RegimenfiscalMap : ClassMap<c_Regimenfiscal> {
        
        public c_RegimenfiscalMap() {
			Table("c_RegimenFiscal");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.Fisica).Column("fisica").Not.Nullable();
			Map(x => x.Moral).Column("moral").Not.Nullable();
        }
    }
}
