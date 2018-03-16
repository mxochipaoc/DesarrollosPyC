using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_TiporegimenController : BaseController<c_Tiporegimen>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TiporegimenController instance = new c_TiporegimenController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TiporegimenController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TiporegimenController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
