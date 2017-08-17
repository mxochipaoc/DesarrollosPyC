using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller
{
    /// <summary>
    /// Manejo directo de datos
    /// </summary>
    public static class DataHelper<T> where T : Model.BaseEntidad
    {
        /// <summary>
        /// Sesión con base de datos
        /// </summary>
        static ISession _Session { get; set; }

        /// <summary>
        /// Cosntructor de la clase
        /// </summary>
        static DataHelper()
        {
            _Session = SessionHelper.GetNewSession();
        }

        /// <summary>
        /// REcuepra lista de elementos
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <returns>Lista de elementos</returns>
        public static IList<T> GetList()
        {
            return _Session.CreateCriteria<T>()
                .List<T>();
        }

        /// <summary>
        /// Recuepración de elemento por id
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="id">Id</param>
        /// <returns>Elemento</returns>
        public static T GetnEntity(string id)
        {
            return _Session.Get<T>(id);
        }
    }
}
