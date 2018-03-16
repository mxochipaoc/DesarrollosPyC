using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_FormapagoController : BaseController<c_Formapago>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_FormapagoController instance = new c_FormapagoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_FormapagoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_FormapagoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
