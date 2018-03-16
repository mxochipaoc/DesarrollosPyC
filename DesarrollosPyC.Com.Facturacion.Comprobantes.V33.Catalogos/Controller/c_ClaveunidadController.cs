using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_ClaveunidadController : BaseController<c_Claveunidad>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_ClaveunidadController instance = new c_ClaveunidadController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_ClaveunidadController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_ClaveunidadController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
