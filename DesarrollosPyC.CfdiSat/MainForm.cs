using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.CfdiSat
{
    /// <summary>
    /// Formulario de apertura de aplicaciones de análisis de Cfdi
    /// </summary>
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            DevExpress.UserSkins.BonusSkins.Register();
            tniLoockAndFeel.SubItems.Clear();
            DevExpress.Skins.SkinContainerCollection skins = DevExpress.Skins.SkinManager.Default.Skins;
            for (int i = 0; i < skins.Count; i++)
            {
                var sk = new DevExpress.XtraBars.Navigation.TileNavSubItem()
                {
                    Alignment= DevExpress.XtraBars.Navigation.NavButtonAlignment.Default,
                    Caption= skins[i].SkinName,
                    TileText= skins[i].SkinName,
                    Name= skins[i].SkinName,
                    GroupName ="Skins"
                };
                
                sk.Tile.Elements.Add(new DevExpress.XtraEditors.TileItemElement()
                {
                    Image = DevExpress.Skins.SkinCollectionHelper.GetSkinIcon(skins[i].SkinName, DevExpress.Skins.SkinIconsSize.Small),
                });
                //sk.Tile.DropDownOptions.BeakColor = skins[i].CommonSkin.BaseColor;
                sk.ElementClick += (s, e) =>
                 {
                     DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = e.Element.Name;
                 };
                tniLoockAndFeel.SubItems.Add(sk);
            }
        }
                       
        /// <summary>
        /// Ejecución durante el cierre del formulario
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CefSharp.Cef.Shutdown();
        }

        /// <summary>
        /// Selección de elemento en menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tnpMenu_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (e.Element == tniDescargaMasiva)
            {
                var form = this.MdiChildren.Where(i => i is DesarrollosPyC.DescargaCfdiSat.MainForm).FirstOrDefault();
                if (form == null)
                {
                    form = new DesarrollosPyC.DescargaCfdiSat.MainForm();
                    form.MdiParent = this;
                    form.Show();
                }
                else
                    form.Focus();
            }
            if (e.Element == tniAnalisis)
            {
                var form = this.MdiChildren.Where(i => i is DesarrollosPyC.AnalisisCfdiSat.MainForm).FirstOrDefault();
                if (form == null)
                {
                    form = new DesarrollosPyC.AnalisisCfdiSat.MainForm();
                    form.MdiParent = this;
                    form.Show();
                }
                else
                    form.Focus();
            }
        }
    }
}
