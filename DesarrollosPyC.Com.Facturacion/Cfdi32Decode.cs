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
    public static class Cfdi32Decode
    {
        #region Recuperación de complementos de facturas
        /// <summary>
        /// Recupera el timbre fiscal digital del Cfdi
        /// </summary>
        /// <param name="cfdi">Cfdi</param>
        /// <returns>Timbre fiscal digital</returns>
        public static Comprobantes.Complementos.Tfd.V10.TimbreFiscalDigital RecuperaTimbreFiscalDigital(Comprobantes.V32.Comprobante cfdi)
        {
            Comprobantes.Complementos.Tfd.V10.TimbreFiscalDigital timbre = null;
            System.Xml.XmlElement impL = cfdi.Complemento.Any.Where(j => j.LocalName.Equals("TimbreFiscalDigital")).FirstOrDefault();
            if (impL != null)
            {
                timbre = Comprobantes.Complementos.Tfd.V10.TimbreFiscalDigital.Deserialize(impL.OuterXml);
            }

            return timbre;
        }

        /// <summary>
        /// Recupera el complemento de nómina en su version 1.1
        /// </summary>
        /// <param name="cfdi">Cfdi</param>
        /// <returns>Nómina</returns>
        public static Comprobantes.Complementos.Nomina.V11.Nomina RecuperaNomina11(Comprobantes.V32.Comprobante cfdi)
        {
            Comprobantes.Complementos.Nomina.V11.Nomina nomina11 = null;
            try
            {
                System.Xml.XmlElement nom = cfdi.Complemento.Any.Where(i => i.LocalName.Equals("Nomina")).FirstOrDefault();
                if (nom != null)
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Comprobantes.Complementos.Nomina.V11.Nomina));
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
                        writer.Write(nom.OuterXml);
                        writer.Flush();

                        stream.Position = 0;
                        nomina11 = (Comprobantes.Complementos.Nomina.V11.Nomina)serializer.Deserialize(stream);
                    }
                }
            }
            catch
            {
                nomina11 = null;
            }

            return nomina11;
        }

        /// <summary>
        /// Recupera el complemento de nómina en su versión 1.2
        /// </summary>
        /// <param name="cfdi">Cfdi</param>
        /// <returns>Nómina</returns>
        public static Comprobantes.Complementos.Nomina.V12.Nomina RecuperaNomina12(Comprobantes.V32.Comprobante cfdi)
        {
            Comprobantes.Complementos.Nomina.V12.Nomina nomina12 = null;
            try
            {
                System.Xml.XmlElement nom = cfdi.Complemento.Any.Where(i => i.LocalName.Equals("Nomina")).FirstOrDefault();
                if (nom != null)
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Comprobantes.Complementos.Nomina.V12.Nomina));
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
                        writer.Write(nom.OuterXml);
                        writer.Flush();

                        stream.Position = 0;
                        nomina12 = (Comprobantes.Complementos.Nomina.V12.Nomina)serializer.Deserialize(stream);
                    }
                }
            }
            catch
            {
                nomina12 = null;
            }

            return nomina12;
        }

        /// <summary>
        /// Recupera los impuestos locales del comprobante
        /// </summary>
        /// <param name="cfdi">Cfdi</param>
        /// <returns>Impuestos locales</returns>
        public static Comprobantes.Complementos.ImpuestosLocales RecuperaImpuestosLocales(Comprobantes.V32.Comprobante cfdi)
        {
            Comprobantes.Complementos.ImpuestosLocales implocal = null;
            try
            {
                System.Xml.XmlElement nom = cfdi.Complemento.Any.Where(i => i.LocalName.Equals("ImpuestosLocales")).FirstOrDefault();
                if (nom != null)
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Comprobantes.Complementos.ImpuestosLocales));
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                    {
                        System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
                        writer.Write(nom.OuterXml);
                        writer.Flush();

                        stream.Position = 0;
                        implocal = (Comprobantes.Complementos.ImpuestosLocales)serializer.Deserialize(stream);
                    }
                }
            }
            catch
            {
                implocal = null;
            }

            return implocal;
        }
        #endregion
    }
}
