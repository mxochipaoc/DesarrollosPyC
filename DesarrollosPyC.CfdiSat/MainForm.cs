using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.CfdiSat
{
    /// <summary>
    /// Formulario de apertura de aplicaciones de análisis de Cfdi
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
        /// <summary>
        /// Apertura de formulario de descarga masiva
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void nvbDescargaMasiva_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DesarrollosPyC.DescargaCfdiSat.MainForm form = new DescargaCfdiSat.MainForm();
            form.MdiParent = this;
            form.Show();
        }
        /// <summary>
        /// Apertura de formulario de analisis de elementos descargados
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void nvbAnalisis_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DesarrollosPyC.AnalisisCfdiSat.MainForm form = new AnalisisCfdiSat.MainForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}
