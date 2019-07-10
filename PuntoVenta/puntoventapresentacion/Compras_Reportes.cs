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
    public partial class Compras_Reportes : Form
    {
        Compras_Mod _owner;

        PuntoVentaDAL.CONEXIONDataContext db = null;

        PuntoVentaBL.Reporte MyDataGridViewPrinter;

        PuntoVentaBL.Ventas objVentas = new PuntoVentaBL.Ventas();

        PuntoVentaBL.Cliente objCliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        public int ProveedorId = 0;

        public int Accion = 0;

        public Compras_Reportes(Compras_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }
        private void Compras_Reportes_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }
        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpHasta.Value < this.dtpDesde.Value)
                {
                    MessageBox.Show("La fecha de finalización no puede ser mayor a la de inicio!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.dtpHasta.Value = this.dtpDesde.Value;

                    return;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpHasta.Value < this.dtpDesde.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la de finalización!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.dtpHasta.Value = this.dtpDesde.Value;

                    return;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Proveedor_Reportes_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

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

        private void btnBuscaProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Proveedor ProveedorAsignar = new Sel_Proveedor(this);
                ProveedorAsignar.tipo = 6;
                ProveedorAsignar.TopLevel = false;
                ProveedorAsignar.Parent = this;
                ProveedorAsignar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar buscar los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
                         try
            {
                this.OpenConn();

                 //todas


                var bus = from x in db.ObtieneCompras_Vws
                          //join eq in db.Equipos on x.EquipoId equals eq.Id
                          join m in db.Movimientos on x.MovimientoId equals m.Id
                          where x.MovimientoId == 3 && x.Activo == true
                          orderby x.Id descending
                          select new {x.Id,x.ProveedorId, x.FacturaId,x.Nombre,x.Fecha,Fecha1=x.Fecha.ToShortDateString(),x.Hora,x.Descuento,x.Impuesto,x.Total};

                //var bus = from x in db.ObtieneCompras_Vw
                //          join eq in db.Equipo on x.EquipoId equals eq.Id
                //          join m in db.Movimiento on x.MovimientoId equals m.Id
                //          where x.MovimientoId == 3 && eq.NombreEquipo == System.Environment.MachineName.ToString()
                //          orderby x.Id descending
                //          select x;//solo las de la maquina actual

                //var bus = (from fe in db.FacturaEncabezado
                //           join c in db.Proveedor on fe.ProveedorId equals c.Id
                //           where fe.Activo == true
                //           orderby fe.Id descending
                //           select new { ProveedorId = c.Id, fe.Id, Nombre = c.Nombre, Descuento = fe.Descuento == null ? Convert.ToDecimal("0.00") : fe.Descuento, fe.Total, fe.Fecha, fe.Hora, fe.Activo });

                this.objVentas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objVentas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());

                if (this.rbEntreFechas.Checked)
                {
                    bus = from x in bus
                          where this.objVentas.FechaInicio <= x.Fecha && x.Fecha <= this.objVentas.FechaFinal
                          select x;
                }
    
                if (this.rbProveedor.Checked)
                {
                    bus = from x in bus
                          where x.ProveedorId == Convert.ToInt32(this.cmbProveedor.SelectedValue.ToString())
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
                        case "Proveedor":
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

                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;
                
                var tot = from t in bus
                          select t.Total;
                decimal total = 0;
                if (tot.Count() > 0)
                {
                    total = tot.Sum();
                }
                

                var des = from t in bus
                          select Convert.ToDecimal(t.Descuento);
                decimal descuento = 0;
                if (des.Count()>0)
                {
                    descuento = des.Sum();
                }


                var imp = from t in bus
                          select Convert.ToDecimal(t.Impuesto);
                decimal impuesto = 0;
                if (imp.Count() > 0)
                {
                    impuesto = imp.Sum();
                }


                MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos,
                    "Total en descuentos: " + descuento.ToString("##,#0.#0"),
                    "Total en impuestos: " + impuesto.ToString("##,#0.#0"),
                    "Total en compras: " + total.ToString("##,#0.#0"), 
                    "",
                    pdReporte, true, true, "LISTADO DE COMPRAS", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

                PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
                printPrvDlg.Height = this.Height;
                printPrvDlg.Width = this.Width;
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
                    pdfTable.WidthPercentage = 95;
                    //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 0;

                    float[] widths = new float[] { 30, 50, 25, 25, 30, 30, 30 };
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
                        string nombre = "LISTADO DE COMPRAS" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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

                            Paragraph Reporte = new Paragraph("LISTADO DE COMPRAS", contentFont);
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

                            decimal total = 0;
                            decimal descuento = 0;
                            decimal impuesto = 0;

                            foreach (DataGridViewRow item in this.dgvDatos.Rows)
                            {
                                total += Convert.ToDecimal(item.Cells[6].Value.ToString());
                                descuento += Convert.ToDecimal(item.Cells[4].Value.ToString());
                                impuesto += Convert.ToDecimal(item.Cells[5].Value.ToString());
                            }
                            Paragraph Descuento = new Paragraph("TOTAL EN DESCUENTOS: " + descuento.ToString("##,#0.#0"), contentFont);
                            Descuento.Alignment = Element.ALIGN_RIGHT;
                            Descuento.IndentationRight = 50;

                            pdfDoc.Add(espacio);

                            pdfDoc.Add(Descuento);

                            Paragraph IMPUESTO = new Paragraph("TOTAL EN IMPUESTOS: " + impuesto.ToString("##,#0.#0"), contentFont);
                            IMPUESTO.Alignment = Element.ALIGN_RIGHT;
                            IMPUESTO.IndentationRight = 50;

                            pdfDoc.Add(espacio);

                            pdfDoc.Add(IMPUESTO);

                            Paragraph TOTAL = new Paragraph("TOTAL EN COMPRAS: " + total.ToString("##,#0.#0"), contentFont);
                            TOTAL.Alignment = Element.ALIGN_RIGHT;
                            TOTAL.IndentationRight = 50;

                            pdfDoc.Add(espacio);

                            pdfDoc.Add(TOTAL);

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

                    xlWorkSheet.Cells[1, 1] = "LISTADO DE COMPRAS";
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

                    decimal total = 0;
                    decimal descuento = 0;
                    decimal impuesto = 0;

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        total += Convert.ToDecimal(item.Cells[6].Value.ToString());
                        descuento += Convert.ToDecimal(item.Cells[4].Value.ToString());
                        impuesto += Convert.ToDecimal(item.Cells[5].Value.ToString());
                    }

                    xlWorkSheet.Cells[i + 8,1] = "TOTAL EN DESCUENTOS: " + descuento.ToString("##,#0.#0");
                    xlWorkSheet.Cells[i + 9,1] = "TOTAL EN IMPUESTOS: " + impuesto.ToString("##,#0.#0");
                    xlWorkSheet.Cells[i + 10,1] = "TOTAL EN COMPRAS: " + total.ToString("##,#0.#0");

                    FolderBrowserDialog file = new FolderBrowserDialog();

                    if (file.ShowDialog() != DialogResult.Cancel)
                    {

                        xlWorkBook.SaveAs(file.SelectedPath + "\\LISTADO DE COMPRAS" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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
            pdReporte.DocumentName = "LISTADO DE COMPRAS";
            pdReporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pdReporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pdReporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pdReporte.DefaultPageSettings.Landscape = false;

            return true;
        }


    }
}
