using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.DescargaCfdiSat
{
    /// <summary>
    /// Clase extención de datos del CFDI a descargar
    /// </summary>
    public class Helper_Cfdi
    {
        /// <summary>
        /// Constructo de la clase
        /// </summary>
        /// <param name="uuid">UUID</param>
        /// <param name="pagedownload">Pagina de descarga</param>
        public Helper_Cfdi(string uuid, string pagedownload)
        {
            this.UUID = uuid;
            this.PageDownload = pagedownload;
            this.IsDownload = false;
        }
        public string UUID { get; set; }
        public string PageDownload { get; set; }
        public bool IsDownload { get; set; }
    }
}
