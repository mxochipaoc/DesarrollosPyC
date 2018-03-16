using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_TipojornadaController : BaseController<c_Tipojornada>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TipojornadaController instance = new c_TipojornadaController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipojornadaController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TipojornadaController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
