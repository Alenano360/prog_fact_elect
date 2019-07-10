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
    public partial class Marca_CrearReporte : Form
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        Restaurante_BL.Reporte MyDataGridViewPrinter;
        public string Impresora = string.Empty;
        public int UserIdTemp = 0;
        Marca_Reportes _owner;
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();
        Restaurante_BL.Login objLogin = new Restaurante_BL.Login();
        Restaurante_BL.MarcasPersonal objMarcas = new Restaurante_BL.MarcasPersonal();
        Restaurante_BL.Ticket objTicket = new Restaurante_BL.Ticket();

        public int Accion = 0;

        public Marca_CrearReporte(Marca_Reportes owner)
        {
            InitializeComponent();
            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Marca_CrearReporte_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.objLogin.ObtieneUsuario(this.cmbUsuarios);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar la información de reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                    float[] sglTblHdWidths = new float[7];
                    sglTblHdWidths[0] = 35f;//movimiento40
                    sglTblHdWidths[1] = 35f;//comprobante
                    sglTblHdWidths[2] = 100f;//descripcion
                    sglTblHdWidths[3] = 35f;//monto
                    sglTblHdWidths[4] = 35f;//saldo
                    sglTblHdWidths[5] = 60f;//nombre
                    sglTblHdWidths[6] = 30f;//fecha
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
                        string nombre = "LISTADO DE MARCAS DE EMPLEADOS" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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

                            Paragraph Reporte = new Paragraph("LISTADO DE MARCAS DE EMPLEADOS", contentFont);
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

                    xlWorkSheet.Cells[1, 1] = "LISTADO DE MARCAS DE EMPLEADOS";
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
                            xlWorkSheet.Cells[i + 7, j + 1] = cell.Value.ToString ();
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

                        xlWorkBook.SaveAs(file.SelectedPath + "\\LISTADO DE MARCAS DE EMPLEADOS" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
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

                   Facturacion_Pago . RawPrinterHelper.SendStringToPrinter(Impresora, System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 112, 48, 55, 121 }));//para abrir la caja

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
                this.objTicket.Marcas.Clear();

                if (this.dgvDatos.Rows.Count >0)
                {
                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        DateTime Fecha;
                        TimeSpan Hora_Entrada, Hora_Salida,Total_Horas;

                        Fecha = DateTime .Parse (item.Cells [0].Value .ToString ()).Date ;
                        Hora_Entrada = TimeSpan.Parse(item.Cells[4].Value.ToString());
                        Hora_Salida  = TimeSpan.Parse(item.Cells[5].Value.ToString());
                        Total_Horas  = TimeSpan.Parse(item.Cells[6].Value.ToString());


                        this.objTicket.Marcas.Add(Fecha.ToString("dd/MM/yyyy")   + ";" + item.Cells[2].Value.ToString() + ";"+
                                                  item.Cells[3].Value.ToString() + ";" + string.Format("{0:hh\\:mm}", Hora_Entrada) + ";" +
                                                  string.Format("{0:hh\\:mm}", Hora_Salida) + ";" + string.Format("{0:hh\\:mm}",Total_Horas));

                      //  this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[1].Value.ToString()).ToString("F") + ";" + item.Cells[2].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.AltoPapel += 20;
                    }
                }
                this.objTicket.ObtieneInformacionGeneral();
                this.objTicket.UserId = UserIdTemp;
                this.objTicket.Accion = 5;

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
            pdReporte.DocumentName = "LISTADO DE MARCAS DE EMPLEADOS";
            pdReporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pdReporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pdReporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pdReporte.DefaultPageSettings.Landscape = false;

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                this.OpenConn();

                var bus = (from a in db.Marcas_Personal
                           join u in db.Usuarios on a.Id_Usuario equals u.Id
                           where a.Hora_Salida != null 
                           orderby a.Fecha ascending 
                           select new
                           {
                              Fecha= a.Fecha ,
                               a.Id_Usuario,
                               LoginUsuario = u.Login,
                               NombreEmpleado = (u.Nombre + " " + u.Apellido),
                               Hora_Entrada = new TimeSpan(a.Hora_Entrada.Hours, a.Hora_Entrada.Minutes, a.Hora_Entrada.Seconds),
                               Hora_Salida = a.Hora_Salida,
                               Total_Horas = DateTime.Parse(a.Hora_Salida.ToString()).Subtract(DateTime.Parse(a.Hora_Entrada.ToString()))
                           });

                if (this.rbEntreFechas.Checked)
                {
                    this.objMarcas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                    this.objMarcas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());

                    bus = from x in bus
                          where this.objMarcas.FechaInicio <= Convert.ToDateTime(x.Fecha) && Convert.ToDateTime(x.Fecha) <= this.objMarcas.FechaFinal
                          select x;
                }
                if (this.rbUsuarioEsp.Checked)
                {
                    bus = from x in bus
                          where x.Id_Usuario == Convert.ToInt32(cmbUsuarios.SelectedValue)
                          select x;
                }

                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    switch (this.cmbOrdenar.Text)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Fecha ascending
                                      select x;
                                break;
                            }
                        case "Usuario":
                            {
                                bus = from x in bus
                                      orderby x.LoginUsuario ascending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }
                }
                if (bus.Count()>0)
                {
                    this.dgvDatos.AutoGenerateColumns = false;

                    this.dgvDatos.DataSource = bus;

                    pdReporte.DefaultPageSettings.Landscape = true;

                    MyDataGridViewPrinter = new Restaurante_BL.Reporte(this.dgvDatos, pdReporte, true, true, "LISTADO DE MARCAS DE EMPLEADOS", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

                    PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

                    printPrvDlg.Document = pdReporte;

                    printPreviewControl1.Document = pdReporte;

                    this.Accion = 1;
                }
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

        private void pdReporte_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool mas_paginas = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (mas_paginas == true)
            {
                e.HasMorePages = true;
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
