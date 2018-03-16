using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_TipootropagoController : BaseController<c_Tipootropago>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TipootropagoController instance = new c_TipootropagoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipootropagoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TipootropagoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
