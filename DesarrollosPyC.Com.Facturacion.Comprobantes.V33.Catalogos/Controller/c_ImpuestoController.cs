using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_ImpuestoController : BaseController<c_Impuesto>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_ImpuestoController instance = new c_ImpuestoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_ImpuestoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_ImpuestoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
