using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_UsocfdiController : BaseController<c_Usocfdi>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_UsocfdiController instance = new c_UsocfdiController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_UsocfdiController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_UsocfdiController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
