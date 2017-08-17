using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.AnalisisCfdiSat.Documents
{
    /// <summary>
    /// Base de formularios de previsualziación de documentos
    /// </summary>
    public partial class BaseViewReportForm : Form
    {
        /// <summary>
        /// Cosntructor de la clase
        /// </summary>
        public BaseViewReportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Genera el documento
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BaseViewReportForm_Load(object sender, EventArgs e)
        {
            RefreshReportView();
        }

        /// <summary>
        /// Genera el reporte
        /// </summary>
        protected virtual void RefreshReportView()
        {
        }
    }
}
