using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller
{
    public static class MethodSaveEntityHelper
    {
        /// <summary>
        /// Guardado de la entidad de manera segura
        /// </summary>
        /// <param name="method">Método de guardado</param>
        public static void MethodSaveEntity(MethodSaveEntity method)
        {
            using (ISession session = SessionHelper.GetNewSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        method(session);
                        tx.Commit();
                    }
                    catch(Exception ex)
                    {
                        tx.Rollback();
                    }
                    finally
                    {
                        session.Clear();
                    }
                }
            }
        }
    }
}