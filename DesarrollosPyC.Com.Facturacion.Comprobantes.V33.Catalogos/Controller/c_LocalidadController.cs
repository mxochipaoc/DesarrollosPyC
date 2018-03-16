using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
using NHibernate.Criterion;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_LocalidadController : BaseController<c_Localidad>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_LocalidadController instance = new c_LocalidadController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_LocalidadController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_LocalidadController Instance
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
        public c_Localidad GetEntity(string ida, string idb)
        {
            c_Localidad entity = _Session.Get<c_Localidad>(new c_Localidad()
            {
                Id = ida,
                IdEstado = idb
            });

            if (entity == null)
            {
                DetachedCriteria criteria = DetachedCriteria.For<c_Localidad>();
                criteria.Add(Restrictions.Eq("Clave", ida));
                criteria.Add(Restrictions.Eq("IdEstado", idb));
                criteria.SetMaxResults(1);

                entity = criteria.GetExecutableCriteria(_Session).UniqueResult<c_Localidad>();
            }

            return entity;
        }
        #endregion
    }
}
