using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model; 

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.Maps {
    
    
    public class c_PaisMap : ClassMap<c_Pais> {
        
        public c_PaisMap() {
			Table("c_Pais");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Assigned().Column("id");
			Map(x => x.Clave).Column("clave").Not.Nullable();
			Map(x => x.Descripcion).Column("descripcion").Not.Nullable();
			Map(x => x.MaskCodigoPostal).Column("mask_codigo_postal").Not.Nullable();
			Map(x => x.MaskIdentidadTriburaria).Column("mask_identidad_triburaria").Not.Nullable();
			Map(x => x.ValidaIdentidadTriburaria).Column("valida_identidad_triburaria").Not.Nullable();
			Map(x => x.Agrupaciones).Column("agrupaciones").Not.Nullable();
        }
    }
}
