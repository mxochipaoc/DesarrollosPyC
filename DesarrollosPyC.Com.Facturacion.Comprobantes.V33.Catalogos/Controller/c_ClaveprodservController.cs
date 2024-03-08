using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
using NHibernate.Criterion;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_ClaveprodservController : BaseController<c_Claveprodserv>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_ClaveprodservController instance = new c_ClaveprodservController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_ClaveprodservController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_ClaveprodservController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Métodos propios de la clase

        /// <summary>
        /// Recupera la lista de clave producto servicio paginada
        /// </summary>
        /// <param name="filter">Filtro</param>
        /// <param name="size">Tamaño página</param>
        /// <param name="page">Página</param>
        /// <returns>Datos</returns>
        public c_Claveprodserv[] GetList(string filter, int size, int page)
        {
            DetachedCriteria criteria = DetachedCriteria.For<c_Claveprodserv>();
            criteria.Add(Restrictions.Disjunction()
                .Add(Restrictions.InsensitiveLike("Clave", filter, MatchMode.Anywhere))
                .Add(Restrictions.InsensitiveLike("Descripcion", filter, MatchMode.Anywhere))
                .Add(Restrictions.InsensitiveLike("PalabrasSimilares", filter, MatchMode.Anywhere))
            );
            criteria.SetFirstResult(size * page);
            criteria.SetMaxResults(size);

            return criteria.GetExecutableCriteria(_Session)
                .List<c_Claveprodserv>()
                .ToArray();
        }
        #endregion
    }
}
