using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_TipocontratoController : BaseController<c_Tipocontrato>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TipocontratoController instance = new c_TipocontratoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipocontratoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TipocontratoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
