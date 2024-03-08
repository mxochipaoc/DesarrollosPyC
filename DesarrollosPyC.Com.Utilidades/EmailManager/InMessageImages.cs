using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Utilidades.EmailManager
{
    public class InMessageImages
    {
        /// <summary>
        /// Imagenes agregadas
        /// </summary>
        Dictionary<string,string> Data { get; set; }

        /// <summary>
        /// Cosntructor de la clase
        /// </summary>
        public InMessageImages()
        {
            this.Data = new Dictionary<string, string>();
        }

        /// <summary>
        /// Agrega imagen a la lista
        /// </summary>
        /// <param name="cid">Identificador</param>
        /// <param name="b64image">Imagen eb base 64</param>
        public void Add(string cid, string b64image)
        {
            if (!this.Data.ContainsKey(cid))
                this.Data.Add(cid, b64image);
            else
                this.Data[cid] = b64image;
        }

        /// <summary>
        /// Retira una imagen agregada
        /// </summary>
        /// <param name="cid">Identificador</param>
        public void Remove(string cid)
        {
            if (!this.Data.ContainsKey(cid))
                this.Data.Remove(cid);
        }

        /// <summary>
        /// Conteo de elementos
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.Data.Count;
        }

        /// <summary>
        /// Lista de datos en formato arreglo
        /// </summary>
        /// <returns>Imagenes en correo</returns>
        public InMessageImagesElement[] ToArray()
        {
            return this.Data.Select(d => new InMessageImagesElement()
            {
                cid = d.Key,
                b64imagem = d.Value
            }).ToArray();
        }

        /// <summary>
        /// Lista de datos en formato lista
        /// </summary>
        /// <returns>Imagenes en correo</returns>
        public List<InMessageImagesElement> ToList()
        {
            return this.Data.Select(d => new InMessageImagesElement()
            {
                cid = d.Key,
                b64imagem = d.Value
            }).ToList();
        }
    }
}
