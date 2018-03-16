using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller
{
    
    public sealed class c_TipodeduccionController : BaseController<c_Tipodeduccion>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_TipodeduccionController instance = new c_TipodeduccionController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipodeduccionController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_TipodeduccionController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
