using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_PaisController : BaseController<c_Pais>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_PaisController instance = new c_PaisController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_PaisController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_PaisController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
