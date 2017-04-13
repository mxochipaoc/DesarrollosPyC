using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace DesarrollosPyC.DescargaCfdiSat
{
    /// <summary>
    /// Manejador de descarga de elementos
    /// </summary>
    public class DesarrollosPycDownloadHandler : CefSharp.IDownloadHandler
    {
        /// <summary>
        /// Constructor de la clase, forzado de ruta de guardado
        /// </summary>
        /// <param name="path"></param>
        public DesarrollosPycDownloadHandler(string path)
        {
            this.DownloadPath = path;
        }
        /// <summary>
        /// Ruta de descarga de datos
        /// </summary>
        string DownloadPath { get; set; }
        /// <summary>
        /// Antes de la descarga de datos
        /// </summary>
        /// <param name="browser">Navegador</param>
        /// <param name="downloadItem">Elemento descargado</param>
        /// <param name="callback">Procesamiento</param>
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            callback.Continue(this.DownloadPath, false);
        }
        /// <summary>
        /// Durante la descarga de datos
        /// </summary>
        /// <param name="browser">Navegador</param>
        /// <param name="downloadItem">Elemento en descarga</param>
        /// <param name="callback">Procesamiento</param>
        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            // No hace nada
        }
    }
}
