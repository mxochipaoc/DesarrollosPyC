using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DesarrollosPyC.Com.Facturacion
{
    /// <summary>
    /// Manejador de los complementos del CFDi 3.3
    /// </summary>
    public static class CFDi33ComplementosManager
    {
        /// <summary>
        /// Serializa el complemento de nómina
        /// </summary>
        /// <param name="nomina">Nómina</param>
        /// <returns>Elemento xml</returns>
        public static XmlElement SerializeCmplNomina(Object nomina)
        {
            if (nomina != null)
            {
                XmlDocument documentoXml = new XmlDocument();
                System.Xml.Serialization.XmlSerializerNamespaces xmlNamespace = new System.Xml.Serialization.XmlSerializerNamespaces();
                xmlNamespace.Add("nomina12", "http://www.sat.gob.mx/nomina12");

                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina));
                    serializer.Serialize(stream, nomina, xmlNamespace);
                    stream.Position = 0;
                    documentoXml.Load(stream);
                    stream.Close();
                }

                XmlElement encabezado = (XmlElement)documentoXml.GetElementsByTagName("nomina12:Nomina")[0];
                XmlAttribute schemaLocation = documentoXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                schemaLocation.Value =
                    "http://www.sat.gob.mx/nomina12" +
                    " http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd";

                encabezado.SetAttributeNode(schemaLocation);
                documentoXml.AppendChild(encabezado);

                return documentoXml.DocumentElement;
            }
            return null;
        }

        /// <summary>
        /// Serializa el complemento de pago
        /// </summary>
        /// <param name="pago">Pago</param>
        /// <returns>Elemento xml</returns>
        public static XmlElement SerializeCmplPago(Object pago)
        {
            if (pago != null)
            {
                XmlDocument documentoXml = new XmlDocument();
                System.Xml.Serialization.XmlSerializerNamespaces xmlNamespace = new System.Xml.Serialization.XmlSerializerNamespaces();
                xmlNamespace.Add("pago10", "http://www.sat.gob.mx/Pagos");

                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Com.Facturacion.Comprobantes.Complementos.Pagos));
                    serializer.Serialize(stream, pago, xmlNamespace);
                    stream.Position = 0;
                    documentoXml.Load(stream);
                    stream.Close();
                }
                
                XmlElement encabezado = (XmlElement)documentoXml.GetElementsByTagName("pago10:Pagos")[0];
                XmlAttribute schemaLocation = documentoXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                schemaLocation.Value =
                    "http://www.sat.gob.mx/Pagos" +
                    " http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos10.xsd";

                encabezado.SetAttributeNode(schemaLocation);
                documentoXml.AppendChild(encabezado);

                return documentoXml.DocumentElement;
            }

            return null;
        }
    }
}
