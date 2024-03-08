using DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model;
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
    /// Controlador de los catálogos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseController<T> where T : BaseEntidad
    {
        #region Propiedades de la clase

        /// <summary>
        /// Sesión con base de datos
        /// </summary>
        public static ISession _Session
        {
            get
            {
                return SessionHelper.GetNewSession();
            }
        }
        #endregion

        #region Propiedades de manejo de datos en cache
        /// <summary>
        /// Datos en cache
        /// </summary>
        protected IList<T> Data { get; set; }
        #endregion

        #region Métodos de recuperación de datos, actualización de cache
        /// <summary>
        /// Actualización de registros en cache
        /// </summary>
        /// <param name="data">Nuevos datos</param>
        public void Merge(IList<T> data)
        {
            if (Data == null)
                Data = new List<T>();

            if (data != null)
            {
                List<T> remove = (from d in data
                                     join r in Data on d.Id equals r.Id
                                     select d
                                    ).ToList();

                Data = Data.Except(remove)
                    .ToList();

                foreach (T a in data)
                {
                    if (a != null)
                        Data.Add(a);
                }
            }
        }

        /// <summary>
        /// Adición de elemento a la cache
        /// </summary>
        /// <param name="add">Elemento</param>
        public void Merge(T add)
        {
            if (add != null)
            {
                IList<T> merge = new List<T>();
                merge.Add(add);
                Merge(merge);
            }
        }

        /// <summary>
        /// Recupera la lista de elementos activos
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> GetList()
        {
            IList<T> data = _Session.CreateCriteria<T>()
                .List<T>();
            
            Merge(data);

            return data;
        }
        
        /// <summary>
        /// Recuperación de elemento de catálogo mediante su id
        /// </summary>
        /// <param name="id">Id de elemento</param>
        /// <returns>Elemento</returns>
        public virtual T GetEntity(string id)
        {
            T entity = _Session.Get<T>(id);
            if (entity == null)
            {
                DetachedCriteria criteria = DetachedCriteria.For<T>();
                criteria.Add(Restrictions.Eq("Clave", id));
                criteria.SetMaxResults(1);

                entity = criteria.GetExecutableCriteria(_Session).UniqueResult<T>();
            }

            return entity;
        }

        /// <summary>
        /// Fecha actual de la base de datos
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDate()
        {
            return _Session.CreateSQLQuery("select now()")
                .UniqueResult<DateTime>();
        }
        #endregion

        #region Métodos de guardado de datos
        /// <summary>
        /// Inserta o actualiza
        /// </summary>
        /// <param name="entity">Elemento</param>
        public virtual void SaveUpdateEntity(T entity)
        {
            MethodSaveEntityHelper.MethodSaveEntity((ISession session) =>
            {
                session.SaveOrUpdate(entity);
            });
        }
        #endregion

        #region Métodos de IDisponsable
        /// <summary>
        /// Destructor de la clase
        /// </summary>
        public void Dispose()
        {
            //session = null;
            GC.Collect();
        }
        #endregion
    }
}
