using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_BancoMap : ClassMap<c_Banco> {
        
        public c_BancoMap() {
			Table("c_Banco");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.NombreRazonSocial).Column("nombre_razon_social").Not.Nullable();
        }
    }
}
