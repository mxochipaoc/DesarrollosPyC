using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller {
    
    public sealed class c_OrigenrecursoController : BaseController<c_Origenrecurso>
    {
        #region Arranque único de instancia
        /// <summary>
        /// Instancia única de la clase
        /// </summary>
        private static readonly c_OrigenrecursoController instance = new c_OrigenrecursoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_OrigenrecursoController()
        {
        }
        /// <summary>
        /// Acceso a instancia única
        /// </summary>
        public static c_OrigenrecursoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
