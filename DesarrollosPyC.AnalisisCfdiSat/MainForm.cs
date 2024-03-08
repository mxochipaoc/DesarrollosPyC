using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.AnalisisCfdiSat
{
    /// <summary>
    /// Analisis de facturas
    /// </summary>
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
        }

        #region Estatus de carga del formulario
        /// <summary>
        /// Estados de procesamiento del formulario
        /// </summary>
        enum Estado_Formulario
        {
            En_Reposo,
            Carga_Ingresos,
            Carga_Egresos
        }
        #endregion

        #region Propiedades de la pantalla
        /// <summary>
        /// Bandera de proceso de carga
        /// </summary>
        bool EnProceso { get; set; }
        /// <summary>
        /// Mensaje de estatus de proceso
        /// </summary>
        string EstatusProceso { get; set; }
        /// <summary>
        /// Estatus general de la aplicación
        /// </summary>
        string EstatusGeneral { get; set; }
        #endregion

        #region Propiedades de manejo de visualización de datos
        /// <summary>
        /// Estatus de procesamiento del formulario
        /// </summary>
        Estado_Formulario EstatusFormulario { get; set; }
        /// <summary>
        /// Facturas de ingreso
        /// </summary>
        Helper_DataTable Facturas_Ingresos_Detallado { get; set; }
        /// <summary>
        /// Facturas de ingreso
        /// </summary>
        Helper_DataTable Facturas_Ingresos_Concentrado { get; set; }
        /// <summary>
        /// Recibos de nómina 1.1
        /// </summary>
        Helper_DataTable Facturas_Nomima11 { get; set; }
        /// <summary>
        /// Recibos de nómina 1.2
        /// </summary>
        Helper_DataTable Facturas_Nomima12 { get; set; }
        /// <summary>
        /// Facturas de egreso
        /// </summary>
        Helper_DataTable Facturas_Egresos_Detallado { get; set; }
        /// <summary>
        /// Facturas de egreso
        /// </summary>
        Helper_DataTable Facturas_Egresos_Concentrado { get; set; }
        /// <summary>
        /// Facturas de egreso, nomina 11 recibida
        /// </summary>
        Helper_DataTable Facturas_Egresos_Nomina11 { get; set; }
        /// <summary>
        /// Facturas de egreso, nomina 12 recibida
        /// </summary>
        Helper_DataTable Facturas_Egresos_Nomina12 { get; set; }
        /// <summary>
        /// Comprobantes seleccionados
        /// </summary>
        Dictionary<string, object> Uuid_Cfdi { get; set; }
        /// <summary>
        /// Cliente de validación de CFDi en el portal del SAT
        /// </summary>
        ConsultaCFDIService.ConsultaCFDIServiceClient SatClient { get; set; }
        #endregion

        #region Métodos propios del formulario
        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            pgpCargaDatos.Hide();

            if (DesarrollosPyC.CfdiSat.Environment.Aplicacion.Licencias == null)
                DesarrollosPyC.CfdiSat.Environment.Manejador.CargaLicencias();

            lkpRazonSocial.Properties.DataSource = DesarrollosPyC.CfdiSat.Environment.Aplicacion.Licencias;
        }

        /// <summary>
        /// Cuando el formulario de accesa
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada != null)
                lkpRazonSocial.EditValue = DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada.Receptor.Rfc;

            txtRutaIngresos.Text = DesarrollosPyC.CfdiSat.Environment.Aplicacion.DirectorioDescargaCfdiAnalisisCfdi;
            txtRutaEgresos.Text = DesarrollosPyC.CfdiSat.Environment.Aplicacion.DirectorioDescargaCfdiAnalisisCfdi;
        }

        /// <summary>
        /// Selección de razon social, reseteo de controles
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void lkpRazonSocial_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.OldValue != null)
            {
                if (!e.OldValue.ToString().Equals(e.NewValue.ToString()))
                {
                    if (DesarrollosPyC.Com.Controles.Dialogos.ConfirmaPersonalizada("Esta acción reiniciará el análisis de datos, ¿Esta seguro de continuar con esta acción?"))
                    {
                        DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada = (DesarrollosPyC.Com.Licencias.Class.Licencia)lkpRazonSocial.Properties.GetDataSourceRowByKeyValue(e.NewValue);
                        txtRFC.Text = DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada.Receptor.Rfc;

                        InicializaControlesAnalisis();
                    }
                    else
                        e.Cancel = true;
                }
            }
            else
            {
                DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada = (DesarrollosPyC.Com.Licencias.Class.Licencia)lkpRazonSocial.Properties.GetDataSourceRowByKeyValue(e.NewValue);
                txtRFC.Text = DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada.Receptor.Rfc;

                InicializaControlesAnalisis();
            }
        }

        /// <summary>
        /// Inicializa controles de análisis
        /// </summary>
        void InicializaControlesAnalisis()
        {
            grdIngresos.DataSource = null;
            grdNominas11.DataSource = null;
            grdNominas12.DataSource = null;

            grdEgresos.DataSource = null;
            grdEgresosNomina11.DataSource = null;
            grdEgresosNomina12.DataSource = null;

            Facturas_Ingresos_Detallado = null;
            Facturas_Ingresos_Concentrado = null;
            Facturas_Nomima11 = null;
            Facturas_Nomima12 = null;

            Facturas_Egresos_Detallado = null;
            Facturas_Egresos_Concentrado = null;
            Facturas_Egresos_Nomina11 = null;
            Facturas_Egresos_Nomina12 = null;

            Uuid_Cfdi = new Dictionary<string, object>();
        }

        /// <summary>
        /// Ejecución de operaciones en un tiempo determinado
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tmrTemporizador_Tick(object sender, EventArgs e)
        {
            this.Enabled = !EnProceso;
            if (EnProceso)
            {
                if (!pgpCargaDatos.IsLoading)
                    pgpCargaDatos.Show();
            }
            else
                pgpCargaDatos.Hide();

            pgpCargaDatos.Description = EstatusProceso;
            lblEstatusGeneral.Text = EstatusGeneral;

            if (!EnProceso)
            {
                // Visualización de facturas de ingresos
                if (EstatusFormulario == Estado_Formulario.Carga_Ingresos)
                {
                    chkIngresosConcentradoDetallado_Toggled(chkIngresosConcentradoDetallado, EventArgs.Empty);

                    GeneraCamposBandasCmposFacturas(grdViewBandNominas11, Facturas_Nomima11);
                    grdNominas11.DataSource = Facturas_Nomima11;

                    GeneraCamposBandasCmposFacturas(grdViewBandNominas12, Facturas_Nomima12);
                    grdNominas12.DataSource = Facturas_Nomima12;

                    EstatusFormulario = Estado_Formulario.En_Reposo;
                }

                // Visualización de facturas de egresos
                if (EstatusFormulario == Estado_Formulario.Carga_Egresos)
                {
                    chkEgresosConcentradoDetallado_Toggled(chkEgresosConcentradoDetallado, EventArgs.Empty);

                    GeneraCamposBandasCmposFacturas(grdViewBandEgresosNomina11, Facturas_Egresos_Nomina11);
                    grdEgresosNomina11.DataSource = Facturas_Egresos_Nomina11;

                    GeneraCamposBandasCmposFacturas(grdViewBandEgresosNomina12, Facturas_Egresos_Nomina12);
                    grdEgresosNomina12.DataSource = Facturas_Egresos_Nomina12;

                    EstatusFormulario = Estado_Formulario.En_Reposo;
                }
            }
        }
        #endregion

        #region Métodos de manejo de facturas de ingresos
        /// <summary>
        /// Lanzado de selección de carpeta de carga de datos de ingresos
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void txtRutaIngresos_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string path = string.Empty;
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = txtRutaIngresos.Text;
                if (dialog.ShowDialog() == DialogResult.OK)
                    path = dialog.SelectedPath;
            }
            txtRutaIngresos.Text = path;
            btnRecargarIngresos_Click(btnRecargarIngresos, EventArgs.Empty);
        }
        /// <summary>
        /// Re lectura de la información de la carpeta de ingresos seleccionada
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnRecargarIngresos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRutaIngresos.Text))
            {
                System.Threading.Thread hilo = new System.Threading.Thread(() =>
                  {
                      // Inicia proceso
                      DateTime inicia_proceso = DateTime.Now;
                      EnProceso = true;
                      EstatusFormulario = Estado_Formulario.Carga_Ingresos;
                      EstatusProceso = "Leyendo carpeta...";
                      EstatusGeneral = "Iniciando análisis de ingresos ...";

                      // Ejecución de análisis
                      string[] files = System.IO.Directory.GetFiles(txtRutaIngresos.Text, "*.xml", System.IO.SearchOption.AllDirectories);
                      System.Collections.ArrayList listData = new System.Collections.ArrayList();
                      int conteo = 0;
                      int total = files.Length;
                      List<object> cfdis = new List<object>();
                      Dictionary<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina> nominas11 = new Dictionary<Com.Facturacion.Comprobantes.V32.Comprobante, Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina>();
                      Dictionary<object, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina> nominas12 = new Dictionary<object, Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina>();
                      foreach (string f in files)
                      {
                          conteo++;
                          EstatusProceso = string.Format("Procesando {0} de {1} ...", conteo, total);

                          System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
                          xml.Load(f);
                          
                          DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante cfdi32 = null;
                          DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante cfdi33 = null;

                          if (xml.GetElementsByTagName("cfdi:Comprobante")[0].Attributes["version"]!= null)
                          {
                              try
                              {
                                  cfdi32 = DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante.LoadFromFile(f);
                              }
                              catch
                              {
                                  // No hace nada
                              }
                          }
                          else if (xml.GetElementsByTagName("cfdi:Comprobante")[0].Attributes["Version"] != null)
                          {
                              try
                              {
                                  cfdi33 = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante.LoadFromFile(f);
                              }
                              catch
                              {
                                  // No hace nada
                              }
                          }
                          if (cfdi32 != null)
                          {
                              if (!cfdi32.Emisor.rfc.Equals(txtRFC.Text))
                                  continue;

                              // Complemento de timbrado
                              DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Tfd.V10.TimbreFiscalDigital timbre = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(cfdi32);
                              if (timbre == null)
                                  continue;

                              // Recuperación de nomina
                              DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina nomina11 = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaNomina11(cfdi32);
                              DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina nomina12 = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaNomina12(cfdi32);

                              if (nomina11 != null)
                                  nominas11.Add(cfdi32, nomina11);
                              else if (nomina12 != null)
                                  nominas12.Add(cfdi32, nomina12);
                              else
                                  cfdis.Add(cfdi32);

                              // lista de facturas generales
                              if (!Uuid_Cfdi.ContainsKey(timbre.UUID))
                                  Uuid_Cfdi.Add(timbre.UUID, cfdi32);
                          }
                          if (cfdi33 != null)
                          {
                              if (!cfdi33.Emisor.Rfc.Equals(txtRFC.Text))
                                  continue;

                              // Complemento de timbrado
                              DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Tfd.V11.TimbreFiscalDigital timbre = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(cfdi33);
                              if (timbre == null)
                                  continue;

                              // Recuperación de nomina
                              DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina nomina12 = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaNomina12(cfdi33);
                              
                              if (nomina12 != null)
                                  nominas12.Add(cfdi33, nomina12);
                              else
                                  cfdis.Add(cfdi33);

                              // lista de facturas generales
                              if (!Uuid_Cfdi.ContainsKey(timbre.UUID))
                                  Uuid_Cfdi.Add(timbre.UUID, cfdi33);
                          }
                      }

                      // Formado de columnas de tabla de ingresos
                      EstatusProceso = "Generando tabla de visualización de datos...";
                      Facturas_Ingresos_Detallado = GeneraTablaDatosCfdiPuroDetallado(cfdis);
                      Facturas_Ingresos_Concentrado = GeneraTablaDatosCfdiPuroConcentrado(cfdis);
                      Facturas_Nomima11 = GeneraTablaDatosCfdiNomina11(nominas11);
                      Facturas_Nomima12 = GeneraTablaDatosCfdiNomina12(nominas12);
                      
                      // Termina proceso
                      EnProceso = false;
                      DateTime termina_proceso = DateTime.Now;
                      TimeSpan duracion = termina_proceso - inicia_proceso;
                      EstatusGeneral = string.Format("{0} elementos procesados en {1:00}:{2:00}:{3:00}", files.Length, duracion.Hours, duracion.Minutes, duracion.Seconds);
                  });
                hilo.Start();
            }
        }
        /// <summary>
        /// Variación de presentación de datos, concentrado, detallado
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void chkIngresosConcentradoDetallado_Toggled(object sender, EventArgs e)
        {
            if (!chkIngresosConcentradoDetallado.IsOn)
            {
                GeneraCamposBandasCmposFacturas(grdViewBandIngresos, Facturas_Ingresos_Detallado);
                grdIngresos.DataSource = Facturas_Ingresos_Detallado;
            }
            else
            {
                GeneraCamposBandasCmposFacturas(grdViewBandIngresos, Facturas_Ingresos_Concentrado);
                grdIngresos.DataSource = Facturas_Ingresos_Concentrado;
            }
        }
        #endregion

        #region Métodos de manejo de facturas de egresos
        /// <summary>
        /// Lanzado de selección de carpeta de carga de datos de egresos
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void txtRutaEgresos_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string path = string.Empty;
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = txtRutaEgresos.Text;
                if (dialog.ShowDialog() == DialogResult.OK)
                    path = dialog.SelectedPath;
            }
            txtRutaEgresos.Text = path;
            btnRecargarEgresos_Click(btnRecargarEgresos, EventArgs.Empty);
        }
        /// <summary>
        /// Re lectura de la información de la carpeta de egresos seleccionada
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnRecargarEgresos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRutaEgresos.Text))
            {
                System.Threading.Thread hilo = new System.Threading.Thread(() =>
                {
                    // Inicia proceso
                    DateTime inicia_proceso = DateTime.Now;
                    EnProceso = true;
                    EstatusFormulario = Estado_Formulario.Carga_Egresos;
                    EstatusProceso = "Leyendo carpeta...";
                    EstatusGeneral = "Iniciando análisis de egresos ...";

                    // Ejecución de análisis
                    string[] files = System.IO.Directory.GetFiles(txtRutaEgresos.Text, "*.xml", System.IO.SearchOption.AllDirectories);
                    System.Collections.ArrayList listData = new System.Collections.ArrayList();
                    int conteo = 0;
                    int total = files.Length;
                    List<object> cfdis = new List<object>();
                    Dictionary<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina> nominas11 = new Dictionary<Com.Facturacion.Comprobantes.V32.Comprobante, Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina>();
                    Dictionary<object, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina> nominas12 = new Dictionary<object, Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina>();
                    foreach (string f in files)
                    {
                        conteo++;
                        EstatusProceso = string.Format("Procesando {0} de {1} ...", conteo, total);

                        System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
                        xml.Load(f);

                        DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante cfdi32 = null;
                        DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante cfdi33 = null;

                        if (xml.GetElementsByTagName("cfdi:Comprobante")[0].Attributes["version"] != null)
                        {
                            try
                            {
                                cfdi32 = DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante.LoadFromFile(f);
                            }
                            catch
                            {
                                // No hace nada
                            }
                        }
                        else if (xml.GetElementsByTagName("cfdi:Comprobante")[0].Attributes["Version"] != null)
                        {
                            try
                            {
                                cfdi33 = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante.LoadFromFile(f);
                            }
                            catch
                            {
                                // No hace nada
                            }
                        }

                        if (cfdi32 != null)
                        {
                            if (!cfdi32.Receptor.rfc.Equals(txtRFC.Text))
                                continue;

                            // Complemento de timbrado
                            DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Tfd.V10.TimbreFiscalDigital timbre = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(cfdi32);
                            if (timbre == null)
                                continue;

                            // Recuperación de nomina
                            DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina nomina11 = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaNomina11(cfdi32);
                            DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina nomina12 = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaNomina12(cfdi32);

                            if (nomina11 != null)
                                nominas11.Add(cfdi32, nomina11);
                            else if (nomina12 != null)
                                nominas12.Add(cfdi32, nomina12);
                            else
                                cfdis.Add(cfdi32);

                            // lista de facturas generales
                            if (!Uuid_Cfdi.ContainsKey(timbre.UUID))
                                Uuid_Cfdi.Add(timbre.UUID, cfdi32);
                        }
                        if (cfdi33 != null)
                        {
                            if (!cfdi33.Receptor.Rfc.Equals(txtRFC.Text))
                                continue;

                            // Complemento de timbrado
                            DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Tfd.V11.TimbreFiscalDigital timbre = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(cfdi33);
                            if (timbre == null)
                                continue;

                            // Recuperación de nomina
                            DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina nomina12 = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaNomina12(cfdi33);

                            if (nomina12 != null)
                                nominas12.Add(cfdi33, nomina12);
                            else
                                cfdis.Add(cfdi33);

                            // lista de facturas generales
                            if (!Uuid_Cfdi.ContainsKey(timbre.UUID))
                                Uuid_Cfdi.Add(timbre.UUID, cfdi33);
                        }
                    }

                    // Formado de columnas de tabla de ingresos
                    EstatusProceso = "Generando tabla de visualización de datos...";
                    Facturas_Egresos_Detallado = GeneraTablaDatosCfdiPuroDetallado(cfdis);
                    Facturas_Egresos_Concentrado = GeneraTablaDatosCfdiPuroConcentrado(cfdis);
                    Facturas_Egresos_Nomina11 = GeneraTablaDatosCfdiNomina11(nominas11);
                    Facturas_Egresos_Nomina12 = GeneraTablaDatosCfdiNomina12(nominas12);

                    // Termina proceso
                    EnProceso = false;
                    DateTime termina_proceso = DateTime.Now;
                    TimeSpan duracion = termina_proceso - inicia_proceso;
                    EstatusGeneral = string.Format("{0} elementos procesados en {1:00}:{2:00}:{3:00}", files.Length, duracion.Hours, duracion.Minutes, duracion.Seconds);
                });
                hilo.Start();
            }
        }
        /// <summary>
        /// Variación de presentación de datos, concentrado, detallado
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void chkEgresosConcentradoDetallado_Toggled(object sender, EventArgs e)
        {
            if (!chkEgresosConcentradoDetallado.IsOn)
            {
                GeneraCamposBandasCmposFacturas(grdViewBandEgresos, Facturas_Egresos_Detallado);
                grdEgresos.DataSource = Facturas_Egresos_Detallado;
            }
            else
            {
                GeneraCamposBandasCmposFacturas(grdViewBandEgresos, Facturas_Egresos_Concentrado);
                grdEgresos.DataSource = Facturas_Egresos_Concentrado;
            }
        }
        #endregion

        #region Formado de tablas de datos a ser visualizadas
        /// <summary>
        /// Genera la tabla de visualización de datos en formato detallado
        /// </summary>
        /// <param name="cfdis">Facturas recuepradas</param>
        /// <returns></returns>
        public Helper_DataTable GeneraTablaDatosCfdiPuroDetallado(List<object> cfdis)
        {
            var tabla = new Helper_DataTable();
            EstatusProceso = "Generando columnas principales ...";
            var datosGenerales = tabla.NewGroupDataColumn("Datos principales");
            datosGenerales.NewDataColumn("ID", "ID", typeof(int), false);
            datosGenerales.NewDataColumn("Version", "Versión", typeof(string), false);
            datosGenerales.NewDataColumn("Emisor", "Emisor", typeof(string), true);
            datosGenerales.NewDataColumn("EmisorRFC", "Emisor RFC", typeof(string), false);
            datosGenerales.NewDataColumn("Receptor", "Receptor", typeof(string), true);
            datosGenerales.NewDataColumn("ReceptorRFC", "Receptor RFC", typeof(string), false);
            datosGenerales.NewDataColumn("Serie", "Serie", typeof(string), true);
            datosGenerales.NewDataColumn("Folio", "Folio", typeof(string), true);
            datosGenerales.NewDataColumn("UUID", "UUID", typeof(string), false);
            datosGenerales.NewDataColumn("Fecha", "Fecha", typeof(DateTime), false, DevExpress.Utils.FormatType.DateTime, "d");
            datosGenerales.NewDataColumn("Anhio", "Año", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "0000");
            datosGenerales.NewDataColumn("Mes", "Mes", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");
            datosGenerales.NewDataColumn("Semana", "Semana", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");

            var importesTotales = tabla.NewGroupDataColumn("Importes totales");
            EstatusProceso = "Generando columnas de importes totales ...";
            var importes = importesTotales.NewGroupDataColumn("Importes");
            importes.NewDataColumn("TipoComprobante", "T. comprobante", typeof(string), true);
            importes.NewDataColumn("MetodoPago", "M. pago", typeof(string), true);
            importes.NewDataColumn("NoCuentaPago", "Cta. pago", typeof(string), true);
            importes.NewDataColumn("FactOriginal", "Fact. original", typeof(string), true);
            importes.NewDataColumn("Moneda", "Moneda", typeof(string), true);
            importes.NewDataColumn("TipoCambio", "T. cambio", typeof(string), true);
            importes.NewDataColumn("Subtotal", "Subtotal", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");
            importes.NewDataColumn("Descuento", "Descuento", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");
            importes.NewDataColumn("MotivoDescuento", "M. descuento", typeof(string), true);
            importes.NewDataColumn("Total", "Total", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");

            EstatusProceso = "Generando columnas de impuestos ...";
            List<Impuestos_Encontrados> imps = new List<Impuestos_Encontrados>();
            //-------------------------------------------------------------------   CFDi 3.2
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante)c).ToList())
            {
                // Recuperación de impuestos federales
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                         i.Impuesto.Equals(imp.impuesto.ToString()) &&
                         i.Tasa == imp.tasa).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                Impuesto = imp.impuesto.ToString(),
                                Tasa = imp.tasa
                            });
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones)
                    {
                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido &&
                         i.Impuesto.Equals(imp.impuesto.ToString())).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Retenido,
                                Impuesto = imp.impuesto.ToString(),
                                Tasa = imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR ? 10M :
                                    imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.IVA ? 10.67M : 0
                            });
                    }
                }
                // Recuperación de impuestos locales
                DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocales implocal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    if (implocal.Items != null)
                    {
                        foreach (var imp in implocal.Items)
                        {
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocTrasladado) &&
                                    i.Tasa == im.TasadeTraslado).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocTrasladado,
                                        Tasa = im.TasadeTraslado
                                    });
                            }
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocRetenido) &&
                                    i.Tasa == im.TasadeRetencion).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocRetenido,
                                        Tasa = im.TasadeRetencion
                                    });
                            }
                        }
                    }
                }
            }
            //------------------------------------------------------------------------------
            //-------------------------------------------------------------------   CFDi 3.3
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante)c).ToList())
            {
                // Recuperación de impuestos federales
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());

                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                         i.Impuesto.Equals(c_imp.Descripcion) &&
                         i.Tasa == imp.TasaOCuota * 100M).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                Impuesto = c_imp.Descripcion,
                                Tasa = imp.TasaOCuota * 100M
                            });
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones)
                    {
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());

                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido &&
                         i.Impuesto.Equals(c_imp.Descripcion)).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Retenido,
                                Impuesto = c_imp.Descripcion,
                                Tasa = imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item001 ? 10M :
                                    imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item002 ? 10.67M : 0
                            });
                    }
                }
                // Recuperación de impuestos locales
                DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocales implocal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    if (implocal.Items != null)
                    {
                        foreach (var imp in implocal.Items)
                        {
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocTrasladado) &&
                                    i.Tasa == im.TasadeTraslado).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocTrasladado,
                                        Tasa = im.TasadeTraslado
                                    });
                            }
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocRetenido) &&
                                    i.Tasa == im.TasadeRetencion).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocRetenido,
                                        Tasa = im.TasadeRetencion
                                    });
                            }
                        }
                    }
                }
            }
            // Grupos y clumnas de impuestos
            if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal).Count() > 0)
            {
                var impuestosFederales = importesTotales.NewGroupDataColumn("Imp. Federales");
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado).Count() > 0)
                {
                    var impuestosFederalesTraslados = impuestosFederales.NewGroupDataColumn("Trasladados");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado))
                    {
                        impuestosFederalesTraslados.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto + " " + c.Tasa.ToString("n2") + "%",
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido).Count() > 0)
                {
                    var impuestosFederalesTraslados = impuestosFederales.NewGroupDataColumn("Retenidos");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido))
                    {
                        impuestosFederalesTraslados.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto,
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
            }
            if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal).Count() > 0)
            {
                var impuestosEstatales = importesTotales.NewGroupDataColumn("Imp. Estatales");
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado).Count() > 0)
                {
                    var impuestosEstatalesTraslados = impuestosEstatales.NewGroupDataColumn("Trasladados");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado))
                    {
                        impuestosEstatalesTraslados.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto + " " + c.Tasa.ToString("n2") + "%",
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido).Count() > 0)
                {
                    var impuestosEstatalesRetenidos = impuestosEstatales.NewGroupDataColumn("Retenidos");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido))
                    {
                        impuestosEstatalesRetenidos.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto + " " + c.Tasa.ToString("n2") + "%",
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
            }
            //------------------------------------------------------------------------------            
            //-------------------------------------------------------------------  Conceptos
            EstatusProceso = "Generando columnas de conceptos ...";
            var conceptos = tabla.NewGroupDataColumn("Conceptos");
            var conceptoDatos = conceptos.NewGroupDataColumn("Datos del concepto");
            conceptoDatos.NewDataColumn("NoIdentificacion", "No. identificación", typeof(string), true);
            conceptoDatos.NewDataColumn("ClaveProdServ", "Clave prd. serv.", typeof(string), true);
            conceptoDatos.NewDataColumn("Descripcion", "Descripción", typeof(string), false);
            conceptoDatos.NewDataColumn("UM", "U.M.", typeof(string), true);
            conceptoDatos.NewDataColumn("ClaveUnidad", "Clave UM", typeof(string), true);

            var conceptoImportes = conceptos.NewGroupDataColumn("Importes");
            conceptoImportes.NewDataColumn("Cantidad", "Cantidad", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "n2");
            conceptoImportes.NewDataColumn("ValorUnitario", "V. unitario", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");
            conceptoImportes.NewDataColumn("Importe", "Importe", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");
            conceptoImportes.NewDataColumn("C_Descuento", "C. Descuento", typeof(decimal), true, DevExpress.Utils.FormatType.Numeric, "c2");
            var conceptoImpuestos = conceptos.NewGroupDataColumn("Impuestos");
            foreach (var imp in imps)
            {
                conceptoImpuestos.NewDataColumn("C_" + imp.Impuesto.Replace(" ", "").Replace(".", "") + "_" + imp.Tasa.ToString("n2").Replace(".", "_"),
                    imp.Impuesto + " " + imp.Tasa.ToString("n2") + "%",
                    typeof(decimal),
                    true,
                    DevExpress.Utils.FormatType.Numeric,
                    "c2");
            }

            EstatusProceso = "Generando columnas de validaciones ...";
            var validaciones = tabla.NewGroupDataColumn("Validación de datos");
            validaciones.NewDataColumn("ValidaSAT", "SAT", typeof(string), true);
            validaciones.NewDataColumn("Reimprimir", "PDF", typeof(string), true);
            //------------------------------------------------------------------------------

            // paso de datos a ser mostrados
            EstatusProceso = "Paso de datos a ser mostrados ...";
            decimal imp_cal = decimal.Zero;
            bool find_isr = false;
            //-------------------------------------------------------------------   CFDi 3.2
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante)c).ToList())
            {
                Dictionary<object, Impuestos_Analisis32> imps_cfdi = new Dictionary<object, Impuestos_Analisis32>();
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = imp.importe;
                        imp_tr.Tasa = imp.tasa / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones.Where(i => i.impuesto != Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = imp.importe;
                        imp_tr.Tasa = 0.1067M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }
                var implocal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).TasadeTraslado / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).TasadeRetencion / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }

                // Datos de los conceptos
                foreach (var conc in cfdi.Conceptos)
                {
                    var row = tabla.NewRow();
                    row["ID"] = tabla.Rows.Count + 1;
                    row["Version"] = "3.2";
                    row["Emisor"] = cfdi.Emisor.nombre;
                    row["EmisorRFC"] = cfdi.Emisor.rfc;
                    row["Receptor"] = cfdi.Receptor.nombre;
                    row["ReceptorRFC"] = cfdi.Receptor.rfc;
                    row["Serie"] = cfdi.serie;
                    row["Folio"] = cfdi.folio;

                    var timbre = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(cfdi);
                    row["UUID"] = timbre.UUID;

                    row["Fecha"] = cfdi.fecha;
                    row["Anhio"] = cfdi.fecha.Year;
                    row["Mes"] = cfdi.fecha.Month;
                    row["Semana"] = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(cfdi.fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                    row["TipoComprobante"] = cfdi.tipoDeComprobante.ToString();
                    row["MetodoPago"] = cfdi.metodoDePago;
                    row["NoCuentaPago"] = cfdi.NumCtaPago;
                    row["FactOriginal"] = cfdi.FolioFiscalOrig;
                    row["Moneda"] = cfdi.Moneda;
                    row["TipoCambio"] = cfdi.TipoCambio;
                    row["Subtotal"] = cfdi.subTotal;
                    row["Descuento"] = cfdi.descuento;
                    row["MotivoDescuento"] = cfdi.motivoDescuento;
                    row["Total"] = cfdi.total;

                    // Recuperación de impuestos
                    if (cfdi.Impuestos.Traslados != null)
                    {
                        foreach (var imp in cfdi.Impuestos.Traslados)
                        {
                            row[imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.tasa.ToString("n2").Replace(".", "_")] = imp.importe;
                        }
                    }
                    if (cfdi.Impuestos.Retenciones != null)
                    {
                        foreach (var imp in cfdi.Impuestos.Retenciones)
                        {
                            if (imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR)
                                row[imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_10_00"] = imp.importe;
                            else if (imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.IVA)
                                row[imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_10_67"] = imp.importe;
                        }
                    }

                    if (implocal != null)
                    {
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                        {
                            row[imp.ImpLocTrasladado.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeTraslado.ToString("n2").Replace(".", "_")] = imp.Importe;
                        }
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                        {
                            row[imp.ImpLocRetenido.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeRetencion.ToString("n2").Replace(".", "_")] = imp.Importe;
                        }
                    }

                    row["NoIdentificacion"] = conc.noIdentificacion;
                    row["Descripcion"] = conc.descripcion;
                    row["UM"] = conc.unidad;

                    row["Cantidad"] = conc.cantidad;
                    row["ValorUnitario"] = conc.valorUnitario;
                    row["Importe"] = conc.importe;

                    // Recuperación de impuestos
                    if (conc.importe == decimal.Zero)
                        continue;
                    find_isr = false;
                    if (cfdi.Impuestos.Traslados != null)
                    {
                        foreach (var imp in cfdi.Impuestos.Traslados)
                        {
                            if (imps_cfdi.ContainsKey(imp))
                            {
                                if (imps_cfdi[imp].Impuesto_Concepto.ContainsKey(conc))
                                {
                                    imp_cal = imps_cfdi[imp].Impuesto_Concepto[conc];
                                    if (imp_cal > decimal.Zero)
                                        row["C_" + imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.tasa.ToString("n2").Replace(".", "_")] = imp_cal;
                                }
                            }
                        }
                    }
                    if (cfdi.Impuestos.Retenciones != null)
                    {
                        foreach (var imp in cfdi.Impuestos.Retenciones)
                        {
                            if (imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR && !find_isr)
                            {
                                find_isr = true;
                                row["C_" + imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_10_00"] = imp.importe;
                            }
                            else if (imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.IVA)
                            {
                                if (imps_cfdi.ContainsKey(imp))
                                {
                                    if (imps_cfdi[imp].Impuesto_Concepto.ContainsKey(conc))
                                    {
                                        imp_cal = imps_cfdi[imp].Impuesto_Concepto[conc];
                                        if (imp_cal > decimal.Zero)
                                            row["C_" + imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_10_67"] = imp_cal;
                                    }
                                }
                            }
                        }
                    }

                    if (implocal != null)
                    {
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                        {
                            if (imps_cfdi.ContainsKey(imp))
                            {
                                if (imps_cfdi[imp].Impuesto_Concepto.ContainsKey(conc))
                                {
                                    imp_cal = imps_cfdi[imp].Impuesto_Concepto[conc];
                                    if (imp_cal > decimal.Zero)
                                        row["C_" + imp.ImpLocTrasladado.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeTraslado.ToString("n2").Replace(".", "_")] = imp_cal;
                                }
                            }
                        }
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                        {
                            if (imps_cfdi.ContainsKey(imp))
                            {
                                if (imps_cfdi[imp].Impuesto_Concepto.ContainsKey(conc))
                                {
                                    imp_cal = imps_cfdi[imp].Impuesto_Concepto[conc];
                                    if (imp_cal > decimal.Zero)
                                        row["C_" + imp.ImpLocRetenido.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeRetencion.ToString("n2").Replace(".", "_")] = imp_cal;
                                }
                            }
                        }
                    }

                    row["Reimprimir"] = "PDF";

                    tabla.Rows.Add(row);
                }
            }
            //------------------------------------------------------------------------------

            imp_cal = decimal.Zero;
            find_isr = false;
            //-------------------------------------------------------------------   CFDi 3.3
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante)c).ToList())
            {
                Dictionary<object, Impuestos_Analisis33> imps_cfdi = new Dictionary<object, Impuestos_Analisis33>();
                var implocal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis33();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).TasadeTraslado / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis33();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).TasadeRetencion / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }

                // Datos de los conceptos
                foreach (var conc in cfdi.Conceptos)
                {
                    var row = tabla.NewRow();
                    row["ID"] = tabla.Rows.Count + 1;
                    row["Version"] = "3.3";
                    row["Emisor"] = cfdi.Emisor.Nombre;
                    row["EmisorRFC"] = cfdi.Emisor.Rfc;
                    row["Receptor"] = cfdi.Receptor.Nombre;
                    row["ReceptorRFC"] = cfdi.Receptor.Rfc;
                    row["Serie"] = cfdi.Serie;
                    row["Folio"] = cfdi.Folio;

                    var timbre = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(cfdi);
                    row["UUID"] = timbre.UUID;

                    row["Fecha"] = cfdi.Fecha;
                    row["Anhio"] = cfdi.Fecha.Year;
                    row["Mes"] = cfdi.Fecha.Month;
                    row["Semana"] = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(cfdi.Fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                    var c_tipocomp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_TipodecomprobanteController.Instance.GetEntity(cfdi.TipoDeComprobante.ToString());
                    row["TipoComprobante"] = c_tipocomp.Descripcion;
                    var c_formapago = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_FormapagoController.Instance.GetEntity(cfdi.FormaPago.ToString());
                    row["MetodoPago"] = c_formapago.Descripcion;
                    if (cfdi.CfdiRelacionados != null)
                    {
                        var c_relacioncfdi = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_TiporelacionController.Instance.GetEntity(cfdi.CfdiRelacionados.TipoRelacion.ToString());
                        row["FactOriginal"] = c_tipocomp.Descripcion + ": " + cfdi.CfdiRelacionados.CfdiRelacionado.Select(r => r.UUID).Aggregate((a, b) => a + ", " + b);
                    }
                    row["Moneda"] = cfdi.Moneda.ToString();
                    row["TipoCambio"] = cfdi.TipoCambio;
                    row["Subtotal"] = cfdi.SubTotal;
                    row["Descuento"] = cfdi.Descuento;
                    row["Total"] = cfdi.Total;

                    // Recuperación de impuestos
                    if (cfdi.Impuestos.Traslados != null)
                    {
                        foreach (var imp in cfdi.Impuestos.Traslados)
                        {
                            var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());
                            row[c_imp.Descripcion + "_" + (imp.TasaOCuota * 100M).ToString("n2").Replace(".", "_")] = imp.Importe;
                        }
                    }
                    if (cfdi.Impuestos.Retenciones != null)
                    {
                        foreach (var imp in cfdi.Impuestos.Retenciones)
                        {
                            var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());

                            if (imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item001)
                                row[c_imp.Descripcion + "_10_00"] = imp.Importe;
                            else if (imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item002)
                                row[c_imp.Descripcion + "_10_67"] = imp.Importe;

                        }
                    }

                    if (implocal != null)
                    {
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                        {
                            row[imp.ImpLocTrasladado.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeTraslado.ToString("n2").Replace(".", "_")] = imp.Importe;
                        }
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                        {
                            row[imp.ImpLocRetenido.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeRetencion.ToString("n2").Replace(".", "_")] = imp.Importe;
                        }
                    }

                    row["NoIdentificacion"] = conc.NoIdentificacion;
                    row["ClaveProdServ"] = conc.ClaveProdServ.ToString().Replace("Item", "");
                    row["Descripcion"] = conc.Descripcion;
                    row["UM"] = conc.Unidad;
                    row["ClaveUnidad"] = conc.ClaveUnidad.ToString().Replace("Item", "");

                    row["Cantidad"] = conc.Cantidad;
                    row["ValorUnitario"] = conc.ValorUnitario;
                    row["Importe"] = conc.Importe;
                    row["C_Descuento"] = conc.Descuento;

                    // Recuperación de impuestos
                    if (conc.Importe == decimal.Zero)
                        continue;
                    find_isr = false;
                    if (conc.Impuestos != null)
                    {
                        if (conc.Impuestos.Traslados != null)
                        {
                            foreach(var imp in conc.Impuestos.Traslados)
                            {
                                var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());
                                row["C_" + c_imp.Descripcion + "_" + (imp.TasaOCuota * 100M).ToString("n2").Replace(".", "_")] = imp.Importe;
                            }
                        }
                        if (conc.Impuestos.Retenciones != null)
                        {
                            foreach (var imp in conc.Impuestos.Retenciones)
                            {
                                var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());

                                row["C_" + c_imp.Descripcion + "_" + (imp.TasaOCuota * 100M).ToString("n2").Replace(".", "_")] = imp.Importe;
                            }
                        }
                    }
                    if (cfdi.Impuestos.Retenciones != null)
                    {
                        foreach (var imp in cfdi.Impuestos.Retenciones)
                        {
                            var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());
                            if (imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item001 && !find_isr)
                            {
                                find_isr = true;
                                row["C_" + c_imp.Descripcion.Replace(" ", "").Replace(".", "") + "_10_00"] = imp.Importe;
                            }
                            else if (imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item002)
                            {
                                if (imps_cfdi.ContainsKey(imp))
                                {
                                    if (imps_cfdi[imp].Impuesto_Concepto.ContainsKey(conc))
                                    {
                                        imp_cal = imps_cfdi[imp].Impuesto_Concepto[conc];
                                        if (imp_cal > decimal.Zero)
                                            row["C_" + c_imp.Descripcion.Replace(" ", "").Replace(".", "") + "_10_67"] = imp_cal;
                                    }
                                }
                            }
                        }
                    }

                    if (implocal != null)
                    {
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                        {
                            if (imps_cfdi.ContainsKey(imp))
                            {
                                if (imps_cfdi[imp].Impuesto_Concepto.ContainsKey(conc))
                                {
                                    imp_cal = imps_cfdi[imp].Impuesto_Concepto[conc];
                                    if (imp_cal > decimal.Zero)
                                        row["C_" + imp.ImpLocTrasladado.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeTraslado.ToString("n2").Replace(".", "_")] = imp_cal;
                                }
                            }
                        }
                        foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                        {
                            if (imps_cfdi.ContainsKey(imp))
                            {
                                if (imps_cfdi[imp].Impuesto_Concepto.ContainsKey(conc))
                                {
                                    imp_cal = imps_cfdi[imp].Impuesto_Concepto[conc];
                                    if (imp_cal > decimal.Zero)
                                        row["C_" + imp.ImpLocRetenido.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeRetencion.ToString("n2").Replace(".", "_")] = imp_cal;
                                }
                            }
                        }
                    }

                    row["Reimprimir"] = "PDF";

                    tabla.Rows.Add(row);
                }
            }
            //------------------------------------------------------------------------------

            return tabla;
        }
        /// <summary>
        /// Genera la tabla de visualización de datos en formato concentrado
        /// </summary>
        /// <param name="cfdis">Facturas recuepradas</param>
        /// <returns></returns>
        public Helper_DataTable GeneraTablaDatosCfdiPuroConcentrado(List<object> cfdis)
        {
            var tabla = new Helper_DataTable();
            EstatusProceso = "Generando columnas principales ...";
            var datosGenerales = tabla.NewGroupDataColumn("Datos principales");
            datosGenerales.NewDataColumn("ID", "ID", typeof(int), false);
            datosGenerales.NewDataColumn("Version", "Versión", typeof(string), false);
            datosGenerales.NewDataColumn("Emisor", "Emisor", typeof(string), true);
            datosGenerales.NewDataColumn("EmisorRFC", "Emisor RFC", typeof(string), false);
            datosGenerales.NewDataColumn("Receptor", "Receptor", typeof(string), true);
            datosGenerales.NewDataColumn("ReceptorRFC", "Receptor RFC", typeof(string), false);
            datosGenerales.NewDataColumn("Serie", "Serie", typeof(string), true);
            datosGenerales.NewDataColumn("Folio", "Folio", typeof(string), true);
            datosGenerales.NewDataColumn("UUID", "UUID", typeof(string), false);
            datosGenerales.NewDataColumn("Fecha", "Fecha", typeof(DateTime), false, DevExpress.Utils.FormatType.DateTime, "d");
            datosGenerales.NewDataColumn("Anhio", "Año", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "0000");
            datosGenerales.NewDataColumn("Mes", "Mes", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");
            datosGenerales.NewDataColumn("Semana", "Semana", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");

            var importesTotales = tabla.NewGroupDataColumn("Importes totales");
            EstatusProceso = "Generando columnas de importes totales ...";
            var importes = importesTotales.NewGroupDataColumn("Importes");
            importes.NewDataColumn("TipoComprobante", "T. comprobante", typeof(string), true);
            importes.NewDataColumn("MetodoPago", "M. pago", typeof(string), true);
            importes.NewDataColumn("NoCuentaPago", "Cta. pago", typeof(string), true);
            importes.NewDataColumn("FactOriginal", "Fact. original", typeof(string), true);
            importes.NewDataColumn("Moneda", "Moneda", typeof(string), true);
            importes.NewDataColumn("TipoCambio", "T. cambio", typeof(string), true);
            importes.NewDataColumn("Subtotal", "Subtotal", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");
            importes.NewDataColumn("Descuento", "Descuento", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");
            importes.NewDataColumn("MotivoDescuento", "M. descuento", typeof(string), true);
            importes.NewDataColumn("Total", "Total", typeof(decimal), false, DevExpress.Utils.FormatType.Numeric, "c2");

            EstatusProceso = "Generando columnas de impuestos ...";
            List<Impuestos_Encontrados> imps = new List<Impuestos_Encontrados>();
            //-------------------------------------------------------------------   CFDi 3.2
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante)c).ToList())
            {
                // Recuperación de impuestos federales
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                         i.Impuesto.Equals(imp.impuesto.ToString()) &&
                         i.Tasa == imp.tasa).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                Impuesto = imp.impuesto.ToString(),
                                Tasa = imp.tasa
                            });
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones)
                    {
                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido &&
                         i.Impuesto.Equals(imp.impuesto.ToString())).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Retenido,
                                Impuesto = imp.impuesto.ToString(),
                                Tasa = imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR ? 10M :
                                    imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.IVA ? 10.67M : 0
                            });
                    }
                }
                // Recuperación de impuestos locales
                DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocales implocal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    if (implocal.Items != null)
                    {
                        foreach (var imp in implocal.Items)
                        {
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocTrasladado) &&
                                    i.Tasa == im.TasadeTraslado).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocTrasladado,
                                        Tasa = im.TasadeTraslado
                                    });
                            }
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocRetenido) &&
                                    i.Tasa == im.TasadeRetencion).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocRetenido,
                                        Tasa = im.TasadeRetencion
                                    });
                            }
                        }
                    }
                }
            }
            //------------------------------------------------------------------------------
            //-------------------------------------------------------------------   CFDi 3.3
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante)c).ToList())
            {
                // Recuperación de impuestos federales
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());

                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                         i.Impuesto.Equals(c_imp.Descripcion) &&
                         i.Tasa == imp.TasaOCuota * 100M).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                Impuesto = c_imp.Descripcion,
                                Tasa = imp.TasaOCuota * 100M
                            });
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones)
                    {
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());

                        if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal &&
                         i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido &&
                         i.Impuesto.Equals(c_imp.Descripcion)).Count() == 0)
                            imps.Add(new Impuestos_Encontrados()
                            {
                                Tipo = Tipo_Impuestos.Federal,
                                Aplicacion = Tipo_Impuesto_Aplicacion.Retenido,
                                Impuesto = c_imp.Descripcion,
                                Tasa = imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item001 ? 10M :
                                    imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item002 ? 10.67M : 0
                            });
                    }
                }
                // Recuperación de impuestos locales
                DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocales implocal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    if (implocal.Items != null)
                    {
                        foreach (var imp in implocal.Items)
                        {
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocTrasladado) &&
                                    i.Tasa == im.TasadeTraslado).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocTrasladado,
                                        Tasa = im.TasadeTraslado
                                    });
                            }
                            if (imp is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales)
                            {
                                var im = imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales;
                                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal &&
                                    i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado &&
                                    i.Impuesto.Equals(im.ImpLocRetenido) &&
                                    i.Tasa == im.TasadeRetencion).Count() == 0)
                                    imps.Add(new Impuestos_Encontrados()
                                    {
                                        Tipo = Tipo_Impuestos.Estatal,
                                        Aplicacion = Tipo_Impuesto_Aplicacion.Trasladado,
                                        Impuesto = im.ImpLocRetenido,
                                        Tasa = im.TasadeRetencion
                                    });
                            }
                        }
                    }
                }
            }
            // Grupos y clumnas de impuestos
            if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal).Count() > 0)
            {
                var impuestosFederales = importesTotales.NewGroupDataColumn("Imp. Federales");
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado).Count() > 0)
                {
                    var impuestosFederalesTraslados = impuestosFederales.NewGroupDataColumn("Trasladados");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado))
                    {
                        impuestosFederalesTraslados.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto + " " + c.Tasa.ToString("n2") + "%",
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido).Count() > 0)
                {
                    var impuestosFederalesTraslados = impuestosFederales.NewGroupDataColumn("Retenidos");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Federal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido))
                    {
                        impuestosFederalesTraslados.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto,
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
            }
            if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal).Count() > 0)
            {
                var impuestosEstatales = importesTotales.NewGroupDataColumn("Imp. Estatales");
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado).Count() > 0)
                {
                    var impuestosEstatalesTraslados = impuestosEstatales.NewGroupDataColumn("Trasladados");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Trasladado))
                    {
                        impuestosEstatalesTraslados.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto + " " + c.Tasa.ToString("n2") + "%",
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
                if (imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido).Count() > 0)
                {
                    var impuestosEstatalesRetenidos = impuestosEstatales.NewGroupDataColumn("Retenidos");
                    foreach (var c in imps.Where(i => i.Tipo == Tipo_Impuestos.Estatal && i.Aplicacion == Tipo_Impuesto_Aplicacion.Retenido))
                    {
                        impuestosEstatalesRetenidos.NewDataColumn(c.Impuesto.Replace(" ", "").Replace(".", "") + "_" + c.Tasa.ToString("n2").Replace(".", "_"),
                            c.Impuesto + " " + c.Tasa.ToString("n2") + "%",
                            typeof(decimal),
                            true,
                            DevExpress.Utils.FormatType.Numeric,
                            "c2");
                    }
                }
            }

            //------------------------------------------------------------------------------            

            EstatusProceso = "Generando columnas de validaciones ...";
            var validaciones = tabla.NewGroupDataColumn("Validación de datos");
            validaciones.NewDataColumn("ValidaSAT", "SAT", typeof(string), true);
            validaciones.NewDataColumn("Reimprimir", "PDF", typeof(string), true);
            //------------------------------------------------------------------------------

            // paso de datos a ser mostrados
            EstatusProceso = "Paso de datos a ser mostrados ...";
            decimal imp_cal = decimal.Zero;
            bool find_isr = false;
            //-------------------------------------------------------------------   CFDi 3.2
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante)c).ToList())
            {
                Dictionary<object, Impuestos_Analisis32> imps_cfdi = new Dictionary<object, Impuestos_Analisis32>();
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = imp.importe;
                        imp_tr.Tasa = imp.tasa / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones.Where(i => i.impuesto != Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = imp.importe;
                        imp_tr.Tasa = 0.1067M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }
                var implocal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).TasadeTraslado / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis32();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).TasadeRetencion / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }

                var row = tabla.NewRow();
                row["ID"] = tabla.Rows.Count + 1;
                row["Version"] = "3.2";
                row["Emisor"] = cfdi.Emisor.nombre;
                row["EmisorRFC"] = cfdi.Emisor.rfc;
                row["Receptor"] = cfdi.Receptor.nombre;
                row["ReceptorRFC"] = cfdi.Receptor.rfc;
                row["Serie"] = cfdi.serie;
                row["Folio"] = cfdi.folio;

                var timbre = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(cfdi);
                row["UUID"] = timbre.UUID;

                row["Fecha"] = cfdi.fecha;
                row["Anhio"] = cfdi.fecha.Year;
                row["Mes"] = cfdi.fecha.Month;
                row["Semana"] = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(cfdi.fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                row["TipoComprobante"] = cfdi.tipoDeComprobante.ToString();
                row["MetodoPago"] = cfdi.metodoDePago;
                row["NoCuentaPago"] = cfdi.NumCtaPago;
                row["FactOriginal"] = cfdi.FolioFiscalOrig;
                row["Moneda"] = cfdi.Moneda;
                row["TipoCambio"] = cfdi.TipoCambio;
                row["Subtotal"] = cfdi.subTotal;
                row["Descuento"] = cfdi.descuento;
                row["MotivoDescuento"] = cfdi.motivoDescuento;
                row["Total"] = cfdi.total;

                // Recuperación de impuestos
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        row[imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.tasa.ToString("n2").Replace(".", "_")] = imp.importe;
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones)
                    {
                        if (imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR)
                            row[imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_10_00"] = imp.importe;
                        else if (imp.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.IVA)
                            row[imp.impuesto.ToString().Replace(" ", "").Replace(".", "") + "_10_67"] = imp.importe;
                    }
                }

                if (implocal != null)
                {
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                    {
                        row[imp.ImpLocTrasladado.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeTraslado.ToString("n2").Replace(".", "_")] = imp.Importe;
                    }
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                    {
                        row[imp.ImpLocRetenido.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeRetencion.ToString("n2").Replace(".", "_")] = imp.Importe;
                    }
                }
                
                row["Reimprimir"] = "PDF";

                tabla.Rows.Add(row);
            }
            //------------------------------------------------------------------------------

            imp_cal = decimal.Zero;
            find_isr = false;
            //-------------------------------------------------------------------   CFDi 3.3
            foreach (var cfdi in cfdis.Where(c => c is DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante).Select(c => (DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante)c).ToList())
            {
                Dictionary<object, Impuestos_Analisis33> imps_cfdi = new Dictionary<object, Impuestos_Analisis33>();
                var implocal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaImpuestosLocales(cfdi);
                if (implocal != null)
                {
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis33();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).TasadeTraslado / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                    {
                        var imp_tr = new Impuestos_Analisis33();
                        imp_tr.Impuesto = imp;
                        imp_tr.Importe = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Importe;
                        imp_tr.Tasa = (imp as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).TasadeRetencion / 100M;
                        imp_tr.AddConceptos(cfdi.Conceptos);
                        imps_cfdi.Add(imp, imp_tr);
                    }
                }

                var row = tabla.NewRow();
                row["ID"] = tabla.Rows.Count + 1;
                row["Version"] = "3.3";
                row["Emisor"] = cfdi.Emisor.Nombre;
                row["EmisorRFC"] = cfdi.Emisor.Rfc;
                row["Receptor"] = cfdi.Receptor.Nombre;
                row["ReceptorRFC"] = cfdi.Receptor.Rfc;
                row["Serie"] = cfdi.Serie;
                row["Folio"] = cfdi.Folio;

                var timbre = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(cfdi);
                row["UUID"] = timbre.UUID;

                row["Fecha"] = cfdi.Fecha;
                row["Anhio"] = cfdi.Fecha.Year;
                row["Mes"] = cfdi.Fecha.Month;
                row["Semana"] = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(cfdi.Fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                var c_tipocomp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_TipodecomprobanteController.Instance.GetEntity(cfdi.TipoDeComprobante.ToString());
                row["TipoComprobante"] = c_tipocomp.Descripcion;
                var c_formapago = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_FormapagoController.Instance.GetEntity(cfdi.FormaPago.ToString());
                row["MetodoPago"] = c_formapago.Descripcion;
                if (cfdi.CfdiRelacionados != null)
                {
                    var c_relacioncfdi = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_TiporelacionController.Instance.GetEntity(cfdi.CfdiRelacionados.TipoRelacion.ToString());
                    row["FactOriginal"] = c_tipocomp.Descripcion + ": " + cfdi.CfdiRelacionados.CfdiRelacionado.Select(r => r.UUID).Aggregate((a, b) => a + ", " + b);
                }
                row["Moneda"] = cfdi.Moneda.ToString();
                row["TipoCambio"] = cfdi.TipoCambio;
                row["Subtotal"] = cfdi.SubTotal;
                row["Descuento"] = cfdi.Descuento;
                row["Total"] = cfdi.Total;

                // Recuperación de impuestos
                if (cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in cfdi.Impuestos.Traslados)
                    {
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());
                        row[c_imp.Descripcion + "_" + (imp.TasaOCuota * 100M).ToString("n2").Replace(".", "_")] = imp.Importe;
                    }
                }
                if (cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in cfdi.Impuestos.Retenciones)
                    {
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.c_ImpuestoController.Instance.GetEntity(imp.Impuesto.ToString());

                        if (imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item001)
                            row[c_imp.Descripcion + "_10_00"] = imp.Importe;
                        else if (imp.Impuesto == Com.Facturacion.Comprobantes.Catalogos.c_Impuesto.Item002)
                            row[c_imp.Descripcion + "_10_67"] = imp.Importe;

                    }
                }

                if (implocal != null)
                {
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                    {
                        row[imp.ImpLocTrasladado.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeTraslado.ToString("n2").Replace(".", "_")] = imp.Importe;
                    }
                    foreach (var imp in implocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).Select(i => i as DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                    {
                        row[imp.ImpLocRetenido.ToString().Replace(" ", "").Replace(".", "") + "_" + imp.TasadeRetencion.ToString("n2").Replace(".", "_")] = imp.Importe;
                    }
                }
                
                row["Reimprimir"] = "PDF";

                tabla.Rows.Add(row);
            }
            //------------------------------------------------------------------------------

            return tabla;
        }
        /// <summary>
        /// Genera tabla de visualización de datos de nomina 11
        /// </summary>
        /// <param name="nomina11">Cfdi de nomina</param>
        /// <returns>Tabla de datos generada</returns>
        public Helper_DataTable GeneraTablaDatosCfdiNomina11(Dictionary<DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina> nomina11)
        {
            var tabla = new Helper_DataTable();
            EstatusProceso = "Generando columnas principales ...";
            var datosGenerales = tabla.NewGroupDataColumn("Datos generales");

            var datosEmisor = datosGenerales.NewGroupDataColumn("Datos del emisor");
            datosEmisor.NewDataColumn("ID", "ID", typeof(int), false);
            datosEmisor.NewDataColumn("Emisor", "Emisor", typeof(string), true);
            datosEmisor.NewDataColumn("EmisorRFC", "Emisor RFC", typeof(string), false);
            datosEmisor.NewDataColumn("RegistroPatronal", "R, patronal", typeof(string), true);

            var datosEmpleado = datosGenerales.NewGroupDataColumn("Datos de empleado");
            datosEmpleado.NewDataColumn("NoEmpleado", "No. empleado", typeof(string), true);
            datosEmpleado.NewDataColumn("Nombre", "Nombre", typeof(string), true);
            datosEmpleado.NewDataColumn("ReceptorRFC", "Empleado RFC", typeof(string), false);
            datosEmpleado.NewDataColumn("ReceptorCURP", "Empleado CURP", typeof(string), true);
            datosEmpleado.NewDataColumn("NoSegSocial", "No. seguridad social", typeof(string), true);
            datosEmpleado.NewDataColumn("Regimen", "Rég. conttratación", typeof(string), true);
            datosEmpleado.NewDataColumn("TipoContrato", "Contrato", typeof(string), true);
            datosEmpleado.NewDataColumn("TipoJornada", "Jornada", typeof(string), true);
            datosEmpleado.NewDataColumn("PeriodicidadPago", "Periodicidad", typeof(string), true);
            datosEmpleado.NewDataColumn("Puesto", "Puesto", typeof(string), true);
            datosEmpleado.NewDataColumn("Departamento", "Departamento", typeof(string), true);
            datosEmpleado.NewDataColumn("FechaIniRelLabores", "Inicio labores", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");
            datosEmpleado.NewDataColumn("Antiguedad", "Antigüedad", typeof(int), true, DevExpress.Utils.FormatType.Numeric, "n");
            datosEmpleado.NewDataColumn("RiesgoPuesto", "Riesgo puesto", typeof(string), true);
            datosEmpleado.NewDataColumn("SalarioBase", "S. base cotización", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            datosEmpleado.NewDataColumn("SalarioDiario", "S. diario integrado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");

            EstatusProceso = "Generando columnas de totales facturados ...";
            var datosFacturados = tabla.NewGroupDataColumn("Datos facturados");
            var facturaGenerales = datosFacturados.NewGroupDataColumn("Principales");
            facturaGenerales.NewDataColumn("Serie", "Serie", typeof(string), true);
            facturaGenerales.NewDataColumn("Folio", "Folio", typeof(string), true);
            facturaGenerales.NewDataColumn("UUID", "UUID", typeof(string), false);
            facturaGenerales.NewDataColumn("FechaEmision", "Fecha emisión", typeof(DateTime), false, DevExpress.Utils.FormatType.DateTime, "d");
            facturaGenerales.NewDataColumn("Anhio", "Año", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "0000");
            facturaGenerales.NewDataColumn("Mes", "Mes", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");
            facturaGenerales.NewDataColumn("Semana", "Semana", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");

            facturaGenerales.NewDataColumn("Subtotal", "Percepciones", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            facturaGenerales.NewDataColumn("Descuento", "Deducciones", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            facturaGenerales.NewDataColumn("ISR", "ISR", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            facturaGenerales.NewDataColumn("Total", "Imp. a pagar", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");

            facturaGenerales.NewDataColumn("MetodoPago", "M. pago", typeof(string), true);
            facturaGenerales.NewDataColumn("Banco", "Banco", typeof(string), true);
            facturaGenerales.NewDataColumn("CLABE", "C. CLABE", typeof(string), true);
            facturaGenerales.NewDataColumn("FechaPago", "Fecha de pago", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");
            facturaGenerales.NewDataColumn("FechaInicioPago", "Inicio pago", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");
            facturaGenerales.NewDataColumn("FechaTerminoPago", "Termino pago", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");

            EstatusProceso = "Generando columnas de percepciones y deducciones ...";
            Dictionary<string, string> pers = new Dictionary<string, string>();
            Dictionary<string, string> deds = new Dictionary<string, string>();
            foreach (var cfdi in nomina11)
            {
                if (cfdi.Value.Percepciones != null)
                {
                    foreach (var p in cfdi.Value.Percepciones.Percepcion)
                    {
                        if (pers.Where(i => i.Key.Equals(p.TipoPercepcion + "." +p.Clave)).Count() == 0)
                            pers.Add(p.TipoPercepcion + "." + p.Clave, p.Concepto);
                    }
                }
                if (cfdi.Value.Deducciones != null)
                {
                    foreach (var p in cfdi.Value.Deducciones.Deduccion)
                    {
                        if (deds.Where(i => i.Key.Equals(p.TipoDeduccion + "." + p.Clave)).Count() == 0)
                            deds.Add(p.TipoDeduccion + "." + p.Clave, p.Concepto);
                    }
                }
            }

            // Generación de campos de percepciones
            if (pers.Count > 0)
            {
                var facturaPercepciones = datosFacturados.NewGroupDataColumn("Percepciones");
                facturaPercepciones.NewDataColumn("P_Total_Gravado", "Gravado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                facturaPercepciones.NewDataColumn("P_Total_Exento", "Exento", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");

                foreach (var p in pers)
                {
                    var per = facturaPercepciones.NewGroupDataColumn(p.Key + " - " + p.Value);
                    per.NewDataColumn("P_" + p.Key.Replace(".", "_") + "_Gravado", "Gravado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                    per.NewDataColumn("P_" + p.Key.Replace(".", "_") + "_Exento", "Exento", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                }
            }

            // Generación de campos de deducciones
            if (deds.Count > 0)
            {
                var facturaDeducciones = datosFacturados.NewGroupDataColumn("Deducciones");
                facturaDeducciones.NewDataColumn("D_Total_Gravado", "Gravado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                facturaDeducciones.NewDataColumn("D_Total_Exento", "Exento", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");

                foreach (var d in deds)
                {
                    var ded = facturaDeducciones.NewGroupDataColumn(d.Key + " - " + d.Value);
                    ded.NewDataColumn("D_" + d.Key.Replace(".", "_") + "_Gravado", "Gravado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                    ded.NewDataColumn("D_" + d.Key.Replace(".", "_") + "_Exento", "Exento", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                }
            }

            var validaciones = tabla.NewGroupDataColumn("Validación de datos");
            validaciones.NewDataColumn("ValidaSAT", "SAT", typeof(string), true);
            validaciones.NewDataColumn("Reimprimir", "PDF", typeof(string), true);

            EstatusProceso = "Paso de datos a ser visualizados ...";
            foreach (var cfdi in nomina11)
            {
                var row = tabla.NewRow();
                row["ID"] = tabla.Rows.Count + 1;
                row["Emisor"] = cfdi.Key.Emisor.nombre;
                row["EmisorRFC"] = cfdi.Key.Emisor.rfc;
                row["RegistroPatronal"] = cfdi.Value.RegistroPatronal;

                row["NoEmpleado"] = cfdi.Value.NumEmpleado;
                row["Nombre"] = cfdi.Key.Receptor.nombre;
                row["ReceptorRFC"] = cfdi.Key.Receptor.rfc;
                row["ReceptorCURP"] = cfdi.Value.CURP;
                row["NoSegSocial"] = cfdi.Value.NumSeguridadSocial;
                row["Regimen"] = cfdi.Value.TipoRegimen;
                row["TipoContrato"] = cfdi.Value.TipoContrato;
                row["TipoJornada"] = cfdi.Value.TipoJornada;
                row["PeriodicidadPago"] = cfdi.Value.PeriodicidadPago;
                row["Puesto"] = cfdi.Value.Puesto;
                row["Departamento"] = cfdi.Value.Departamento;
                if (cfdi.Value.FechaInicioRelLaboralSpecified)
                    row["FechaIniRelLabores"] = (DateTime?)cfdi.Value.FechaInicioRelLaboral;
                if (cfdi.Value.AntiguedadSpecified)
                    row["Antiguedad"] = (int?)cfdi.Value.Antiguedad;
                if (cfdi.Value.RiesgoPuestoSpecified)
                    row["RiesgoPuesto"] = (int?)cfdi.Value.RiesgoPuesto;
                if (cfdi.Value.SalarioBaseCotAporSpecified)
                    row["SalarioBase"] = (decimal?)cfdi.Value.SalarioBaseCotApor;
                if (cfdi.Value.SalarioDiarioIntegradoSpecified)
                    row["SalarioDiario"] = (decimal?)cfdi.Value.SalarioDiarioIntegrado;

                row["Serie"] = cfdi.Key.serie;
                row["Folio"] = cfdi.Key.folio;
                var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(cfdi.Key);
                row["UUID"] = timbreFiscal.UUID;
                row["FechaEmision"] = cfdi.Key.fecha;
                row["Anhio"] = cfdi.Key.fecha.Year;
                row["Mes"] = cfdi.Key.fecha.Month;
                row["Semana"] = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(cfdi.Key.fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                row["Subtotal"] = cfdi.Key.subTotal;
                row["Descuento"] = cfdi.Key.descuento;
                if (cfdi.Key.Impuestos != null)
                {
                    if (cfdi.Key.Impuestos.Retenciones != null)
                    {
                        var isr = cfdi.Key.Impuestos.Retenciones.Where(i => i.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR).FirstOrDefault();
                        if (isr != null)
                            row["ISR"] = isr.importe;
                    }
                }
                row["Total"] = cfdi.Key.total;

                row["MetodoPago"] = cfdi.Key.metodoDePago;
                row["Banco"] = cfdi.Value.Banco;
                row["CLABE"] = cfdi.Value.CLABE;
                row["FechaPago"] = cfdi.Value.FechaPago;
                row["FechaInicioPago"] = cfdi.Value.FechaInicialPago;
                row["FechaTerminoPago"] = cfdi.Value.FechaFinalPago;

                if (cfdi.Value.Percepciones != null)
                {
                    row["P_Total_Gravado"] = cfdi.Value.Percepciones.TotalGravado;
                    row["P_Total_Exento"] = cfdi.Value.Percepciones.TotalExento;

                    foreach (var p in cfdi.Value.Percepciones.Percepcion)
                    {
                        row["P_" + p.TipoPercepcion + "_" + p.Clave + "_Gravado"] = p.ImporteGravado;
                        row["P_" + p.TipoPercepcion + "_" + p.Clave + "_Exento"] = p.ImporteExento;
                    }
                }

                if (cfdi.Value.Deducciones != null)
                {
                    row["D_Total_Gravado"] = cfdi.Value.Deducciones.TotalGravado;
                    row["D_Total_Exento"] = cfdi.Value.Deducciones.TotalExento;

                    foreach (var p in cfdi.Value.Deducciones.Deduccion)
                    {
                        row["D_" + p.TipoDeduccion + "_" + p.Clave + "_Gravado"] = p.ImporteGravado;
                        row["D_" + p.TipoDeduccion + "_" + p.Clave + "_Exento"] = p.ImporteExento;
                    }
                }

                row["Reimprimir"] = "PDF";

                tabla.Rows.Add(row);
            }

            return tabla;
        }
        /// <summary>
        /// Genera tabla de visualización de datos de nomina 12
        /// </summary>
        /// <param name="nomina12">Cfdi de nomina</param>
        /// <returns>Tabla de datos generada</returns>
        public Helper_DataTable GeneraTablaDatosCfdiNomina12(Dictionary<object, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina> nomina12)
        {
            var tabla = new Helper_DataTable();
            EstatusProceso = "Generando columnas principales ...";
            var datosGenerales = tabla.NewGroupDataColumn("Datos generales");

            var datosEmisor = datosGenerales.NewGroupDataColumn("Datos del emisor");
            datosEmisor.NewDataColumn("ID", "ID", typeof(int), false);
            datosEmisor.NewDataColumn("Emisor", "Emisor", typeof(string), true);
            datosEmisor.NewDataColumn("EmisorRFC", "Emisor RFC", typeof(string), false);
            datosEmisor.NewDataColumn("RegistroPatronal", "R, patronal", typeof(string), true);
            datosEmisor.NewDataColumn("EmisorCURP", "CURP", typeof(string), true);
            datosEmisor.NewDataColumn("RFCPatronOriginal", "P. original", typeof(string), true);

            var datosEmpleado = datosGenerales.NewGroupDataColumn("Datos de empleado");
            datosEmpleado.NewDataColumn("NoEmpleado", "No. empleado", typeof(string), true);
            datosEmpleado.NewDataColumn("Nombre", "Nombre", typeof(string), true);
            datosEmpleado.NewDataColumn("ReceptorRFC", "Empleado RFC", typeof(string), false);
            datosEmpleado.NewDataColumn("ReceptorCURP", "Empleado CURP", typeof(string), true);
            datosEmpleado.NewDataColumn("NoSegSocial", "No. seguridad social", typeof(string), true);
            datosEmpleado.NewDataColumn("Regimen", "Rég. conttratación", typeof(string), true);
            datosEmpleado.NewDataColumn("TipoContrato", "Contrato", typeof(string), true);
            datosEmpleado.NewDataColumn("TipoJornada", "Jornada", typeof(string), true);
            datosEmpleado.NewDataColumn("PeriodicidadPago", "Periodicidad", typeof(string), true);
            datosEmpleado.NewDataColumn("Puesto", "Puesto", typeof(string), true);
            datosEmpleado.NewDataColumn("Departamento", "Departamento", typeof(string), true);
            datosEmpleado.NewDataColumn("FechaIniRelLabores", "Inicio labores", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");
            datosEmpleado.NewDataColumn("Antiguedad", "Antigüedad", typeof(string), true);
            datosEmpleado.NewDataColumn("RiesgoPuesto", "Riesgo puesto", typeof(string), true);
            datosEmpleado.NewDataColumn("SalarioBase", "S. base cotización", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            datosEmpleado.NewDataColumn("SalarioDiario", "S. diario integrado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");

            EstatusProceso = "Generando columnas de totales facturados ...";
            var datosFacturados = tabla.NewGroupDataColumn("Datos facturados");
            var facturaGenerales = datosFacturados.NewGroupDataColumn("Principales");
            facturaGenerales.NewDataColumn("Serie", "Serie", typeof(string), true);
            facturaGenerales.NewDataColumn("Folio", "Folio", typeof(string), true);
            facturaGenerales.NewDataColumn("UUID", "UUID", typeof(string), false);
            facturaGenerales.NewDataColumn("FechaEmision", "Fecha emisión", typeof(DateTime), false, DevExpress.Utils.FormatType.DateTime, "d");
            facturaGenerales.NewDataColumn("Anhio", "Año", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "0000");
            facturaGenerales.NewDataColumn("Mes", "Mes", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");
            facturaGenerales.NewDataColumn("Semana", "Semana", typeof(int), false, DevExpress.Utils.FormatType.Numeric, "00");

            facturaGenerales.NewDataColumn("TotalPercepciones", "T. percepciones", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            facturaGenerales.NewDataColumn("TotalOtrosPagos", "T. Otros pagos", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            facturaGenerales.NewDataColumn("TotalDeducciones", "T. deducciones", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            facturaGenerales.NewDataColumn("Total", "Imp. a pagar", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            
            facturaGenerales.NewDataColumn("Banco", "Banco", typeof(string), true);
            facturaGenerales.NewDataColumn("CuentaPago", "C. CLABE", typeof(string), true);
            facturaGenerales.NewDataColumn("FechaPago", "Fecha de pago", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");
            facturaGenerales.NewDataColumn("FechaInicioPago", "Inicio pago", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");
            facturaGenerales.NewDataColumn("FechaTerminoPago", "Termino pago", typeof(DateTime), true, DevExpress.Utils.FormatType.DateTime, "d");

            EstatusProceso = "Generando columnas de percepciones y deducciones ...";
            Dictionary<string, string> pers = new Dictionary<string, string>();
            Dictionary<string, string> deds = new Dictionary<string, string>();
            Dictionary<string, string> otrs = new Dictionary<string, string>();
            foreach (var cfdi in nomina12)
            {
                if (cfdi.Value.Percepciones != null)
                {
                    foreach (var p in cfdi.Value.Percepciones.Percepcion)
                    {
                        if (pers.Where(i => i.Key.Equals(p.TipoPercepcion.ToString().Replace("Item", "") + "." + p.Clave)).Count() == 0)
                            pers.Add(p.TipoPercepcion.ToString().Replace("Item", "") + "." + p.Clave, p.Concepto);
                    }
                }
                if (cfdi.Value.Deducciones != null)
                {
                    foreach (var p in cfdi.Value.Deducciones.Deduccion)
                    {
                        if (deds.Where(i => i.Key.Equals(p.TipoDeduccion.ToString().Replace("Item", "") + "." + p.Clave)).Count() == 0)
                            deds.Add(p.TipoDeduccion.ToString().Replace("Item", "") + "." + p.Clave, p.Concepto);
                    }
                }
                if (cfdi.Value.OtrosPagos != null)
                {
                    foreach (var p in cfdi.Value.OtrosPagos)
                    {
                        if (otrs.Where(i => i.Key.Equals(p.TipoOtroPago.ToString().Replace("Item", "") + "." + p.Clave)).Count() == 0)
                            otrs.Add(p.TipoOtroPago.ToString().Replace("Item", "") + "." + p.Clave, p.Concepto);
                    }
                }
            }

            // Generación de campos de percepciones
            if (pers.Count > 0)
            {
                var facturaPercepciones = datosFacturados.NewGroupDataColumn("Percepciones");
                foreach (var p in pers)
                {
                    var per = facturaPercepciones.NewGroupDataColumn(p.Key + " - " + p.Value);
                    per.NewDataColumn("P_" + p.Key.Replace(".", "_") + "_Gravado", "Gravado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                    per.NewDataColumn("P_" + p.Key.Replace(".", "_") + "_Exento", "Exento", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                }
                var facturaPercepcionesTotales = facturaPercepciones.NewGroupDataColumn("Totales");
                facturaPercepcionesTotales.NewDataColumn("P_Total_Gravado", "Gravado", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                facturaPercepcionesTotales.NewDataColumn("P_Total_Exento", "Exento", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            }

            // Generación de campos de deducciones
            if (deds.Count > 0)
            {
                var facturaDeducciones = datosFacturados.NewGroupDataColumn("Deducciones");
                var facturaDeduccionesDesglose = facturaDeducciones.NewGroupDataColumn("Desglose");
                foreach (var d in deds)
                {
                    facturaDeduccionesDesglose.NewDataColumn("D_" + d.Key.Replace(".", "_") + "_Importe", d.Key + " - " + d.Value, typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                }
                var facturaDeduccionesTotales = facturaDeducciones.NewGroupDataColumn("Totales");
                facturaDeduccionesTotales.NewDataColumn("D_Total_ImpuestosRetenidos", "Impuestos retenidos", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                facturaDeduccionesTotales.NewDataColumn("D_Total_OtrasDeducciones", "Otras Deducciones", typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
            }

            // Generación de campos de otros pagos
            if (otrs.Count > 0)
            {
                var facturaOtrosPagos = datosFacturados.NewGroupDataColumn("Otros pagos");
                foreach (var d in otrs)
                {
                    facturaOtrosPagos.NewDataColumn("OP_" + d.Key.Replace(".", "_") + "_Importe", d.Key + " - " + d.Value, typeof(string), true, DevExpress.Utils.FormatType.Numeric, "c2");
                }
            }

            var validaciones = tabla.NewGroupDataColumn("Validación de datos");
            validaciones.NewDataColumn("ValidaSAT", "SAT", typeof(string), true);
            validaciones.NewDataColumn("Reimprimir", "PDF", typeof(string), true);

            EstatusProceso = "Paso de datos a ser visualizados ...";
            foreach (var cfdi in nomina12)
            {
                var row = tabla.NewRow();
                row["ID"] = tabla.Rows.Count + 1;
                if (cfdi.Key is DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante)
                {
                    var comprobante = cfdi.Key as DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante;
                    row["Emisor"] = comprobante.Emisor.nombre;
                    row["EmisorRFC"] = comprobante.Emisor.rfc;
                    
                    row["Nombre"] = comprobante.Receptor.nombre;
                    row["ReceptorRFC"] = comprobante.Receptor.rfc;
                    
                    row["Serie"] = comprobante.serie;
                    row["Folio"] = comprobante.folio;
                    var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(comprobante);
                    row["UUID"] = timbreFiscal.UUID;
                    row["FechaEmision"] = comprobante.fecha;
                    row["Anhio"] = comprobante.fecha.Year;
                    row["Mes"] = comprobante.fecha.Month;
                    row["Semana"] = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(comprobante.fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                    
                    row["Total"] = comprobante.total;
                }
                if (cfdi.Key is DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante)
                {
                    var comprobante = cfdi.Key as DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante;
                    row["Emisor"] = comprobante.Emisor.Nombre;
                    row["EmisorRFC"] = comprobante.Emisor.Rfc;

                    row["Nombre"] = comprobante.Receptor.Nombre;
                    row["ReceptorRFC"] = comprobante.Receptor.Rfc;

                    row["Serie"] = comprobante.Serie;
                    row["Folio"] = comprobante.Folio;
                    var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(comprobante);
                    row["UUID"] = timbreFiscal.UUID;
                    row["FechaEmision"] = comprobante.Fecha;
                    row["Anhio"] = comprobante.Fecha.Year;
                    row["Mes"] = comprobante.Fecha.Month;
                    row["Semana"] = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(comprobante.Fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                    row["Total"] = comprobante.Total;
                }

                row["RegistroPatronal"] = cfdi.Value.Emisor.RegistroPatronal;
                row["EmisorCURP"] = cfdi.Value.Emisor.Curp;
                row["RFCPatronOriginal"] = cfdi.Value.Emisor.RfcPatronOrigen;

                row["NoEmpleado"] = cfdi.Value.Receptor.NumEmpleado;

                row["ReceptorCURP"] = cfdi.Value.Receptor.Curp;
                row["NoSegSocial"] = cfdi.Value.Receptor.NumSeguridadSocial;
                row["Regimen"] = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(cfdi.Value.Receptor.TipoRegimen);
                row["TipoContrato"] = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(cfdi.Value.Receptor.TipoContrato);
                row["TipoJornada"] = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(cfdi.Value.Receptor.TipoJornada);
                row["PeriodicidadPago"] = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(cfdi.Value.Receptor.PeriodicidadPago);
                row["Puesto"] = cfdi.Value.Receptor.Puesto;
                row["Departamento"] = cfdi.Value.Receptor.Departamento;
                row["FechaIniRelLabores"] = cfdi.Value.Receptor.FechaInicioRelLaboralSpecified ? (DateTime?)cfdi.Value.Receptor.FechaInicioRelLaboral : null;
                row["Antiguedad"] = cfdi.Value.Receptor.Antigüedad;
                row["RiesgoPuesto"] = cfdi.Value.Receptor.RiesgoPuestoSpecified ? DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(cfdi.Value.Receptor.RiesgoPuesto) : "";
                row["SalarioBase"] = cfdi.Value.Receptor.SalarioBaseCotAporSpecified ? (decimal?)cfdi.Value.Receptor.SalarioBaseCotApor : null;
                row["SalarioDiario"] = cfdi.Value.Receptor.SalarioDiarioIntegradoSpecified ? (decimal?)cfdi.Value.Receptor.SalarioDiarioIntegrado : null;

                row["TotalPercepciones"] = cfdi.Value.TotalPercepcionesSpecified ? (decimal?)cfdi.Value.TotalPercepciones : null;
                row["TotalOtrosPagos"] = cfdi.Value.TotalOtrosPagosSpecified ? (decimal?)cfdi.Value.TotalOtrosPagos : null;
                row["TotalDeducciones"] = cfdi.Value.TotalDeduccionesSpecified ? (decimal?)cfdi.Value.TotalDeducciones : null;

                row["Banco"] = cfdi.Value.Receptor.BancoSpecified ? DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(cfdi.Value.Receptor.Banco) : "-";
                row["CuentaPago"] = cfdi.Value.Receptor.CuentaBancaria;
                row["FechaPago"] = cfdi.Value.FechaPago;
                row["FechaInicioPago"] = cfdi.Value.FechaInicialPago;
                row["FechaTerminoPago"] = cfdi.Value.FechaFinalPago;

                if (cfdi.Value.Percepciones != null)
                {
                    foreach (var p in cfdi.Value.Percepciones.Percepcion)
                    {
                        row["P_" + p.TipoPercepcion.ToString().Replace("Item", "") + "_" + p.Clave + "_Gravado"] = p.ImporteGravado;
                        row["P_" + p.TipoPercepcion.ToString().Replace("Item", "") + "_" + p.Clave + "_Exento"] = p.ImporteExento;
                    }
                    row["P_Total_Gravado"] = cfdi.Value.Percepciones.TotalGravado;
                    row["P_Total_Exento"] = cfdi.Value.Percepciones.TotalExento;
                }

                if (cfdi.Value.Deducciones != null)
                {
                    foreach (var p in cfdi.Value.Deducciones.Deduccion)
                    {
                        row["D_" + p.TipoDeduccion.ToString().Replace("Item", "") + "_" + p.Clave + "_Importe"] = p.Importe;
                    }
                    row["D_Total_ImpuestosRetenidos"] = cfdi.Value.Deducciones.TotalImpuestosRetenidos;
                    row["D_Total_OtrasDeducciones"] = cfdi.Value.Deducciones.TotalOtrasDeducciones;
                }

                if (cfdi.Value.OtrosPagos != null)
                {
                    foreach (var p in cfdi.Value.OtrosPagos)
                    {
                        row["OP_" + p.TipoOtroPago.ToString().Replace("Item", "") + "_" + p.Clave + "_Importe"] = p.Importe;
                    }
                }

                row["Reimprimir"] = "PDF";

                tabla.Rows.Add(row);
            }

            return tabla;
        }
        /// <summary>
        /// Genera los campos de Cfdi puro
        /// </summary>
        /// <param name="grid">Tabla de datos</param>
        /// <param name="cfdis">Lista de CFDi's</param>
        public void GeneraCamposBandasCmposFacturas(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grid, Helper_DataTable cfdis)
        {
            if (cfdis == null)
                return;

            /*grid.OptionsBehavior.ReadOnly = true;
            grid.OptionsBehavior.Editable = false;*/
            grid.Bands.Clear();

            grid.GridControl.RepositoryItems.Clear();

            DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit lnk = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            grid.GridControl.RepositoryItems.Add(lnk);

            foreach (var gro in cfdis.Groups)
            {
                var band = grid.Bands.AddBand(gro.Name);
                band.AutoFillDown = true;
                GeneraBandaColumnas(band, gro);
            }

            grid.Columns["Reimprimir"].OptionsColumn.AllowEdit = true;
            grid.Columns["Reimprimir"].OptionsColumn.ReadOnly = false;
            grid.Columns["Reimprimir"].ColumnEdit = lnk;

            lnk.Click += (s, e) =>
            {
                var row = ((DataRowView)grid.GetFocusedRow()).Row;
                string uuid = row["UUID"].ToString();
                object cfdi = Uuid_Cfdi.Where(i => i.Key.Equals(uuid)).Select(i => i.Value).FirstOrDefault();
                if (cfdi != null)
                {
                    using (Documents.ComprobanteReportViewForm form = new Documents.ComprobanteReportViewForm())
                    {
                        form.Cfdi = cfdi;
                        form.ShowDialog();
                    }
                }
            };

            grid.BestFitColumns();
        }

        /// <summary>
        /// Métod recursivo de generación de bandas y columnas por banda
        /// </summary>
        /// <param name="band">Banda</param>
        /// <param name="group">Grupo de columnas</param>
        void GeneraBandaColumnas(DevExpress.XtraGrid.Views.BandedGrid.GridBand band, Helper_GroupDataColumn group)
        {
            // Generación de columnas de l a banda, primero
            foreach (var col in group.Columns)
            {
                if (col.GridColumnFormatType != null)
                    band.Columns.Add(GeneraColumnaDatos("Grid_" + col.ColumnName, col.Caption, col.ColumnName, true, (DevExpress.Utils.FormatType)col.GridColumnFormatType, col.GridColumnFormatString));
                else
                    band.Columns.Add(GeneraColumnaDatos("Grid_" + col.ColumnName, col.Caption, col.ColumnName, true));
            }
            // Iteración de los grupos del grupo actual
            foreach (var gro in group.Groups)
            {
                var b = band.Children.AddBand(gro.Name);
                b.AutoFillDown = true;
                GeneraBandaColumnas(b, gro);
            }
        }

        /// <summary>
        /// Genera una columna para el grid de presentación de datos
        /// </summary>
        /// <param name="name">Nombre de columna</param>
        /// <param name="caption">Título de columna</param>
        /// <param name="fieldname">Nombre de campo</param>
        /// <param name="visible">Si es visible</param>
        /// <param name="formattype">Tipo de formato</param>
        /// <param name="formatstring">Cadena de formato</param>
        /// <returns>Columna</returns>
        DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GeneraColumnaDatos(string name, string caption, string fieldname, bool visible, DevExpress.Utils.FormatType formattype= DevExpress.Utils.FormatType.None, string formatstring = "")
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn column = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            column.Name = name;
            column.Caption = caption;
            column.FieldName = fieldname;
            column.Visible = visible;

            column.OptionsColumn.ReadOnly = true;
            column.OptionsColumn.AllowEdit = false;

            if (formattype != DevExpress.Utils.FormatType.None && !string.IsNullOrEmpty(formatstring))
            {
                column.DisplayFormat.FormatType = formattype;
                column.DisplayFormat.FormatString = formatstring;
            }
                        
            return column;
        }
        #endregion

        #region Validación y exportación de datos
        /// <summary>
        /// Validación / exportacion de información
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tabAnalisis_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            if (e.Button.Caption.Equals("Exportar información"))
            {
                if (e.ActivePage == tbIngresos)
                    ExportaDatosExcel(grdViewBandIngresos, txtRFC.Text + "_Ingresos_" + DateTime.Today.ToShortDateString().Replace("/", ""));
                else if (e.ActivePage == tbNomina11)
                    ExportaDatosExcel(grdViewBandNominas11, txtRFC.Text + "_Nomina11_" + DateTime.Today.ToShortDateString().Replace("/", ""));
                else if (e.ActivePage == tbNomina12)
                    ExportaDatosExcel(grdViewBandNominas12, txtRFC.Text + "_Nomina12_" + DateTime.Today.ToShortDateString().Replace("/", ""));
                else if (e.ActivePage == tbEgresos)
                {
                    if (tabCfdiErgesos.SelectedTabPage == tbEgresosCfdi)
                        ExportaDatosExcel(grdViewBandEgresos, txtRFC.Text + "_Egresos_" + DateTime.Today.ToShortDateString().Replace("/", ""));
                    if (tabCfdiErgesos.SelectedTabPage == tbEgresosNomina11)
                        ExportaDatosExcel(grdViewBandEgresosNomina11, txtRFC.Text + "_Egresos_Nomina11_" + DateTime.Today.ToShortDateString().Replace("/", ""));
                    if (tabCfdiErgesos.SelectedTabPage == tbEgresosNomina12)
                        ExportaDatosExcel(grdViewBandEgresosNomina12, txtRFC.Text + "_Egresos_Nomina12_" + DateTime.Today.ToShortDateString().Replace("/", ""));
                }
            }
            else if (e.Button.Caption.Equals("Validar Cfdi encontrados"))
            {
                if (e.ActivePage == tbIngresos)
                {
                    if (!chkIngresosConcentradoDetallado.IsOn)
                        ValidaCfdiSat(Facturas_Ingresos_Detallado);
                    else
                        ValidaCfdiSat(Facturas_Ingresos_Concentrado);
                }
                else if (e.ActivePage == tbNomina11)
                    ValidaCfdiSat(Facturas_Nomima11);
                else if (e.ActivePage == tbNomina12)
                    ValidaCfdiSat(Facturas_Nomima12);
                else if (e.ActivePage == tbEgresos)
                {
                    if (tabCfdiErgesos.SelectedTabPage == tbEgresosCfdi)
                    {
                        if (!chkEgresosConcentradoDetallado.IsOn)
                            ValidaCfdiSat(Facturas_Egresos_Detallado);
                        else
                            ValidaCfdiSat(Facturas_Egresos_Concentrado);
                    }
                    if (tabCfdiErgesos.SelectedTabPage == tbEgresosNomina11)
                        ValidaCfdiSat(Facturas_Egresos_Nomina11);
                    if (tabCfdiErgesos.SelectedTabPage == tbEgresosNomina12)
                        ValidaCfdiSat(Facturas_Egresos_Nomina12);
                }
            }
        }

        /// <summary>
        /// Valida los registros de la tabla en el portal del SAT
        /// </summary>
        /// <param name="tabla">Tabla de datos</param>
        void ValidaCfdiSat(Helper_DataTable tabla)
        {
            if (SatClient == null)
                SatClient = new ConsultaCFDIService.ConsultaCFDIServiceClient();
            
            System.Threading.Thread hilo = new System.Threading.Thread(() =>
              {
                  // Inicia proceso
                  DateTime inicia_proceso = DateTime.Now;
                  EnProceso = true;
                  EstatusFormulario = Estado_Formulario.Carga_Egresos;
                  EstatusProceso = "Recuperando los datos a evaluar...";
                  EstatusGeneral = "Validando Cfdis en el SAT ...";
                  
                  int conteo = 0;
                  int total = tabla.Rows.Count;
                  foreach (DataRow r in tabla.Rows)
                  {
                      conteo++;
                      EstatusProceso = string.Format("Procesando {0} de {1} ...", conteo, total);

                      string cbd = string.Format("?re={0}&rr={1}&tt={2:0000000000.000000}&id={3}",
                                    r["EmisorRFC"],
                                    r["ReceptorRFC"],
                                    r["Total"],
                                    r["UUID"]);
                      try
                      {
                          var acuse = SatClient.Consulta(cbd);
                          r["ValidaSAT"] = acuse.Estado;
                      }
                      // catch (TimeoutException ex)
                      finally
                      {
                          /// No hace nada
                      }
                  }

                  // Termina proceso
                  EnProceso = false;
                  DateTime termina_proceso = DateTime.Now;
                  TimeSpan duracion = termina_proceso - inicia_proceso;
                  EstatusGeneral = string.Format("{0} elementos procesados en {1:00}:{2:00}:{3:00}", tabla.Rows.Count, duracion.Hours, duracion.Minutes, duracion.Seconds);
              });

            hilo.Start();
        }

        /// <summary>
        /// Exporta los datos de un grid seleccionado a formato excel
        /// </summary>
        /// <param name="grid">Grid</param>
        /// <param name="filename">Nombre de archivo</param>
        void ExportaDatosExcel(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grid, string filename)
        {
            string file = string.Empty;
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "*.xlsx|*.xlsx";
                dialog.FileName = filename;
                if (dialog.ShowDialog() == DialogResult.OK)
                    file = dialog.FileName;
            }

            if (!string.IsNullOrEmpty(file))
            {
                grid.OptionsPrint.AutoWidth = true;
                grid.OptionsPrint.RtfReportHeader = filename;
                grid.OptionsPrint.PrintHeader = true;
                grid.OptionsPrint.PrintBandHeader = true;

                grid.ExportToXlsx(file, new DevExpress.XtraPrinting.XlsxExportOptions()
                {
                    ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile,
                    ExportHyperlinks = true,
                    ShowGridLines = true,
                    IgnoreErrors = DevExpress.XtraPrinting.XlIgnoreErrors.NumberStoredAsText,
                    TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text,
                    FitToPrintedPageWidth = true
                });
                System.Diagnostics.Process.Start(file);
            }
        }
        #endregion
    }
}
