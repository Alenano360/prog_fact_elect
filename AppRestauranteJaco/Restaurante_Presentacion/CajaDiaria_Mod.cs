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
    public partial class CajaDiaria_Mod : Form
    {
        Principal _owner;
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();
        Restaurante_BL.CajaDiaria objCajaDiaria = new Restaurante_BL.CajaDiaria();
        Restaurante_BL.Movimiento objMovimiento = new Restaurante_BL.Movimiento();
        Restaurante_BL.ModuloPrincipal objModulo = new Restaurante_BL.ModuloPrincipal();

        Restaurante_DAL.BaseDatosDataContext db = null;


        public decimal SaldoInicial = 0;

        Restaurante_BL.Reporte MyDataGridViewPrinter;

        public CajaDiaria_Mod(Principal owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Principal_Load(sender, e);
        }
        public void CajaDiaria_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.objMovimiento.ObtieneMovimientos(this.cmbMovimientos);

               this.objCajaDiaria.ObtieneCajaDiaria(this.dgvDatos);

                this.objModulo.ObtieneCajaDiariaBotonesAperturaCierre(this.btnApertura, this.btnCierre);

                this.cmbOrdenar.Text = "--Seleccione--";

                this.txtBuscar.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RealizaCierreCaja()
        {
            try
            {
                this.objCajaDiaria.CierreCajaDiaria(Login.UserId);

                this.objMovimiento.ObtieneMovimientos(this.cmbMovimientos);

                this.objCajaDiaria.ObtieneCajaDiaria(this.dgvDatos);

                this.NuevaVistaCaja();

                this.objModulo.ObtieneCajaDiariaBotonesAperturaCierre(this.btnApertura, this.btnCierre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void RealizaAperturaCaja()
        {
            try
            {
                this.objCajaDiaria.Saldo = SaldoInicial;

                this.objCajaDiaria.AperturaCajaDiaria(Login.UserId);

                this.objMovimiento.ObtieneMovimientos(this.cmbMovimientos);

                this.objCajaDiaria.ObtieneCajaDiaria(this.dgvDatos);

                this.objModulo.ObtieneCajaDiariaBotonesAperturaCierre(this.btnApertura, this.btnCierre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CajaDiaria_Mod_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {

            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        Int64 x = Convert.ToInt64(this.txtBuscar.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Para la búsqueda del comprobante digite únicamente números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.CajaDiaria_Mod_Load(sender, e);
                        return;
                    }
                    if (this.txtBuscar.Text.Length == 0 || Convert.ToInt64(this.txtBuscar.Text) == 0 || this.txtBuscar.Text == "")
                    {
                        this.txtBuscar.Text = string.Empty;
                        return;
                    }
                    this.objCajaDiaria.ComprobanteId = Convert.ToInt64(this.txtBuscar.Text);
                    this.objCajaDiaria.ObtieneCajaDiariaBusquedaComprobante(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.objCajaDiaria.MovimientoId = Convert.ToInt32(this.cmbMovimientos.SelectedValue.ToString());
                this.objCajaDiaria.ObtieneCajaDiariaBusquedaMovimiento(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrdenar.Text == "--Seleccione--")
                {
                    this.CajaDiaria_Mod_Load(sender, e);
                    return;
                }
                this.objCajaDiaria.Descripcion = this.cmbOrdenar.Text;
                this.objCajaDiaria.ObtieneCajaDiariaOrdenada(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.CajaDiaria_Mod_Load(sender, e);
            }
            catch (Exception)
            {
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }
                CajaDiaria_Mantenimiento mantenimiento = new CajaDiaria_Mantenimiento(this);
                mantenimiento.TopLevel = false;
                mantenimiento.Parent = this;
                mantenimiento.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar un movimiento a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApertura_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show("¿Está seguro que desea realizar la apertura de la caja?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {

                    //this.RealizaAperturaCaja();
                    Apertura apertura = new Apertura(this);
                    apertura.TopLevel = false;
                    apertura.Parent = this;
                    apertura.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar la apertura a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == MessageBox.Show("¿Está seguro que desea realizar el cierre de la caja?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    Cierre cierre = new Cierre(this);
                    cierre.TopLevel = false;
                    cierre.Parent = this;
                    cierre.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                CajaDiaria_Reportes rep = new CajaDiaria_Reportes(this);
                rep.TopLevel = false;
                rep.Parent = this;
                rep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CajaDiaria_Detalle Detalle = new CajaDiaria_Detalle(this);
                Detalle.TopLevel = false;
                Detalle.Parent = this;
                Detalle.Movimiento = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[9].Value.ToString());
                Detalle.Comprobante = this.dgvDatos.CurrentRow.Cells[1].Value.ToString();
                Detalle.Descripcion = this.dgvDatos.CurrentRow.Cells[2].Value.ToString();
                Detalle.Monto = this.dgvDatos.CurrentRow.Cells[3].Value.ToString();
                Detalle.Saldo = this.dgvDatos.CurrentRow.Cells[4].Value.ToString();
                if (this.dgvDatos.CurrentRow.Cells[8].Value == null)
                {
                    Detalle.AutorizadoPor = 0;
                }
                else
                {
                    Detalle.AutorizadoPor = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[8].Value.ToString());
                }
                Detalle.Fecha = this.dgvDatos.CurrentRow.Cells[6].Value.ToString();
                Detalle.Hora = this.dgvDatos.CurrentRow.Cells[7].Value.ToString();
                Detalle.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el detalle de la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnExpPDF_Click()
        {
            try
            {
                PdfPTable pdfTable = new PdfPTable(this.dgvDatos.ColumnCount - 3);
                //pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 93;
                //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 0;

                int limite = 1;
                //Adding Header row
                foreach (DataGridViewColumn column in this.dgvDatos.Columns)
                {
                    if (column.Index < 8)
                    {
                        iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 16, iTextSharp.text.Font.BOLD);
                        Paragraph HEADERTEXT = new Paragraph(column.HeaderText, contentFont);
                        HEADERTEXT.Alignment = Element.ALIGN_CENTER;

                        PdfPCell cell = new PdfPCell(HEADERTEXT);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(cell);
                    }
                    limite++;
                }

                //Adding DataRow
                foreach (DataGridViewRow row in this.dgvDatos.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex < 8)
                        {
                            if (cell.Value != null)
                            {
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                            else
                            {
                                pdfTable.AddCell("");
                            }
                        }
                    }
                }
                //Exporting to PDF

                FolderBrowserDialog file = new FolderBrowserDialog();

                if (file.ShowDialog() != DialogResult.Cancel)
                {
                    string folderPath = file.SelectedPath + "\\";
                    string nombre = "INFORMACION DE CIERRE DE CAJA" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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

                        Paragraph Reporte = new Paragraph("INFORMACION DE CIERRE DE CAJA", contentFont);
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

        public void btnExpXLS_Click()
        {
            try
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

                xlWorkSheet.Cells[1, 1] = "INFORMACION DE CIERRE DE CAJA";
                xlWorkSheet.Cells[1, 1].Font.Size = 16;
                xlWorkSheet.Cells[2, 1] = bus.First().Nombre.ToString();
                xlWorkSheet.Cells[2, 1].Font.Size = 16;

                xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                xlWorkSheet.Cells[3, 1].Font.Size = 12;
                xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                xlWorkSheet.Cells[4, 1].Font.Size = 12;

                xlWorkSheet.Cells[5, 1] = "    ";


                this.CloseConn();


                for (int t = 1; t < (this.dgvDatos.Columns.Count - 3) + 1; t++)
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
                    for (j = 0; j <= (this.dgvDatos.Columns.Count - 3) - 1; j++)
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

                    xlWorkBook.SaveAs(file.SelectedPath + "\\INFORMACION DE CIERRE DE CAJA" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar exportar el documento a Excel: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void limpiadatagrid()
        {
            this.dgvDatos.DataSource = null;
        }

        public void NuevaVistaCaja()
        {
            try
            {
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    this.objCajaDiaria.Id = Convert.ToInt64(item.Cells[10].Value.ToString());

                    this.objCajaDiaria.ApagaCajaDiaria();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
