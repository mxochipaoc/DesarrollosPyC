using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.DescargaCfdiSat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainForm();
            form.FormClosing += (s, e) =>
            {
                CefSharp.Cef.Shutdown();
            };
            Application.Run(form);
        }
    }
}
