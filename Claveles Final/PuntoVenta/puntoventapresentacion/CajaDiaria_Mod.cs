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
    public partial class CajaDiaria_Mod : Form
    {
        Sel_Mod _owner;

        PuntoVentaBL.Movimiento objMovimiento = new PuntoVentaBL.Movimiento();
        PuntoVentaBL.CajaDiaria objCajaDiaria = new PuntoVentaBL.CajaDiaria();
        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();
        PuntoVentaDAL.CONEXIONDataContext db = null;


        public decimal SaldoInicial = 0;

        PuntoVentaBL.Reporte MyDataGridViewPrinter;
        public CajaDiaria_Mod(Sel_Mod owner)
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

        private void CajaDiaria_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        public void CajaDiaria_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objMovimiento.ObtieneMovimientos(this.cmbMovimientos);

                this.objCajaDiaria.ObtieneCajaDiaria(this.dgvDatos);

                this.objModulo.ObtieneCajaDiariaBotonesAperturaCierre(this.btnApertura, this.btnCierre);

                this.txtBuscar.Text = string.Empty;

                this.cmbOrdenar.Text = "--Seleccione--";

                //Cambios Realizados 16/12/2015: modifica acceso, botón de cierre de caja inhabilitado
                if (Login.RolId == 4)//facturar
                {
                    btnReportes.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnCierre.Enabled = false;
                }
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
                btnExpXLS_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

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

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //try
                    //{
                    //    Int64 x = Convert.ToInt64(this.txtBuscar.Text);
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Para la búsqueda del comprobante digite únicamente números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.CajaDiaria_Mod_Load(sender, e);
                    //    return;
                    //}
                    if (this.txtBuscar.Text.StartsWith("\r") || this.txtBuscar.Text.StartsWith("\n"))
                    {
                        e.Handled = true;

                        this.txtBuscar.Text = string.Empty;
                        e.SuppressKeyPress = true;
                    }
                    if (this.txtBuscar.Text.Length == 0 || this.txtBuscar.Text == "")
                    {
                        this.objCajaDiaria.ObtieneCajaDiaria(this.dgvDatos);
                        e.Handled = true;

                        this.txtBuscar.Text = string.Empty;
                        e.SuppressKeyPress = true;
                        return;
                    }
                    this.objCajaDiaria.ComprobanteId = (this.txtBuscar.Text);
                    this.objCajaDiaria.ObtieneCajaDiariaBusquedaComprobante(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    this.txtBuscar.Text = string.Empty;
                    e.SuppressKeyPress = true;
                    return;
                }
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

        public void AgregaCajaDiariaCierre()
        {
            try
            {
                this.objCajaDiaria.CierreCajaDiaria(Login.UserId);

                this.objCajaDiaria.ObtieneCajaDiaria(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RealizaCierreCaja()
        {
            try
            {
                this.NuevaVistaCaja();

                this.objModulo.ObtieneCajaDiariaBotonesAperturaCierre(this.btnApertura, this.btnCierre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        public void btnExpPDF_Click()
        {
            try
            {
                PdfPTable pdfTable = new PdfPTable(this.dgvDatos.ColumnCount - 3);

                pdfTable.HeaderRows = 1;


                //pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 93;
                //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 0;

                float[] widths = new float[] { 25, 30, 70, 25, 25, 40, 20, 20 };
                pdfTable.SetWidths(widths);

                int limite = 1;
                //Adding Header row
                foreach (DataGridViewColumn column in this.dgvDatos.Columns)
                {
                    if (column.Index < 8)
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
                    limite++;
                }
                iTextSharp.text.Font celdas = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 14, iTextSharp.text.Font.NORMAL);
                //Adding DataRow
                foreach (DataGridViewRow row in this.dgvDatos.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex < 8)
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
                }


                //Apertura
                //Venta
                //Compra
                //Retiro
                //Cobranza
                //Reintegro
                //Devolucion
                //Cierre
                //Gasto
                //Deposito




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
                        //Paragraph fax = new Paragraph("FAX: " + bus.First().Fax.ToString(), contentFont2);
                        //fax.Alignment = Element.ALIGN_CENTER;
                        Paragraph espacio = new Paragraph("    ", contentFont2);

                        pdfDoc.Add(titulo);
                        pdfDoc.Add(Reporte);
                        pdfDoc.Add(telefono);
                        //pdfDoc.Add(fax);
                        pdfDoc.Add(espacio);

                        pdfDoc.Add(pdfTable);

                        this.OpenConn();
                        decimal sumas = 0;
                        decimal restas = 0;

                        var suma = from x in db.CajaDiarias
                                   where x.Activo == true && x.Visible == true && (x.MovimientoId == 2 || x.MovimientoId == 5 || x.MovimientoId == 6 || x.MovimientoId == 10)
                                   select x.Monto;

                        if (suma.Count() > 0)
                        {
                            sumas = suma.Sum();
                        }

                        var resta = from x in db.CajaDiarias
                                    where x.Activo == true && x.Visible == true && (x.MovimientoId == 3 || x.MovimientoId == 4 || x.MovimientoId == 7 || x.MovimientoId == 9)
                                    select x.Monto;

                        if (resta.Count() > 0)
                        {
                            restas = resta.Sum();
                        }

                        var apertura = (from x in db.CajaDiarias
                                        where x.Activo == true && x.Visible == true && x.MovimientoId == 1
                                        select x).First();


                        decimal total = apertura.Saldo + sumas - restas;

                        Paragraph Ganancia = new Paragraph("TOTAL CAJA DIARIA: " + total.ToString("##,#0.#0"), contentFont);
                        Ganancia.Alignment = Element.ALIGN_RIGHT;
                        Ganancia.IndentationRight = 50;

                        pdfDoc.Add(espacio);

                        pdfDoc.Add(Ganancia);


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
                //xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                //xlWorkSheet.Cells[4, 1].Font.Size = 12;

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


                this.OpenConn();
                decimal sumas = 0;
                decimal restas = 0;

                var suma = from x in db.CajaDiarias
                           where x.Activo == true && x.Visible == true && (x.MovimientoId == 2 || x.MovimientoId == 5 || x.MovimientoId == 6 || x.MovimientoId == 10)
                           select x.Monto;

                if (suma.Count() > 0)
                {
                    sumas = suma.Sum();
                }

                var resta = from x in db.CajaDiarias
                            where x.Activo == true && x.Visible == true && (x.MovimientoId == 3 || x.MovimientoId == 4 || x.MovimientoId == 7 || x.MovimientoId == 9)
                            select x.Monto;

                if (resta.Count() > 0)
                {
                    restas = resta.Sum();
                }

                var apertura = (from x in db.CajaDiarias
                                where x.Activo == true && x.Visible == true && x.MovimientoId == 1
                                select x).First();


                decimal total = apertura.Saldo + sumas - restas;

                xlWorkSheet.Cells[i + 8, 1] = "TOTAL CAJA DIARIA: " + total.ToString("##,#0.#0");
                xlWorkSheet.Cells[i + 8, 1].Font.Size = 12;

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

        private void btnArqueo_Click(object sender, EventArgs e)
        {
            try
            {
                CajaDiaria_Arqueo arqueo = new CajaDiaria_Arqueo(this);
                arqueo.TopLevel = false;
                arqueo.Parent = this;
                arqueo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar acceder al arqueo de la caja: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    if (this.dgvDatos.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un registro", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //if (Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[0].Value) != 4 && Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[0].Value) != 6)
                    //{
                    //    MessageBox.Show("Seleccione un registro de retiro o de reintegro de dinero", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    if (Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[9].Value) == 1)
                    {
                        MessageBox.Show("No puede eliminar el registro de apertura de caja", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.dgvDatos.SelectedRows.Count > 0)
                        {
                            //if (Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value) == 4)
                            //{

                            //    return;
                            //}
                            //if (Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value) == 6)
                            //{

                            //    return;
                            //}
                            this.objCajaDiaria.Id = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[10].Value);

                            this.objCajaDiaria.EliminaRegistroCajaDiara();

                            this.objCajaDiaria.ObtieneCajaDiaria(this.dgvDatos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el registro de la caja: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
