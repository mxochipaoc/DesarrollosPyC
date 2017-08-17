using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrollosPyC.AnalisisCfdiSat.Documents
{
    /// <summary>
    /// Previsualización de CFDi
    /// </summary>
    public partial class ComprobanteReportViewForm : BaseViewReportForm
    {
        /// <summary>
        /// Cosntructor de la clase
        /// </summary>
        public ComprobanteReportViewForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Comprobante 
        /// </summary>
        public object Cfdi { get; set; }

        /// <summary>
        /// Genera documento
        /// </summary>
        protected override void RefreshReportView()
        {
            DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante cfdi32 = Cfdi as DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante;
            DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante cfdi33 =  Cfdi as DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante;

            if (cfdi32 != null)
            {
                var nomina11 = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaNomina11(cfdi32);
                var nomina12 = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaNomina12(cfdi32);

                if (nomina11 != null)
                {
                    var report = Helper_ComprobantesReport.GeneraReciboNomina11Report(cfdi32, nomina11);
                    ReportViewer.PrintingSystem = report.PrintingSystem;
                }
                else if (nomina12 != null)
                {
                    var report = Helper_ComprobantesReport.GeneraReciboNomina12Report(cfdi32, nomina12);
                    ReportViewer.PrintingSystem = report.PrintingSystem;
                }
                else
                {
                    var report = Helper_ComprobantesReport.GeneraComprobanteReport(cfdi32);
                    ReportViewer.PrintingSystem = report.PrintingSystem;
                }
            }

            if (cfdi33 != null)
            {
                var nomina12 = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaNomina12(cfdi33);

                if (nomina12 != null)
                {
                    var report = Helper_ComprobantesReport.GeneraReciboNomina12Report(cfdi33, nomina12);
                    ReportViewer.PrintingSystem = report.PrintingSystem;
                }
                else
                {
                    var report = Helper_ComprobantesReport.GeneraComprobanteReport(cfdi33);
                    ReportViewer.PrintingSystem = report.PrintingSystem;
                }
            }
        }
    }
}
