using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_TipopercepcionController : BaseController<c_Tipopercepcion>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_TipopercepcionController instance = new c_TipopercepcionController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipopercepcionController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_TipopercepcionController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
