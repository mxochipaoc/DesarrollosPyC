using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
using NHibernate.Criterion;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_MunicipioController : BaseController<c_Municipio>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_MunicipioController instance = new c_MunicipioController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_MunicipioController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_MunicipioController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Sobre escritura de métodos
        /// <summary>
        /// Recupera un elemento
        /// </summary>
        /// <param name="ida">Id a</param>
        /// <param name="adb">Id b</param>
        /// <returns></returns>
        public c_Municipio GetEntity(string ida, string idb)
        {
            c_Municipio entity = _Session.Get<c_Municipio>(new c_Municipio()
            {
                Id = ida,
                IdEstado = idb
            });

            if (entity == null)
            {
                DetachedCriteria criteria = DetachedCriteria.For<c_Municipio>();
                criteria.Add(Restrictions.Eq("Clave", ida));
                criteria.Add(Restrictions.Eq("IdEstado", idb));
                criteria.SetMaxResults(1);

                entity = criteria.GetExecutableCriteria(_Session).UniqueResult<c_Municipio>();
            }

            return entity;
        }
        #endregion
    }
}
