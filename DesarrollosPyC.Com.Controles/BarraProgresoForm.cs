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
    public partial class BarraProgresoForm : Form
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="animacion">Animación de la barra de progreso</param>
        public BarraProgresoForm(BarraProgresoAnimacion animacion = BarraProgresoAnimacion.Animacion2)
        {
            InitializeComponent();
            
            if (animacion == BarraProgresoAnimacion.Animacion1)
                imgLoading.Image = Properties.Resources.loading_circulo;
            if (animacion == BarraProgresoAnimacion.Animacion2)
                imgLoading.Image = Properties.Resources.loading_circulo2;
            if (animacion == BarraProgresoAnimacion.Animacion3)
                imgLoading.Image = Properties.Resources.loading_circulo3;
            if (animacion == BarraProgresoAnimacion.Animacion4)
                imgLoading.Image = Properties.Resources.loading_circulo4;
            if (animacion == BarraProgresoAnimacion.Animacion5)
                imgLoading.Image = Properties.Resources.loading_circulo_colores;
            if (animacion == BarraProgresoAnimacion.Animacion6)
                imgLoading.Image = Properties.Resources.loading_cuadros_color;
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
        /// Encabezado del proceso
        /// </summary>
        string Encabezado { get; set; }

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
            lblEncabezado.Text = string.IsNullOrEmpty(Encabezado) ? "Cargando datos" : Encabezado;
            lblEstatus.Text = string.IsNullOrEmpty(Estatus) ? "Espere mientras la operación termina" : Estatus;
            if (!Hilo.IsAlive)
            {
                Timer.Stop();
                if (Ex != null)
                {
                    lblEncabezado.Text = "Error en la operación";
                    lblEncabezado.ForeColor = System.Drawing.Color.Red;
                    lblEstatus.Text = Ex.Message;
                    lknVerMasDetalles.Visible = true;
                    lknCancelar.Text = "Cerrar";
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        /// <summary>
        /// Visualización detallada de error, si ocurre
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void lknVerMasDetalles_Click(object sender, EventArgs e)
        {
            Dialogos.Error(Ex);
            DialogResult = DialogResult.Abort;
            Close();
        }

        /// <summary>
        /// Cancelación de carga, cierre en falso
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void lknCancelar_Click(object sender, EventArgs e)
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
        public void MuestraEstatusProceso(string encabezado = "Cargando datos", string estatus = "Espere mientras la operación termina")
        {
            Encabezado = encabezado;
            Estatus = estatus;
        }
        #endregion
    }
}
