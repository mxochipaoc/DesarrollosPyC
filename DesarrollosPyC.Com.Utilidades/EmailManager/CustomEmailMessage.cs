using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades.EmailManager
{
    /// <summary>
    /// Mensaje personalizado de correo
    /// </summary>
    public class CustomEmailMessage
    {
        public string HtmlMessage { get; set; }
        public InMessageImages MessageImages { get; private set; }
        public InMessageAttachmentFile AttachmentFiles { get; private set; }

        /// <summary>
        /// Cosntructor de la clase
        /// </summary>
        public CustomEmailMessage()
        {
            this.HtmlMessage = string.Empty;
            this.MessageImages = new InMessageImages();
            this.AttachmentFiles = new InMessageAttachmentFile();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="message">Mensaje</param>
        public CustomEmailMessage(string message)
        {
            this.HtmlMessage = message;
            this.MessageImages = new InMessageImages();
            this.AttachmentFiles = new InMessageAttachmentFile();
        }

        /// <summary>
        /// Agrega imagen ligada a mensaje
        /// </summary>
        /// <param name="cid">Identificador</param>
        /// <param name="b64image">Imagen en base 64</param>
        public void AddImage(string cid, string b64image)
        {
            this.MessageImages.Add(cid, b64image);
        }

        /// <summary>
        /// Agrega archivo ligada a mensaje
        /// </summary>
        /// <param name="filename">Nombre de archivo</param>
        /// <param name="b64data">Arhivo en base 64</param>
        public void AddAttachmentFile(string filename, string b64data)
        {
            this.AttachmentFiles.Add(filename, b64data);
        }
    }
}
