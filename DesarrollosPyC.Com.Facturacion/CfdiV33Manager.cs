using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DesarrollosPyC.Com.Facturacion
{
    /// <summary>
    /// Manejador de firmado de XML
    /// </summary>
    public static class CfdiV33Manager
    {
        #region Constructor de la clase
        /// <summary>
        /// Inicializa la clase
        /// </summary>
        static CfdiV33Manager()
        {
            // string path = System.IO.Directory.GetCurrentDirectory();
            string path = System.IO.Path.GetTempPath();
            path = path + "\\xslt";
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            XlstPath = path + "\\";
            char[] split = new char[] { '.' };
            string fileName = string.Empty;
            string[] resources = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (string s in resources)
            {
                string[] sp = s.Split(split);
                string name = sp[sp.Length - 2] + "." + sp[sp.Length - 1];
                fileName = XlstPath + name;
                if (!System.IO.File.Exists(fileName))
                {
                    using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(s))
                    {
                        using (System.IO.FileStream file = System.IO.File.Create(fileName, (int)stream.Length))
                        {
                            byte[] bytesInStream = new byte[stream.Length];
                            stream.Read(bytesInStream, 0, bytesInStream.Length);
                            file.Write(bytesInStream, 0, bytesInStream.Length);
                            file.Close();
                        }
                    }
                }
            }
        }
        #endregion

        #region Cadena original

        /// <summary>
        /// Cadena original del complemento de timbre fiscal digital
        /// </summary>
        /// <param name="xml">Documento XML</param>
        /// <returns>Cadena original</returns>
        public static string CadenaOriginalTimbreFiscalDigital(System.Xml.XmlDocument xml)
        {
            System.Xml.Xsl.XslCompiledTransform xlst = new System.Xml.Xsl.XslCompiledTransform();
            xlst.Load(Xslt_cadenaoriginal_TFD_1_1);

            StringWriterWithEncoding stringwriter = new StringWriterWithEncoding(Encoding.UTF8);
            xlst.Transform(xml, null, stringwriter);

            string result = stringwriter.ToString().Trim();
            if (!result.StartsWith("||"))
                result = "|" + result;
            if (!result.EndsWith("||"))
                result = result + "||";

            return result;
        }

        /// <summary>
        /// Recupera cadena original de timbre fiscal digital a partir de Cfdi
        /// </summary>
        /// <param name="cfdi">Comprobante</param>
        /// <returns>Cadena</returns>
        public static string CadenaOriginalTimbreFiscalDigital(Comprobantes.V33.Comprobante cfdi)
        {
            System.Xml.XmlDocument document = new System.Xml.XmlDocument();
            document.LoadXml(cfdi.Serialize());

            return CadenaOriginalTimbreFiscalDigital(document);
        }

        /// <summary>
        /// Cadena original del complemento de timbre fiscal digital
        /// </summary>
        /// <param name="xml">Documento XML</param>
        /// <returns>Cadena original</returns>
        public static string CadenaOriginalCFDi(System.Xml.XmlDocument xml)
        {
            System.Xml.Xsl.XslCompiledTransform xlst = new System.Xml.Xsl.XslCompiledTransform();
            xlst.Load(Xslt_cadenaoriginal_3_3_l);

            StringWriterWithEncoding stringwriter = new StringWriterWithEncoding(Encoding.UTF8);
            xlst.Transform(xml, null, stringwriter);

            string result = stringwriter.ToString().Trim();
            if (!result.StartsWith("||"))
                result = "|" + result;
            if (!result.EndsWith("||"))
                result = result + "||";

            return result;
        }

        /// <summary>
        /// Cadena original del complemento de timbre fiscal digital
        /// </summary>
        /// <param name="xml">Documento XML</param>
        /// <returns>Cadena original</returns>
        public static string CadenaOriginalCFDi(Comprobantes.V33.Comprobante cfdi)
        {
            System.Xml.XmlDocument document = GeneraXml(cfdi);
            return CadenaOriginalCFDi(document);
        }

        /// <summary>
        /// Genera sello digital
        /// </summary>
        /// <param name="cadenaoriginal">Cadena original</param>
        /// <param name="rkey">Llave</param>
        /// <param name="pass">Pass</param>
        /// <returns>Cadena firmada</returns>
        public static string GeneraSelloDigital(string cadenaoriginal, string rkey, string pass)
        {
            System.Security.Cryptography.HashAlgorithm hasher = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            System.Security.SecureString securepass = new System.Security.SecureString();
            securepass.Clear();
            foreach (char c in pass.Trim().ToCharArray())
                securepass.AppendChar(c);
            byte[] keyBytes = System.IO.File.ReadAllBytes(rkey);
            System.Security.Cryptography.RSACryptoServiceProvider rsa = Opensslkey.DecodeEncryptedPrivateKeyInfo(keyBytes, securepass);

            if (rsa == null)
                throw new Exception("No se pudo abrir la llave privada, por favor verifique su contraseña.");
            byte[] bytesFirmados = rsa.SignData(System.Text.Encoding.UTF8.GetBytes(cadenaoriginal), hasher);
            string selloDigital = Convert.ToBase64String(bytesFirmados);
            return selloDigital;
        }
        #endregion

        #region Constantes de la clase
        /// <summary>
        /// Ruta de acceso a xslt
        /// </summary>
        public static string XlstPath { get; private set; }
        /// <summary>
        /// Ruta de acceso a xstl de cadena original del timbre fiscal digital
        /// </summary>
        public static string Xslt_cadenaoriginal_TFD_1_1 { get { return XlstPath + "cadenaoriginal_TFD_1_1.xslt"; } }
        /// <summary>
        /// Ruta de acceso a xstl de cadena original del cfdi
        /// </summary>
        public static string Xslt_cadenaoriginal_3_3_l { get { return XlstPath + "cadenaoriginal_3_3_l.xslt"; } }
        #endregion

        #region Generación de XML

        /// <summary>
        /// Convierte el CFDi en objeto XML
        /// </summary>
        /// <param name="comprobante">CFDi</param>
        /// <returns>Xml</returns>
        static XmlDocument GeneraXml(Com.Facturacion.Comprobantes.V33.Comprobante comprobante)
        {
            XmlDocument documentoXml = new XmlDocument();
            System.Xml.Serialization.XmlSerializerNamespaces xmlNameSpace = new System.Xml.Serialization.XmlSerializerNamespaces();
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(memoryStream, Encoding.UTF8);

            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Com.Facturacion.Comprobantes.V33.Comprobante));
            xs.Serialize(streamWriter, comprobante, xmlNameSpace);

            memoryStream.Position = 0;
            documentoXml.Load(memoryStream);
            memoryStream.Close();
            
            XmlElement encabezado = (XmlElement)documentoXml.GetElementsByTagName("cfdi:Comprobante")[0];
            XmlAttribute schemaLocation = documentoXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
            schemaLocation.Value = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd";

            encabezado.SetAttributeNode(schemaLocation);
            documentoXml.AppendChild(encabezado);

            return documentoXml;
        }

        /// <summary>
        /// Firma Xml
        /// </summary>
        /// <param name="xml">Xml</param>
        /// <param name="rcer">Ruta certificado</param>
        /// <param name="rkey">Ruta llave</param>
        /// <param name="pass">Password</param>
        /// <returns>Xml firmado</returns>
        static XmlDocument FirmarXml(XmlDocument xml, string rcer, string rkey, string pass)
        {
            string cadenaoriginal = CadenaOriginalCFDi(xml);
            string sello = GeneraSelloDigital(cadenaoriginal, rkey, pass);

            xml.GetElementsByTagName("cfdi:Comprobante")[0].Attributes["Sello"].Value = sello;

            return xml;
        }
        #endregion

        #region Timbrado de pruebas

        /// <summary>
        /// Timbrado de pruebas
        /// </summary>
        /// <param name="cfdi"></param>
        /// <param name="rcer"></param>
        /// <param name="rkey"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static KeyValuePair<string, string> TimbrarPruebasFactureHoy(Comprobantes.V33.Comprobante cfdi, string rcer, string rkey, string pass)
        {
            var xml = GeneraXml(cfdi);
            byte[] xmlBytes =  Encoding.UTF8.GetBytes(xml.OuterXml);

            pruebas.facturehoy.com.WsEmisionTimbrado33 timbrado = new pruebas.facturehoy.com.WsEmisionTimbrado33();
            var result = timbrado.EmitirTimbrar("AAA010101AAA.Test.User", "Prueba$1", 5906390, xmlBytes);
            if (result.isError)
                throw new Exception(result.message);

            return new KeyValuePair<string, string>(result.folioUDDI, Encoding.UTF8.GetString(result.XML));
        }

        /// <summary>
        /// Timbrado de pruebas
        /// </summary>
        /// <param name="cfdi"></param>
        /// <param name="rcer"></param>
        /// <param name="rkey"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static KeyValuePair<string, string> TimbrarPruebasSeFactura(Comprobantes.V33.Comprobante cfdi, string rcer, string rkey, string pass)
        {
            var xml = GeneraXml(cfdi);

            mx.com.sefactura.pruebas.TimbradoServiceService timbrado = new mx.com.sefactura.pruebas.TimbradoServiceService();
            var result = timbrado.timbrado(xml.OuterXml, "PAPM821210RD2", "PAPM821210RD2");
            //mx.com.sefactura.www.TimbradoServiceService timbrado = new mx.com.sefactura.www.TimbradoServiceService();
            //var result = timbrado.timbrado(xml.OuterXml, "mpalacios", "PAPM821210RD2");
            if (string.IsNullOrEmpty(result.timbre))
                throw new Exception(result.status);

            var cfditimbrado = Com.Facturacion.Comprobantes.V33.Comprobante.Deserialize(result.timbre);
            var tfd = Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(cfditimbrado);
            
            return new KeyValuePair<string, string>(tfd.UUID, result.timbre);
        }
        #endregion

        #region Pruebas de cancelación
        
        /// <summary>
        /// Timbrado de pruebas
        /// </summary>
        /// <param name="cfdi"></param>
        /// <param name="rcer"></param>
        /// <param name="rkey"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string CancelarPruebasSeFactura(string uuid, string rcer, string rkey, string pass)
        {
            mx.com.sefactura.pruebas.TimbradoServiceService timbrado = new mx.com.sefactura.pruebas.TimbradoServiceService();
            var cancelacion = new mx.com.sefactura.pruebas.solCancelacion();
            cancelacion.uuid = new string[] { uuid };
            cancelacion.certificado = rcer;
            cancelacion.llavePrivada = rkey;
            cancelacion.password = Com.Utilidades.Cadenas.ToB64(pass);
            string result = timbrado.cancelacion(cancelacion, "PAPM821210RD2", "PAPM821210RD2");

            if (!result.Contains("201") && !result.Contains("202") && !result.ToLower().Contains("correctamente"))
                throw new Exception(result);
            
            return result;
        }
        #endregion

        #region Servicio SeFactura

        /// <summary>
        /// Timbrado de CFDi
        /// </summary>
        /// <param name="cfdi">CFDi a ser timbrado</param>
        /// <param name="rcer">Ruta certificado</param>
        /// <param name="rkey">Ruta llave</param>
        /// <param name="pass">Pass</param>
        /// <param name="sfpass">Usuario SeFactura</param>
        /// <param name="sfusuario">Pass SeFactura</param>
        /// <returns></returns>
        public static KeyValuePair<string, string> TimbrarSeFactura(Comprobantes.V33.Comprobante cfdi, string rcer, string rkey, string pass, string sfusuario, string sfpass)
        {
            var xml = GeneraXml(cfdi);

            mx.com.sefactura.www.TimbradoServiceService timbrado = new mx.com.sefactura.www.TimbradoServiceService();
            var result = timbrado.timbrado(xml.OuterXml, sfusuario, sfpass);
            if (string.IsNullOrEmpty(result.timbre))
                throw new Exception(result.status);

            var cfditimbrado = Com.Facturacion.Comprobantes.V33.Comprobante.Deserialize(result.timbre);
            var tfd = Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(cfditimbrado);

            return new KeyValuePair<string, string>(tfd.UUID, result.timbre);
        }

        /// <summary>
        /// Cancelación SeFactura
        /// </summary>
        /// <param name="uuid">UUID a cancelar</param>
        /// <param name="rcer">Ruta certificado</param>
        /// <param name="rkey">Ruta llave</param>
        /// <param name="pass">Pass</param>
        /// <param name="sfpass">Usuario SeFactura</param>
        /// <param name="sfusuario">Pass SeFactura</param>
        /// <returns></returns>
        public static string CancelarSeFactura(string uuid, string rcer, string rkey, string pass, string sfusuario, string sfpass)
        {
            mx.com.sefactura.www.TimbradoServiceService timbrado = new mx.com.sefactura.www.TimbradoServiceService();
            var cancelacion = new mx.com.sefactura.www.solCancelacion();
            cancelacion.uuid = new string[] { uuid };
            cancelacion.certificado = Com.Utilidades.Archivos.ArchivoToB64(rcer);
            cancelacion.llavePrivada = Com.Utilidades.Archivos.ArchivoToB64(rkey);
            cancelacion.password = Com.Utilidades.Cadenas.ToB64(pass);
            string result = timbrado.cancelacion(cancelacion, sfusuario, sfpass);

            if (!result.Contains("201") && !result.Contains("202") && !result.ToLower().Contains("correctamente"))
                throw new Exception(result);

            return result;
        }
        #endregion

        #region Servicio FactureHoy

        /// <summary>
        /// Timbrado FactureHoy
        /// </summary>
        /// <param name="cfdi">CFDi a ser timbrado</param>
        /// <param name="rcer">Ruta certificado</param>
        /// <param name="rkey">Ruta llave</param>
        /// <param name="pass">Pass</param>
        /// <param name="fhusuario">Usuario FactureHoy</param>
        /// <param name="fhpass">Pass FactureHoy</param>
        /// <param name="fhservicio">Servicio FactreHoy</param>
        /// <returns></returns>
        public static KeyValuePair<string, string> TimbrarFactureHoy(Comprobantes.V33.Comprobante cfdi, string rcer, string rkey, string pass, string fhusuario, string fhpass, string fhservicio)
        {
            var xml = GeneraXml(cfdi);
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml.OuterXml);
            
            com.facturehoy.wsprod3.WsEmisionTimbrado33 timbrado = new com.facturehoy.wsprod3.WsEmisionTimbrado33();
            var result = timbrado.EmitirTimbrar(fhusuario, fhpass, Convert.ToInt32(fhservicio), xmlBytes);
            if (result.isError)
                throw new Exception(result.message);

            return new KeyValuePair<string, string>(result.folioUDDI, Encoding.UTF8.GetString(result.XML));
        }
        #endregion
    }
}
