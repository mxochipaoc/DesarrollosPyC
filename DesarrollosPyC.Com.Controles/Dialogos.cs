using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.Com.Controles
{
    /// <summary>
    /// Clase perteneciente al manejo de mensajes/alertas de las aplicaciones
    /// </summary>
    public static class Dialogos
    {
        /// <summary>
        /// Mensaje de operación exitosa
        /// </summary>
        public static void OperacionExitosa()
        {
            XtraMessageBox.Show("Operación exitosa", "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
        }
        /// <summary>
        /// Visualización de alerta personalizada
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        public static void Alerta(string mensaje)
        {
            XtraMessageBox.Show(mensaje, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
        /// <summary>
        /// Confirmación de guardado de un elemento
        /// </summary>
        /// <returns>Resultado de la confirmación</returns>
        public static bool ConfirmaGuardado()
        {
            return XtraMessageBox.Show("¿Esta seguro de guardar el elemento?", "Confirmación", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) ==
                 System.Windows.Forms.DialogResult.Yes;
        }
        /// <summary>
        /// Confirmación de guardado de cancelado de un elemento
        /// </summary>
        /// <returns>Resultado de la confirmación</returns>
        public static bool ConfirmaCancelacion()
        {
            return XtraMessageBox.Show("¿Esta seguro de cancelar el elemento?", "Confirmación", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) ==
                 System.Windows.Forms.DialogResult.Yes;
        }
        /// <summary>
        /// Confirmación de guardado de cancelado de un elemento
        /// </summary>
        /// <param name="mensaje">Mensaje personalizado</param>
        /// <returns>Resultado de la confirmación</returns>
        public static bool ConfirmaPersonalizada(string mensaje)
        {
            return XtraMessageBox.Show(mensaje, "Confirmación", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) ==
                 System.Windows.Forms.DialogResult.Yes;
        }
        /// <summary>
        /// Visualización de error
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        public static void Error(string mensaje)
        {
            XtraMessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        /// <summary>
        /// Visualización de error
        /// </summary>
        /// <param name="error">Exepción</param>
        public static void Error(Exception error)
        {
            XtraMessageBox.Show(error.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
