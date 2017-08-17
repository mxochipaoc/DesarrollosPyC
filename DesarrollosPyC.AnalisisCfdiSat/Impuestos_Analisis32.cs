using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.AnalisisCfdiSat
{
    /// <summary>
    /// Propiedades para el análisis de los impuestos de las facturas
    /// </summary>
    public class Impuestos_Analisis32
    {
        public object Impuesto { get; set; }
        public decimal Tasa { get; set; }
        public decimal Importe { get; set; }
                
        /// <summary>
        /// Concepto e impuesto calculados
        /// </summary>
        public Dictionary<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.ComprobanteConcepto, decimal> Impuesto_Concepto { get; private set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Impuestos_Analisis32()
        {
            Impuesto_Concepto = new Dictionary<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.ComprobanteConcepto, decimal>();
        }

        #region Propiedades de solo lectura
        /// <summary>
        /// Subtotal del impuesto
        /// </summary>
        public decimal Subtotal
        {
            get { return Tasa > decimal.Zero ? Importe / Tasa : decimal.Zero; }
        }
        /// <summary>
        /// Importe faltante de conceptos para el subtotal
        /// </summary>
        public decimal Importe_Faltante
        {
            get { return Subtotal - (Impuesto_Concepto.Sum(i => i.Value)); }
        }
        #endregion

        #region Tratado de conceptos de factura, determinación de punestos
        /// <summary>
        /// Agrega la lista de onceptos de la factura para la evaluación del impuesto actual
        /// </summary>
        /// <param name="conceptos">Conceptos</param>
        public void AddConceptos(List<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.ComprobanteConcepto> conceptos)
        {
            if (Subtotal == decimal.Zero)
                return;

            // Genera proporciones de conceptos
            Dictionary<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.ComprobanteConcepto, decimal> proporciones = new Dictionary<Com.Facturacion.Comprobantes.V32.ComprobanteConcepto, decimal>();
            foreach (var c in conceptos)
            {
                proporciones.Add(c, c.importe / Subtotal);
            }

            // Discrimina proporciones
            Dictionary<Com.Facturacion.Comprobantes.V32.ComprobanteConcepto, decimal> addings = new Dictionary<Com.Facturacion.Comprobantes.V32.ComprobanteConcepto, decimal>();
            List<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.ComprobanteConcepto> bl = new List<Com.Facturacion.Comprobantes.V32.ComprobanteConcepto>();
            foreach (var c in conceptos)
            {
                if (decimal.Round(addings.Sum(i => i.Value), 2) < decimal.Round(Importe, 2))
                {
                    decimal imp = Importe * proporciones[c];
                    decimal pivote = imp + addings.Sum(i => i.Value);
                    if (decimal.Round(pivote, 2) > decimal.Round(Importe, 2))
                    {
                        decimal passed = pivote - Importe;
                        Com.Facturacion.Comprobantes.V32.ComprobanteConcepto remove = null;
                        foreach (var a in addings)
                        {
                            if (decimal.Round(a.Value, 2) >= decimal.Round(passed, 2))
                            {
                                remove = a.Key;
                                break;
                            }
                        }
                        if (remove != null)
                            addings.Remove(remove);
                        else
                            break;
                    }
                    addings.Add(c, imp);
                }
            }
            Impuesto_Concepto = addings;
        }

        #endregion
    }
}
