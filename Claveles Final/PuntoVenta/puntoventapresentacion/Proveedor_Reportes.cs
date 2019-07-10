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

namespace PuntoVentaPresentacion
{
    public partial class Proveedor_Reportes : Form
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        PuntoVentaBL.Reporte MyDataGridViewPrinter;

        Proveedor_Mod _owner;

        PuntoVentaBL.Proveedores objProveedor = new PuntoVentaBL.Proveedores();

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        public int Accion = 0;

        public int ProveedorId = 0;

        public Proveedor_Reportes(Proveedor_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }
   
        private void Proveedor_Reportes_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void Proveedor_Reportes_Load(object sender, EventArgs e)
        {
            try
            {
                this.objInventario.ObtieneProveedores(this.cmbProveedor);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar la información de reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenConn();

                //var bus = (from x in db.Articulo
                //           join p in db.Proveedor on x.ProveedorId equals p.Id
                //           where p.Activo == true
                //           select new {x.Existencias,x.Descripcion,x.PrecioIVU,x.Precio2IVU,x.FechaUltimaCompra,p.Id,p.Nombre,p.Cedula,p.Contacto,p.CreacionFecha,p.Telefono1,p.Telefono2});


                var bus = (from x in db.Proveedors
                           where x.Activo == true
                           select new { x.Id,x.Nombre,x.Contacto,x.Cedula,x.Telefono1,x.Telefono2,x.CreacionFecha,CreacionFecha1=x.CreacionFecha});

                if (this.rbFiltro.Checked)
                {
                    //bus = from x in bus
                    //      where x.FechaUltimaCompra >= System.DateTime.Now.AddMonths(-1)
                    //      select x;
                    bus = from x in bus
                          where x.CreacionFecha >= System.DateTime.Now.AddMonths(-1)
                          select x;
                }

                if (this.rbEntre.Checked)
                {
                    //bus = from x in bus
                    //      where  Convert.ToDateTime(this.dtpFechaInicial.Value.ToShortDateString())<=x.FechaUltimaCompra && x.FechaUltimaCompra<=Convert.ToDateTime(this.dtpFechaFinal.Value.ToShortDateString())
                    //      select x;

                    bus =from x in bus
                         where Convert.ToDateTime(this.dtpFechaInicial.Value.ToShortDateString()) <= x.CreacionFecha && x.CreacionFecha <= Convert.ToDateTime(this.dtpFechaFinal.Value.ToShortDateString())
                         select x;
                }

                if (this.rbProveedor.Checked)
                {
                    bus = from x in bus
                          where x.Id == Convert.ToInt32(this.cmbProveedor.SelectedValue)
                          select x;
                }
                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    switch (this.cmbOrdenar.Text)
                    {
                        case "Nombre":
                            {
                                bus = from x in bus
                                      orderby x.Nombre ascending
                                      select x;
                                break;
                            }
                        case "Contacto":
                            {
                                bus = from x in bus
                                      orderby x.Contacto ascending
                                      select x;
                                break;
                            }
                        case "Inicio relaciones":
                            {
                                bus = from x in bus
                                      orderby x.CreacionFecha ascending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }
                }

                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;

                MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos, pdReporte, true, true, "LISTADO DE PROVEEDORES", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

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
                    CoolPrintPreview.CoolPrintPreviewDialog printPrvDlg = new CoolPrintPreview.CoolPrintPreviewDialog();

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
                    pdfTable.HeaderRows = 1;

                    //pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 93;
                    //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 0;

                    float[] widths = new float[] { 35, 35, 35, 35, 35, 35 };
                    pdfTable.SetWidths(widths);

                    //Adding Header row
                    foreach (DataGridViewColumn column in this.dgvDatos.Columns)
                    {
                        iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 16, iTextSharp.text.Font.BOLD);
                        Paragraph HEADERTEXT = new Paragraph(column.HeaderText, contentFont);
                        HEADERTEXT.Alignment = Element.ALIGN_LEFT;

                        PdfPCell cell = new PdfPCell(HEADERTEXT);
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.Border = 0;
                        cell.BorderWidthBottom = 3;
                        cell.PaddingBottom = 10;
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
                                celda.Alignment = Element.ALIGN_LEFT;

                                PdfPCell cell1 = new PdfPCell(celda);
                                cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell1.BorderWidth = 0f;
                                pdfTable.AddCell(cell1);
                            }
                            else
                            {
                                Paragraph celda = new Paragraph("", celdas);
                                celda.Alignment = Element.ALIGN_LEFT;

                                PdfPCell cell1 = new PdfPCell(celda);
                                cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell1.BorderWidth = 0f;
                                pdfTable.AddCell(cell1);
                            }

                        }
                    }
                    //Exporting to PDF

                    FolderBrowserDialog file = new FolderBrowserDialog();

                    if (file.ShowDialog() != DialogResult.Cancel)
                    {
                        string folderPath = file.SelectedPath + "\\";
                        string nombre = "LISTADO DE PROVEEDORES" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        using (FileStream stream = new FileStream(folderPath + nombre, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 10f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            this.OpenConn();
                            var bus = from x in db.InformacionGeneral
                                      select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax) };


                            iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font contentFont2 = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 12, iTextSharp.text.Font.NORMAL);

                            Paragraph Reporte = new Paragraph("LISTADO DE PROVEEDORES", contentFont);
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

                    xlWorkSheet.Cells[1, 1] = "LISTADO DE PROVEEDORES";
                    xlWorkSheet.Cells[1, 1].Font.Size = 16;
                    xlWorkSheet.Cells[2, 1] = bus.First().Nombre.ToString();
                    xlWorkSheet.Cells[2, 1].Font.Size = 16;

                    //xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                    //xlWorkSheet.Cells[3, 1].Font.Size = 12;
                    //xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                    //xlWorkSheet.Cells[4, 1].Font.Size = 12;

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

                        xlWorkBook.SaveAs(file.SelectedPath + "\\LISTADO DE PROVEEDORES" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
            pdReporte.DocumentName = "LISTADO DE PROVEEDORES";
            pdReporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pdReporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pdReporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pdReporte.DefaultPageSettings.Landscape = false;

            return true;
        }

        public void OpenConn()
        {
            if (db == null) db = new PuntoVentaDAL.CONEXIONDataContext();
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

        private void btnBuscaProveedor_Click(object sender, EventArgs e)
        {
            Sel_Proveedor ProveedorAsignar = new Sel_Proveedor(this);
            ProveedorAsignar.tipo = 1;
            ProveedorAsignar.TopLevel = false;
            ProveedorAsignar.Parent = this;
            ProveedorAsignar.Show();
        }

        public void CambiaProveedor()
        {
            try
            {
                this.cmbProveedor.SelectedValue = ProveedorId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el proveedor: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
