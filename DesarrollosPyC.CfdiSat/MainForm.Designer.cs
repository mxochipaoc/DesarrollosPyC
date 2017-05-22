namespace DesarrollosPyC.CfdiSat
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nvgCfdiSat = new DevExpress.XtraNavBar.NavBarGroup();
            this.nvbDescargaMasiva = new DevExpress.XtraNavBar.NavBarItem();
            this.nvbAnalisis = new DevExpress.XtraNavBar.NavBarItem();
            this.nvgLicencias = new DevExpress.XtraNavBar.NavBarGroup();
            this.nvgSistema = new DevExpress.XtraNavBar.NavBarGroup();
            this.nvvbLookAndFeel = new DevExpress.XtraNavBar.NavBarItem();
            this.nvbAcercaDe = new DevExpress.XtraNavBar.NavBarItem();
            this.tabMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.nvgCfdiSat;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nvgCfdiSat,
            this.nvgLicencias,
            this.nvgSistema});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nvbDescargaMasiva,
            this.nvbAnalisis,
            this.nvvbLookAndFeel,
            this.nvbAcercaDe});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 147;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl1.Size = new System.Drawing.Size(147, 492);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navMenuPrincipal";
            // 
            // nvgCfdiSat
            // 
            this.nvgCfdiSat.Caption = "Cfdis";
            this.nvgCfdiSat.Expanded = true;
            this.nvgCfdiSat.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.nvgCfdiSat.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvbDescargaMasiva),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvbAnalisis)});
            this.nvgCfdiSat.LargeImage = global::DesarrollosPyC.CfdiSat.Properties.Resources.Xml_tool;
            this.nvgCfdiSat.Name = "nvgCfdiSat";
            this.nvgCfdiSat.ShowIcons = DevExpress.Utils.DefaultBoolean.True;
            // 
            // nvbDescargaMasiva
            // 
            this.nvbDescargaMasiva.Caption = "Descaga Cfdi";
            this.nvbDescargaMasiva.LargeImage = global::DesarrollosPyC.CfdiSat.Properties.Resources.Save;
            this.nvbDescargaMasiva.Name = "nvbDescargaMasiva";
            this.nvbDescargaMasiva.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvbDescargaMasiva_LinkClicked);
            // 
            // nvbAnalisis
            // 
            this.nvbAnalisis.Caption = "Análisis Cfdi";
            this.nvbAnalisis.LargeImage = global::DesarrollosPyC.CfdiSat.Properties.Resources.xlsx_16x16;
            this.nvbAnalisis.Name = "nvbAnalisis";
            this.nvbAnalisis.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvbAnalisis_LinkClicked);
            // 
            // nvgLicencias
            // 
            this.nvgLicencias.Caption = "Licencias";
            this.nvgLicencias.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nvgLicencias.LargeImage = global::DesarrollosPyC.CfdiSat.Properties.Resources.tickets;
            this.nvgLicencias.Name = "nvgLicencias";
            // 
            // nvgSistema
            // 
            this.nvgSistema.Caption = "Sistema";
            this.nvgSistema.Expanded = true;
            this.nvgSistema.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
            this.nvgSistema.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvvbLookAndFeel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvbAcercaDe)});
            this.nvgSistema.LargeImage = global::DesarrollosPyC.CfdiSat.Properties.Resources.Wizard;
            this.nvgSistema.Name = "nvgSistema";
            // 
            // nvvbLookAndFeel
            // 
            this.nvvbLookAndFeel.Caption = "Look & Feel";
            this.nvvbLookAndFeel.LargeImage = global::DesarrollosPyC.CfdiSat.Properties.Resources.Themes;
            this.nvvbLookAndFeel.Name = "nvvbLookAndFeel";
            // 
            // nvbAcercaDe
            // 
            this.nvbAcercaDe.Caption = "Acerca de";
            this.nvbAcercaDe.LargeImage = global::DesarrollosPyC.CfdiSat.Properties.Resources.Bulb;
            this.nvbAcercaDe.Name = "nvbAcercaDe";
            // 
            // tabMdiManager
            // 
            this.tabMdiManager.MdiParent = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 492);
            this.Controls.Add(this.navBarControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Descarga masiva y análisis de Cfdi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup nvgCfdiSat;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdiManager;
        private DevExpress.XtraNavBar.NavBarGroup nvgLicencias;
        private DevExpress.XtraNavBar.NavBarItem nvbDescargaMasiva;
        private DevExpress.XtraNavBar.NavBarItem nvbAnalisis;
        private DevExpress.XtraNavBar.NavBarGroup nvgSistema;
        private DevExpress.XtraNavBar.NavBarItem nvvbLookAndFeel;
        private DevExpress.XtraNavBar.NavBarItem nvbAcercaDe;
    }
}

