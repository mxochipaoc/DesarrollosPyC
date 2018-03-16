using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
using NHibernate.Criterion;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_CodigopostalController : BaseController<c_Codigopostal>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_CodigopostalController instance = new c_CodigopostalController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_CodigopostalController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_CodigopostalController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Recuperaci�n de c�digos postales lisos por estado

        /// <summary>
        /// Recupera los c�digos postales por estado
        /// </summary>
        /// <param name="id_estado">Id estado</param>
        /// <returns>C�digos postales</returns>
        public string[] GetListByIdEstado(string id_estado)
        {
            DetachedCriteria criteria = DetachedCriteria.For<c_Codigopostal>();
            criteria.Add(Restrictions.Eq("IdEstado", id_estado));
            criteria.SetProjection(Projections.Property("Clave"));

            return criteria.GetExecutableCriteria(_Session)
                .List<string>()
                .ToArray();
        }
        #endregion
    }
}
