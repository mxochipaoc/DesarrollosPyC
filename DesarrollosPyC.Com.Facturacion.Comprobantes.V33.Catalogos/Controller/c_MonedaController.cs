using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_MonedaController : BaseController<c_Moneda>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_MonedaController instance = new c_MonedaController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_MonedaController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_MonedaController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
