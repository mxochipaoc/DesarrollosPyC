using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.AnalisisCfdiSat
{
    /// <summary>
    /// Clase simple de representación de impuestos encontrados, generación de columnas y grupos de columnas
    /// </summary>
    public class Impuestos_Encontrados
    {
        public Tipo_Impuestos Tipo { get; set; }
        public Tipo_Impuesto_Aplicacion Aplicacion { get; set; }
        public string Impuesto { get; set; }
        public decimal Tasa { get; set; }
    }
}
