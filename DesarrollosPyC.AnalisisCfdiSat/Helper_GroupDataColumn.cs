using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.AnalisisCfdiSat
{
    /// <summary>
    /// Generación de grupos de columnas de tabla
    /// </summary>
    public class Helper_GroupDataColumn
    {
        #region Propiedades de la clase
        /// <summary>
        /// Identificador de objeto
        /// </summary>
        public Guid ID { get; private set; }
        /// <summary>
        /// Nombre del grupo
        /// </summary>
        public string Name { get; set; }
        #endregion

        #region Propiedades de columnas de tabla
        /// <summary>
        /// Grupoas de columnas de la tabla
        /// </summary>
        List<Helper_DataColumn> _Columns { get; set; }
        /// <summary>
        /// Recuperación de los grupos principales de 
        /// </summary>
        public Helper_DataColumn[] Columns { get { return _Columns.ToArray(); } }
        #endregion

        #region Propiedades recursivas de la clase
        /// <summary>
        /// Grupoas de columnas de la tabla
        /// </summary>
        List<Helper_GroupDataColumn> _Groups { get; set; }
        /// <summary>
        /// Recuperación de los grupos principales de 
        /// </summary>
        public Helper_GroupDataColumn[] Groups { get { return _Groups.ToArray(); } }
        /// <summary>
        /// Grupo principal de datos
        /// </summary>
        public object Parent { get; private set; }
        #endregion

        #region Constructores de la clase
        /// <summary>
        /// Constructor sin parámetros
        /// </summary>
        public Helper_GroupDataColumn()
        {
            this.ID = Guid.NewGuid();
            this._Columns = new List<Helper_DataColumn>();
            this._Groups = new List<Helper_GroupDataColumn>();
        }
        /// <summary>
        /// Constructor por nombre del grupo
        /// </summary>
        /// <param name="name"></param>
        public Helper_GroupDataColumn(string name)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this._Columns = new List<Helper_DataColumn>();
            this._Groups = new List<Helper_GroupDataColumn>();
        }
        /// <summary>
        /// Construtor con elemento padre
        /// </summary>
        /// <param name="parent">Elemento padre</param>
        public Helper_GroupDataColumn(object parent)
        {
            this.ID = Guid.NewGuid();
            this.Parent = parent;
            this._Columns = new List<Helper_DataColumn>();
            this._Groups = new List<Helper_GroupDataColumn>();
        }
        /// <summary>
        /// Constructor con elemento padre y nombre
        /// </summary>
        /// <param name="name">Nombre</param>
        /// <param name="parent">Elemento padre</param>
        public Helper_GroupDataColumn(string name, object parent)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.Parent = parent;
            this._Columns = new List<Helper_DataColumn>();
            this._Groups = new List<Helper_GroupDataColumn>();
        }
        #endregion

        #region Métodos de manejo de columnas
        /// <summary>
        /// Generación de nueva columna y la adiciona a la tabla
        /// </summary>
        /// <returns>Column</returns>
        public Helper_DataColumn NewDataColumn()
        {
            Helper_DataColumn column = new Helper_DataColumn();
            column.SetGroupDataColumn(this);
            this._Columns.Add(column);
            this.AddColumnToTable(column);
            return column;
        }
        /// <summary>
        /// Generación de nueva columna y la adiciona a la tabla
        /// </summary>
        /// <param name="columnname">Nombre de columna</param>
        /// <param name="caption"></param>
        /// <param name="type"></param>
        /// <param name="allowdbnull"></param>
        /// <param name="gridcolumnformattype">Formato de columna, si existe</param>
        /// <param name="gridcolumnformatstring">Cadena de formato, si existe</param>
        /// <returns></returns>
        public Helper_DataColumn NewDataColumn(string columnname, string caption, Type type, bool allowdbnull = true, object gridcolumnformattype = null, string gridcolumnformatstring = null)
        {
            Helper_DataColumn column = new Helper_DataColumn();
            column.ColumnName = columnname;
            column.Caption = caption;
            column.DataType = type;
            column.AllowDBNull = allowdbnull;

            if (gridcolumnformattype != null && !string.IsNullOrWhiteSpace(gridcolumnformatstring))
            {
                column.GridColumnFormatType = gridcolumnformattype;
                column.GridColumnFormatString = gridcolumnformatstring;
            }

            column.SetGroupDataColumn(this);
            this._Columns.Add(column);
            this.AddColumnToTable(column);
            return column;
        }
        /// <summary>
        /// Adiciona una columna al grupo actual
        /// </summary>
        /// <param name="column">Columna</param>
        /// <param name="addtable">Si adiciona a tabla<param>
        public void AddDataColumn(Helper_DataColumn column, bool addtable = true)
        {
            this._Columns.Add(column);
            if (addtable)
                this.AddColumnToTable(column);
        }
        /// <summary>
        /// Adición de la coumna actual a la tabla
        /// </summary>
        /// <param name="column">Columna</param>
        void AddColumnToTable(Helper_DataColumn column)
        {
            if (this.Parent != null)
            {
                if (this.Parent is Helper_GroupDataColumn)
                {
                    object parent_parent = this.Parent;
                    bool find = false;
                    while (!find)
                    {
                        if (((Helper_GroupDataColumn)parent_parent).Parent != null)
                        {
                            parent_parent = ((Helper_GroupDataColumn)parent_parent).Parent;
                            if (parent_parent is Helper_DataTable)
                                find = true;
                        }
                        else
                            break;
                    }

                    if (find)
                        ((Helper_DataTable)parent_parent).Columns.Add(column);
                }
                else if (this.Parent is Helper_DataTable)
                {
                    ((Helper_DataTable)this.Parent).Columns.Add(column);
                }
            }
        }
        #endregion

        #region Métodos de manejo de los grupos hijos
        /// <summary>
        /// Genera un nuevo grupo y lo adiciona al grupo actual
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Helper_GroupDataColumn NewGroupDataColumn(string name = "")
        {
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
            group.SetParent(this);
            this._Groups.Add(group);
        }
        /// <summary>
        /// Selecciona el elemento padre del objecto
        /// </summary>
        /// <param name="parent">Elemento padre</param>
        public void SetParent(object parent)
        {
            this.Parent = parent;
        }
        #endregion
    }
}
