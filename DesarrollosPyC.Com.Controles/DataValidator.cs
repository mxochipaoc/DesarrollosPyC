using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.Com.Controles
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(DesarrollosPyC.Com.Controles.DataValidator), "DesarrollosPyC.Com.Controles.Properties.Resources.Flag_red.png")]
    public partial class DataValidator : Component
    {
        /// <summary>
        /// Color del borde del campo con error
        /// </summary>
        [Category("Apariencia"), DefaultValue(typeof(Color), "Red")]
        [Description("Determina el color del control al ser invalido su contenido")]
        public Color ErrorBorderColor
        {
            get { return errorBorderColor; }
            set { errorBorderColor = value; }
        }

        /// <summary>
        /// Color del borde del control evaluado
        /// </summary>
        private Color errorBorderColor = Color.Red;

        /// <summary>
        /// Tiempo de cierre del mensaje de validación
        /// </summary>
        [Category("Apariencia"), DefaultValue((int)1500)]
        [Description("Tiempo de cierre del mensaje de validación en milisegundos")]
        public int DelayPopUp
        {
            get { return delayPopUp; }
            set { delayPopUp = value; }
        }
        private int delayPopUp = 1500;

        /// <summary>
        /// Título del mensaje de validación
        /// </summary>
        [Category("Apariencia"), DefaultValue("Elemento no válido")]
        [Description("Título del mesaje de validación")]
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        /// <summary>
        /// Encabezado del mensaje
        /// </summary>
        private string titulo = "Elemento no válido";

        /// <summary>
        /// Mensaje de validación
        /// </summary>
        [Category("Apariencia"), DefaultValue("El contenido del campo no es válido.")]
        [Description("Mensaje de validación por defecto.")]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        /// <summary>
        /// Mensaje de valdiación
        /// </summary>
        private string mensaje = "Mensaje de validación por defecto.";
        
        /// <summary>
        /// Ubicación del mensaje de validación
        /// </summary>
        [Category("Apariencia"), DefaultValue(typeof(ToolTipLocation), "Default")]
        [Description("Ubicación del mensaje de validación.")]
        public ToolTipLocation UbicacionMensaje
        {
            get { return ubicacionMensaje; }
            set { ubicacionMensaje = value; }
        }

        /// <summary>
        /// Ubicación del mensaje de validación
        /// </summary>
        private ToolTipLocation ubicacionMensaje = ToolTipLocation.Default;

        /// <summary>
        /// Validador de controles DevExpress ConEditValue
        /// </summary>
        /// <param name="ctl">Control a aplicar validación</param>
        /// <param name="Mensaje">Mensaje de validación (Alternativo, si no se conoce poner null)</param>
        /// <returns>Resultado de la validación</returns>
        public bool ValidaContenidoControl(DevExpress.XtraEditors.BaseEdit ctl, string Mensaje)
        {
            if (ctl != null)
            {
                bool valido = !string.IsNullOrEmpty(ctl.Text);

                if (valido)
                {
                    if (ctl.Properties.DisplayFormat.FormatType == FormatType.Numeric ||
                        ctl.Properties.EditFormat.FormatType == FormatType.Numeric)
                        valido = Convert.ToDecimal(ctl.EditValue) > decimal.Zero;
                }

                if (!valido)
                {
                    ctl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    ctl.Properties.Appearance.BorderColor = ErrorBorderColor;

                    ctl.Focus();

                    ToolTipController mensaje = new ToolTipController();
                    mensaje.ToolTipType = ToolTipType.SuperTip;
                    mensaje.AutoPopDelay = DelayPopUp;
                    mensaje.ToolTipLocation = UbicacionMensaje;
                    mensaje.AppearanceTitle.BeginUpdate();
                    mensaje.AppearanceTitle.Options.UseImage = true;
                    mensaje.AppearanceTitle.Image = Properties.Resources.Flag_red;
                    mensaje.AppearanceTitle.EndUpdate();

                    Point p = ctl.Location;
                    Control parent = ctl.Parent;
                    while (parent != null)
                    {
                        p = new Point(parent.Location.X + p.X, parent.Location.Y + p.Y);
                        parent = parent.Parent;
                    }
                    p = new Point(p.X + ctl.Size.Width, p.Y + ctl.Size.Height);

                    if (string.IsNullOrEmpty(Mensaje))
                        mensaje.ShowHint(this.Mensaje, Titulo, p);
                    else
                        mensaje.ShowHint(Mensaje, Titulo, p);
                }
                else
                {
                    ctl.BorderStyle = BorderStyles.Default;
                    ctl.Properties.Appearance.BorderColor = Color.Empty;

                    ctl.SuperTip = null;
                }
                return valido;
            }
            else
                return false;
        }
    }
}