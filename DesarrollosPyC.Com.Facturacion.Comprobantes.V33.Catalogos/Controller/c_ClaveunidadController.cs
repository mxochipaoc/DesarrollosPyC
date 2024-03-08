using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
using NHibernate.Criterion;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_ClaveunidadController : BaseController<c_Claveunidad>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_ClaveunidadController instance = new c_ClaveunidadController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_ClaveunidadController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_ClaveunidadController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region M�todos propios de la clase

        /// <summary>
        /// Recupera la lista de clave de unidad paginada
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="size">Tama�o p�gina</param>
        /// <param name="page">P�gina</param>
        /// <returns>Datos</returns>
        public c_Claveunidad[] GetList(string filter, int size, int page)
        {
            DetachedCriteria criteria = DetachedCriteria.For<c_Claveunidad>();
            criteria.Add(Restrictions.Disjunction()
                .Add(Restrictions.InsensitiveLike("Clave", filter, MatchMode.Anywhere))
                .Add(Restrictions.InsensitiveLike("Nombre", filter, MatchMode.Anywhere))
            );
            criteria.SetFirstResult(size * page);
            criteria.SetMaxResults(size);

            return criteria.GetExecutableCriteria(_Session)
                .List<c_Claveunidad>()
                .ToArray();
        }
        #endregion
    }
}
