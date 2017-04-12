using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.Com.Controles
{
    /// <summary>
    /// Barra de progreso de carga de datos
    /// </summary>
    public partial class BarraProgresoForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public BarraProgresoForm()
        {
            InitializeComponent();
        }

        #region Propiedades del formulario
        /// <summary>
        /// Métodod e carga de datos
        /// </summary>
        public BarraProgresoMetodoCarga MetodoCarga { get; set; }
        /// <summary>
        /// Error en la carga de datos
        /// </summary>
        public Exception Ex { get; set; }
        /// <summary>
        /// Hilo de carga de datos
        /// </summary>
        System.Threading.Thread Hilo { get; set; }
        /// <summary>
        /// Estatus del proceso
        /// </summary>
        string Estatus { get; set; }
        /// <summary>
        /// Inicio de la carga de datos
        /// </summary>
        DateTime InicioCarga { get; set; }
        /// <summary>
        /// Datos cargados
        /// </summary>
        public object DatosCargados { get; set; }
        #endregion

        #region Métodos del formulario
        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BarraProgresoForm_Load(object sender, EventArgs e)
        {
            Timer.Start();
            InicioCarga = DateTime.Now;
            Hilo = new System.Threading.Thread(() =>
            {
                if (MetodoCarga != null)
                {
                    try
                    {
                        DatosCargados = MetodoCarga(MuestraEstatusProceso);
                    }
                    catch (Exception ex)
                    {
                        Ex = ex;
                    }
                }
            });

            Hilo.Start();
        }
        /// <summary>
        /// Reporta el estatus del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan transcurrido = DateTime.Now - InicioCarga;
            lblTiempo.Text = transcurrido.ToString(@"hh\:mm\:ss");
            txtEstatus.Text = string.IsNullOrEmpty(Estatus) ? "Cargando datos ..." : Estatus;
            if (!Hilo.IsAlive)
            {
                Timer.Stop();
                if (Ex != null)
                {
                    txtEstatus.Text = Ex.Message;
                    btnCancelar.Text = "Cerrar";
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }
        /// <summary>
        /// Cancelación de carga, cierre en falso
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Hilo.ThreadState == System.Threading.ThreadState.Running)
                Hilo.Abort();

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
        /// <summary>
        /// Muestra el estatus del proceso
        /// </summary>
        /// <param name="estatus">Estatus</param>
        public void MuestraEstatusProceso(string estatus)
        {
            Estatus = estatus;
        }
        #endregion
    }
}
