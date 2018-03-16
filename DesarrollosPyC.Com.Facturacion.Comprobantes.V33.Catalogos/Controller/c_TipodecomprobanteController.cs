using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_TipodecomprobanteController : BaseController<c_Tipodecomprobante>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TipodecomprobanteController instance = new c_TipodecomprobanteController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipodecomprobanteController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TipodecomprobanteController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
