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
    public partial class CajaDiaria_Reportes : Form
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        Restaurante_BL.Reporte MyDataGridViewPrinter;

        CajaDiaria_Mod _owner;

        Restaurante_BL.CajaDiaria objCajaDiaria = new Restaurante_BL.CajaDiaria();

        public int Accion = 0;

        public CajaDiaria_Reportes(CajaDiaria_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void CajaDiaria_Reportes_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objCajaDiaria.ObtieneUsuario(this.cmbUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar la información de reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CajaDiaria_Reportes_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenConn();

                var bus1 = (from x in db.CajaDiarias
                            join eq in db.Equipos on x.EquipoId equals eq.Id
                            //where eq.NombreEquipo == System.Environment.MachineName.ToString()
                            orderby x.Id descending
                            select x);

                var bus = (from cd in db.CajaDiarias
                           join eq in db.Equipos on cd.EquipoId equals eq.Id
                           join m in db.Movimientos on cd.MovimientoId equals m.Id
                           join u in db.Usuarios on cd.UsuarioId equals u.Id
                           join fe in db.FacturaEncabezado on cd.ComprobanteId equals fe.Id into fg from fe in fg.DefaultIfEmpty()
                           where cd.Activo == true //&& eq.NombreEquipo == System.Environment.MachineName.ToString()//obtengo la c"aja diaria del ultimo dia 
                           select new { TipoPago = (fe.TipoPago == null ? 0 : fe.TipoPago), UsuarioId = u.Id, cd.Id, Movimiento = m.Descripcion, ComprobanteId = (cd.ComprobanteId == null ? 0 : cd.ComprobanteId), cd.Descripcion, cd.Monto, cd.Saldo, Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido),  cd.Fecha, Fecha1 = cd.Fecha.ToShortDateString(), cd.Hora, cd.MovimientoId, cd.AutorizadoPor });

//                from p in context.Periods
//join f in context.Facts on p.id equals f.periodid into fg
//from fgi in fg.Where(f => f.otherid == 17).DefaultIfEmpty()
//where p.companyid == 100
//select f.value
                //fe.TipoPago,
                if (this.rbUsuario.Checked)
                {
                    bus = from x in bus
                          where x.UsuarioId == Convert.ToInt32(this.cmbUsuario.SelectedValue.ToString())
                          orderby x.Id descending
                          select x;
                }

                if (this.rbReporteResumido.Checked)
                {
                    bus = from x in bus
                          where x.MovimientoId == 8 || x.MovimientoId == 1
                          orderby x.Id descending
                          select x;
                }

                if (this.rbEntreFechas.Checked)
                {
                    bus = from x in bus
                          where Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString()) <= x.Fecha && x.Fecha <= Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString())
                          orderby x.Id descending
                          select x;
                }
                if (this.rbTarjeta.Checked)
                {
                    bus = from x in bus
                          where x.TipoPago == 1
                          orderby x.Id descending
                          select x;
                }
                if (this.rbEfectivo.Checked)
                {
                    bus = from x in bus
                          where x.TipoPago == 2
                          orderby x.Id descending
                          select x;
                }

                this.dgvDatos.AutoGenerateColumns = false;
                this.dgvDatos.DataSource = bus;

                pdReporte.DefaultPageSettings.Landscape = true;

                MyDataGridViewPrinter = new Restaurante_BL.Reporte(this.dgvDatos, pdReporte, true, true, "LISTADO DE MOVIMIENTOS DE CAJA DIARIA", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    pdfTable.WidthPercentage = 100;


                    float[] sglTblHdWidths = new float[8];
                    sglTblHdWidths[0] = 35f;//movimiento40
                    sglTblHdWidths[1] = 35f;//comprobante
                    sglTblHdWidths[2] = 100f;//descripcion
                    sglTblHdWidths[3] = 35f;//monto
                    sglTblHdWidths[4] = 35f;//saldo
                    sglTblHdWidths[5] = 60f;//nombre
                    sglTblHdWidths[6] = 30f;//fecha
                    sglTblHdWidths[7] = 30f;//hora
                    // Set the column widths on table creation. Unlike HTML cells cannot be sized.
                    pdfTable.SetWidths(sglTblHdWidths);

                    //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 0;

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
                        string nombre = "LISTADO DE MOVIMIENTOS DE CAJA DIARIA" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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
                            var bus = from x in db.InformacionGeneral
                                      select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax) };


                            iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font contentFont2 = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 12, iTextSharp.text.Font.NORMAL);

                            Paragraph Reporte = new Paragraph("LISTADO DE MOVIMIENTOS DE CAJA DIARIA", contentFont);
                            Reporte.Alignment = Element.ALIGN_CENTER;
                            Paragraph titulo = new Paragraph(bus.First().Nombre.ToString(), contentFont);
                            titulo.Alignment = Element.ALIGN_CENTER;
                            Paragraph telefono = new Paragraph("TELÉFONO: " + bus.First().Telefono.ToString(), contentFont2);
                            telefono.Alignment = Element.ALIGN_CENTER;
                            Paragraph fax = new Paragraph("FAX: " + bus.First().Fax.ToString(), contentFont2);
                            fax.Alignment = Element.ALIGN_CENTER;
                            Paragraph espacio = new Paragraph("    ", contentFont2);

                            pdfDoc.Add(titulo);
                            pdfDoc.Add(Reporte);
                            pdfDoc.Add(telefono);
                            pdfDoc.Add(fax);
                            pdfDoc.Add(espacio);

                            pdfDoc.Add(pdfTable);

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
                    var bus = from x in db.InformacionGeneral
                              select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax) };

                    xlWorkSheet.Cells[1, 1] = "LISTADO DE MOVIMIENTOS DE CAJA DIARIA";
                    xlWorkSheet.Cells[1, 1].Font.Size = 16;
                    xlWorkSheet.Cells[2, 1] = bus.First().Nombre.ToString();
                    xlWorkSheet.Cells[2, 1].Font.Size = 16;

                    xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                    xlWorkSheet.Cells[3, 1].Font.Size = 12;
                    xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                    xlWorkSheet.Cells[4, 1].Font.Size = 12;

                    xlWorkSheet.Cells[5, 1] = "    ";


                    this.CloseConn();


                    for (int t = 1; t < this.dgvDatos.Columns.Count + 1; t++)
                    {
                        xlWorkSheet.Cells[6, t] = this.dgvDatos.Columns[t - 1].HeaderText;
                        xlWorkSheet.Cells[6, t].Font.Size = 16;
                        xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                        xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                        xlWorkSheet.Cells[6, t].Rows.AutoFit();
                        xlWorkSheet.Cells[6, t].Columns.AutoFit();

                        intx++;
                    }

                    for (i = 0; i <= this.dgvDatos.RowCount - 1; i++)
                    {
                        inty = 0;
                        for (j = 0; j <= this.dgvDatos.ColumnCount - 1; j++)
                        {
                            DataGridViewCell cell = this.dgvDatos[j, i];
                            xlWorkSheet.Cells[i + 7, j + 1] = cell.Value;
                            xlWorkSheet.Cells[i + 7, j + 1].Font.Size = 12;
                            xlWorkSheet.Cells[i + 7, j + 1].Rows.AutoFit();
                            xlWorkSheet.Cells[i + 7, j + 1].Columns.AutoFit();
                            inty++;
                        }
                        intx++;
                    }


                    Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[6, 1];
                    Excel.Range c2 = (Excel.Range)xlWorkSheet.Cells[intx, inty];
                    Excel.Range range = xlWorkSheet.get_Range(c1, c2);


                    range.Rows.AutoFit();
                    range.Columns.AutoFit();

                    FolderBrowserDialog file = new FolderBrowserDialog();

                    if (file.ShowDialog() != DialogResult.Cancel)
                    {

                        xlWorkBook.SaveAs(file.SelectedPath + "\\LISTADO DE MOVIMIENTOS DE CAJA DIARIA" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
                    if (instaladorImpresora())
                    {
                        pdReporte.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar imprimir el documento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            pdReporte.DocumentName = "LISTADO DE MOVIMIENTOS DE CAJA DIARIA";
            pdReporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pdReporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pdReporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pdReporte.DefaultPageSettings.Landscape = false;

            return true;
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

        private void rbTodosUsuario_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

