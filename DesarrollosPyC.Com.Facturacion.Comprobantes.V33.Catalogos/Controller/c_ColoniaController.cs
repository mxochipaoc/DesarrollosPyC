using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
using NHibernate.Criterion;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_ColoniaController : BaseController<c_Colonia>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_ColoniaController instance = new c_ColoniaController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_ColoniaController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_ColoniaController Instance
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
        public c_Colonia GetEntity(string ida, string idb)
        {
            c_Colonia entity = _Session.Get<c_Colonia>(new c_Colonia()
            {
                Id = ida,
                IdCodigoPostal = idb
            });

            if (entity == null)
            {
                DetachedCriteria criteria = DetachedCriteria.For<c_Colonia>();
                criteria.Add(Restrictions.Eq("Clave", ida));
                criteria.Add(Restrictions.Eq("IdCodigoPostal", idb));
                criteria.SetMaxResults(1);

                entity = criteria.GetExecutableCriteria(_Session).UniqueResult<c_Colonia>();
            }

            return entity;
        }

        /// <summary>
        /// Recupera colonia por código postal
        /// </summary>
        /// <param name="codigo_postal">Código postal</param>
        /// <returns>Colonia</returns>
        public c_Colonia[] GetEntitiesByCodigoPostal(string codigo_postal)
        {
            DetachedCriteria criteria = DetachedCriteria.For<c_Colonia>();
            criteria.Add(Restrictions.Eq("IdCodigoPostal", codigo_postal));

            return criteria.GetExecutableCriteria(_Session).List<c_Colonia>()
                .ToArray();
        }
        #endregion
    }
}
