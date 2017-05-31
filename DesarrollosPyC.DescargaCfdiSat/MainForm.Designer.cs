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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panWebBrowser = new DevExpress.XtraEditors.PanelControl();
            this.pgpCargaDatos = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panDatosContribuyente = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRFC = new DevExpress.XtraEditors.LabelControl();
            this.lblRazonSocial = new DevExpress.XtraEditors.LabelControl();
            this.txtRFC = new DevExpress.XtraEditors.TextEdit();
            this.btnDescargarCfdi = new DevExpress.XtraEditors.SimpleButton();
            this.lkpRazonSocial = new DevExpress.XtraEditors.LookUpEdit();
            this.panDatosGuardado = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOrganizaDatos = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panRutaAgregada = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRutaGuardado = new DevExpress.XtraEditors.LabelControl();
            this.txtRutaPrincipal = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panRutaDisponible = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRutaAnio = new DevExpress.XtraEditors.SimpleButton();
            this.btnRutaMes = new DevExpress.XtraEditors.SimpleButton();
            this.btnRutaRFCEmisor = new DevExpress.XtraEditors.SimpleButton();
            this.btnRutaRFCReceptor = new DevExpress.XtraEditors.SimpleButton();
            this.btnSerieFolio = new DevExpress.XtraEditors.SimpleButton();
            this.btnUUID = new DevExpress.XtraEditors.SimpleButton();
            this.panEstatusGeneral = new DevExpress.XtraEditors.PanelControl();
            this.lblEstatusGeneral = new DevExpress.XtraEditors.LabelControl();
            this.tmrTemporizador = new System.Windows.Forms.Timer(this.components);
            this.DefaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panWebBrowser)).BeginInit();
            this.panWebBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panDatosContribuyente)).BeginInit();
            this.panDatosContribuyente.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpRazonSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDatosGuardado)).BeginInit();
            this.panDatosGuardado.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaPrincipal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panRutaDisponible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panEstatusGeneral)).BeginInit();
            this.panEstatusGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.panWebBrowser, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panDatosContribuyente, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panDatosGuardado, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panEstatusGeneral, 1, 3);
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
            this.panWebBrowser.Controls.Add(this.pgpCargaDatos);
            this.panWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panWebBrowser.Location = new System.Drawing.Point(8, 138);
            this.panWebBrowser.Name = "panWebBrowser";
            this.panWebBrowser.Size = new System.Drawing.Size(960, 330);
            this.panWebBrowser.TabIndex = 0;
            // 
            // pgpCargaDatos
            // 
            this.pgpCargaDatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgpCargaDatos.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.pgpCargaDatos.Appearance.Options.UseBackColor = true;
            this.pgpCargaDatos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.pgpCargaDatos.Caption = "Procesando información";
            this.pgpCargaDatos.Description = "Espere por favor ...";
            this.pgpCargaDatos.Location = new System.Drawing.Point(338, 112);
            this.pgpCargaDatos.Name = "pgpCargaDatos";
            this.pgpCargaDatos.Padding = new System.Windows.Forms.Padding(3);
            this.pgpCargaDatos.Size = new System.Drawing.Size(284, 89);
            this.pgpCargaDatos.TabIndex = 0;
            this.pgpCargaDatos.UseWaitCursor = true;
            this.pgpCargaDatos.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Line;
            // 
            // panDatosContribuyente
            // 
            this.panDatosContribuyente.Controls.Add(this.tableLayoutPanel2);
            this.panDatosContribuyente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDatosContribuyente.Location = new System.Drawing.Point(8, 8);
            this.panDatosContribuyente.Name = "panDatosContribuyente";
            this.panDatosContribuyente.Size = new System.Drawing.Size(332, 124);
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.Controls.Add(this.lblRFC, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblRazonSocial, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRFC, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnDescargarCfdi, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.lkpRazonSocial, 2, 1);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(328, 102);
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
            // txtRFC
            // 
            this.txtRFC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRFC.EditValue = "";
            this.txtRFC.Location = new System.Drawing.Point(84, 47);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.txtRFC.Properties.Appearance.Options.UseFont = true;
            this.txtRFC.Properties.AutoHeight = false;
            this.txtRFC.Properties.Mask.EditMask = "[A-Z&]{3,4}[0-9]{6}[A-Z0-9]{3}";
            this.txtRFC.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRFC.Properties.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.txtRFC, 2);
            this.txtRFC.Size = new System.Drawing.Size(171, 46);
            this.txtRFC.TabIndex = 4;
            // 
            // btnDescargarCfdi
            // 
            this.btnDescargarCfdi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDescargarCfdi.Image = global::DesarrollosPyC.DescargaCfdiSat.Properties.Resources.Save;
            this.btnDescargarCfdi.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDescargarCfdi.Location = new System.Drawing.Point(266, 47);
            this.btnDescargarCfdi.Name = "btnDescargarCfdi";
            this.tableLayoutPanel2.SetRowSpan(this.btnDescargarCfdi, 2);
            this.btnDescargarCfdi.Size = new System.Drawing.Size(46, 46);
            this.btnDescargarCfdi.TabIndex = 6;
            this.btnDescargarCfdi.Click += new System.EventHandler(this.btnDescargarCfdi_Click);
            // 
            // lkpRazonSocial
            // 
            this.lkpRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.lkpRazonSocial, 3);
            this.lkpRazonSocial.Location = new System.Drawing.Point(84, 8);
            this.lkpRazonSocial.Name = "lkpRazonSocial";
            this.lkpRazonSocial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.lkpRazonSocial.Properties.Appearance.Options.UseFont = true;
            this.lkpRazonSocial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpRazonSocial.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Receptor.Rfc", 100, "RFC"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Receptor.RazonSocial", 300, "Razón social")});
            this.lkpRazonSocial.Properties.DisplayMember = "Receptor.RazonSocial";
            this.lkpRazonSocial.Properties.NullText = "";
            this.lkpRazonSocial.Properties.PopupWidth = 400;
            this.lkpRazonSocial.Properties.ShowHeader = false;
            this.lkpRazonSocial.Properties.ValueMember = "Receptor.Rfc";
            this.tableLayoutPanel2.SetRowSpan(this.lkpRazonSocial, 2);
            this.lkpRazonSocial.Size = new System.Drawing.Size(228, 28);
            this.lkpRazonSocial.TabIndex = 3;
            this.lkpRazonSocial.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.lkpRazonSocial_EditValueChanging);
            // 
            // panDatosGuardado
            // 
            this.panDatosGuardado.Controls.Add(this.tableLayoutPanel3);
            this.panDatosGuardado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDatosGuardado.Location = new System.Drawing.Point(346, 8);
            this.panDatosGuardado.Name = "panDatosGuardado";
            this.panDatosGuardado.Size = new System.Drawing.Size(622, 124);
            this.panDatosGuardado.TabIndex = 2;
            this.panDatosGuardado.Text = "Datos de guardado de Cfdi descargados";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(618, 102);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnOrganizaDatos
            // 
            this.btnOrganizaDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrganizaDatos.Image = global::DesarrollosPyC.DescargaCfdiSat.Properties.Resources.Content_reorder;
            this.btnOrganizaDatos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOrganizaDatos.Location = new System.Drawing.Point(558, 47);
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
            this.panelControl2.Location = new System.Drawing.Point(284, 45);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(1);
            this.panelControl2.Name = "panelControl2";
            this.tableLayoutPanel3.SetRowSpan(this.panelControl2, 2);
            this.panelControl2.Size = new System.Drawing.Size(265, 50);
            this.panelControl2.TabIndex = 7;
            // 
            // panRutaAgregada
            // 
            this.panRutaAgregada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRutaAgregada.Location = new System.Drawing.Point(2, 2);
            this.panRutaAgregada.Name = "panRutaAgregada";
            this.panRutaAgregada.Size = new System.Drawing.Size(261, 46);
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
            this.txtRutaPrincipal.Location = new System.Drawing.Point(108, 47);
            this.txtRutaPrincipal.Name = "txtRutaPrincipal";
            this.txtRutaPrincipal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtRutaPrincipal.Properties.ReadOnly = true;
            this.txtRutaPrincipal.Size = new System.Drawing.Size(172, 20);
            this.txtRutaPrincipal.TabIndex = 4;
            this.txtRutaPrincipal.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtRutaPrincipal_ButtonClick);
            // 
            // panelControl1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.panelControl1, 4);
            this.panelControl1.Controls.Add(this.panRutaDisponible);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(106, 6);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(500, 32);
            this.panelControl1.TabIndex = 5;
            // 
            // panRutaDisponible
            // 
            this.panRutaDisponible.Controls.Add(this.btnRutaAnio);
            this.panRutaDisponible.Controls.Add(this.btnRutaMes);
            this.panRutaDisponible.Controls.Add(this.btnRutaRFCEmisor);
            this.panRutaDisponible.Controls.Add(this.btnRutaRFCReceptor);
            this.panRutaDisponible.Controls.Add(this.btnSerieFolio);
            this.panRutaDisponible.Controls.Add(this.btnUUID);
            this.panRutaDisponible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRutaDisponible.Location = new System.Drawing.Point(2, 2);
            this.panRutaDisponible.Name = "panRutaDisponible";
            this.panRutaDisponible.Size = new System.Drawing.Size(496, 28);
            this.panRutaDisponible.TabIndex = 5;
            // 
            // btnRutaAnio
            // 
            this.btnRutaAnio.Image = ((System.Drawing.Image)(resources.GetObject("btnRutaAnio.Image")));
            this.btnRutaAnio.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRutaAnio.Location = new System.Drawing.Point(3, 3);
            this.btnRutaAnio.Name = "btnRutaAnio";
            this.btnRutaAnio.Size = new System.Drawing.Size(62, 23);
            this.btnRutaAnio.TabIndex = 2;
            this.btnRutaAnio.Text = "Año";
            this.btnRutaAnio.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnRutaMes
            // 
            this.btnRutaMes.Image = ((System.Drawing.Image)(resources.GetObject("btnRutaMes.Image")));
            this.btnRutaMes.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRutaMes.Location = new System.Drawing.Point(71, 3);
            this.btnRutaMes.Name = "btnRutaMes";
            this.btnRutaMes.Size = new System.Drawing.Size(62, 23);
            this.btnRutaMes.TabIndex = 3;
            this.btnRutaMes.Text = "Mes";
            this.btnRutaMes.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnRutaRFCEmisor
            // 
            this.btnRutaRFCEmisor.Image = ((System.Drawing.Image)(resources.GetObject("btnRutaRFCEmisor.Image")));
            this.btnRutaRFCEmisor.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRutaRFCEmisor.Location = new System.Drawing.Point(139, 3);
            this.btnRutaRFCEmisor.Name = "btnRutaRFCEmisor";
            this.btnRutaRFCEmisor.Size = new System.Drawing.Size(88, 23);
            this.btnRutaRFCEmisor.TabIndex = 0;
            this.btnRutaRFCEmisor.Text = "Rfc emisor";
            this.btnRutaRFCEmisor.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnRutaRFCReceptor
            // 
            this.btnRutaRFCReceptor.Image = ((System.Drawing.Image)(resources.GetObject("btnRutaRFCReceptor.Image")));
            this.btnRutaRFCReceptor.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnRutaRFCReceptor.Location = new System.Drawing.Point(233, 3);
            this.btnRutaRFCReceptor.Name = "btnRutaRFCReceptor";
            this.btnRutaRFCReceptor.Size = new System.Drawing.Size(88, 23);
            this.btnRutaRFCReceptor.TabIndex = 1;
            this.btnRutaRFCReceptor.Text = "Rfc receptor";
            this.btnRutaRFCReceptor.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnSerieFolio
            // 
            this.btnSerieFolio.Image = ((System.Drawing.Image)(resources.GetObject("btnSerieFolio.Image")));
            this.btnSerieFolio.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSerieFolio.Location = new System.Drawing.Point(327, 3);
            this.btnSerieFolio.Name = "btnSerieFolio";
            this.btnSerieFolio.Size = new System.Drawing.Size(75, 23);
            this.btnSerieFolio.TabIndex = 4;
            this.btnSerieFolio.Text = "Serie-folio";
            this.btnSerieFolio.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // btnUUID
            // 
            this.btnUUID.Image = ((System.Drawing.Image)(resources.GetObject("btnUUID.Image")));
            this.btnUUID.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnUUID.Location = new System.Drawing.Point(408, 3);
            this.btnUUID.Name = "btnUUID";
            this.btnUUID.Size = new System.Drawing.Size(75, 23);
            this.btnUUID.TabIndex = 5;
            this.btnUUID.Text = "UUID";
            this.btnUUID.DoubleClick += new System.EventHandler(this.btnBotonRuta_DoubleClick);
            // 
            // panEstatusGeneral
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panEstatusGeneral, 2);
            this.panEstatusGeneral.Controls.Add(this.lblEstatusGeneral);
            this.panEstatusGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panEstatusGeneral.Location = new System.Drawing.Point(8, 474);
            this.panEstatusGeneral.Name = "panEstatusGeneral";
            this.panEstatusGeneral.Size = new System.Drawing.Size(960, 19);
            this.panEstatusGeneral.TabIndex = 3;
            // 
            // lblEstatusGeneral
            // 
            this.lblEstatusGeneral.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEstatusGeneral.Location = new System.Drawing.Point(8, 3);
            this.lblEstatusGeneral.Name = "lblEstatusGeneral";
            this.lblEstatusGeneral.Size = new System.Drawing.Size(4, 13);
            this.lblEstatusGeneral.TabIndex = 0;
            this.lblEstatusGeneral.Text = ".";
            // 
            // tmrTemporizador
            // 
            this.tmrTemporizador.Enabled = true;
            this.tmrTemporizador.Tick += new System.EventHandler(this.tmrTemporizador_Tick);
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
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panWebBrowser)).EndInit();
            this.panWebBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panDatosContribuyente)).EndInit();
            this.panDatosContribuyente.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpRazonSocial.Properties)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.panEstatusGeneral)).EndInit();
            this.panEstatusGeneral.ResumeLayout(false);
            this.panEstatusGeneral.PerformLayout();
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
        private DevExpress.XtraEditors.TextEdit txtRFC;
        private DevExpress.XtraEditors.SimpleButton btnDescargarCfdi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.LabelControl lblRutaGuardado;
        private DevExpress.XtraEditors.ButtonEdit txtRutaPrincipal;
        private DevExpress.XtraEditors.SimpleButton btnRutaRFCEmisor;
        private System.Windows.Forms.FlowLayoutPanel panRutaDisponible;
        private System.Windows.Forms.FlowLayoutPanel panRutaAgregada;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRutaRFCReceptor;
        private DevExpress.XtraEditors.SimpleButton btnRutaAnio;
        private DevExpress.XtraEditors.SimpleButton btnRutaMes;
        private DevExpress.XtraEditors.SimpleButton btnSerieFolio;
        private DevExpress.XtraEditors.SimpleButton btnUUID;
        private DevExpress.XtraEditors.SimpleButton btnOrganizaDatos;
        private DevExpress.XtraWaitForm.ProgressPanel pgpCargaDatos;
        private System.Windows.Forms.Timer tmrTemporizador;
        private DevExpress.XtraEditors.PanelControl panEstatusGeneral;
        private DevExpress.XtraEditors.LabelControl lblEstatusGeneral;
        private DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel;
        private DevExpress.XtraEditors.LookUpEdit lkpRazonSocial;
    }
}

