using System;
using System.Text;
using System.Collections.Generic;
using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller
{
    
    public sealed class c_BancoController : BaseController<c_Banco>
    {
        #region Arranque �nico de instancia
        /// <summary>
        /// Instancia �nica de la clase
        /// </summary>
        private static readonly c_BancoController instance = new c_BancoController();
        /// <summary>
        /// Constructor
        /// </summary>
        private c_BancoController()
        {
        }
        /// <summary>
        /// Acceso a instancia �nica
        /// </summary>
        public static c_BancoController Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
