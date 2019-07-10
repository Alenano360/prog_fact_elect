using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Restaurante_Presentacion
{
    public partial class Ventas_Reportes : Form
    {
        Reportes_Mod _owner;
        public int UserIdTemp = 0;
        Restaurante_DAL.BaseDatosDataContext db = null;
        public string Impresora = string.Empty;

        Restaurante_BL.Reporte MyDataGridViewPrinter;

        Restaurante_BL.Ventas objVentas = new Restaurante_BL.Ventas();

        //Restaurante_BL.Cliente objCliente = new Restaurante_BL.Cliente();

        Restaurante_BL.Familia objFamilia = new Restaurante_BL.Familia();

        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();

        Restaurante_BL.Ticket objTicket = new Restaurante_BL.Ticket();

        public int FamiliaId = 0;

        public int Accion = 0;

        public decimal impventas, impservicio, ganancia = 0;

        public Ventas_Reportes(Reportes_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ventas_Reportes_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {
            }
        }

        private void Ventas_Reportes_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.objFamilia.ObtieneFamilia(this.cmbFamilia);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar la información de reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtieneInfoInferior()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.tls_Usuario.Text = "Usuario: " + Login.LoginUsuarioFinal.ToString().ToUpper();

                this.tlsNombreRest.Text = "Restaurante: " + this.objInformacionGeneral.Nombre.ToString();

                this.tlsWebHtml.Text = "Web: " + this.objInformacionGeneral.Web.ToString();

                this.tlsFecha.Text = "Fecha: " + System.DateTime.Now.ToShortDateString();

                this.tlsHora.Text = "Hora: " + System.DateTime.Now.ToShortTimeString();

                UserIdTemp = Login.UserId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResizeLoad()
        {
            try
            {
                var width = this.Width;
                var height = (this.Height - 85) / 5;
                this.tls_Usuario.Width = ((this.Width / 9) * 2) + 15;
                this.tlsNombreRest.Width = ((this.Width / 9) * 3) - 32;
                this.tlsWebHtml.Width = (this.Width / 9) * 2;
                this.tlsFecha.Width = (this.Width / 9);
                this.tlsHora.Width = (this.Width / 9);

                this.panelCompleto.Location = new Point(((this.Width - this.panelCompleto.Width) / 2), 0);
            }
            catch (Exception)
            {
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.ObtieneVentas_Vw
                           join eq in db.Equipos on x.EquipoId equals eq.Id
                           join m in db.Movimientos on x.MovimientoId equals m.Id
                           where x.MovimientoId == 2
                           orderby x.Id descending
                           select new { x.TipoPago,ClienteId = x.ClienteId, x.Id, Nombre = x.Nombre, Descuento = x.Descuento, Total = x.Total,                                
                               x.Fecha,x.Hora, x.Activo, x.Monto });

                this.objVentas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objVentas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());

                if (this.rbEntreFechas.Checked)
                {
                    bus = from x in bus
                          where this.objVentas.FechaInicio <= Convert.ToDateTime(x.Fecha) && Convert.ToDateTime(x.Fecha) <= this.objVentas.FechaFinal
                          select x;
                }
                if (this.rbEfectivo.Checked)
                {
                    bus = from x in bus
                          where x.TipoPago == 2
                          select x;
                }
                if (this.rbTarjetaCredito.Checked)
                {
                    bus = from x in bus
                          where x.TipoPago == 1
                          select x;
                }


                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    switch (this.cmbOrdenar.Text)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Fecha descending
                                      select x;
                                break;
                            }
                        case "Comprobante":
                            {
                                bus = from x in bus
                                      orderby x.Id descending
                                      select x;
                                break;
                            }
                        case "Cliente":
                            {
                                bus = from x in bus
                                      orderby x.Nombre ascending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }
                }

                //decimal impventas = 0;
                //decimal impservicio = 0;
                decimal temp = 0;

                foreach (var item in bus)
                {
                    temp += Convert.ToDecimal(item.Monto);
                }

                var porc = (from ig in db.InformacionGeneral
                            select ig).First();

                string simpuestos = "1." + (Convert.ToDecimal(porc.IVA + porc.ImpuestoServicio).ToString("#"));
                decimal tempval = temp / Convert.ToDecimal(simpuestos);

                string simpventa="1."+(Convert.ToDecimal(porc.IVA).ToString("#"));
                string simpservicio = "1." + (Convert.ToDecimal(porc.ImpuestoServicio).ToString("#"));

                //impventas = temp * Convert.ToDecimal(porc.IVA/100);
                //impservicio = temp * Convert.ToDecimal(porc.ImpuestoServicio / 100);
                //ganancia = temp - impventas - impservicio;
                impventas = tempval * Convert.ToDecimal(porc.IVA / 100);
                impservicio = tempval * Convert.ToDecimal(porc.ImpuestoServicio / 100);
                ganancia = tempval;


                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;


                if (this.chkArticulosReporte.Checked)
                {

                    var busArticulos = (from x in db.VentasArticulo_Vws                                       
                                        select x);

                    if (this.rbFamilia.Checked)
                    {
                        busArticulos = from x in busArticulos
                                       where x.Familia == this.cmbFamilia.Text
                                       select x;
                    }

                    if (this.rbEntreFechas.Checked)
                    {
                        busArticulos = from x in busArticulos
                                       where Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString()) <= x.Fecha &&
                                       x.Fecha <= Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString())
                              select x;
                    }

                    if (this.cmbOrdenar.Text != "--Seleccione--")
                    {
                        switch (this.cmbOrdenar.Text)
                        {
                            case "Familia":
                                {
                                    busArticulos = from x in busArticulos
                                          orderby x.Familia descending
                                          select x;
                                    break;
                                }
                            default:
                                break;
                        }
                    }

                    this.dgvDatos1.AutoGenerateColumns = false;

                    this.dgvDatos1.DataSource = busArticulos;

                    pdReporte.DefaultPageSettings.Landscape = true;

                    MyDataGridViewPrinter = new Restaurante_BL.Reporte(this.dgvDatos1, pdReporte, true, true, "LISTADO DE VENTAS", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);
                }
                else
                {
                    pdReporte.DefaultPageSettings.Landscape = true;
                    MyDataGridViewPrinter = new Restaurante_BL.Reporte(this.dgvDatos, pdReporte, true, true, "LISTADO DE VENTAS", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);
                }

                PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

                printPrvDlg.Document = pdReporte;

                printPreviewControl1.Document = pdReporte;

                this.Accion = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar la vista preliminar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void OpenConn()
        {
            if (db == null) db = new Restaurante_DAL.BaseDatosDataContext();
        }

        public void CloseConn()
        {
            if (db != null)
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();

                db.Dispose();
                db = null;
            }
        }

        private void pdReporte_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool mas_paginas = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (mas_paginas == true)
            {
                e.HasMorePages = true;
            }
        }

        private void btnPreliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == 1)
                {
                    PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

                    printPrvDlg.Document = pdReporte;
                    printPrvDlg.Height = this.Height;
                    printPrvDlg.Width = this.Width;
                    printPrvDlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar imprimir el documento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExpPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == 1)
                {

                    PdfPTable pdfTable = new PdfPTable(this.dgvDatos.ColumnCount);
                    //pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 93;                    
                    //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 0;                    

                    float[] sglTblHdWidths = new float[6];
                    sglTblHdWidths[0] = 40f;//comprobante
                    sglTblHdWidths[1] = 100f;//cliente
                    sglTblHdWidths[2] = 40f;//fecha
                    sglTblHdWidths[3] = 40f;//hora
                    sglTblHdWidths[4] = 40f;//descuento
                    sglTblHdWidths[5] = 60f;//importe total

                    pdfTable.SetWidths(sglTblHdWidths);
                    //Adding Header row
                    foreach (DataGridViewColumn column in this.dgvDatos.Columns)
                    {
                        iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 16, iTextSharp.text.Font.BOLD);
                        Paragraph HEADERTEXT = new Paragraph(column.HeaderText, contentFont);
                        HEADERTEXT.Alignment = Element.ALIGN_CENTER;

                        PdfPCell cell = new PdfPCell(HEADERTEXT);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(cell);
                    }

                    iTextSharp.text.Font celdas = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 14, iTextSharp.text.Font.NORMAL);

                    //Adding DataRow
                    foreach (DataGridViewRow row in this.dgvDatos.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                Paragraph celda = new Paragraph(cell.Value.ToString(), celdas);
                                celda.Alignment = Element.ALIGN_CENTER;

                                PdfPCell cell1 = new PdfPCell(celda);
                                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell1.BorderWidth = 0f;

                                pdfTable.AddCell(cell1);
                            }
                            else
                            {
                                pdfTable.AddCell("");
                            }

                        }
                    }
                    //Exporting to PDF

                    FolderBrowserDialog file = new FolderBrowserDialog();

                    if (file.ShowDialog() != DialogResult.Cancel)
                    {
                        string folderPath = file.SelectedPath + "\\";
                        string nombre = "LISTADO DE VENTAS" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        using (FileStream stream = new FileStream(folderPath + nombre, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            this.OpenConn();
                            var bus = from x in  db.InformacionGeneral
                                      select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax) };


                            iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font contentFont2 = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 12, iTextSharp.text.Font.NORMAL);
                            

                            Paragraph Reporte = new Paragraph("LISTADO DE VENTAS", contentFont);
                            Reporte.Alignment = Element.ALIGN_CENTER;
                            Paragraph titulo = new Paragraph(bus.First().Nombre.ToString(), contentFont);
                            titulo.Alignment = Element.ALIGN_CENTER;
                            //Paragraph telefono = new Paragraph("TELÉFONO: " + bus.First().Telefono.ToString(), contentFont2);
                            //telefono.Alignment = Element.ALIGN_CENTER;
                            //Paragraph fax = new Paragraph("FAX: " + bus.First().Fax.ToString(), contentFont2);
                            //fax.Alignment = Element.ALIGN_CENTER;
                            Paragraph espacio = new Paragraph("    ", contentFont2);

                            pdfDoc.Add(titulo);
                            pdfDoc.Add(Reporte);
                            //pdfDoc.Add(telefono);
                            //pdfDoc.Add(fax);
                            pdfDoc.Add(espacio);

                            pdfDoc.Add(pdfTable);
                            pdfDoc.Add(espacio);
                            pdfDoc.Add(espacio);

                            iTextSharp.text.Font contentFont3 = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 14, iTextSharp.text.Font.BOLD);
                            Paragraph IMPVENTAS = new Paragraph("IMPUESTO DE VENTAS: " + impventas.ToString("F"), contentFont3);
                            IMPVENTAS.Alignment = Element.ALIGN_LEFT;
                            IMPVENTAS.IndentationLeft = 50f;
                            pdfDoc.Add(IMPVENTAS);

                            Paragraph IMPSERVICIO = new Paragraph("IMPUESTO DE SERVICIO: " + impservicio.ToString("F"), contentFont3);
                            IMPSERVICIO.Alignment = Element.ALIGN_LEFT;
                            IMPSERVICIO.IndentationLeft = 50f;
                            pdfDoc.Add(IMPSERVICIO);

                            Paragraph GANANCIA = new Paragraph("GANANCIA ENTRE EL PERIÓDO SELECCIONADO: " + ganancia.ToString("F"), contentFont3);
                            GANANCIA.Alignment = Element.ALIGN_LEFT;
                            GANANCIA.IndentationLeft = 50f;
                            pdfDoc.Add(GANANCIA);

                            Paragraph GRANTOTAL = new Paragraph("GRAN TOTAL: " + (ganancia+impservicio+impventas).ToString("F"), contentFont3);
                            GRANTOTAL.Alignment = Element.ALIGN_LEFT;
                            GRANTOTAL.IndentationLeft = 50f;
                            pdfDoc.Add(GRANTOTAL);

                            pdfDoc.Close();
                            stream.Close();

                            this.CloseConn();
                        }

                        MessageBox.Show("Archivo creado con éxito!");

                        System.Diagnostics.Process.Start(@file.SelectedPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar exportar el documento a PDF: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnExpXLS_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == 1)
                {
                    int intx = 0;
                    int inty = 0;
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    int i = 0;
                    int j = 0;

                    this.OpenConn();
                    var bus = from x in  db.InformacionGeneral
                              select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax) };


                    xlWorkSheet.Cells[1, 1] = bus.First().Nombre.ToString();
                    xlWorkSheet.Cells[1, 1].Font.Size = 16;
                    xlWorkSheet.Cells[2, 1] = "LISTADO DE VENTAS";
                    xlWorkSheet.Cells[2, 1].Font.Size = 16;

                    //xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                    //xlWorkSheet.Cells[3, 1].Font.Size = 12;
                    //xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                    //xlWorkSheet.Cells[4, 1].Font.Size = 12;

                    xlWorkSheet.Cells[3, 1] = "    ";


                    this.CloseConn();


                    for (int t = 1; t < this.dgvDatos.Columns.Count + 1; t++)
                    {
                        xlWorkSheet.Cells[4, t] = this.dgvDatos.Columns[t - 1].HeaderText;
                        xlWorkSheet.Cells[4, t].Font.Size = 16;
                        xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                        xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                        xlWorkSheet.Cells[4, t].Rows.AutoFit();
                        xlWorkSheet.Cells[4, t].Columns.AutoFit();

                        intx++;
                    }

                    for (i = 0; i <= this.dgvDatos.RowCount - 1; i++)
                    {
                        inty = 0;
                        for (j = 0; j <= this.dgvDatos.ColumnCount - 1; j++)
                        {
                            DataGridViewCell cell = this.dgvDatos[j, i];
                            xlWorkSheet.Cells[i + 5, j + 1] = cell.Value;
                            xlWorkSheet.Cells[i + 5, j + 1].Font.Size = 12;
                            xlWorkSheet.Cells[i + 5, j + 1].Rows.AutoFit();
                            xlWorkSheet.Cells[i + 5, j + 1].Columns.AutoFit();
                            inty++;
                        }
                        intx++;
                    }


                    Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[4, 1];
                    Excel.Range c2 = (Excel.Range)xlWorkSheet.Cells[intx, inty];
                    Excel.Range range = xlWorkSheet.get_Range(c1, c2);

                    range.Rows.AutoFit();
                    range.Columns.AutoFit();

                    xlWorkSheet.Cells[i + 6, 1] = "IMPUESTO DE VENTA: " + impventas.ToString("F");
                    xlWorkSheet.Cells[i + 6, 1].Font.Size = 14;
                    xlWorkSheet.Cells[i + 6, 1].Font.Bold = true;
                    xlWorkSheet.Cells[i + 6, 1].Rows.AutoFit();
                    xlWorkSheet.Cells[i + 6, 1].Columns.AutoFit();

                    xlWorkSheet.Cells[i + 7, 1] = "IMPUESTO DE SERVICIO: " + impservicio.ToString("F");
                    xlWorkSheet.Cells[i + 7, 1].Font.Size = 14;
                    xlWorkSheet.Cells[i + 7, 1].Font.Bold = true;
                    xlWorkSheet.Cells[i + 7, 1].Rows.AutoFit();
                    xlWorkSheet.Cells[i + 7, 1].Columns.AutoFit();


                    xlWorkSheet.Cells[i + 8, 1] = "GANANCIA: " + ganancia.ToString("F");
                    xlWorkSheet.Cells[i + 8, 1].Font.Size = 14;
                    xlWorkSheet.Cells[i + 8, 1].Font.Bold = true;
                    xlWorkSheet.Cells[i + 8, 1].Rows.AutoFit();
                    xlWorkSheet.Cells[i + 8, 1].Columns.AutoFit();

                    xlWorkSheet.Cells[i + 9, 1] = "GRAN TOTAL: " + (ganancia + impservicio + impventas).ToString("F");
                    xlWorkSheet.Cells[i + 9, 1].Font.Size = 14;
                    xlWorkSheet.Cells[i + 9, 1].Font.Bold = true;
                    xlWorkSheet.Cells[i + 9, 1].Rows.AutoFit();
                    xlWorkSheet.Cells[i + 9, 1].Columns.AutoFit();

                    //int iTotalColumns = xlWorkSheet.UsedRange.Columns.Count;
                    //int iTotalRows = xlWorkSheet.UsedRange.Rows.Count;
                   
                    //xlWorkSheet.Columns.ClearFormats();
                    //xlWorkSheet.Rows.ClearFormats();

                    //iTotalColumns = xlWorkSheet.UsedRange.Columns.Count;
                    //iTotalRows = xlWorkSheet.UsedRange.Rows.Count;

                    //Excel.Range last = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    //Excel.Range range = xlWorkSheet.get_Range("A1", last);

                    FolderBrowserDialog file = new FolderBrowserDialog();

                    if (file.ShowDialog() != DialogResult.Cancel)
                    {

                        xlWorkBook.SaveAs(file.SelectedPath + "\\LISTADO DE VENTAS" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);

                        MessageBox.Show("Archivo creado con éxito!");

                        System.Diagnostics.Process.Start(@file.SelectedPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar exportar el documento a Excel: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == 1)
                {
                    /*if (instaladorImpresora())
                    {
                        pdReporte.Print();
                    }*/
                    ConstruyeTicket();

                    PrinterSettings ps = new PrinterSettings();
                    foreach (string printer in PrinterSettings.InstalledPrinters)
                    {
                        ps.PrinterName = printer;
                        if (ps.IsDefaultPrinter)
                        {
                            Impresora = printer;
                        }
                    }

                    Facturacion_Pago.RawPrinterHelper.SendStringToPrinter(Impresora, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 112, 48, 55, 121 }));//para abrir la caja

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar imprimir el documento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ConstruyeTicket()
        {
            try
            {
                this.objTicket.Facturas.Clear();

                if (this.dgvDatos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        DateTime Fecha;

                        Fecha = DateTime.Parse(item.Cells[2].Value.ToString()).Date;

                        this.objTicket.Facturas.Add(item.Cells[0].Value.ToString() + ";"+item.Cells[1].Value.ToString() + ";"+
                                                    Fecha.ToString("dd/MM/yyyy") + ";" + item.Cells[3].Value.ToString() + ";"+
                                                    item.Cells[4].Value.ToString() + ";"+item.Cells[5].Value.ToString());

                        //  this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[1].Value.ToString()).ToString("F") + ";" + item.Cells[2].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.AltoPapel += 20;
                    }
                }
                this.objTicket.ObtieneInformacionGeneral();
                this.objTicket.UserId = UserIdTemp;
                this.objTicket.Accion = 6;

                this.objTicket.print();

                this.objTicket.Offset = 40;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool instaladorImpresora()
        {
            PrintDialog dialogo_impresion = new PrintDialog();
            dialogo_impresion.AllowCurrentPage = false;
            dialogo_impresion.AllowPrintToFile = false;
            dialogo_impresion.AllowSelection = false;
            dialogo_impresion.AllowSomePages = false;
            dialogo_impresion.PrintToFile = false;
            dialogo_impresion.ShowHelp = false;
            dialogo_impresion.ShowNetwork = false;


            if (dialogo_impresion.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            pdReporte.DocumentName = "LISTADO DE VENTAS";
            pdReporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pdReporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pdReporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pdReporte.DefaultPageSettings.Landscape = false;

            return true;
        }

        private void cmbFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbFamilia.Text.Length>0)
            {
                this.FamiliaId = Convert.ToInt32(this.cmbFamilia.SelectedValue.ToString());
            }
        }

        private void chkArticulosReporte_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkArticulosReporte.Checked)
            {
                this.gb_Familias.Visible = true;
            }
            else
            {
                this.gb_Familias.Visible = false;
            }
        }

        private void rbFamilia_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
