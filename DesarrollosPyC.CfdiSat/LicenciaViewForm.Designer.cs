namespace DesarrollosPyC.CfdiSat
{
    partial class LicenciaViewForm
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
            this.panCerrar = new DevExpress.XtraEditors.PanelControl();
            this.btnCerrar = new DevExpress.XtraEditors.SimpleButton();
            this.webViewer = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.panCerrar)).BeginInit();
            this.panCerrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCerrar
            // 
            this.panCerrar.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panCerrar.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.panCerrar.Appearance.Options.UseBackColor = true;
            this.panCerrar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panCerrar.Controls.Add(this.btnCerrar);
            this.panCerrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panCerrar.Location = new System.Drawing.Point(0, 226);
            this.panCerrar.Name = "panCerrar";
            this.panCerrar.Size = new System.Drawing.Size(387, 45);
            this.panCerrar.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(91, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(205, 28);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // webViewer
            // 
            this.webViewer.AllowNavigation = false;
            this.webViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewer.Location = new System.Drawing.Point(0, 0);
            this.webViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.webViewer.Name = "webViewer";
            this.webViewer.ScrollBarsEnabled = false;
            this.webViewer.Size = new System.Drawing.Size(387, 226);
            this.webViewer.TabIndex = 1;
            // 
            // LicenciaViewForm
            // 
            this.AcceptButton = this.btnCerrar;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(387, 271);
            this.ControlBox = false;
            this.Controls.Add(this.webViewer);
            this.Controls.Add(this.panCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LicenciaViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.LicenciaViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panCerrar)).EndInit();
            this.panCerrar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panCerrar;
        private DevExpress.XtraEditors.SimpleButton btnCerrar;
        private System.Windows.Forms.WebBrowser webViewer;
    }
}