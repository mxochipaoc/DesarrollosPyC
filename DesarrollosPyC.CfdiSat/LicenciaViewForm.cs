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
    /// Formulario de visualización de licencias
    /// </summary>
    public partial class LicenciaViewForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="licencia">Licencia a ser visualizada</param>
        public LicenciaViewForm(DesarrollosPyC.Com.Licencias.Class.Licencia licencia)
        {
            InitializeComponent();
            this.Licencia = licencia;
        }

        /// <summary>
        /// Licencia a ser visualizada
        /// </summary>
        DesarrollosPyC.Com.Licencias.Class.Licencia Licencia { get; set; }

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void LicenciaViewForm_Load(object sender, EventArgs e)
        {
            string html = string.Format(@"
<html>
    <head>
        <title>
            Datos de la licencia
        </title>
    </head>
    <body style='margin: auto; background-color: #F3F3F3; font-family: Arial; font-size: 8pt;'>
       <header>
         <div style='background-color: #FFFFFF; border: 1px solid #DEDEDE; border-radius: 5px; margin: 5px; padding: 5px; text-align: center; color: #8F8F8F;'>
           <h2>{0}</h2>
           <h3>{1}</h3>
         </div>
       </header>       
        <div style='background-color: #FFFFFF; border: 1px solid #DEDEDE; border-radius: 5px; margin: 5px; padding: 5px;'>
          <table style='width: 60%; border-collapse: collapse; text-align: left; vertical-align: middle; font-family: Arial; font-size: 8pt; color: #8F8F8F;'>
            <tr>
            	<td style='width: 50%;'>
                  	Fecha de emisión: 
              	</td>
              	<td>
                  	<strong>{2:d}</strong>
              </td>
            </tr>
            <tr>
            	<td>
                  	Fecha de término: 
              	</td>
              	<td>
                  	<strong>{3:d}</strong>
                </td>
            </tr>
            <tr>
            	<td>
                  Días transcurridos: 
              	</td>
              	<td>
                  <strong>{4}</strong>
              	</td>
            </tr>
          </table>
        </div>
        <footer>
          <div style='background-color: #FFFFFF; border: 1px solid #DEDEDE; border-radius: 5px; margin: 5px; padding: 5px; text-align: left; color: #8F8F8F; text-align: center;'>
            <span>Licencia emitida por: </span><strong>{5}</strong>
          </div>
      	</footer>
    </body>
</html>",
                                Licencia.Receptor.Rfc,
                                Licencia.Receptor.RazonSocial,
                                Licencia.FechaEmision,
                                Licencia.FechaVigencia,
                                Licencia.DiasOcupado,
                                Licencia.EmitidoPor.Nombre);

            webViewer.DocumentText = html;
        }

        /// <summary>
        /// Cierre del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
