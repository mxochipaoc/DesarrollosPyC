using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.Test
{
    /// <summary>
    /// Formulario test de generación de licencias
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
        /// Carga de formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            txtEntidadEmisora.Text = "Desarrollos PyC";
            cldFechaEmision.EditValue = DateTime.Today;
            cldFechaVigencia.EditValue = DateTime.Today.AddDays(30);
            txtDiasTranscurridos.EditValue = 0;

            txtFoliosFacturas.EditValue = 0;
            txtFoliosNominas.EditValue = 0;
            txtFoliosRecepcionPagos.EditValue = 0;

        }
        /// <summary>
        /// Genera la licencia a partir de datos
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DesarrollosPyC.Com.Licencias.Class.Licencia lic = new Com.Licencias.Class.Licencia();
            lic.EmitidoPor = new Com.Licencias.Class.EntidadEmisora();
            lic.EmitidoPor.Nombre = txtEntidadEmisora.Text;

            List<DesarrollosPyC.Com.Licencias.Class._Aplicacion_Licencia> ap = new List<Com.Licencias.Class._Aplicacion_Licencia>();
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem i in chkAplicacionLicencia.Properties.Items)
            {
                if (i.CheckState == CheckState.Checked)
                    ap.Add((Com.Licencias.Class._Aplicacion_Licencia)Convert.ToInt16(i.Value));
            }
            lic.A_Licencia = ap.ToArray();

            lic.Receptor = new Com.Licencias.Class.Receptor();
            lic.Receptor.Rfc = txtRFCReceptor.Text;
            lic.Receptor.RazonSocial = txtRazonSocialReceptor.Text;

            lic.FechaEmision = (DateTime)cldFechaEmision.EditValue;
            lic.FechaVigencia = (DateTime)cldFechaVigencia.EditValue;
            if (cldFechaCargaSistema.EditValue != null)
                lic.FechaCargaEnSistema = (DateTime)cldFechaCargaSistema.EditValue;
            lic.DiasOcupado = Convert.ToInt32(txtDiasTranscurridos.EditValue);

            lic.FoliosFacturas = Convert.ToInt32(txtFoliosFacturas.EditValue);
            lic.FoliosNominas = Convert.ToInt32(txtFoliosNominas.EditValue);
            lic.FoliosRecepcionPagos = Convert.ToInt32(txtFoliosRecepcionPagos.EditValue);

            lic.T_ServicioTimbrado = (Com.Licencias.Class._Servicio_Timbrado)System.Enum.Parse(typeof(Com.Licencias.Class._Servicio_Timbrado), rdgTipoServicioTimbrado.EditValue.ToString());
            lic.T_Usuario = txtUsuarioTimbrado.Text;
            lic.T_Pass = txtPassUsuarioTiumbrado.Text;
            lic.T_IdServicio = txtNoServicioTimbrado.Text;

            var result = DesarrollosPyC.Com.Licencias.Managers.M_Licencia.GeneraLicenciaFile(lic);
            txtDiccionario.Text = lic.A_Ascii.Select(i => i.Key.ToString("000")).Aggregate((a, b) => a + b);
            txtMatriz.Text = lic.M_Encriptado.ToString();
            txtResultado.Text = result.ToString().Trim();
            
            //var retorno = DesarrollosPyC.Com.Licencias.Managers.M_Licencia.GeneraLicenciaObj(txtResultado.Lines);
        }

        /// <summary>
        /// Guarda el archivo de liencia
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void txtGuardaLicencia_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "*.lic|*.lic";
                dialog.FileName = txtRFCReceptor.Text + "." + ((DateTime)cldFechaEmision.EditValue).ToShortDateString().Replace("/", "");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtGuardaLicencia.Text = dialog.FileName;
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(dialog.FileName))
                    {
                        for (int i = 0; i < txtResultado.Lines.Length; i++)
                            writer.WriteLine(txtResultado.Lines[i]);

                        writer.Flush();
                        writer.Close();
                    }
                }
            }
        }
    }
}
