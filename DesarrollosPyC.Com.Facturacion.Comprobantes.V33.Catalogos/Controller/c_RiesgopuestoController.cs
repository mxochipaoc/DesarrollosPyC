using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_RiesgopuestoController : BaseController<c_Riesgopuesto>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_RiesgopuestoController instance = new c_RiesgopuestoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_RiesgopuestoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_RiesgopuestoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
