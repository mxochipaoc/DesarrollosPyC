using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {

    public sealed class c_ClaveprodservController : BaseController<c_Claveprodserv>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_ClaveprodservController instance = new c_ClaveprodservController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_ClaveprodservController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_ClaveprodservController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
