using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Facturacion
{
    /// <summary>
    /// Encoding de string writer
    /// </summary>
    public class StringWriterWithEncoding : System.IO.StringWriter
    {
        /// <summary>
        /// Encoding
        /// </summary>
        Encoding encoding;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="encoding">Encoding</param>
        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }
        
        /// <summary>
        /// Get encoding
        /// </summary>
        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}
