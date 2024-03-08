using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades.EmailManager
{
    /// <summary>
    /// Archivos adjuntos
    /// </summary>
    public class InMessageAttachmentFile
    {
        /// <summary>
        /// Imagenes agregadas
        /// </summary>
        Dictionary<string, string> Data { get; set; }

        /// <summary>
        /// Cosntructor de la clase
        /// </summary>
        public InMessageAttachmentFile()
        {
            this.Data = new Dictionary<string, string>();
        }

        /// <summary>
        /// Agrega archivo a la lista
        /// </summary>
        /// <param name="filename">Nombre de archivo</param>
        /// <param name="b64data">Archivo en base 64</param>
        public void Add(string filename, string b64data)
        {
            if (!this.Data.ContainsKey(filename))
                this.Data.Add(filename, b64data);
            else
                this.Data[filename] = b64data;
        }

        /// <summary>
        /// Retira archivo agregado
        /// </summary>
        /// <param name="filename">Nombre de archivo</param>
        public void Remove(string filename)
        {
            if (!this.Data.ContainsKey(filename))
                this.Data.Remove(filename);
        }

        /// <summary>
        /// Conteo de elementos
        /// </summary>
        /// <returns>No de registros</returns>
        public int Count()
        {
            return this.Data.Count;
        }

        /// <summary>
        /// Lista de datos en formato arreglo
        /// </summary>
        /// <returns>Imagenes en correo</returns>
        public InMessageAttachmentFileElement[] ToArray()
        {
            return this.Data.Select(d => new InMessageAttachmentFileElement()
            {
                filename = d.Key,
                fileb64data = d.Value
            }).ToArray();
        }

        /// <summary>
        /// Lista de datos en formato lista
        /// </summary>
        /// <returns>Imagenes en correo</returns>
        public List<InMessageAttachmentFileElement> ToList()
        {
            return this.Data.Select(d => new InMessageAttachmentFileElement()
            {
                filename = d.Key,
                fileb64data = d.Value
            }).ToList();
        }
    }
}
