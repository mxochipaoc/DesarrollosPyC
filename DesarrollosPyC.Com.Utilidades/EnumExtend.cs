using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades
{
    /// <summary>
    /// Manejo de propiedades extendidas de los enumeradores
    /// </summary>
    public static class EnumExtend
    {
        /// <summary>
        /// Recupera la descripción de un enumerador especificado
        /// </summary>
        /// <param name="value">Valor en enumerador</param>
        /// <returns>Descripción</returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
