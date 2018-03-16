namespace DesarrollosPyC.Com.Controles
{
    partial class BarraProgresoForm
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
            this.Timer = new System.Windows.Forms.Timer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imgLoading = new DevExpress.XtraEditors.PictureEdit();
            this.lblTiempo = new DevExpress.XtraEditors.LabelControl();
            this.lknCancelar = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.lknVerMasDetalles = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.imgLoading, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTiempo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lknCancelar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblEncabezado, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEstatus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lknVerMasDetalles, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 146);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // imgLoading
            // 
            this.imgLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLoading.EditValue = global::DesarrollosPyC.Com.Controles.Properties.Resources.loading_circulo2;
            this.imgLoading.Location = new System.Drawing.Point(0, 0);
            this.imgLoading.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.imgLoading.Properties.Appearance.Options.UseBackColor = true;
            this.imgLoading.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imgLoading.Properties.ReadOnly = true;
            this.imgLoading.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgLoading.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.imgLoading.Properties.ZoomAccelerationFactor = 1D;
            this.tableLayoutPanel1.SetRowSpan(this.imgLoading, 4);
            this.imgLoading.Size = new System.Drawing.Size(146, 146);
            this.imgLoading.TabIndex = 0;
            // 
            // lblTiempo
            // 
            this.lblTiempo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTiempo.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.lblTiempo.Location = new System.Drawing.Point(149, 129);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(42, 14);
            this.lblTiempo.TabIndex = 2;
            this.lblTiempo.Text = "00:00:00";
            // 
            // lknCancelar
            // 
            this.lknCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lknCancelar.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.lknCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lknCancelar.Location = new System.Drawing.Point(337, 129);
            this.lknCancelar.Name = "lknCancelar";
            this.lknCancelar.Size = new System.Drawing.Size(44, 14);
            this.lknCancelar.TabIndex = 3;
            this.lknCancelar.Text = "Cancelar";
            this.lknCancelar.Click += new System.EventHandler(this.lknCancelar_Click);
            // 
            // lblEncabezado
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblEncabezado, 2);
            this.lblEncabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEncabezado.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblEncabezado.Location = new System.Drawing.Point(149, 0);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(232, 30);
            this.lblEncabezado.TabIndex = 4;
            this.lblEncabezado.Text = "Cargando datos";
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblEstatus, 2);
            this.lblEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstatus.Location = new System.Drawing.Point(149, 30);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(232, 76);
            this.lblEstatus.TabIndex = 5;
            this.lblEstatus.Text = "Espere mientras la operación termina";
            // 
            // lknVerMasDetalles
            // 
            this.lknVerMasDetalles.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lknVerMasDetalles.Appearance.Font = new System.Drawing.Font("Arial", 8F);
            this.lknVerMasDetalles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lknVerMasDetalles.Location = new System.Drawing.Point(300, 109);
            this.lknVerMasDetalles.Name = "lknVerMasDetalles";
            this.lknVerMasDetalles.Size = new System.Drawing.Size(81, 14);
            this.lknVerMasDetalles.TabIndex = 6;
            this.lknVerMasDetalles.Text = "Ver mas detalles";
            this.lknVerMasDetalles.Visible = false;
            this.lknVerMasDetalles.Click += new System.EventHandler(this.lknVerMasDetalles_Click);
            // 
            // BarraProgresoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 146);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarraProgresoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BarraProgresoForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PictureEdit imgLoading;
        private DevExpress.XtraEditors.LabelControl lblTiempo;
        private DevExpress.XtraEditors.HyperlinkLabelControl lknCancelar;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Label lblEstatus;
        private DevExpress.XtraEditors.HyperlinkLabelControl lknVerMasDetalles;
    }
}