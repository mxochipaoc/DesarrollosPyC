using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_TiporelacionController : BaseController<c_Tiporelacion>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TiporelacionController instance = new c_TiporelacionController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TiporelacionController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TiporelacionController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
