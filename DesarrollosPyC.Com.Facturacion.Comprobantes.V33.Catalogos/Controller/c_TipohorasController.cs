using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_TipohorasController : BaseController<c_Tipohoras>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_TipohorasController instance = new c_TipohorasController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipohorasController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_TipohorasController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
