using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller
{
    /// <summary>
    /// Delegado de guardado de datos
    /// </summary>
    public delegate void MethodSaveEntity(ISession session);
}