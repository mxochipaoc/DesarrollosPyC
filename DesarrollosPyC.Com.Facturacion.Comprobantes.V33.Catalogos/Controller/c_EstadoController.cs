using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
using NHibernate.Criterion;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_EstadoController : BaseController<c_Estado>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_EstadoController instance = new c_EstadoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_EstadoController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_EstadoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Sobre escritura de métodos
        /// <summary>
        /// ObtenEstados por pais
        /// </summary>
        /// <param name="id_pais">Id pais</param>
        /// <returns>Estados</returns>
        public IList<c_Estado> GetList(string id_pais)
        {
            DetachedCriteria criteria = DetachedCriteria.For<c_Estado>();
            criteria.Add(Restrictions.Eq("IdPais", id_pais));

            return criteria.GetExecutableCriteria(_Session)
                .List<c_Estado>();
        }
        #endregion
    }
}
