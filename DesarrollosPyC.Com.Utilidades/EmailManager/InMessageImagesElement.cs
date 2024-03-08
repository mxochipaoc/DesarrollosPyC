using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades.EmailManager
{
    /// <summary>
    /// Imagenes del mensaje de correo electrónico
    /// </summary>
    public class InMessageImagesElement
    {
        /// <summary>
        /// Id de enlace con el mensaje generado
        /// </summary>
        public string cid { get; set; }
        /// <summary>
        /// Imagen en base 64 para su adjunción directa en el mensaje
        /// </summary>
        public string b64imagem { get; set; }
    }
}
