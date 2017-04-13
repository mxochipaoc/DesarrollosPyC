namespace DesarrollosPyC.DescargaCfdiSat
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panWebBrowser = new DevExpress.XtraEditors.PanelControl();
            this.panDatosContribuyente = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRFC = new DevExpress.XtraEditors.LabelControl();
            this.lblRazonSocial = new DevExpress.XtraEditors.LabelControl();
            this.lblCfdiADescargar = new DevExpress.XtraEditors.LabelControl();
            this.txtRazonSocial = new DevExpress.XtraEditors.MemoEdit();
            this.txtRFC = new DevExpress.XtraEditors.TextEdit();
            this.rdgTipoCfdiDescarga = new DevExpress.XtraEditors.RadioGroup();
            this.btnDescargarCfdi = new DevExpress.XtraEditors.SimpleButton();
            this.panDatosGuardado = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOrganizaDatos = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panRutaAgregada = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRutaGuardado = new DevExpress.XtraEditors.LabelControl();
            this.txtRutaPrincipal = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panRutaDisponible = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAnio = new DevExpress.XtraEditors.SimpleButton();
            this.btnMes = new DevExpress.XtraEditors.SimpleButton();
            this.btnRutaRFCEmisor = new DevExpress.XtraEditors.SimpleButton();
            this.btnRFCReceptor = new DevExpress.XtraEditors.SimpleButton();
            this.btnSerieFolio = new DevExpress.XtraEditors.SimpleButton();
            this.btnUUID = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pgrPorcentajeCargaBrowser = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblEstatusBrowser = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panWebBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDatosContribuyente)).BeginInit();
            this.panDatosContribuyente.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTipoCfdiDescarga.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDatosGuardado)).BeginInit();
            this.panDatosGuardado.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaPrincipal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panRutaDisponible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgrPorcentajeCargaBrowser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Controls.Add(this.panWebBrowser, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panDatosContribuyente, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panDatosGuardado, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl3, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(980, 501);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panWebBrowser
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panWebBrowser, 2);
            this.panWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panWebBrowser.Location = new System.Drawing.Point(8, 138);
            this.panWebBrowser.Name = "panWebBrowser";
            this.panWebBrowser.Size = new System.Drawing.Size(963, 330);
            this.panWebBrowser.TabIndex = 0;
            // 
            // panDatosContribuyente
            // 
            this.panDatosContribuyente.Controls.Add(this.tableLayoutPanel2);
            this.panDatosContribuyente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDatosContribuyente.Location = new System.Drawing.Point(8, 8);
            this.panDatosContribuyente.Name = "panDatosContribuyente";
            this.panDatosContribuyente.Size = new System.Drawing.Size(333, 124);
            this.panDatosContribuyente.TabIndex = 1;
            this.panDatosContribuyente.Text = "Datos de contribuyente";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.Controls.Add(this.lblRFC, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblRazonSocial, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCfdiADescargar, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtRazonSocial, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRFC, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.rdgTipoCfdiDescarga, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnDescargarCfdi, 4, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(329, 102);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblRFC
            // 
            this.lblRFC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRFC.Location = new System.Drawing.Point(8, 50);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblRFC.Size = new System.Drawing.Size(42, 13);
            this.lblRFC.TabIndex = 1;
            this.lblRFC.Text = "R.F.C.: ";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRazonSocial.Location = new System.Drawing.Point(8, 11);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblRazonSocial.Size = new System.Drawing.Size(69, 13);
            this.lblRazonSocial.TabIndex = 0;
            this.lblRazonSocial.Text = "Razón social: ";
            // 
            // lblCfdiADescargar
            // 
            this.lblCfdiADescargar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCfdiADescargar.Location = new System.Drawing.Point(8, 76);
            this.lblCfdiADescargar.Name = "lblCfdiADescargar";
            this.lblCfdiADescargar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblCfdiADescargar.Size = new System.Drawing.Size(76, 13);
            this.lblCfdiADescargar.TabIndex = 2;
            this.lblCfdiADescargar.Text = "Cfdi descarga: ";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.txtRazonSocial, 3);
            this.txtRazonSocial.Location = new System.Drawing.Point(86, 8);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.tableLayoutPanel2.SetRowSpan(this.txtRazonSocial, 2);
            this.txtRazonSocial.Size = new System.Drawing.Size(233, 28);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // txtRFC
            // 
            this.txtRFC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRFC.Location = new System.Drawing.Point(86, 47);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Properties.Mask.EditMask = "[A-Z&]{3,4}[0-9]{6}[A-Z0-9]{3}";
            this.txtRFC.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRFC.Size = new System.Drawing.Size(176, 20);
            this.txtRFC.TabIndex = 4;
            // 
            // rdgTipoCfdiDescarga
            // 
            this.rdgTipoCfdiDescarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdgTipoCfdiDescarga.Location = new System.Drawing.Point(86, 72);
            this.rdgTipoCfdiDescarga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdgTipoCfdiDescarga.Name = "rdgTipoCfdiDescarga";
            this.rdgTipoCfdiDescarga.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Egresos"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Ingresos")});
            this.rdgTipoCfdiDescarga.Size = new System.Drawing.Size(176, 22);
            this.rdgTipoCfdiDescarga.TabIndex = 5;
            // 
            // btnDescargarCfdi
            // 
            this.btnDescargarCfdi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarCfdi.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDescargarCfdi.Location = new System.Drawing.Point(273, 47);
            this.btnDescargarCfdi.Name = "btnDescargarCfdi";
            this.tableLayoutPanel2.SetRowSpan(this.btnDescargarCfdi, 2);
            this.btnDescargarCfdi.Size = new System.Drawing.Size(46, 46);
            this.btnDescargarCfdi.TabIndex = 6;
            this.btnDescargarCfdi.Click += new System.EventHandler(this.btnDescargarCfdi_Click);
            // 
            // panDatosGuardado
            // 
            this.panDatosGuardado.Controls.Add(this.tableLayoutPanel3);
            this.panDatosGuardado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDatosGuardado.Location = new System.Drawing.Point(347, 8);
            this.panDatosGuardado.Name = "panDatosGuardado";
            this.panDatosGuardado.Size = new System.Drawing.Size(624, 124);
            this.panDatosGuardado.TabIndex = 2;
            this.panDatosGuardado.Text = "Datos de guardado de Cfdi descargados";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.Controls.Add(this.btnOrganizaDatos, 5, 3);
            this.tableLayoutPanel3.Controls.Add(this.panelControl2, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblRutaGuardado, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtRutaPrincipal, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.panelControl1, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(620, 102);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnOrganizaDatos
            // 
            this.btnOrganizaDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrganizaDatos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOrganizaDatos.Location = new System.Drawing.Point(563, 47);
            this.btnOrganizaDatos.Name = "btnOrganizaDatos";
            this.tableLayoutPanel3.SetRowSpan(this.btnOrganizaDatos, 2);
            this.btnOrganizaDatos.Size = new System.Drawing.Size(46, 46);
            this.btnOrganizaDatos.TabIndex = 7;
            this.btnOrganizaDatos.Click += new System.EventHandler(this.btnOrganizaDatos_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panRutaAgregada);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(281, 45);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(1);
            this.panelControl2.Name = "panelControl2";
            this.tableLayoutPanel3.SetRowSpan(this.panelControl2, 2);
            this.panelControl2.Size = new System.Drawing.Size(273, 50);
            this.panelControl2.TabIndex = 7;
            // 
            // panRutaAgregada
            // 
            this.panRutaAgregada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRutaAgregada.Location = new System.Drawing.Point(2, 2);
            this.panRutaAgregada.Name = "panRutaAgregada";
            this.panRutaAgregada.Size = new System.Drawing.Size(269, 46);
            this.panRutaAgregada.TabIndex = 6;
            // 
            // lblRutaGuardado
            // 
            this.lblRutaGuardado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRutaGuardado.Location = new System.Drawing.Point(8, 50);
            this.lblRutaGuardado.Name = "lblRutaGuardado";
            this.lblRutaGuardado.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblRutaGuardado.Size = new System.Drawing.Size(97, 13);
            this.lblRutaGuardado.TabIndex = 3;
            this.lblRutaGuardado.Text = "Ruta de guardado: ";
            // 
            // txtRutaPrincipal
            // 
            this.txtRutaPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRutaPrincipal.Location = new System.Drawing.Point(107, 47);
            this.txtRutaPrincipal.Name = "txtRutaPrincipal";
            this.txtRutaPrincipal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtRutaPrincipal.Properties.ReadOnly = true;
            this.txtRutaPrincipal.Size = new System.Drawing.Size(170, 20);
            this.txtRutaPrincipal.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.panelControl1, 4);
            this.panelControl1.Controls.Add(this.panRutaDisponible);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(105, 6);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(506, 32);
            this.panelControl1.TabIndex = 5;
            // 
            // panRutaDisponible
            // 
            this.panRutaDisponible.Controls.Add(this.btnAnio);
            this.panRutaDisponible.Controls.Add(this.btnMes);
            this.panRutaDisponible.Controls.Add(this.btnRutaRFCEmisor);
            this.panRutaDisponible.Controls.Add(this.btnRFCReceptor);
            this.panRutaDisponible.Controls.Add(this.btnSerieFolio);
            this.panRutaDisponible.Controls.Add(this.btnUUID);
            this.panRutaDisponible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRutaDisponible.Location = new System.Drawing.Point(2, 2);
            this.panRutaDisponible.Name = "panRutaDisponible";
            this.panRutaDisponible.Size = new System.Drawing.Size(502, 28);
            this.panRutaDisponible.TabIndex = 5;
            // 
            // btnAnio
            // 
            this.btnAnio.Location = new System.Drawing.Point(3, 3);
            this.btnAnio.Name = "btnAnio";
            this.btnAnio.Size = new System.Drawing.Size(75, 23);
            this.btnAnio.TabIndex = 2;
            this.btnAnio.Text = "Año";
            this.btnAnio.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnMes
            // 
            this.btnMes.Location = new System.Drawing.Point(84, 3);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(75, 23);
            this.btnMes.TabIndex = 3;
            this.btnMes.Text = "Mes";
            this.btnMes.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnRutaRFCEmisor
            // 
            this.btnRutaRFCEmisor.Location = new System.Drawing.Point(165, 3);
            this.btnRutaRFCEmisor.Name = "btnRutaRFCEmisor";
            this.btnRutaRFCEmisor.Size = new System.Drawing.Size(75, 23);
            this.btnRutaRFCEmisor.TabIndex = 0;
            this.btnRutaRFCEmisor.Text = "RFC emisor";
            this.btnRutaRFCEmisor.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnRFCReceptor
            // 
            this.btnRFCReceptor.Location = new System.Drawing.Point(246, 3);
            this.btnRFCReceptor.Name = "btnRFCReceptor";
            this.btnRFCReceptor.Size = new System.Drawing.Size(75, 23);
            this.btnRFCReceptor.TabIndex = 1;
            this.btnRFCReceptor.Text = "RFC receptor";
            this.btnRFCReceptor.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnSerieFolio
            // 
            this.btnSerieFolio.Location = new System.Drawing.Point(327, 3);
            this.btnSerieFolio.Name = "btnSerieFolio";
            this.btnSerieFolio.Size = new System.Drawing.Size(75, 23);
            this.btnSerieFolio.TabIndex = 4;
            this.btnSerieFolio.Text = "Serie - folio";
            this.btnSerieFolio.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnUUID
            // 
            this.btnUUID.Location = new System.Drawing.Point(408, 3);
            this.btnUUID.Name = "btnUUID";
            this.btnUUID.Size = new System.Drawing.Size(75, 23);
            this.btnUUID.TabIndex = 5;
            this.btnUUID.Text = "UUID";
            this.btnUUID.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // panelControl3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelControl3, 2);
            this.panelControl3.Controls.Add(this.pgrPorcentajeCargaBrowser);
            this.panelControl3.Controls.Add(this.lblEstatusBrowser);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(8, 471);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(963, 25);
            this.panelControl3.TabIndex = 3;
            // 
            // pgrPorcentajeCargaBrowser
            // 
            this.pgrPorcentajeCargaBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pgrPorcentajeCargaBrowser.Location = new System.Drawing.Point(624, 7);
            this.pgrPorcentajeCargaBrowser.Name = "pgrPorcentajeCargaBrowser";
            this.pgrPorcentajeCargaBrowser.Size = new System.Drawing.Size(334, 12);
            this.pgrPorcentajeCargaBrowser.TabIndex = 1;
            // 
            // lblEstatusBrowser
            // 
            this.lblEstatusBrowser.Location = new System.Drawing.Point(5, 6);
            this.lblEstatusBrowser.Name = "lblEstatusBrowser";
            this.lblEstatusBrowser.Size = new System.Drawing.Size(108, 13);
            this.lblEstatusBrowser.TabIndex = 0;
            this.lblEstatusBrowser.Text = "Estatus del navegador";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 501);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descarga de Cfdi SAT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panWebBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDatosContribuyente)).EndInit();
            this.panDatosContribuyente.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazonSocial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTipoCfdiDescarga.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDatosGuardado)).EndInit();
            this.panDatosGuardado.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaPrincipal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panRutaDisponible.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgrPorcentajeCargaBrowser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panWebBrowser;
        private DevExpress.XtraEditors.GroupControl panDatosContribuyente;
        private DevExpress.XtraEditors.GroupControl panDatosGuardado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl lblRFC;
        private DevExpress.XtraEditors.LabelControl lblRazonSocial;
        private DevExpress.XtraEditors.LabelControl lblCfdiADescargar;
        private DevExpress.XtraEditors.MemoEdit txtRazonSocial;
        private DevExpress.XtraEditors.TextEdit txtRFC;
        private DevExpress.XtraEditors.RadioGroup rdgTipoCfdiDescarga;
        private DevExpress.XtraEditors.SimpleButton btnDescargarCfdi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.LabelControl lblRutaGuardado;
        private DevExpress.XtraEditors.ButtonEdit txtRutaPrincipal;
        private DevExpress.XtraEditors.SimpleButton btnRutaRFCEmisor;
        private System.Windows.Forms.FlowLayoutPanel panRutaDisponible;
        private System.Windows.Forms.FlowLayoutPanel panRutaAgregada;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRFCReceptor;
        private DevExpress.XtraEditors.SimpleButton btnAnio;
        private DevExpress.XtraEditors.SimpleButton btnMes;
        private DevExpress.XtraEditors.SimpleButton btnSerieFolio;
        private DevExpress.XtraEditors.SimpleButton btnUUID;
        private DevExpress.XtraEditors.SimpleButton btnOrganizaDatos;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.ProgressBarControl pgrPorcentajeCargaBrowser;
        private DevExpress.XtraEditors.LabelControl lblEstatusBrowser;
    }
}

