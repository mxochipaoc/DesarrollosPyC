using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_RegimenfiscalController : BaseController<c_Regimenfiscal>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_RegimenfiscalController instance = new c_RegimenfiscalController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_RegimenfiscalController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_RegimenfiscalController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
