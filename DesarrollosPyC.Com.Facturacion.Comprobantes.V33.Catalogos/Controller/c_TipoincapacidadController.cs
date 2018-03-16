using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller
{

    public sealed class c_TipoincapacidadController : BaseController<c_Tipoincapacidad>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_TipoincapacidadController instance = new c_TipoincapacidadController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_TipoincapacidadController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_TipoincapacidadController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
