using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.AnalisisCfdiSat
{
    /// <summary>
    /// Extención de la clase de columna de tabla
    /// </summary>
    public class Helper_DataColumn : System.Data.DataColumn
    {
        #region Propiedades de la clase
        /// <summary>
        /// Tipo de columna para grid de datos
        /// </summary>
        public object GridColumnFormatType { get; set; }
        /// <summary>
        /// Cadena de formato para grid de datos
        /// </summary>
        public string GridColumnFormatString { get; set; }
        /// <summary>
        /// Grupo de la columna
        /// </summary>
        public Helper_GroupDataColumn Group { get; private set; }
        #endregion

        #region Métodos de la clase
        /// <summary>
        /// Selecciona el grupo de la columna
        /// </summary>
        /// <param name="group">Grupo de datos</param>
        public void SetGroupDataColumn(Helper_GroupDataColumn group)
        {
            this.Group = group;
        }
        #endregion
    }
}
