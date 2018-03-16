using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_PeriodicidadpagoController : BaseController<c_Periodicidadpago>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_PeriodicidadpagoController instance = new c_PeriodicidadpagoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_PeriodicidadpagoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
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
