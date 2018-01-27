using NHibernate;
using NHibernate.Criterion;
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
            T entity = _Session.Get<T>(id);

            if (entity == null)
            {
                entity = _Session.CreateCriteria<T>()
                .Add(Restrictions.Eq("Clave", id))
                .SetMaxResults(1)
                .UniqueResult<T>();
            }

            return entity;
        }

        /// <summary>
        /// Recupera una entidad mediante su id y la clave del estado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="claveestado"></param>
        /// <returns></returns>
        public static T GetEntityByIdAndEstadoClave(string id, string claveestado)
        {
            T entity = _Session.CreateCriteria<T>()
                .Add(Restrictions.Eq("Id", id))
                .Add(Restrictions.Eq("IdEstado", claveestado))
                .SetMaxResults(1)
                .UniqueResult<T>();

            if (entity == null)
            {
                entity = _Session.CreateCriteria<T>()
                .Add(Restrictions.Eq("Clave", id))
                .Add(Restrictions.Eq("IdEstado", claveestado))
                .SetMaxResults(1)
                .UniqueResult<T>();
            }

            return entity;
        }

        /// <summary>
        /// Recupera una entidad mediante su id y la clave del estado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigopostal"></param>
        /// <returns></returns>
        public static T GetEntityByIdAndCodigoPostal(string id, string codigopostal)
        {
            T entity = _Session.CreateCriteria<T>()
                .Add(Restrictions.Eq("Id", id))
                .Add(Restrictions.Eq("IdCodigoPostal", codigopostal))
                .SetMaxResults(1)
                .UniqueResult<T>();

            if (entity == null)
            {
                entity = _Session.CreateCriteria<T>()
                .Add(Restrictions.Eq("Clave", id))
                .Add(Restrictions.Eq("IdCodigoPostal", codigopostal))
                .SetMaxResults(1)
                .UniqueResult<T>();
            }

            return entity;
        }
    }
}
