using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Facturacion
{
    /// <summary>
    /// Manejador de firmado de XML
    /// </summary>
    public static class CfdiV32Manager
    {
        #region Cosntructor de la clase
        /// <summary>
        /// Inicializa la clase
        /// </summary>
        static CfdiV32Manager()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
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
            xlst.Load(Xslt_cadenaoriginal_TFD_1_0);

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
        public static string CadenaOriginalTimbreFiscalDigital(Comprobantes.V32.Comprobante cfdi)
        {
            System.Xml.XmlDocument document = new System.Xml.XmlDocument();
            document.LoadXml(cfdi.Serialize());

            return CadenaOriginalTimbreFiscalDigital(document);
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
        public static string Xslt_cadenaoriginal_TFD_1_0 { get { return XlstPath + "cadenaoriginal_TFD_1_0.xslt"; } }
        #endregion

        #region Generación de XML

        #endregion
    }
}
