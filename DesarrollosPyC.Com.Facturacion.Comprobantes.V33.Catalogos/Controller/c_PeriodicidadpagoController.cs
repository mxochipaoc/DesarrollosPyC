using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_PeriodicidadpagoController : BaseController<c_Periodicidadpago>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_PeriodicidadpagoController instance = new c_PeriodicidadpagoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_PeriodicidadpagoController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_PeriodicidadpagoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
