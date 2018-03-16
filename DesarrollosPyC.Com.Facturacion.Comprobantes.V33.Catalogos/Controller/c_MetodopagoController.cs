using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_MetodopagoController : BaseController<c_Metodopago>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_MetodopagoController instance = new c_MetodopagoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_MetodopagoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_MetodopagoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
