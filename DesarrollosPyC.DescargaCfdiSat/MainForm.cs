using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using DesarrollosPyC.Com.Controles;

namespace DesarrollosPyC.DescargaCfdiSat
{
    /// <summary>
    /// Formulario principal de lanzado de descarga masiva e Cfdi desde portal del SAT
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Propiedades del formulario
        /// <summary>
        /// Navegador de carga de datos
        /// </summary>
        public ChromiumWebBrowser Browser;
        #endregion

        #region Métodos directos del formulario
        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Carga del navegador de internet
            CefSettings settings = new CefSettings();
            
            Cef.Initialize(settings);
            Browser = new ChromiumWebBrowser("https://portalcfdi.facturaelectronica.sat.gob.mx/?id=SATUPCFDiCon&sid=0&option=credential&sid=0");
            this.panWebBrowser.Controls.Add(Browser);
            Browser.Dock = DockStyle.Fill;
            
            // Manejo de descarga de datos
            Browser.DownloadHandler = new DesarrollosPycDownloadHandler(txtRutaPrincipal.Text + "\\");

            // Visualziación de estatus del navegador    
            Browser.FrameLoadEnd += Browser_FrameLoadEnd;
            Browser.StatusMessage += Browser_StatusMessage;
        }
        
        /// <summary>
        /// Cierre del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        #endregion

        #region Eventos del navegador
        /// <summary>
        /// Visualización de mensaje de estatus del navegador
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Browser_StatusMessage(object sender, StatusMessageEventArgs e)
        {
            
        }
        /// <summary>
        /// Termino de carga, comienzo de operaciones
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            
        }
        #endregion

        #region Manejo de ruta de guardado
        /// <summary>
        /// Paso de controles a ruta de guardado
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnBotonRuta_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton button = sender as DevExpress.XtraEditors.SimpleButton;
            if (button != null)
            {
                if (button.Parent == panRutaDisponible)
                {
                    panRutaDisponible.Controls.Remove(button);
                    panRutaAgregada.Controls.Add(button);

                    panRutaDisponible.Enabled = button != btnSerieFolio && button != btnUUID;
                }
                else if (button.Parent == panRutaAgregada)
                {
                    panRutaAgregada.Controls.Remove(button);
                    panRutaDisponible.Controls.Add(button);

                    if(!panRutaDisponible.Enabled)
                        panRutaDisponible.Enabled = button == btnSerieFolio || button == btnUUID;
                }
            }
        }
        /// <summary>
        /// Organiza los datos descargados conforme la orgranización seleccinada
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnOrganizaDatos_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Lanzado de descarga de datos
        /// <summary>
        /// Inicia la descarga de datos
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnDescargarCfdi_Click(object sender, EventArgs e)
        {
            // validación del tipo de descarga
            if (rdgTipoCfdiDescarga.EditValue == null)
            {
                Dialogos.Alerta("Debe seleccionar el tipo de captura.");
                rdgTipoCfdiDescarga.Focus();
                return;
            }


        }
        #endregion
    }
}
