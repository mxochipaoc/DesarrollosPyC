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

        #endregion

        #region Métodos directos del formulario
        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeChromium();
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

        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();

            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://portalcfdi.facturaelectronica.sat.gob.mx/?id=SATUPCFDiCon&sid=0&option=credential&sid=0");
            // Add it to the form and fill it to the form window.
            this.panWebBrowser.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
        

        private void btnBotonRuta_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton button = sender as DevExpress.XtraEditors.SimpleButton;
            if (button != null)
            {
                if (button.Parent == panRutaDisponible)
                {
                    panRutaDisponible.Controls.Remove(button);
                    panRutaAgregada.Controls.Add(button);
                }
                else if (button.Parent == panRutaAgregada)
                {
                    panRutaAgregada.Controls.Remove(button);
                    panRutaDisponible.Controls.Add(button);
                }
            }
        }
    }
}
