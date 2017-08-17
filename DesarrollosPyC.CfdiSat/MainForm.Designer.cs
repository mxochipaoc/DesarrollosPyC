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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DefaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.tnpMenu = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.tncAplicacionesCFDi = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.tniDescargaMasiva = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniAnalisis = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tlnLicencias = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.tlnSistema = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.tniAcercaDe = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tniLoockAndFeel = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.tileNavSubItem1 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tnpMenu
            // 
            this.tnpMenu.ButtonPadding = new System.Windows.Forms.Padding(12);
            this.tnpMenu.Buttons.Add(this.tncAplicacionesCFDi);
            this.tnpMenu.Buttons.Add(this.tlnLicencias);
            this.tnpMenu.Buttons.Add(this.tlnSistema);
            // 
            // tileNavCategory1
            // 
            this.tnpMenu.DefaultCategory.Name = "tileNavCategory1";
            this.tnpMenu.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tnpMenu.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tnpMenu.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tnpMenu.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tnpMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tnpMenu.Location = new System.Drawing.Point(0, 0);
            this.tnpMenu.Name = "tnpMenu";
            this.tnpMenu.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tnpMenu.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tnpMenu.Size = new System.Drawing.Size(852, 43);
            this.tnpMenu.TabIndex = 0;
            this.tnpMenu.Text = "tileNavPane1";
            this.tnpMenu.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.tnpMenu_ElementClick);
            // 
            // tncAplicacionesCFDi
            // 
            this.tncAplicacionesCFDi.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.tncAplicacionesCFDi.Caption = "Aplicaciones de Cfdi";
            this.tncAplicacionesCFDi.Glyph = global::DesarrollosPyC.CfdiSat.Properties.Resources.Xml_tool;
            this.tncAplicacionesCFDi.GroupName = "";
            // 
            // tniDescargaMasiva
            // 
            this.tniDescargaMasiva.Caption = "Descarga masiva";
            this.tniDescargaMasiva.Name = "tniDescargaMasiva";
            this.tniDescargaMasiva.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniDescargaMasiva.OwnerCollection = this.tncAplicacionesCFDi.Items;
            // 
            // 
            // 
            this.tniDescargaMasiva.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Image = global::DesarrollosPyC.CfdiSat.Properties.Resources.Save;
            tileItemElement1.Text = "Descarga masiva";
            this.tniDescargaMasiva.Tile.Elements.Add(tileItemElement1);
            this.tniDescargaMasiva.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniDescargaMasiva.Tile.Name = "tileBarItem1";
            this.tncAplicacionesCFDi.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.tniDescargaMasiva,
            this.tniAnalisis});
            this.tncAplicacionesCFDi.Name = "tncAplicacionesCFDi";
            this.tncAplicacionesCFDi.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tncAplicacionesCFDi.OwnerCollection = null;
            // 
            // 
            // 
            this.tncAplicacionesCFDi.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            this.tncAplicacionesCFDi.Tile.Elements.Add(tileItemElement3);
            this.tncAplicacionesCFDi.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // tniAnalisis
            // 
            this.tniAnalisis.Caption = "Análisis Cfdi";
            this.tniAnalisis.Name = "tniAnalisis";
            this.tniAnalisis.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniAnalisis.OwnerCollection = this.tncAplicacionesCFDi.Items;
            // 
            // 
            // 
            this.tniAnalisis.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Image = global::DesarrollosPyC.CfdiSat.Properties.Resources.xlsx_24x24;
            tileItemElement2.Text = "Análisis Cfdi";
            this.tniAnalisis.Tile.Elements.Add(tileItemElement2);
            this.tniAnalisis.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniAnalisis.Tile.Name = "tileBarItem2";
            // 
            // tlnLicencias
            // 
            this.tlnLicencias.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.tlnLicencias.Caption = "Licencias";
            this.tlnLicencias.Glyph = global::DesarrollosPyC.CfdiSat.Properties.Resources.tickets;
            this.tlnLicencias.Name = "tlnLicencias";
            this.tlnLicencias.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tlnLicencias.OwnerCollection = null;
            // 
            // 
            // 
            this.tlnLicencias.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tlnLicencias.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // tlnSistema
            // 
            this.tlnSistema.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.tlnSistema.Caption = "Sistema";
            this.tlnSistema.Glyph = global::DesarrollosPyC.CfdiSat.Properties.Resources.Computer;
            this.tlnSistema.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.tniAcercaDe,
            this.tniLoockAndFeel});
            this.tlnSistema.Name = "tlnSistema";
            this.tlnSistema.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tlnSistema.OwnerCollection = null;
            // 
            // 
            // 
            this.tlnSistema.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tlnSistema.Tile.Elements.Add(tileItemElement6);
            this.tlnSistema.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // tniAcercaDe
            // 
            this.tniAcercaDe.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.tniAcercaDe.Caption = "Acerca de";
            this.tniAcercaDe.Name = "tniAcercaDe";
            this.tniAcercaDe.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniAcercaDe.OwnerCollection = this.tlnSistema.Items;
            // 
            // 
            // 
            this.tniAcercaDe.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.Image = global::DesarrollosPyC.CfdiSat.Properties.Resources.Glossary;
            tileItemElement4.Text = "Acerca de";
            this.tniAcercaDe.Tile.Elements.Add(tileItemElement4);
            this.tniAcercaDe.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniAcercaDe.Tile.Name = "tileBarItem1";
            // 
            // tniLoockAndFeel
            // 
            this.tniLoockAndFeel.Caption = "Loock and feel";
            this.tniLoockAndFeel.Name = "tniLoockAndFeel";
            this.tniLoockAndFeel.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tniLoockAndFeel.OwnerCollection = this.tlnSistema.Items;
            // 
            // 
            // 
            this.tniLoockAndFeel.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.Image = global::DesarrollosPyC.CfdiSat.Properties.Resources.Themes;
            tileItemElement5.Text = "Loock and feel";
            this.tniLoockAndFeel.Tile.Elements.Add(tileItemElement5);
            this.tniLoockAndFeel.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tniLoockAndFeel.Tile.Name = "tileBarItem2";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // tileNavSubItem1
            // 
            this.tileNavSubItem1.Caption = "tileNavSubItem1";
            this.tileNavSubItem1.Name = "tileNavSubItem1";
            this.tileNavSubItem1.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            // 
            // 
            // 
            this.tileNavSubItem1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.Text = "tileNavSubItem1";
            this.tileNavSubItem1.Tile.Elements.Add(tileItemElement7);
            this.tileNavSubItem1.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 492);
            this.Controls.Add(this.tnpMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Descarga masiva y análisis de Cfdi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel;
        private DevExpress.XtraBars.Navigation.TileNavPane tnpMenu;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Navigation.TileNavCategory tncAplicacionesCFDi;
        private DevExpress.XtraBars.Navigation.TileNavCategory tlnLicencias;
        private DevExpress.XtraBars.Navigation.TileNavCategory tlnSistema;
        private DevExpress.XtraBars.Navigation.TileNavItem tniAnalisis;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem1;
        private DevExpress.XtraBars.Navigation.TileNavItem tniLoockAndFeel;
        private DevExpress.XtraBars.Navigation.TileNavItem tniAcercaDe;
        private DevExpress.XtraBars.Navigation.TileNavItem tniDescargaMasiva;
    }
}

