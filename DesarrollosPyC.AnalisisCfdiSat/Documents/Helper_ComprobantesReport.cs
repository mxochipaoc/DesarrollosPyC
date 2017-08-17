using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrollosPyC.AnalisisCfdiSat.Documents
{
    /// <summary>
    /// Clase generadora de los documentos Cfdi impresos
    /// </summary>
    public static class Helper_ComprobantesReport
    {
        #region CFDi 3.2
        /// <summary>
        /// Genera el documento Cfdi impreso
        /// </summary>
        /// <param name="Cfdi">Comprobante</param>
        /// <returns>Documento</returns>
        public static Documents.Reports.ComprobanteReport GeneraComprobanteReport(DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante Cfdi)
        {
            DS.ComprobanteDS ds = new DS.ComprobanteDS();
            DS.ComprobanteDS.ComprobanteRow row = ds.Comprobante.NewComprobanteRow();
            row.ID = 1;
            row.Folio = Cfdi.serie + "-" + Cfdi.folio;
            row.Fecha = Cfdi.fecha;
            row.No_Certificado = Cfdi.noCertificado;
            row.Metodo_Pago = Cfdi.metodoDePago;
            row.Forma_Pago = Cfdi.formaDePago;

            row.Emisor = Cfdi.Emisor.nombre;
            row.Emisor_Rfc = Cfdi.Emisor.rfc;
            row.Emisor_Regimen = Cfdi.Emisor.RegimenFiscal[0].Regimen;

            if (Cfdi.Emisor.DomicilioFiscal != null)
            {
                row.Emisor_Domicilio_Fiscal = (
                    Cfdi.Emisor.DomicilioFiscal.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noExterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noExterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noInterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.localidad) ? "" : Cfdi.Emisor.DomicilioFiscal.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.colonia) ? "" : Cfdi.Emisor.DomicilioFiscal.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.municipio) ? "" : Cfdi.Emisor.DomicilioFiscal.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.estado) ? "" : Cfdi.Emisor.DomicilioFiscal.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.pais) ? "" : Cfdi.Emisor.DomicilioFiscal.pais + ", ")
                    + Cfdi.Emisor.DomicilioFiscal.codigoPostal
                    ).Trim();
            }
            if (Cfdi.Emisor.ExpedidoEn != null)
            {
                row.Emisor_Expedido_En = (
                    Cfdi.Emisor.ExpedidoEn.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noExterior) ? "" : Cfdi.Emisor.ExpedidoEn.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noExterior) ? "" : Cfdi.Emisor.ExpedidoEn.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noInterior) ? "" : Cfdi.Emisor.ExpedidoEn.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.localidad) ? "" : Cfdi.Emisor.ExpedidoEn.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.colonia) ? "" : Cfdi.Emisor.ExpedidoEn.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.municipio) ? "" : Cfdi.Emisor.ExpedidoEn.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.estado) ? "" : Cfdi.Emisor.ExpedidoEn.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.pais) ? "" : Cfdi.Emisor.ExpedidoEn.pais + ", ")
                    + Cfdi.Emisor.ExpedidoEn.codigoPostal
                    ).Trim();
            }

            row.Lugar_Expedicion = Cfdi.LugarExpedicion;

            row.Receptor = Cfdi.Receptor.nombre;
            row.Receptor_Rfc = Cfdi.Receptor.rfc;
            if (Cfdi.Receptor.Domicilio != null)
            {
                row.Receptor_Domicilio_Fiscal = (
                    Cfdi.Receptor.Domicilio.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noExterior) ? "" : Cfdi.Receptor.Domicilio.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noExterior) ? "" : Cfdi.Receptor.Domicilio.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noInterior) ? "" : Cfdi.Receptor.Domicilio.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.localidad) ? "" : Cfdi.Receptor.Domicilio.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.colonia) ? "" : Cfdi.Receptor.Domicilio.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.municipio) ? "" : Cfdi.Receptor.Domicilio.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.estado) ? "" : Cfdi.Receptor.Domicilio.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.pais) ? "" : Cfdi.Receptor.Domicilio.pais + ", ")
                    + Cfdi.Receptor.Domicilio.codigoPostal
                    ).Trim();
            }
            row.NoCuentaPago = Cfdi.NumCtaPago;

            var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(Cfdi);
            row.UUID = timbreFiscal.UUID;
            row.No_Certificado_Sat = timbreFiscal.noCertificadoSAT;
            row.Fecha_Certificacion = timbreFiscal.FechaTimbrado;

            row.Sello_Digital_Cfdi = Cfdi.sello;
            row.Sello_Digital_Sat = timbreFiscal.selloSAT;
            row.Cadena_Original_Certificacion = DesarrollosPyC.Com.Facturacion.CfdiV32Manager.CadenaOriginalTimbreFiscalDigital(Cfdi);
            row.Total_Letra = DesarrollosPyC.Com.Utilidades.NumeroALetra.GeneraNumeroALetra((double)Cfdi.total, Cfdi.Moneda ?? "MXN");

            ds.Comprobante.AddComprobanteRow(row);

            foreach (var item in Cfdi.Conceptos)
            {
                DS.ComprobanteDS.ConceptosRow r = ds.Conceptos.NewConceptosRow();
                r.ID_Comprobante = 1;
                r.ID = ds.Conceptos.Count + 1;
                r.Identificador = item.noIdentificacion;
                r.Descripcion = item.descripcion;
                r.Unidad_Medida = item.unidad;
                r.Cantidad = item.cantidad;
                r.Valor_Unitario = item.valorUnitario;
                r.Importe = item.importe;

                ds.Conceptos.AddConceptosRow(r);
            }

            DS.ComprobanteDS.ImportesRow sub = ds.Importes.NewImportesRow();
            sub.ID_Comprobante = 1;
            sub.ID = ds.Importes.Count + 1;
            sub.Descripcion = "Subtotal";
            sub.Importe = Cfdi.subTotal;
            ds.Importes.AddImportesRow(sub);

            DS.ComprobanteDS.ImportesRow desc = ds.Importes.NewImportesRow();
            desc.ID_Comprobante = 1;
            desc.ID = ds.Importes.Count + 1;
            desc.Descripcion = "Descuento";
            desc.Importe = Cfdi.descuento;
            ds.Importes.AddImportesRow(desc);

            if (Cfdi.Impuestos != null)
            {
                if (Cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in Cfdi.Impuestos.Traslados)
                    {
                        DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                        impuesto.ID_Comprobante = 1;
                        impuesto.ID = ds.Importes.Count + 1;
                        impuesto.Descripcion = imp.impuesto.ToString() + " " + decimal.Round(imp.tasa, 2).ToString() + "%";
                        impuesto.Importe = imp.importe;
                        ds.Importes.AddImportesRow(impuesto);
                    }
                }
                if (Cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in Cfdi.Impuestos.Retenciones)
                    {
                        DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                        impuesto.ID_Comprobante = 1;
                        impuesto.ID = ds.Importes.Count + 1;
                        impuesto.Descripcion = "Ret. " + imp.impuesto.ToString();
                        impuesto.Importe = imp.importe;
                        ds.Importes.AddImportesRow(impuesto);
                    }
                }
            }

            var impLocal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaImpuestosLocales(Cfdi);
            if (impLocal != null)
            {
                foreach (DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales imp in impLocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                {
                    DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                    impuesto.ID_Comprobante = 1;
                    impuesto.ID = ds.Importes.Count + 1;
                    impuesto.Descripcion = imp.ImpLocTrasladado + " " + decimal.Round(imp.TasadeTraslado, 2).ToString() + "%";
                    impuesto.Importe = imp.Importe;
                    ds.Importes.AddImportesRow(impuesto);
                }
                foreach (DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales imp in impLocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                {
                    DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                    impuesto.ID_Comprobante = 1;
                    impuesto.ID = ds.Importes.Count + 1;
                    impuesto.Descripcion = "Ret. " + imp.ImpLocRetenido + " " + decimal.Round(imp.TasadeRetencion, 2).ToString() + "%";
                    impuesto.Importe = imp.Importe;
                    ds.Importes.AddImportesRow(impuesto);
                }
            }

            DS.ComprobanteDS.ImportesRow total = ds.Importes.NewImportesRow();
            total.ID_Comprobante = 1;
            total.ID = ds.Importes.Count + 1;
            total.Descripcion = "Total";
            total.Importe = Cfdi.total;
            ds.Importes.AddImportesRow(total);

            Reports.ComprobanteReport report = new Reports.ComprobanteReport();
            report.DataSource = ds;

            string cbd = string.Format("?re={0}&rr={1}&tt={2:0000000000.000000}&id={3}",
                                    Cfdi.Emisor.rfc,
                                    Cfdi.Receptor.rfc,
                                    Cfdi.total,
                                    timbreFiscal.UUID);
            Gma.QrCodeNet.Encoding.QrEncoder Encoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            Gma.QrCodeNet.Encoding.QrCode Code = Encoder.Encode(cbd);
            System.Drawing.Bitmap TempBMP = new System.Drawing.Bitmap(Code.Matrix.Width, Code.Matrix.Height);
            for (int X = 0; X <= Code.Matrix.Width - 1; X++)
            {
                for (int Y = 0; Y <= Code.Matrix.Height - 1; Y++)
                {
                    if (Code.Matrix[X, Y])
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.Black);
                    else
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.White);
                }
            }
            report.imQR.Image = TempBMP;

            report.CreateDocument();

            return report;
        }

        /// <summary>
        /// Generación de representación impresa de nomina 1.1
        /// </summary>
        /// <param name="cfdi">Comprobante</param>
        /// <param name="nomina">Complemento nómina</param>
        /// <returns>Representación impresa</returns>
        public static Documents.Reports.ReciboNominaReport GeneraReciboNomina11Report(DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante Cfdi, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V11.Nomina nomina)
        {
            DS.ReciboNominaDS ds = new DS.ReciboNominaDS();
            DS.ReciboNominaDS.ComprobanteRow row = ds.Comprobante.NewComprobanteRow();
            row.ID = 1;
            row.Folio = Cfdi.serie + "-" + Cfdi.folio;
            row.Fecha = Cfdi.fecha;
            row.No_Certificado = Cfdi.noCertificado;
            row.Metodo_Pago = Cfdi.metodoDePago;
            row.Forma_Pago = Cfdi.formaDePago;

            row.Emisor = Cfdi.Emisor.nombre;
            row.Emisor_Rfc = Cfdi.Emisor.rfc;
            row.Emisor_Regimen = Cfdi.Emisor.RegimenFiscal[0].Regimen;

            row.Emisor_Registro_Patronal = nomina.RegistroPatronal;

            if (Cfdi.Emisor.DomicilioFiscal != null)
            {
                row.Emisor_Domicilio_Fiscal = (
                    Cfdi.Emisor.DomicilioFiscal.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noExterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noExterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noInterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.localidad) ? "" : Cfdi.Emisor.DomicilioFiscal.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.colonia) ? "" : Cfdi.Emisor.DomicilioFiscal.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.municipio) ? "" : Cfdi.Emisor.DomicilioFiscal.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.estado) ? "" : Cfdi.Emisor.DomicilioFiscal.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.pais) ? "" : Cfdi.Emisor.DomicilioFiscal.pais + ", ")
                    + Cfdi.Emisor.DomicilioFiscal.codigoPostal
                    ).Trim();
            }
            if (Cfdi.Emisor.ExpedidoEn != null)
            {
                row.Emisor_Expedido_En = (
                    Cfdi.Emisor.ExpedidoEn.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noExterior) ? "" : Cfdi.Emisor.ExpedidoEn.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noExterior) ? "" : Cfdi.Emisor.ExpedidoEn.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noInterior) ? "" : Cfdi.Emisor.ExpedidoEn.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.localidad) ? "" : Cfdi.Emisor.ExpedidoEn.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.colonia) ? "" : Cfdi.Emisor.ExpedidoEn.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.municipio) ? "" : Cfdi.Emisor.ExpedidoEn.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.estado) ? "" : Cfdi.Emisor.ExpedidoEn.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.pais) ? "" : Cfdi.Emisor.ExpedidoEn.pais + ", ")
                    + Cfdi.Emisor.ExpedidoEn.codigoPostal
                    ).Trim();
            }

            row.Lugar_Expedicion = Cfdi.LugarExpedicion;

            row.Receptor = Cfdi.Receptor.nombre;
            row.Receptor_Rfc = Cfdi.Receptor.rfc;
            if (Cfdi.Receptor.Domicilio != null)
            {
                row.Receptor_Domicilio_Fiscal = (
                    Cfdi.Receptor.Domicilio.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noExterior) ? "" : Cfdi.Receptor.Domicilio.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noExterior) ? "" : Cfdi.Receptor.Domicilio.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noInterior) ? "" : Cfdi.Receptor.Domicilio.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.localidad) ? "" : Cfdi.Receptor.Domicilio.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.colonia) ? "" : Cfdi.Receptor.Domicilio.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.municipio) ? "" : Cfdi.Receptor.Domicilio.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.estado) ? "" : Cfdi.Receptor.Domicilio.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.pais) ? "" : Cfdi.Receptor.Domicilio.pais + ", ")
                    + Cfdi.Receptor.Domicilio.codigoPostal
                    ).Trim();
            }
            row.NoCuentaPago = Cfdi.NumCtaPago;

            row.Receptor_NoEmplreado = nomina.NumEmpleado;
            row.Receptor_NoSeguridadSocial = nomina.NumSeguridadSocial;
            if (nomina.FechaInicioRelLaboralSpecified)
                row.Receptor_FehraIniciorelLaborales = nomina.FechaInicioRelLaboral;
            if (nomina.AntiguedadSpecified)
                row.Receptor_Antiguedad = nomina.Antiguedad.ToString();
            row.Fecha_InioPago = nomina.FechaInicialPago;
            row.Fecha_TerminoPago = nomina.FechaFinalPago;
            row.Fecha_Pago = nomina.FechaPago;

            //row.Receptor_Curp = nomina.CURP;
            row.Receptor_Departamento = nomina.Departamento;
            row.Receptor_Puesto = nomina.Puesto;
            row.Receptor_RiesgoPuesto = nomina.RiesgoPuesto.ToString();
            row.Receptor_TipoContrato = nomina.TipoContrato;
            row.Receptor_TipoJornada = nomina.TipoJornada;
            row.Receptor_RegimenContratacion = nomina.TipoRegimen.ToString();

            if (nomina.SalarioBaseCotAporSpecified)
                row.Receptor_SalarioBase = nomina.SalarioBaseCotApor;
            if (nomina.SalarioDiarioIntegradoSpecified)
                row.Receptor_SalarioDiario = nomina.SalarioDiarioIntegrado;

            var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(Cfdi);
            row.UUID = timbreFiscal.UUID;
            row.No_Certificado_Sat = timbreFiscal.noCertificadoSAT;
            row.Fecha_Certificacion = timbreFiscal.FechaTimbrado;

            row.Sello_Digital_Cfdi = Cfdi.sello;
            row.Sello_Digital_Sat = timbreFiscal.selloSAT;
            row.Cadena_Original_Certificacion = DesarrollosPyC.Com.Facturacion.CfdiV32Manager.CadenaOriginalTimbreFiscalDigital(Cfdi);
            row.Total_Letra = DesarrollosPyC.Com.Utilidades.NumeroALetra.GeneraNumeroALetra((double)Cfdi.total, Cfdi.Moneda ?? "MXN");

            row.Subtotal = Cfdi.subTotal;
            row.Descuento = Cfdi.descuento;
            if (Cfdi.Impuestos != null)
            {
                if (Cfdi.Impuestos.Retenciones != null)
                {
                    var isr = Cfdi.Impuestos.Retenciones.Where(i => i.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR).FirstOrDefault();
                    if (isr != null)
                        row.ISR = isr.importe;
                }
            }
            row.Total = Cfdi.total;

            ds.Comprobante.AddComprobanteRow(row);

            if (nomina.Percepciones != null)
            {
                if (nomina.Percepciones.Percepcion != null)
                {
                    foreach (var p in nomina.Percepciones.Percepcion)
                    {
                        var r = ds.Percepciones.NewPercepcionesRow();
                        r.ID = ds.Percepciones.Count + 1;
                        r.ID_Comprobante = 1;
                        r.TipoPercepcion = p.TipoPercepcion;
                        r.Clave = p.Clave;
                        r.Descripcion = p.Concepto;
                        r.Importe = p.ImporteGravado + p.ImporteExento;

                        ds.Percepciones.AddPercepcionesRow(r);
                    }
                }
            }

            if (nomina.Deducciones != null)
            {
                if (nomina.Deducciones.Deduccion != null)
                {
                    foreach (var p in nomina.Deducciones.Deduccion)
                    {
                        var r = ds.Deducciones.NewDeduccionesRow();
                        r.ID = ds.Deducciones.Count + 1;
                        r.ID_Comprobante = 1;
                        r.TipoDeduccion = p.TipoDeduccion;
                        r.Clave = p.Clave;
                        r.Descripcion = p.Concepto;
                        r.Importe = p.ImporteGravado + p.ImporteExento;

                        ds.Deducciones.AddDeduccionesRow(r);
                    }
                }
            }

            Reports.ReciboNominaReport report = new Reports.ReciboNominaReport();
            report.DataSource = ds;

            string cbd = string.Format("?re={0}&rr={1}&tt={2:0000000000.000000}&id={3}",
                                    Cfdi.Emisor.rfc,
                                    Cfdi.Receptor.rfc,
                                    Cfdi.total,
                                    timbreFiscal.UUID);
            Gma.QrCodeNet.Encoding.QrEncoder Encoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            Gma.QrCodeNet.Encoding.QrCode Code = Encoder.Encode(cbd);
            System.Drawing.Bitmap TempBMP = new System.Drawing.Bitmap(Code.Matrix.Width, Code.Matrix.Height);
            for (int X = 0; X <= Code.Matrix.Width - 1; X++)
            {
                for (int Y = 0; Y <= Code.Matrix.Height - 1; Y++)
                {
                    if (Code.Matrix[X, Y])
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.Black);
                    else
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.White);
                }
            }
            report.imQR.Image = TempBMP;

            report.CreateDocument();

            return report;
        }

        /// <summary>
        /// Generación de representación impresa de nomina 1.2
        /// </summary>
        /// <param name="cfdi">Comprobante</param>
        /// <param name="nomina">Complemento nómina</param>
        /// <returns>Representación impresa</returns>
        public static Documents.Reports.ReciboNominaReport GeneraReciboNomina12Report(DesarrollosPyC.Com.Facturacion.Comprobantes.V32.Comprobante Cfdi, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina nomina)
        {
            DS.ReciboNominaDS ds = new DS.ReciboNominaDS();
            DS.ReciboNominaDS.ComprobanteRow row = ds.Comprobante.NewComprobanteRow();
            row.ID = 1;
            row.Folio = Cfdi.serie + "-" + Cfdi.folio;
            row.Fecha = Cfdi.fecha;
            row.No_Certificado = Cfdi.noCertificado;
            row.Metodo_Pago = Cfdi.metodoDePago;
            row.Forma_Pago = Cfdi.formaDePago;

            row.Emisor = Cfdi.Emisor.nombre;
            row.Emisor_Rfc = Cfdi.Emisor.rfc;
            row.Emisor_Regimen = Cfdi.Emisor.RegimenFiscal[0].Regimen;

            row.Emisor_Registro_Patronal = nomina.Emisor.RegistroPatronal;

            if (Cfdi.Emisor.DomicilioFiscal != null)
            {
                row.Emisor_Domicilio_Fiscal = (
                    Cfdi.Emisor.DomicilioFiscal.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noExterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noExterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.noInterior) ? "" : Cfdi.Emisor.DomicilioFiscal.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.localidad) ? "" : Cfdi.Emisor.DomicilioFiscal.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.colonia) ? "" : Cfdi.Emisor.DomicilioFiscal.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.municipio) ? "" : Cfdi.Emisor.DomicilioFiscal.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.estado) ? "" : Cfdi.Emisor.DomicilioFiscal.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.DomicilioFiscal.pais) ? "" : Cfdi.Emisor.DomicilioFiscal.pais + ", ")
                    + Cfdi.Emisor.DomicilioFiscal.codigoPostal
                    ).Trim();
            }
            if (Cfdi.Emisor.ExpedidoEn != null)
            {
                row.Emisor_Expedido_En = (
                    Cfdi.Emisor.ExpedidoEn.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noExterior) ? "" : Cfdi.Emisor.ExpedidoEn.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noExterior) ? "" : Cfdi.Emisor.ExpedidoEn.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.noInterior) ? "" : Cfdi.Emisor.ExpedidoEn.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.localidad) ? "" : Cfdi.Emisor.ExpedidoEn.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.colonia) ? "" : Cfdi.Emisor.ExpedidoEn.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.municipio) ? "" : Cfdi.Emisor.ExpedidoEn.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.estado) ? "" : Cfdi.Emisor.ExpedidoEn.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Emisor.ExpedidoEn.pais) ? "" : Cfdi.Emisor.ExpedidoEn.pais + ", ")
                    + Cfdi.Emisor.ExpedidoEn.codigoPostal
                    ).Trim();
            }

            row.Lugar_Expedicion = Cfdi.LugarExpedicion;

            row.Receptor = Cfdi.Receptor.nombre;
            row.Receptor_Rfc = Cfdi.Receptor.rfc;
            if (Cfdi.Receptor.Domicilio != null)
            {
                row.Receptor_Domicilio_Fiscal = (
                    Cfdi.Receptor.Domicilio.calle + " "
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noExterior) ? "" : Cfdi.Receptor.Domicilio.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noExterior) ? "" : Cfdi.Receptor.Domicilio.noExterior + " ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.noInterior) ? "" : Cfdi.Receptor.Domicilio.noInterior + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.localidad) ? "" : Cfdi.Receptor.Domicilio.localidad + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.colonia) ? "" : Cfdi.Receptor.Domicilio.colonia + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.municipio) ? "" : Cfdi.Receptor.Domicilio.municipio + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.estado) ? "" : Cfdi.Receptor.Domicilio.estado + ", ")
                    + (string.IsNullOrEmpty(Cfdi.Receptor.Domicilio.pais) ? "" : Cfdi.Receptor.Domicilio.pais + ", ")
                    + Cfdi.Receptor.Domicilio.codigoPostal
                    ).Trim();
            }
            row.NoCuentaPago = Cfdi.NumCtaPago;

            row.Receptor_NoEmplreado = nomina.Receptor.NumEmpleado;
            row.Receptor_NoSeguridadSocial = nomina.Receptor.NumSeguridadSocial;
            if (nomina.Receptor.FechaInicioRelLaboralSpecified)
                row.Receptor_FehraIniciorelLaborales = nomina.Receptor.FechaInicioRelLaboral;
            row.Receptor_Antiguedad = nomina.Receptor.Antigüedad;
            row.Fecha_InioPago = nomina.FechaInicialPago;
            row.Fecha_TerminoPago = nomina.FechaFinalPago;
            row.Fecha_Pago = nomina.FechaPago;

            //row.Receptor_Curp = nomina.CURP;
            row.Receptor_Departamento = nomina.Receptor.Departamento;
            row.Receptor_Puesto = nomina.Receptor.Puesto;
            row.Receptor_RiesgoPuesto = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.RiesgoPuesto);
            row.Receptor_TipoContrato = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.TipoContrato);
            row.Receptor_TipoJornada = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.TipoJornada);
            row.Receptor_RegimenContratacion = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.TipoRegimen);

            if (nomina.Receptor.SalarioBaseCotAporSpecified)
                row.Receptor_SalarioBase = nomina.Receptor.SalarioBaseCotApor;
            if (nomina.Receptor.SalarioDiarioIntegradoSpecified)
                row.Receptor_SalarioDiario = nomina.Receptor.SalarioDiarioIntegrado;

            var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi32Decode.RecuperaTimbreFiscalDigital(Cfdi);
            row.UUID = timbreFiscal.UUID;
            row.No_Certificado_Sat = timbreFiscal.noCertificadoSAT;
            row.Fecha_Certificacion = timbreFiscal.FechaTimbrado;

            row.Sello_Digital_Cfdi = Cfdi.sello;
            row.Sello_Digital_Sat = timbreFiscal.selloSAT;
            row.Cadena_Original_Certificacion = DesarrollosPyC.Com.Facturacion.CfdiV32Manager.CadenaOriginalTimbreFiscalDigital(Cfdi);
            row.Total_Letra = DesarrollosPyC.Com.Utilidades.NumeroALetra.GeneraNumeroALetra((double)Cfdi.total, Cfdi.Moneda ?? "MXN");

            row.Subtotal = Cfdi.subTotal;
            row.Descuento = Cfdi.descuento;
            if (Cfdi.Impuestos != null)
            {
                if (Cfdi.Impuestos.Retenciones != null)
                {
                    var isr = Cfdi.Impuestos.Retenciones.Where(i => i.impuesto == Com.Facturacion.Comprobantes.V32.ComprobanteImpuestosRetencionImpuesto.ISR).FirstOrDefault();
                    if (isr != null)
                        row.ISR = isr.importe;
                }
            }
            row.Total = Cfdi.total;

            ds.Comprobante.AddComprobanteRow(row);

            if (nomina.Percepciones != null)
            {
                if (nomina.Percepciones.Percepcion != null)
                {
                    foreach (var p in nomina.Percepciones.Percepcion)
                    {
                        var r = ds.Percepciones.NewPercepcionesRow();
                        r.ID = ds.Percepciones.Count + 1;
                        r.ID_Comprobante = 1;
                        r.TipoPercepcion = p.TipoPercepcion.ToString().Replace("Item", "");
                        r.Clave = p.Clave;
                        r.Descripcion = p.Concepto;
                        r.Importe = p.ImporteGravado + p.ImporteExento;

                        ds.Percepciones.AddPercepcionesRow(r);
                    }
                }
            }

            if (nomina.OtrosPagos != null)
            {
                foreach (var p in nomina.OtrosPagos)
                {
                    var r = ds.OtrosPagos.NewOtrosPagosRow();
                    r.ID = ds.OtrosPagos.Count + 1;
                    r.ID_Comprobante = 1;
                    r.TipoOtroPago = p.TipoOtroPago.ToString().Replace("Item", "");
                    r.Clave = p.Clave;
                    r.Descripcion = p.Concepto;
                    r.Importe = p.Importe;

                    ds.OtrosPagos.AddOtrosPagosRow(r);
                }
            }

            if (nomina.Deducciones != null)
            {
                if (nomina.Deducciones.Deduccion != null)
                {
                    foreach (var p in nomina.Deducciones.Deduccion)
                    {
                        var r = ds.Deducciones.NewDeduccionesRow();
                        r.ID = ds.Deducciones.Count + 1;
                        r.ID_Comprobante = 1;
                        r.TipoDeduccion = p.TipoDeduccion.ToString().Replace("Item", "");
                        r.Clave = p.Clave;
                        r.Descripcion = p.Concepto;
                        r.Importe = p.Importe;

                        ds.Deducciones.AddDeduccionesRow(r);
                    }
                }
            }

            Reports.ReciboNominaReport report = new Reports.ReciboNominaReport();
            report.DataSource = ds;

            string cbd = string.Format("?re={0}&rr={1}&tt={2:0000000000.000000}&id={3}",
                                    Cfdi.Emisor.rfc,
                                    Cfdi.Receptor.rfc,
                                    Cfdi.total,
                                    timbreFiscal.UUID);
            Gma.QrCodeNet.Encoding.QrEncoder Encoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            Gma.QrCodeNet.Encoding.QrCode Code = Encoder.Encode(cbd);
            System.Drawing.Bitmap TempBMP = new System.Drawing.Bitmap(Code.Matrix.Width, Code.Matrix.Height);
            for (int X = 0; X <= Code.Matrix.Width - 1; X++)
            {
                for (int Y = 0; Y <= Code.Matrix.Height - 1; Y++)
                {
                    if (Code.Matrix[X, Y])
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.Black);
                    else
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.White);
                }
            }
            report.imQR.Image = TempBMP;

            report.CreateDocument();

            return report;
        }
        #endregion

        #region CFDi 3.3
        /// <summary>
        /// Genera el documento Cfdi impreso
        /// </summary>
        /// <param name="Cfdi">Comprobante</param>
        /// <returns>Documento</returns>
        public static Documents.Reports.ComprobanteReport GeneraComprobanteReport(DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante Cfdi)
        {
            DS.ComprobanteDS ds = new DS.ComprobanteDS();
            DS.ComprobanteDS.ComprobanteRow row = ds.Comprobante.NewComprobanteRow();
            row.ID = 1;
            row.Folio = Cfdi.Serie + "-" + Cfdi.Folio;
            row.Fecha = Cfdi.Fecha;
            row.No_Certificado = Cfdi.NoCertificado;
            var c_mp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Metodopago>.GetnEntity(Cfdi.MetodoPago.ToString());
            row.Metodo_Pago = c_mp.Descripcion;
            var c_fp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Formapago>.GetnEntity(Cfdi.FormaPago.ToString());
            row.Forma_Pago = c_fp.Descripcion;

            row.Emisor = Cfdi.Emisor.Nombre;
            row.Emisor_Rfc = Cfdi.Emisor.Rfc;
            var c_rf = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Regimenfiscal>.GetnEntity(Cfdi.Emisor.RegimenFiscal.ToString());
            row.Emisor_Regimen = c_rf.Descripcion;
            
            row.Lugar_Expedicion = Cfdi.LugarExpedicion.ToString().Replace("Item", "");

            row.Receptor = Cfdi.Receptor.Nombre;
            row.Receptor_Rfc = Cfdi.Receptor.Rfc;

            var c_uso = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Usocfdi>.GetnEntity(Cfdi.Receptor.UsoCFDI.ToString());
            row.Receptor_Domicilio_Fiscal = "Uso de CFDi: " + c_uso.Descripcion;
            
            var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(Cfdi);
            row.UUID = timbreFiscal.UUID;
            row.No_Certificado_Sat = timbreFiscal.NoCertificadoSAT;
            row.Fecha_Certificacion = timbreFiscal.FechaTimbrado;

            row.Sello_Digital_Cfdi = Cfdi.Sello;
            row.Sello_Digital_Sat = timbreFiscal.SelloSAT;
            row.Cadena_Original_Certificacion = DesarrollosPyC.Com.Facturacion.CfdiV33Manager.CadenaOriginalTimbreFiscalDigital(Cfdi);
            row.Total_Letra = DesarrollosPyC.Com.Utilidades.NumeroALetra.GeneraNumeroALetra((double)Cfdi.Total, Cfdi.Moneda.ToString());

            ds.Comprobante.AddComprobanteRow(row);

            foreach (var item in Cfdi.Conceptos)
            {
                DS.ComprobanteDS.ConceptosRow r = ds.Conceptos.NewConceptosRow();
                r.ID_Comprobante = 1;
                r.ID = ds.Conceptos.Count + 1;
                r.Identificador = item.NoIdentificacion;
                r.Descripcion = item.ClaveProdServ.ToString().Replace("Item", "") + " " + item.Descripcion;
                r.Unidad_Medida = item.ClaveUnidad.ToString().Replace("Item", "") + " " + item.Unidad;
                r.Cantidad = item.Cantidad;
                r.Valor_Unitario = item.ValorUnitario;
                r.Importe = item.Importe;

                ds.Conceptos.AddConceptosRow(r);

                if (item.Impuestos != null)
                {
                    foreach (var imp in item.Impuestos.Traslados)
                    {
                        DS.ComprobanteDS.Concepto_ImpuestosRow i = ds.Concepto_Impuestos.NewConcepto_ImpuestosRow();
                        i.ID = ds.Concepto_Impuestos.Count + 1;
                        i.ID_Concepto = r.ID;

                        i.Importe = imp.Importe;

                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Impuesto>.GetnEntity(imp.Impuesto.ToString());
                        i.Descripcion = c_imp.Descripcion + " " + (imp.TasaOCuota * 100M).ToString("n2") + "%";

                        ds.Concepto_Impuestos.AddConcepto_ImpuestosRow(i);
                    }

                    foreach (var imp in item.Impuestos.Retenciones)
                    {
                        DS.ComprobanteDS.Concepto_ImpuestosRow i = ds.Concepto_Impuestos.NewConcepto_ImpuestosRow();
                        i.ID = ds.Concepto_Impuestos.Count + 1;
                        i.ID_Concepto = r.ID;

                        i.Importe = imp.Importe;

                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Impuesto>.GetnEntity(imp.Impuesto.ToString());
                        i.Descripcion = "Ret. " + c_imp.Descripcion + " " + (imp.TasaOCuota * 100M).ToString("n2") + "%";

                        ds.Concepto_Impuestos.AddConcepto_ImpuestosRow(i);
                    }
                }
            }

            DS.ComprobanteDS.ImportesRow sub = ds.Importes.NewImportesRow();
            sub.ID_Comprobante = 1;
            sub.ID = ds.Importes.Count + 1;
            sub.Descripcion = "Subtotal";
            sub.Importe = Cfdi.SubTotal;
            ds.Importes.AddImportesRow(sub);

            DS.ComprobanteDS.ImportesRow desc = ds.Importes.NewImportesRow();
            desc.ID_Comprobante = 1;
            desc.ID = ds.Importes.Count + 1;
            desc.Descripcion = "Descuento";
            desc.Importe = Cfdi.Descuento;
            ds.Importes.AddImportesRow(desc);

            if (Cfdi.Impuestos != null)
            {
                if (Cfdi.Impuestos.Traslados != null)
                {
                    foreach (var imp in Cfdi.Impuestos.Traslados)
                    {
                        DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                        impuesto.ID_Comprobante = 1;
                        impuesto.ID = ds.Importes.Count + 1;
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Impuesto>.GetnEntity(imp.Impuesto.ToString());
                        impuesto.Descripcion = c_imp.Descripcion + " " + decimal.Round(imp.TasaOCuota, 2).ToString() + "%";
                        impuesto.Importe = imp.Importe;
                        ds.Importes.AddImportesRow(impuesto);
                    }
                }
                if (Cfdi.Impuestos.Retenciones != null)
                {
                    foreach (var imp in Cfdi.Impuestos.Retenciones)
                    {
                        DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                        impuesto.ID_Comprobante = 1;
                        impuesto.ID = ds.Importes.Count + 1;
                        var c_imp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Impuesto>.GetnEntity(imp.Impuesto.ToString());
                        impuesto.Descripcion = "Ret. " + c_imp.Descripcion;
                        impuesto.Importe = imp.Importe;
                        ds.Importes.AddImportesRow(impuesto);
                    }
                }
            }

            var impLocal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaImpuestosLocales(Cfdi);
            if (impLocal != null)
            {
                foreach (DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales imp in impLocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesTrasladosLocales).ToList())
                {
                    DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                    impuesto.ID_Comprobante = 1;
                    impuesto.ID = ds.Importes.Count + 1;
                    impuesto.Descripcion = imp.ImpLocTrasladado + " " + decimal.Round(imp.TasadeTraslado, 2).ToString() + "%";
                    impuesto.Importe = imp.Importe;
                    ds.Importes.AddImportesRow(impuesto);
                }
                foreach (DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales imp in impLocal.Items.Where(i => i is DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.ImpuestosLocalesRetencionesLocales).ToList())
                {
                    DS.ComprobanteDS.ImportesRow impuesto = ds.Importes.NewImportesRow();
                    impuesto.ID_Comprobante = 1;
                    impuesto.ID = ds.Importes.Count + 1;
                    impuesto.Descripcion = "Ret. " + imp.ImpLocRetenido + " " + decimal.Round(imp.TasadeRetencion, 2).ToString() + "%";
                    impuesto.Importe = imp.Importe;
                    ds.Importes.AddImportesRow(impuesto);
                }
            }

            DS.ComprobanteDS.ImportesRow total = ds.Importes.NewImportesRow();
            total.ID_Comprobante = 1;
            total.ID = ds.Importes.Count + 1;
            total.Descripcion = "Total";
            total.Importe = Cfdi.Total;
            ds.Importes.AddImportesRow(total);

            Reports.ComprobanteReport report = new Reports.ComprobanteReport();
            report.DataSource = ds;

            string cbd = string.Format("?re={0}&rr={1}&tt={2:0000000000.000000}&id={3}",
                                    Cfdi.Emisor.Rfc,
                                    Cfdi.Receptor.Rfc,
                                    Cfdi.Total,
                                    timbreFiscal.UUID);
            Gma.QrCodeNet.Encoding.QrEncoder Encoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            Gma.QrCodeNet.Encoding.QrCode Code = Encoder.Encode(cbd);
            System.Drawing.Bitmap TempBMP = new System.Drawing.Bitmap(Code.Matrix.Width, Code.Matrix.Height);
            for (int X = 0; X <= Code.Matrix.Width - 1; X++)
            {
                for (int Y = 0; Y <= Code.Matrix.Height - 1; Y++)
                {
                    if (Code.Matrix[X, Y])
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.Black);
                    else
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.White);
                }
            }
            report.imQR.Image = TempBMP;

            report.CreateDocument();

            return report;
        }
        
        /// <summary>
        /// Generación de representación impresa de nomina 1.2
        /// </summary>
        /// <param name="cfdi">Comprobante</param>
        /// <param name="nomina">Complemento nómina</param>
        /// <returns>Representación impresa</returns>
        public static Documents.Reports.ReciboNominaReport GeneraReciboNomina12Report(DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Comprobante Cfdi, DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Nomina.V12.Nomina nomina)
        {
            DS.ReciboNominaDS ds = new DS.ReciboNominaDS();
            DS.ReciboNominaDS.ComprobanteRow row = ds.Comprobante.NewComprobanteRow();
            row.ID = 1;
            row.Folio = Cfdi.Serie + "-" + Cfdi.Folio;
            row.Fecha = Cfdi.Fecha;
            row.No_Certificado = Cfdi.NoCertificado;
            var c_mp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Metodopago>.GetnEntity(Cfdi.MetodoPago.ToString());
            row.Metodo_Pago = c_mp.Descripcion;
            var c_fp = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Formapago>.GetnEntity(Cfdi.FormaPago.ToString());
            row.Forma_Pago = c_fp.Descripcion;

            row.Emisor = Cfdi.Emisor.Nombre;
            row.Emisor_Rfc = Cfdi.Emisor.Rfc;
            var c_rf = DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Controller.DataHelper<DesarrollosPyC.Com.Facturacion.Comprobantes.V33.Catalogos.Model.c_Regimenfiscal>.GetnEntity(Cfdi.Emisor.RegimenFiscal.ToString());
            row.Emisor_Regimen = c_rf.Descripcion;

            row.Emisor_Registro_Patronal = nomina.Emisor.RegistroPatronal;

            row.Lugar_Expedicion = Cfdi.LugarExpedicion.ToString().Replace("Item", "");

            row.Receptor = Cfdi.Receptor.Nombre;
            row.Receptor_Rfc = Cfdi.Receptor.Rfc;

            row.Receptor_NoEmplreado = nomina.Receptor.NumEmpleado;
            row.Receptor_NoSeguridadSocial = nomina.Receptor.NumSeguridadSocial;
            if (nomina.Receptor.FechaInicioRelLaboralSpecified)
                row.Receptor_FehraIniciorelLaborales = nomina.Receptor.FechaInicioRelLaboral;
            row.Receptor_Antiguedad = nomina.Receptor.Antigüedad;
            row.Fecha_InioPago = nomina.FechaInicialPago;
            row.Fecha_TerminoPago = nomina.FechaFinalPago;
            row.Fecha_Pago = nomina.FechaPago;

            //row.Receptor_Curp = nomina.CURP;
            row.Receptor_Departamento = nomina.Receptor.Departamento;
            row.Receptor_Puesto = nomina.Receptor.Puesto;
            row.Receptor_RiesgoPuesto = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.RiesgoPuesto);
            row.Receptor_TipoContrato = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.TipoContrato);
            row.Receptor_TipoJornada = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.TipoJornada);
            row.Receptor_RegimenContratacion = DesarrollosPyC.Com.Utilidades.EnumExtend.GetEnumDescription(nomina.Receptor.TipoRegimen);

            if (nomina.Receptor.SalarioBaseCotAporSpecified)
                row.Receptor_SalarioBase = nomina.Receptor.SalarioBaseCotApor;
            if (nomina.Receptor.SalarioDiarioIntegradoSpecified)
                row.Receptor_SalarioDiario = nomina.Receptor.SalarioDiarioIntegrado;

            var timbreFiscal = DesarrollosPyC.Com.Facturacion.Cfdi33Decode.RecuperaTimbreFiscalDigital(Cfdi);
            row.UUID = timbreFiscal.UUID;
            row.No_Certificado_Sat = timbreFiscal.NoCertificadoSAT;
            row.Fecha_Certificacion = timbreFiscal.FechaTimbrado;

            row.Sello_Digital_Cfdi = Cfdi.Sello;
            row.Sello_Digital_Sat = timbreFiscal.SelloSAT;
            row.Cadena_Original_Certificacion = DesarrollosPyC.Com.Facturacion.CfdiV33Manager.CadenaOriginalTimbreFiscalDigital(Cfdi);
            row.Total_Letra = DesarrollosPyC.Com.Utilidades.NumeroALetra.GeneraNumeroALetra((double)Cfdi.Total, Cfdi.Moneda.ToString());

            row.Subtotal = Cfdi.SubTotal;
            row.Descuento = Cfdi.Descuento;
            row.Total = Cfdi.Total;

            ds.Comprobante.AddComprobanteRow(row);

            if (nomina.Percepciones != null)
            {
                if (nomina.Percepciones.Percepcion != null)
                {
                    foreach (var p in nomina.Percepciones.Percepcion)
                    {
                        var r = ds.Percepciones.NewPercepcionesRow();
                        r.ID = ds.Percepciones.Count + 1;
                        r.ID_Comprobante = 1;
                        r.TipoPercepcion = p.TipoPercepcion.ToString().Replace("Item", "");
                        r.Clave = p.Clave;
                        r.Descripcion = p.Concepto;
                        r.Importe = p.ImporteGravado + p.ImporteExento;

                        ds.Percepciones.AddPercepcionesRow(r);
                    }
                }
            }

            if (nomina.OtrosPagos != null)
            {
                foreach (var p in nomina.OtrosPagos)
                {
                    var r = ds.OtrosPagos.NewOtrosPagosRow();
                    r.ID = ds.OtrosPagos.Count + 1;
                    r.ID_Comprobante = 1;
                    r.TipoOtroPago = p.TipoOtroPago.ToString().Replace("Item", "");
                    r.Clave = p.Clave;
                    r.Descripcion = p.Concepto;
                    r.Importe = p.Importe;

                    ds.OtrosPagos.AddOtrosPagosRow(r);
                }
            }

            if (nomina.Deducciones != null)
            {
                if (nomina.Deducciones.Deduccion != null)
                {
                    foreach (var p in nomina.Deducciones.Deduccion)
                    {
                        var r = ds.Deducciones.NewDeduccionesRow();
                        r.ID = ds.Deducciones.Count + 1;
                        r.ID_Comprobante = 1;
                        r.TipoDeduccion = p.TipoDeduccion.ToString().Replace("Item", "");
                        r.Clave = p.Clave;
                        r.Descripcion = p.Concepto;
                        r.Importe = p.Importe;

                        ds.Deducciones.AddDeduccionesRow(r);
                    }
                }
            }

            Reports.ReciboNominaReport report = new Reports.ReciboNominaReport();
            report.DataSource = ds;

            string cbd = string.Format("?re={0}&rr={1}&tt={2:0000000000.000000}&id={3}",
                                    Cfdi.Emisor.Rfc,
                                    Cfdi.Receptor.Rfc,
                                    Cfdi.Total,
                                    timbreFiscal.UUID);
            Gma.QrCodeNet.Encoding.QrEncoder Encoder = new Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            Gma.QrCodeNet.Encoding.QrCode Code = Encoder.Encode(cbd);
            System.Drawing.Bitmap TempBMP = new System.Drawing.Bitmap(Code.Matrix.Width, Code.Matrix.Height);
            for (int X = 0; X <= Code.Matrix.Width - 1; X++)
            {
                for (int Y = 0; Y <= Code.Matrix.Height - 1; Y++)
                {
                    if (Code.Matrix[X, Y])
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.Black);
                    else
                        TempBMP.SetPixel(X, Y, System.Drawing.Color.White);
                }
            }
            report.imQR.Image = TempBMP;

            report.CreateDocument();

            return report;
        }
        #endregion
    }
}
