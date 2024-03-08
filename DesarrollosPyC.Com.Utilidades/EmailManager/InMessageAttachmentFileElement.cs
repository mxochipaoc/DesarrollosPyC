using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades.EmailManager
{
    /// <summary>
    /// Propiedades de los archivos adjuntos
    /// </summary>
    public class InMessageAttachmentFileElement
    {
        public string filename { get; set; }
        public string fileb64data { get; set; }
    }
}
