using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_TiponominaController : BaseController<c_Tiponomina>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TiponominaController instance = new c_TiponominaController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TiponominaController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TiponominaController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
