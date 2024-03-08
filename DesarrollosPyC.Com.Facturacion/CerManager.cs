using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Facturacion
{
    /// <summary>
    /// Clase manejadora de los certificados CSD/Field
    /// </summary>
    public static class CerManager
    {
        #region Propiedades del certificado
        public const string NoCertificado = "NoCertificado";
        public const string VigenciaDesde = "VigenciaDesde";
        public const string VigenciaHasta = "VigenciaHasta";
        public const string TipoCertificado = "TipoCertificado";
        public const string RfcPropietario = "RfcPropietario";
        #endregion

        #region Validaciones

        #endregion

        #region Info

        /// <summary>
        /// Recupera el certificado por ruta
        /// </summary>
        /// <param name="rcer">Ruta certificado</param>
        /// <param name="pass">Password certificado</param>
        /// <returns>Certificado</returns>
        public static System.Security.Cryptography.X509Certificates.X509Certificate2 GetCertificado(string rcer, string pass)
        {
            if (rcer.Trim() != String.Empty)
            {
                System.Security.Cryptography.X509Certificates.X509Certificate2 objCert = new System.Security.Cryptography.X509Certificates.X509Certificate2(rcer, pass);
                return objCert;
            }

            return null;
        }

        /// <summary>
        /// No de certificado a partir de serial del mismo
        /// </summary>
        /// <param name="serialnumber">Serial number</param>
        /// <returns>No certificado</returns>
        public static string NoCerBySerialNumber(string serialnumber)
        {
            string DatoHex = serialnumber;
            StringBuilder result = new StringBuilder();
            while (DatoHex.Length > 0)
            {
                result.Append(System.Convert.ToChar(System.Convert.ToUInt32(DatoHex.Substring(0, 2), 16)).ToString());
                DatoHex = DatoHex.Substring(2, DatoHex.Length - 2);
            }
            return result.ToString().Trim();
        }
        #endregion
    }
}
