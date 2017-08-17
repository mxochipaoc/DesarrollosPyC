using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Facturacion
{
    /// <summary>
    /// Decodificación de Cfdi
    /// </summary>
    public static class Cfdi33Decode
    {
        #region Recuperación de complementos de facturas
        /// <summary>
        /// Recupera el timbre fiscal digital del Cfdi
        /// </summary>
        /// <param name="cfdi">Cfdi</param>
        /// <returns>Timbre fiscal digital</returns>
        public static Comprobantes.Complementos.Tfd.V11.TimbreFiscalDigital RecuperaTimbreFiscalDigital(Comprobantes.V33.Comprobante cfdi)
        {
            Comprobantes.Complementos.Tfd.V11.TimbreFiscalDigital timbre = null;
            foreach (var cpl in cfdi.Complemento)
            {
                System.Xml.XmlElement impL = cpl.Any.Where(j => j.LocalName.Equals("TimbreFiscalDigital")).FirstOrDefault();
                if (impL != null)
                {
                    timbre = Comprobantes.Complementos.Tfd.V11.TimbreFiscalDigital.Deserialize(impL.OuterXml);
                }

                if (timbre != null)
                    break;
            }

            return timbre;
        }
        
        /// <summary>
        /// Recupera el complemento de nómina en su versión 1.2
        /// </summary>
        /// <param name="cfdi">Cfdi</param>
        /// <returns>Nómina</returns>
        public static Comprobantes.Complementos.Nomina.V12.Nomina RecuperaNomina12(Comprobantes.V33.Comprobante cfdi)
        {
            Comprobantes.Complementos.Nomina.V12.Nomina nomina12 = null;
            foreach (var cpl in cfdi.Complemento)
            {
                System.Xml.XmlElement impL = cpl.Any.Where(j => j.LocalName.Equals("Nomina")).FirstOrDefault();
                if (impL != null)
                {
                    nomina12 = Comprobantes.Complementos.Nomina.V12.Nomina.Deserialize(impL.OuterXml);
                }

                if (nomina12 != null)
                    break;
            }

            return nomina12;
        }

        /// <summary>
        /// Recupera los impuestos locales del comprobante
        /// </summary>
        /// <param name="cfdi">Cfdi</param>
        /// <returns>Impuestos locales</returns>
        public static Comprobantes.Complementos.ImpuestosLocales RecuperaImpuestosLocales(Comprobantes.V33.Comprobante cfdi)
        {
            Comprobantes.Complementos.ImpuestosLocales implocal = null;
            foreach (var cpl in cfdi.Complemento)
            {
                System.Xml.XmlElement impL = cpl.Any.Where(j => j.LocalName.Equals("ImpuestosLocales")).FirstOrDefault();
                if (impL != null)
                {
                    implocal = Comprobantes.Complementos.ImpuestosLocales.Deserialize(impL.OuterXml);
                }

                if (implocal != null)
                    break;
            }

            return implocal;
        }
        #endregion
    }
}
