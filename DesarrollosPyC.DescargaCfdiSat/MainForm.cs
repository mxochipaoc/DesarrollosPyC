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
using DesarrollosPyC.Com.Controles;

namespace DesarrollosPyC.DescargaCfdiSat
{
    /// <summary>
    /// Formulario principal de lanzado de descarga masiva e Cfdi desde portal del SAT
    /// </summary>
    public partial class MainForm : DevExpress.XtraEditors.XtraForm, CefSharp.IBrowserProcessHandler//, CefSharp.IDownloadHandler
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Propiedades del formulario
        /// <summary>
        /// Navegador de carga de datos
        /// </summary>
        public ChromiumWebBrowser Browser;
        
        /// <summary>
        /// Si es apertura de nuevo navegador
        /// </summary>
        bool AperturaNuevoNavegador { get; set; }

        /// <summary>
        /// Ruta default de descarga de datos
        /// </summary>
        string DefaultDescargaCfdi { get { return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Cfdi descargados"; } }
        
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

        #region Métodos directos del formulario
        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Configuraciones iniciales del navegador
            Cef.EnableHighDPISupport();
            CefSharpSettings.ShutdownOnExit = false;

            // Carga de valores default
            txtRutaPrincipal.Text = DefaultDescargaCfdi;
            if (!System.IO.Directory.Exists(DefaultDescargaCfdi))
                System.IO.Directory.CreateDirectory(DefaultDescargaCfdi);
            
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
        }

        /// <summary>
        /// Inicializa el navegador
        /// </summary>
        private void NavegadorNuevo()
        {
            // Carga del navegador de internet
            if (!Cef.IsInitialized)
            {
                Cef.Initialize(new CefSettings(), false, null);//, true, this);
            }

            Browser = new ChromiumWebBrowser("https://portalcfdi.facturaelectronica.sat.gob.mx/?id=SATUPCFDiCon&sid=0&option=credential&sid=0");
            this.panWebBrowser.Controls.Add(Browser);
            Browser.Dock = DockStyle.Fill;
            //Browser.DownloadHandler = this;
            Browser.LoadingStateChanged += (s, e) =>
            {
                EnProceso = e.IsLoading;
                EstatusProceso = "Cargando página, por favor espere ...";
                EstatusGeneral = "En espera de operaciones ...";
            };
            Browser.FrameLoadEnd += (s, e) =>
            {
                if (e.Frame.IsMain)
                {
                    string rfc = txtRFC.Text;
                    System.Threading.Thread hilo = new System.Threading.Thread(() =>
                      {
                          string script = @"
                            (function() {
                                var element = document.getElementById('rfc');
                                if(element != undefined) {
                                    element.value = '"+ rfc +@"';
                                    element.readOnly = true;
                                }
                            })();";
                          var task = Browser.EvaluateScriptAsync(script, TimeSpan.FromSeconds(10));
                          task.Wait();
                          if (!task.IsFaulted)
                          {
                              if (task.Result.Success)
                                  AperturaNuevoNavegador = false;
                          }
                      });
                    hilo.Start();
                }
            };
            
            AperturaNuevoNavegador = true;
        }

        /// <summary>
        /// Elimina navegadores abiertos en el control
        /// </summary>
        private void ReinicaNavegador()
        {
            string script_close = @"
                        (function() {
                            window.location = '/logout.aspx?salir=y';
                        })();";

            EstatusProceso = "Cerrando sesión ...";
            EstatusGeneral = "Cambiando razon social de descarga ...";
            var task = Browser.EvaluateScriptAsync(script_close, TimeSpan.FromSeconds(10));
            task.Wait();
            if (!task.IsFaulted)
            {
                if (task.Result.Success)
                {
                    Cef.Shutdown();
                    this.panWebBrowser.Controls.Remove(Browser);
                    NavegadorNuevo();
                }
            }
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
                    if (DesarrollosPyC.Com.Controles.Dialogos.ConfirmaPersonalizada("Esta acción cerrará la sesión de descarga masiva, ¿Esta seguro de continuar con esta acción?"))
                    {
                        DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada = (DesarrollosPyC.Com.Licencias.Class.Licencia)lkpRazonSocial.Properties.GetDataSourceRowByKeyValue(e.NewValue);
                        txtRFC.Text = DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada.Receptor.Rfc;

                        ReinicaNavegador();
                    }
                    else
                        e.Cancel = true;
                }
            }
            else
            {
                DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada = (DesarrollosPyC.Com.Licencias.Class.Licencia)lkpRazonSocial.Properties.GetDataSourceRowByKeyValue(e.NewValue);
                txtRFC.Text = DesarrollosPyC.CfdiSat.Environment.Aplicacion.LicenciaSeleccionada.Receptor.Rfc;

                NavegadorNuevo();
            }
        }
        #endregion
        
        #region Visualización de estatus, barra de progreso
        /// <summary>
        /// Lanzado, ocultado de mensaje de espera, visualización de estatus
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
        }
        #endregion

        #region Manejo de ruta de guardado
        /// <summary>
        /// Paso de controles a ruta de guardado
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnBotonRuta_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton button = sender as DevExpress.XtraEditors.SimpleButton;
            if (button != null)
            {
                if (button.Parent == panRutaDisponible)
                {
                    panRutaDisponible.Controls.Remove(button);
                    panRutaAgregada.Controls.Add(button);

                    panRutaDisponible.Enabled = button != btnSerieFolio && button != btnUUID;
                }
                else if (button.Parent == panRutaAgregada)
                {
                    panRutaAgregada.Controls.Remove(button);
                    panRutaDisponible.Controls.Add(button);

                    if (!panRutaDisponible.Enabled)
                        panRutaDisponible.Enabled = button == btnSerieFolio || button == btnUUID;
                }
            }
        }
        /// <summary>
        /// Organiza los datos descargados conforme la orgranización seleccinada
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnOrganizaDatos_Click(object sender, EventArgs e)
        {
            System.Threading.Thread hilo = new System.Threading.Thread(() =>
            {
                EnProceso = true;
                DateTime inicio_operacion = DateTime.Now;

                // Formado de rutas de guardado
                EstatusProceso = "Recuperando datos del directorio de descarga...";
                string[] cfdis = System.IO.Directory.GetFiles(txtRutaPrincipal.Text, "*.xml", System.IO.SearchOption.TopDirectoryOnly);
                EstatusProceso = string.Format("{0} elementos encontrados..", cfdis.Length);

                // Creación de directorios principales
                string rfc = txtRFC.Text;
                string path_ingresos = txtRutaPrincipal.Text + "\\Ingresos";
                string path_egresos = txtRutaPrincipal.Text + "\\Egresos";
                if (!System.IO.Directory.Exists(path_ingresos))
                    System.IO.Directory.CreateDirectory(path_ingresos);
                if (!System.IO.Directory.Exists(path_egresos))
                    System.IO.Directory.CreateDirectory(path_egresos);

                // Proceso de datos
                int conteo = 0;
                int total = cfdis.Length;
                foreach (string x in cfdis)
                {
                    conteo++;
                    EstatusProceso = string.Format("Procesando {0} de {1} ...", conteo, total);
                    DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante cfdi = DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante.LoadFromFile(x);
                    if (cfdi != null)
                    {
                        DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.TimbreFiscalDigital timbre = null;
                        System.Xml.XmlElement impL = cfdi.Complemento.Any.Where(j => j.LocalName.Equals("TimbreFiscalDigital")).FirstOrDefault();
                        if (impL != null)
                        {
                            timbre = DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.TimbreFiscalDigital.Deserialize(impL.OuterXml);
                        }
                        if (timbre == null)
                            continue;

                        string serie_folio = (cfdi.serie + "-" + cfdi.folio).Trim(' ', '-');
                        if (string.IsNullOrEmpty(serie_folio))
                            serie_folio = timbre.UUID;

                        EstatusGeneral = string.Format("Procesando: {0}", x);
                        // Generación de ruta de guardado
                        Dictionary<Cfdi_Guardado, string> ruta_guardado = new Dictionary<Cfdi_Guardado, string>();
                        ruta_guardado.Add(Cfdi_Guardado.RFC_Emisor, cfdi.Emisor.rfc);
                        ruta_guardado.Add(Cfdi_Guardado.RFC_Receptor, cfdi.Receptor.rfc);
                        ruta_guardado.Add(Cfdi_Guardado.Anhio, cfdi.fecha.Year.ToString());
                        ruta_guardado.Add(Cfdi_Guardado.Mes, cfdi.fecha.Month.ToString("00") + "-" + cfdi.fecha.ToString("MMMM").ToUpper());
                        ruta_guardado.Add(Cfdi_Guardado.Serie_Folio, serie_folio);
                        ruta_guardado.Add(Cfdi_Guardado.UUID, timbre.UUID);

                        string ruta_complemento = string.Empty;
                        foreach (DevExpress.XtraEditors.SimpleButton b in panRutaAgregada.Controls)
                        {
                            if (b == btnRutaRFCEmisor)
                                ruta_complemento = ruta_complemento + "\\" + ruta_guardado[Cfdi_Guardado.RFC_Emisor];
                            if (b == btnRutaRFCReceptor)
                                ruta_complemento = ruta_complemento + "\\" + ruta_guardado[Cfdi_Guardado.RFC_Receptor];
                            if (b == btnRutaAnio)
                                ruta_complemento = ruta_complemento + "\\" + ruta_guardado[Cfdi_Guardado.Anhio];
                            if (b == btnRutaMes)
                                ruta_complemento = ruta_complemento + "\\" + ruta_guardado[Cfdi_Guardado.Mes];

                            if (b == btnUUID)
                                ruta_complemento = ruta_complemento + "\\" + ruta_guardado[Cfdi_Guardado.UUID] + ".xml";
                            if (b == btnSerieFolio)
                                ruta_complemento = ruta_complemento + "\\" + ruta_guardado[Cfdi_Guardado.Serie_Folio] + ".xml";
                        }

                        // Lanzado del reacomodo
                        string path = string.Empty;
                        // Tratado de ingresos
                        if (cfdi.Emisor.rfc.Equals(rfc))
                            path = path_ingresos;
                        // Tratado de egresos
                        if (cfdi.Receptor.rfc.Equals(rfc))
                            path = path_egresos;

                        VerificaDirectorios(path, ruta_complemento);
                        path = path + ruta_complemento;
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(x);
                            string uq = serie_folio + "_" + cfdi.Emisor.rfc + "_" + cfdi.Receptor.rfc + "_" + cfdi.fecha.ToString("ddMMyyyTHHmmss") + ".xml";
                            string[] redir = path.Split(new char[] { '\\' });
                            path = path.Substring(0, path.Length - redir[redir.Length - 1].Length);
                            path = path + uq;
                        }

                        EstatusGeneral = string.Format("Moviendo {0} a {1}...", x, path);
                        System.IO.File.Copy(x, path, true);
                        System.IO.File.Delete(x);
                    }
                }

                EnProceso = false;
                DateTime termino_operacion = DateTime.Now;
                TimeSpan duracion = termino_operacion - inicio_operacion;
                EstatusGeneral = string.Format("{0} elementos descargados en {1:00}:{2:00}:{3:00}", cfdis.Length, duracion.Hours, duracion.Minutes, duracion.Seconds);
            });
            hilo.Start();
        }
        /// <summary>
        /// Verificación de ruta de datos, creación de directorios faltantes
        /// </summary>
        /// <param name="main_path"></param>
        /// <param name="path"></param>
        void VerificaDirectorios(string main_path, string path)
        {
            var dirs = path.Replace(main_path, "").Split(new char[] { '\\' }).ToList();
            dirs.Remove(dirs[dirs.Count - 1]);
            string rec = main_path;
            foreach (string d in dirs)
            {
                if (string.IsNullOrEmpty(d))
                    continue;
                rec = rec + "\\" + d;
                if (System.IO.Directory.Exists(rec))
                    continue;
                System.IO.Directory.CreateDirectory(rec);
            }
        }
        #endregion

        #region Lanzado de descarga de datos
        /// <summary>
        /// Inicia la descarga de datos
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void btnDescargarCfdi_Click(object sender, EventArgs e)
        {
            // recuperación del RFC del portal
            string rfc_script = @"
            (function() {
                var element = document.getElementById('ctl00_LblRfcAutenticado');
                var rfc = '';
                if (element != undefined) {
                    rfc = element.innerHTML;
                }

                return rfc;
            })();";
            object rfc_data = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, rfc_script, 10);
            if (rfc_script != null)
            {
                string[] dat = rfc_data.ToString().Split(new char[] { ':' });
                if (dat.Length > 0)
                    txtRFC.Text = dat[1].Trim();
            }

            // tipo de descarga de datos
            string titulo_script = @"
            (function() {
	            var retorno = -1;
	            var element = document.getElementById('cuerpo');
	            if (element != null) {
		            var h2 = element.getElementsByTagName('h2');
		            var txt = '';
		            for (var i = 0; i < h2.length; i++) {
			            txt = h2[i].innerHTML;
                        if (retorno == -1) {
                            if (txt.trim().toUpperCase() === ('Consultar Facturas Emitidas').trim().toUpperCase()) {
                                retorno = 1;
                            }
			                else if (txt.trim().toUpperCase() === ('Consultar Facturas Recibidas').trim().toUpperCase()) {
				                retorno = 0;
                            }
			            }
		            }
	            }
	            return retorno;
            })();";

            Tipo_Cfdi_Descarga td = Tipo_Cfdi_Descarga.No_definido;
            object value = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, titulo_script, 10);
            if (value != null)
            {
                short val = -1;
                if (!short.TryParse(value.ToString(), out val))
                    val = -1;
                td = (Tipo_Cfdi_Descarga)val;
            }

            // Lanzado de la oepración de descarga en segundo plano
            if (td!= Tipo_Cfdi_Descarga.No_definido)
            {
                System.Threading.Thread hilo = new System.Threading.Thread(() =>
                {
                    EnProceso = true;
                    if (td == Tipo_Cfdi_Descarga.Ingresos)
                    {
                        IniciaDescargaIngresos();
                    }
                    if (td == Tipo_Cfdi_Descarga.Egresos)
                    {
                        IniciaDescargaEgresos();
                    }
                    EnProceso = false;
                });
                hilo.Start();
            }
        }

        #region Métodos comunes de descarga de datos
        /// <summary>
        /// Verifica que no exeda los 500 registros
        /// </summary>
        /// <returns>Resultado</returns>
        bool MasDe500Elemntos()
        {
            string script = @"
            (function() {
                var element = document.getElementById('ctl00_MainContent_PnlLimiteRegistros');
                var result = false;
                if (element != undefined) {
                    var h2 = element.getElementsByTagName('h2');
                    var txt = '';
		            for (var i = 0; i < h2.length; i++) {
			            txt = h2[i].innerHTML;
			            if (txt == 'La consulta realizada solo muestra los primeros 500 registros.') {
				            result = true;
				            break;
			            }
		            }
                }

                return result;
            })();";

            EstatusProceso = "Validando tabla de datos...";
            object value = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, script, 10);
            bool result = false;
            if (!bool.TryParse(value.ToString(), out result))
                result = false;
            return result;
        }
        /// <summary>
        /// Espera la carga de la pagina de datos
        /// </summary>
        /// <param name="descargas">Descargas</param>
        /// <param name="errores">Errores</param>
        /// <param name="estatusProceso">Método de mensaje de carga de datos</param>
        /// <param name="dia">Día de descarga</param>
        private void PintaPaginaDescargaDatos(List<string> descargas, string errores)
        {
            string script = @"
                (function() {
                    var result = '';
                    var contenedor = document.getElementById('ContenedorDinamico');
                    if(contenedor != undefined) {
                        if (contenedor.style.display != 'none') {
                            var tabla = document.getElementById('ctl00_MainContent_tblResult');
                            for (var i = 1; i < tabla.rows.length; i++) {
                                var line = tabla.rows[i].cells[1].getElementsByTagName('span')[0].innerHTML;
                                var btns = tabla.rows[i].cells[0].getElementsByTagName('img');
                                for (var j = 0; j < btns.length; j++) {
                                    var btn = btns[j];
                                    if (btn.getAttribute('name') == 'BtnDescarga') {
                                        line = line + '|' + btn.getAttribute('onclick');
                                        break;
                                    }
                                }
                                result = result + line + '\n';
                            }
                        }
                    }
                    return result;
                })();";

            EstatusProceso = "Validando información ...";
            string xmls = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, script, 20).ToString();
            if (!string.IsNullOrWhiteSpace(xmls))
            {
                List<Helper_Cfdi> to_download = new List<Helper_Cfdi>();
                string[] xml_comp = xmls.Split(new char[] { '\n' });
                foreach (string x in xml_comp)
                {
                    if (string.IsNullOrWhiteSpace(x))
                        continue;

                    string[] xdata = x.Split(new char[] { '|' });
                    string uuid = xdata[0];
                    if (xdata.Length > 1)
                    {
                        string func_data = xdata[1].Split(new char[] { '\'', ',' })[1];
                        to_download.Add(new Helper_Cfdi(uuid, func_data));
                        descargas.Add(uuid);
                    }
                    else
                    {
                        errores = errores + uuid + " Imposible descargar.\n";
                    }
                }

                int conteo = 0;
                int total = to_download.Count;
                foreach (Helper_Cfdi cfdi in to_download)
                {
                    string script_descarga = @"
                        (function() {
                            MantieneSesion();
                            var xmlHttp = new XMLHttpRequest();
                            xmlHttp.open('GET', '" + cfdi.PageDownload + @"',  false); // false for synchronous request
                            xmlHttp.send(null);
                            return xmlHttp.responseText;
                        })();";

                    //var task = Browser.EvaluateScriptAsync("validarDescargaUnitaria", cfdi.PageDownload);
                    conteo++;
                    EstatusProceso = string.Format("Descargando {0} de {1} ...", conteo, total);
                    EstatusGeneral = string.Format("Descargando: {0}", cfdi.UUID);
                    var task = Browser.EvaluateScriptAsync(script_descarga, TimeSpan.FromSeconds(10));
                    task.Wait();
                    if (!task.IsFaulted)
                    {
                        var r = task.Result;
                        string cfdi_xml = r.Result.ToString();
                        string uuid = cfdi.UUID;

                        try
                        {
                            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                            doc.LoadXml(cfdi_xml);
                            doc.Save(txtRutaPrincipal.Text + "\\" + uuid + ".xml");
                        }
                        finally
                        {
                            // No hace nada
                        }
                    }
                    /*task.ContinueWith(t =>
                    {
                        if (!t.IsFaulted)
                        {
                            string cfdi_xml = t.Result.Result.ToString();
                            string uuid = cfdi.UUID;

                            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                            doc.LoadXml(cfdi_xml);
                            doc.Save(txtRutaPrincipal.Text + "\\" + uuid + ".xml");
                        }
                    }, TareaDescarga);*/

                }
            }
        }
        #endregion

        #region Métodos de descarga de facturas de ingresos
        /// <summary>
        /// Inicia la descarga de ingresos
        /// </summary>
        void IniciaDescargaIngresos()
        {
            DateTime inicia_descarga = DateTime.Now;

            string inicialFecha = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaInicial2_Calendario_text"), 
                10).ToString();
            string inicialHora = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaInicial2_DdlHora"), 
                10).ToString();
            string inicialMinuto = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaInicial2_DdlMinuto"), 
                10).ToString();
            string inicialSegundo = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaInicial2_DdlSegundo"), 
                10).ToString();

            string finalFecha = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaFinal2_Calendario_text"), 
                10).ToString();
            string finalHora = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaFinal2_DdlHora"), 
                10).ToString();
            string finalMinuto = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaFinal2_DdlMinuto"), 
                10).ToString();
            string finalSegundo = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaFinal2_DdlSegundo"), 
                10).ToString();

            DateTime inicial = Convert.ToDateTime(inicialFecha
                + " " + inicialHora
                + ":" + inicialMinuto
                + ":" + inicialSegundo);
            DateTime final = Convert.ToDateTime(finalFecha
                + " " + finalHora
                + ":" + finalMinuto
                + ":" + finalSegundo);

            List<string> descargas = new List<string>();
            string errores = string.Empty;
            DescargaMasivaIngresos(inicial, final, descargas, errores);

            DateTime fin_descarga = DateTime.Now;
            TimeSpan duracion = fin_descarga - inicia_descarga;
            EstatusGeneral = string.Format("{0} elementos descargados en {1:00}:{2:00}:{3:00}", descargas.Count, duracion.Hours, duracion.Minutes, duracion.Seconds);
        }
        /// <summary>
        /// Descarga masivamente las facturas de ingresos, carga execiva de archivos
        /// </summary>
        /// <param name="inicial">Fecha inicial</param>
        /// <param name="final">Fecha final</param>
        /// <param name="descargas">Lista de archivos</param>
        /// <param name="errores">Errores</param>
        void DescargaMasivaIngresos(DateTime inicial, DateTime final, List<string> descargas, string errores)
        {
            if (MasDe500Elemntos())
            {
                TimeSpan diferencia = (final - inicial);
                DateTime nuevoFinal = inicial.AddTicks(diferencia.Ticks / 2);

                // Descarga de la primera parte de las facturas
                AsignaFechasBuscaDatosIngresos(inicial, nuevoFinal);
                DescargaMasivaIngresos(inicial, nuevoFinal, descargas, errores);

                // Descarga de la segunda parte de las facturas
                AsignaFechasBuscaDatosIngresos(nuevoFinal, final);
                DescargaMasivaIngresos(nuevoFinal, final, descargas, errores);
            }
            else
                PintaPaginaDescargaDatos(descargas, errores);
        }
        /// <summary>
        /// Asigna las fechas especificadas a la página
        /// </summary>
        /// <param name="inicial">Fecha de inicio</param>
        /// <param name="final">Fecha de termino</param>
        void AsignaFechasBuscaDatosIngresos(DateTime inicial, DateTime final)
        {
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaInicial2_Calendario_text", inicial.ToShortDateString()), 
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaInicial2_DdlHora;", inicial.Hour.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaInicial2_DdlMinuto", inicial.Minute.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaInicial2_DdlSegundo", inicial.Second.ToString()),
                10);

            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaFinal2_Calendario_text", final.ToShortDateString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaFinal2_DdlHora", final.Hour.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaFinal2_DdlMinuto", final.Minute.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser, 
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFechaFinal2_DdlSegundo", final.Second.ToString()),
                10);

            string carga_pagina = @"
            (function(){
	            var element = document.getElementById('ctl00_MainContent_BtnBusqueda');
	            if(element != undefined) {
		            element.click();
		            var intvl = setInterval(function(){
			            var contenedor = document.getElementById('ctl00_MainContent_tblResult');
			            if(contenedor != undefined) {
				            if (contenedor.style.display != 'none') {
					            clearInterval(intvl);
				            }
			            }
		            }, 100);
		            return true;
	            }
	            else
		            return false;
            })();";

            var task = Browser.EvaluateScriptAsync(carga_pagina, TimeSpan.FromSeconds(30));
            task.Wait();
            if (task.IsFaulted)
            {
                throw new Exception("Error al carga pagina de datos.");
            }
        }
        #endregion

        #region Métodos de descarga de facturas de egresos
        /// <summary>
        /// Inicia la descarga de egtresos
        /// </summary>
        void IniciaDescargaEgresos()
        {
            DateTime inicia_descarga = DateTime.Now;

            string inicialFecha = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFechaInicial2_Calendario_text"),
                10).ToString();

            string anhio = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("DdlAnio"),
                10).ToString();
            string mes = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlMes"),
                10).ToString();
            string dia = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlDia"),
                10).ToString();

            string horaIn = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlHora"),
                10).ToString();
            string minutoIn = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlMinuto"),
                10).ToString();
            string segundoIn = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlSegundo"),
                10).ToString();

            string horaFi = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlHoraFin"),
                10).ToString();
            string minutoFi = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlMinutoFin"),
                10).ToString();
            string segundoFi = Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getElementValueById_Js_String("ctl00_MainContent_CldFecha_DdlSegundoFin"),
                10).ToString();

            TimeSpan ini = new TimeSpan(Convert.ToInt32(horaIn), Convert.ToInt32(minutoIn), Convert.ToInt32(segundoIn));
            TimeSpan fin = new TimeSpan(Convert.ToInt32(horaFi), Convert.ToInt32(minutoFi), Convert.ToInt32(segundoFi));

            List<string> descargas = new List<string>();
            string errores = string.Empty;
            DescargaMasivaEgresos(Convert.ToInt32(anhio), Convert.ToInt32(mes), Convert.ToInt32(dia), ini, fin, descargas, errores);

            DateTime fin_descarga = DateTime.Now;
            TimeSpan duracion = fin_descarga - inicia_descarga;
            EstatusGeneral = string.Format("{0} elementos descargados en {1:00}:{2:00}:{3:00}", descargas.Count, duracion.Hours, duracion.Minutes, duracion.Seconds);
        }
        /// <summary>
        /// Descarga masivamente las facturas de ingresos, carga execiva de archivos
        /// </summary>
        /// <param name="anhio">Año</param>
        /// <param name="mes">Mes</param>
        /// <param name="dia">Día</param>
        /// <param name="ini">Hora inicial</param>
        /// <param name="fin">Hora final</param>
        /// <param name="descargas">Lista de archivos</param>
        /// <param name="errores">Errores</param>
        void DescargaMasivaEgresos(int anhio, int mes, int dia, TimeSpan ini, TimeSpan fin, List<string> descargas, string errores)
        {
            if (MasDe500Elemntos())
            {
                DateTime value = new DateTime(anhio, mes, 1);
                value = value.AddDays(31);
                while (value.Month > mes)
                {
                    value = value.AddDays(-1);
                }

                TimeSpan nini = ini;
                TimeSpan nfin = fin;
                while (dia < value.Day)
                {
                    dia = dia + 1;
                    AsignaFechasBuscaDatosEgresos(anhio, mes, dia, ini, fin);
                    if (MasDe500Elemntos())
                    {
                        bool itera = true;
                        while (itera)
                        {
                            TimeSpan newFin = new TimeSpan(nfin.Hours / 2, nfin.Minutes / 2, nfin.Seconds / 2);
                            // Descarga de la primera parte de las facturas
                            AsignaFechasBuscaDatosEgresos(anhio, mes, dia, ini, newFin);
                            if (!MasDe500Elemntos())
                            {
                                PintaPaginaDescargaDatos(descargas, errores);
                                itera = false;

                                // Descarga de la segunda parte de las facturas
                                AsignaFechasBuscaDatosEgresos(anhio, mes, dia, newFin, fin);
                                if (!MasDe500Elemntos())
                                    PintaPaginaDescargaDatos(descargas, errores);
                                else
                                {
                                    nini = newFin;
                                    nfin = fin;
                                }
                            }
                            else
                            {
                                nini = ini;
                                nfin = newFin;
                            }
                        }
                    }
                    else
                        PintaPaginaDescargaDatos(descargas, errores);
                }
            }
            else
                PintaPaginaDescargaDatos(descargas, errores);

        }
        /// <summary>
        /// Asigna las fechas especificadas a la página
        /// </summary>
        /// <param name="anhio">Año</param>
        /// <param name="mes">Mes</param>
        /// <param name="dia">Día</param>
        /// <param name="ini">Hora inicial</param>
        /// <param name="fin">Hora final</param>
        void AsignaFechasBuscaDatosEgresos(int anhio, int mes, int dia, TimeSpan ini, TimeSpan fin)
        {
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("DdlAnio", anhio.ToString("00")),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFecha_DdlMes", mes.ToString()), 
                10);
            if (dia > 0)
                Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                    Helper_HtmlElements.getResultScriptUpdateElementValue("'ctl00_MainContent_CldFecha_DdlDia", dia.ToString("00")),
                    10);

            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFecha_DdlHora", ini.Hours.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFecha_DdlMinuto", ini.Minutes.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFecha_DdlSegundo", ini.Seconds.ToString()),
                10);

            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFecha_DdlHoraFin", fin.Hours.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFecha_DdlMinutoFin", fin.Minutes.ToString()),
                10);
            Helper_HtmlElements.getJavascriptResponse_By_Js(Browser,
                Helper_HtmlElements.getResultScriptUpdateElementValue("ctl00_MainContent_CldFecha_DdlSegundoFin", fin.Seconds.ToString()),
                10);
            
            string carga_pagina = @"
            (function(){
	            var element = document.getElementById('ctl00_MainContent_BtnBusqueda');
	            if(element != undefined) {
		            element.click();
		            var intvl = setInterval(function(){
			            var contenedor = document.getElementById('ctl00_MainContent_tblResult');
			            if(contenedor != undefined) {
				            if (contenedor.style.display != 'none') {
					            clearInterval(intvl);
				            }
			            }
		            }, 100);
		            return true;
	            }
	            else
		            return false;
            })();";

            var task = Browser.EvaluateScriptAsync(carga_pagina, TimeSpan.FromSeconds(30));
            task.Wait();
            if (task.IsFaulted)
            {
                throw new Exception("Error al carga pagina de datos.");
            }
        }
        #endregion

        #endregion

        #region Métodos de Interfaces
        /*
        /// <summary>
        /// Antes de la descarga de datos
        /// </summary>
        /// <param name="browser">Navegador</param>
        /// <param name="downloadItem">Elemento descargado</param>
        /// <param name="callback">Procesamiento</param>
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            string filename = downloadItem.ContentDisposition.Split(new char[] { '=' })[1];
            callback.Continue(txtRutaPrincipal.Text +"\\"+ filename, false);
        }
        /// <summary>
        /// Durante la descarga de datos
        /// </summary>
        /// <param name="browser">Navegador</param>
        /// <param name="downloadItem">Elemento en descarga</param>
        /// <param name="callback">Procesamiento</param>
        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
           
        }
        */

        /// <summary>
        /// Inicializa en contexto
        /// </summary>
        public void OnContextInitialized()
        {
            
        }

        /// <summary>
        /// Programa mensaje de trabajo
        /// </summary>
        /// <param name="delay">Retraso</param>
        public void OnScheduleMessagePumpWork(long delay)
        {
            
        }
        #endregion
    }
}
