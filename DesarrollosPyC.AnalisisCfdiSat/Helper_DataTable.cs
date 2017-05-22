using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.AnalisisCfdiSat
{
    /// <summary>
    /// Clase extención de las propiedades de las tablas de DataSet
    /// </summary>
    public class Helper_DataTable : System.Data.DataTable
    {
        #region Nuevas propiedades de las tablas
        /// <summary>
        /// Grupoas de columnas de la tabla
        /// </summary>
        List<Helper_GroupDataColumn> _Groups { get; set; }
        /// <summary>
        /// Recuperación de los grupos principales de 
        /// </summary>
        public Helper_GroupDataColumn[] Groups { get { return _Groups != null ? _Groups.ToArray() : new Helper_GroupDataColumn[0]; } }
        #endregion

        #region Métodos de manejo de los grupos hijos
        /// <summary>
        /// Genera un nuevo grupo y lo adiciona al grupo actual
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Helper_GroupDataColumn NewGroupDataColumn(string name = "")
        {
            if (this._Groups == null)
                this._Groups = new List<Helper_GroupDataColumn>();

            Helper_GroupDataColumn group = new Helper_GroupDataColumn(name, this);
            this._Groups.Add(group);
            return group;
        }
        /// <summary>
        /// Adición un grupo nuevo al grupo actual
        /// </summary>
        /// <param name="group">Grupo de columnas</param>
        public void AddGroupDataColumn(Helper_GroupDataColumn group)
        {
            if (this._Groups == null)
                this._Groups = new List<Helper_GroupDataColumn>();

            group.SetParent(this);
            this._Groups.Add(group);
        }
        #endregion
    }
}
