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
    public partial class Inventario_Reportes : Form
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        PuntoVentaBL.Reporte MyDataGridViewPrinter;

        Inventario_Mod _owner;

        public int NFamiliaId = 0;

        public int Accion = 0;

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        PuntoVentaBL.Ubicacion objUbicacion = new PuntoVentaBL.Ubicacion();

        

        public Inventario_Reportes(Inventario_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Inventario_Reportes_Load(object sender, EventArgs e)
        {
            try
            {
                this.objInventario.ObtieneFamilia(this.cmbFamilias);

                this.objUbicacion.ObtieneUbicacionesCombo(this.cmbUbicacion);

                this.objInventario.ObtieneProveedores(this.cmd_proveedor);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar la información de reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inventario_Reportes_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);      
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscaFamilia_Click(object sender, EventArgs e)
        {
            Sel_Familia FamiliaAsignar = new Sel_Familia(this);
            FamiliaAsignar.TopLevel = false;
            FamiliaAsignar.Parent = this;
            FamiliaAsignar.tipo = 1;
            FamiliaAsignar.Show();
        }

        public void CambiaFamilia()
        {
            try
            {
                this.cmbFamilias.SelectedValue = NFamiliaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                pdReporte.DefaultPageSettings.Landscape = true;

                this.OpenConn();

                
                var inventariovalorizado = (from x in db.Articulo
                               join p in db.Proveedors on x.ProveedorId equals p.Id
                               join f in db.Familias on x.FamiliaId equals f.Id
                               where x.Activo == true
                               select new
                               {
                                   x.Codigo,
                                   Articulo = x.Descripcion.PadRight(55).Substring(0, 54).Trim(),
                                   Proveedor = p.Nombre,
                                   x.FamiliaId,
                                   Familia = f.Descripcion,
                                   x.Existencias,
                                   x.Precio,
                                   x.Precio2,
                                   x.PrecioIVU,
                                   x.Precio2IVU,
                                   x.ProveedorId,
                                   x.UtilidadPrecio
                               });

                    if (this.chkInventarioValorizado.Checked)
                    {
                        if (this.rbListaPrecios1.Checked)
	                    {

                            if (this.rbPrecioCosto.Checked)
                            {
                                var invn = (from x in inventariovalorizado
                                            join a in db.Articulo on x.Codigo equals a.Codigo
                                            where a.Activo == true
                                            orderby x.Existencias descending
                                            select new
                                            {
                                                x.Codigo,
                                                x.Articulo,
                                                x.Proveedor,
                                                x.Familia,
                                                x.Existencias,
                                                Precio = x.Precio,
                                                ValorTotal = (x.Existencias * x.Precio).ToString(),
                                                x.UtilidadPrecio
                                            });



                                this.dgvDatos2.AutoGenerateColumns = false;
                                this.dgvDatos2.DataSource = invn;
                            }

                            if (this.rbPrecioVenta.Checked)
                            {
                                var invn = (from x in inventariovalorizado
                                            join a in db.Articulo on x.Codigo equals a.Codigo
                                            where a.Activo == true
                                            orderby x.Existencias descending
                                            select new
                                            {
                                                x.Codigo,
                                                x.Articulo,
                                                x.Proveedor,
                                                x.Familia,
                                                x.Existencias,
                                                Precio = x.PrecioIVU,
                                                ValorTotal = (x.Existencias * x.PrecioIVU).ToString(),
                                                x.UtilidadPrecio
                                            });



                                this.dgvDatos2.AutoGenerateColumns = false;
                                this.dgvDatos2.DataSource = invn;
                            }


 
                            decimal valortotal = 0;

                            foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                            {
                                valortotal += Convert.ToDecimal(item.Cells[6].Value);
                            }

                            MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos2, "VALOR TOTAL DEL INVENTARIO: " + Convert.ToDecimal(valortotal).ToString("##,#0.#0"), "", "", "", pdReporte, true, true, "LISTADO DE INVENTARIO VALORIZADO", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

                            PrintPreviewDialog printPrvDlg2 = new PrintPreviewDialog();

                            printPrvDlg2.Document = pdReporte;

                            printPreviewControl1.Document = pdReporte;

                            this.Accion = 1;
	                    }
                        if (this.rbListaPrecios2.Checked)
                        {
                            if (this.rbPrecioCosto.Checked)
                            {
                                var invn = (from x in inventariovalorizado
                                            join a in db.Articulo on x.Codigo equals a.Codigo
                                            where a.Activo == true
                                            orderby x.Existencias descending
                                            select new
                                            {
                                                x.Codigo,
                                                x.Articulo,
                                                x.Proveedor,
                                                x.Familia,
                                                x.Existencias,
                                                Precio = x.Precio2,
                                                ValorTotal = (x.Existencias * x.Precio2).ToString(),
                                                x.UtilidadPrecio
                                            });



                                this.dgvDatos2.AutoGenerateColumns = false;
                                this.dgvDatos2.DataSource = invn;
                            }

                            if (this.rbPrecioVenta.Checked)
                            {
                                var invn = (from x in inventariovalorizado
                                            join a in db.Articulo on x.Codigo equals a.Codigo
                                            where a.Activo == true
                                            orderby x.Existencias descending
                                            select new
                                            {
                                                x.Codigo,
                                                x.Articulo,
                                                x.Proveedor,
                                                x.Familia,
                                                x.Existencias,
                                                Precio = x.Precio2IVU,
                                                ValorTotal = (x.Existencias * x.Precio2IVU).ToString(),
                                                x.UtilidadPrecio
                                            });



                                this.dgvDatos2.AutoGenerateColumns = false;
                                this.dgvDatos2.DataSource = invn;
                            }


                            decimal valortotal = 0;

                            foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                            {
                                valortotal += Convert.ToDecimal(item.Cells[6].Value);
                            }

                            MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos2, "VALOR TOTAL DEL INVENTARIO: " + Convert.ToDecimal(valortotal).ToString("##,#0.#0"), "", "", "", pdReporte, true, true, "LISTADO DE INVENTARIO VALORIZADO", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

                            PrintPreviewDialog printPrvDlg3 = new PrintPreviewDialog();

                            printPrvDlg3.Document = pdReporte;

                            printPreviewControl1.Document = pdReporte;

                            this.Accion = 1;
                        }

                        return;
                    }

                    if (this.rbGananciaArticulo.Checked)
                    {
                        if (this.rbEntreFechas.Checked)
                        {
                            var busGanancia = from g in db.ObtieneGanancias_SP(Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString()), Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString()))
                                              select g;

                            this.dgvDatos3.AutoGenerateColumns = false;
                            this.dgvDatos3.DataSource = busGanancia.ToList();
                        }
                        else
                        {
                            var busGanancia = (from g in db.ObtieneGanancias
                                               //where g.Ganancia > 0
                                               orderby g.Ganancia descending
                                               select new { g.Codigo, g.Articulo, g.Proveedor, g.Familia, g.Ganancia });

                            this.dgvDatos3.AutoGenerateColumns = false;
                            this.dgvDatos3.DataSource = busGanancia;
                        }


                        decimal ganancia = 0;
                        foreach (DataGridViewRow item in this.dgvDatos3.Rows)
                        {
                            ganancia += Convert.ToDecimal(item.Cells[4].Value);
                        }



                        MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos3,"GANANCIA TOTAL DE ARTICULOS: " +ganancia.ToString("##,#0.#0"),"","","", pdReporte, true, true, "LISTADO DE GANANCIA POR ARTICULOS", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

                        PrintPreviewDialog printPrvDlg3 = new PrintPreviewDialog();

                        printPrvDlg3.Document = pdReporte;

                        printPreviewControl1.Document = pdReporte;

                        this.Accion = 1;

                        return;
                    }

                    var bus = (from x in db.Articulo
                               join p in db.Proveedors on x.ProveedorId equals p.Id into pp from p in pp.DefaultIfEmpty()
                               join f in db.Familias on x.FamiliaId equals f.Id into pf from f in pf.DefaultIfEmpty()
                               join u in db.Ubicacions on x.UbicacionId equals u.Id  into pu from u in pu.DefaultIfEmpty()
                               where x.Activo == true
                               select new
                               {
                                   x.Codigo,
                                   Articulo = x.Descripcion.PadRight(64).Substring(0, 54).Trim(),
                                   Proveedor = p.Nombre,
                                   x.FamiliaId,
                                   Familia = f.Descripcion,
                                   x.UbicacionId,
                                   u.Ubicacion1,
                                   x.Existencias,
                                   x.Precio,
                                   x.PrecioIVU,
                                   x.Precio2,
                                   x.Precio2IVU,
                                   x.ProveedorId,
                                   x.ArtConsignacion,
                                   x.UtilidadPrecio
                               });

                    if (this.rbFamiliaIndividual.Checked)
                    {
                        bus = from x in bus
                              where x.FamiliaId == Convert.ToInt32(this.cmbFamilias.SelectedValue.ToString())
                              select x;
                    }

                    if (this.rbXUbicacion.Checked)
                    {
                        this.dgvDatos.Columns[3].HeaderText = "Ubicación"; ;
                        this.dgvDatos.Columns[3].DataPropertyName = "Ubicacion1";
                    }

                    if (this.rbUbicacion.Checked)
                    {
                        this.dgvDatos.Columns[3].HeaderText = "Ubicación";
                        this.dgvDatos.Columns[3].DataPropertyName = "Ubicacion1";

                        if (this.cmbUbicacion.Text.Length>0)
                        {
                            bus = from x in bus
                                  where x.UbicacionId == Convert.ToInt32(this.cmbUbicacion.SelectedValue)
                                  select x;
                        }
                    }

                    if (this.rbProveedor.Checked)
                    {
                        this.dgvDatos.Columns[3].HeaderText = "Proveedor";
                        this.dgvDatos.Columns[3].DataPropertyName = "ProveedorId";

                        if (this.cmd_proveedor.Text.Length > 0)
                        {
                            bus = from x in bus
                                  where x.ProveedorId == Convert.ToInt32(this.cmd_proveedor.SelectedValue)
                                  select x;
                        }
                    }
                    if (this.rbNoUbicacion.Checked)
                    {
                        this.dgvDatos.Columns[3].HeaderText = "Familia";
                        this.dgvDatos.Columns[3].DataPropertyName = "Familia";
                    }

                    if (this.rbArtConExistencia.Checked)
                    {
                        bus = from x in bus
                              where x.Existencias > 0
                              select x;
                    }

                    if (this.rbExistencia0.Checked)
                    {
                        bus = from x in bus
                              where x.Existencias == 0
                              select x;                        
                    }

                    if (this.rbArticulosConsignacion.Checked)
                    {
                        bus = from x in bus
                              where x.ArtConsignacion == true
                              select x;
                    }

                    if (this.cmbOrdenar.Text != "--Seleccione--")
                    {
                        switch (this.cmbOrdenar.Text)
                        {
                            case "Codigo":
                                {
                                    bus = from x in bus
                                          orderby x.Codigo descending
                                          select x;
                                    break;
                                }
                            case "Descripcion":
                                {
                                    bus = from x in bus
                                          orderby x.Articulo descending
                                          select x;
                                    break;
                                }
                            case "Proveedor":
                                {
                                    bus = from x in bus
                                          orderby x.ProveedorId descending
                                          select x;
                                    break;
                                }
                            case "Familia":
                                {
                                    bus = from x in bus
                                          orderby x.FamiliaId descending
                                          select x;
                                    break;
                                }
                            case "Existencia":
                                {
                                    bus = from x in bus
                                          orderby x.Existencias descending
                                          select x;
                                    break;
                                }
                            case "Precio":
                                {
                                    if (this.rbListaPrecios1.Checked)
                                    {
                                        bus = from x in bus
                                              orderby x.Precio descending
                                              select x;
                                    }
                                    if (this.rbListaPrecios2.Checked)
                                    {
                                        bus = from x in bus
                                              orderby x.Precio2 descending
                                              select x;
                                    }
                                    break;
                                }
                            case "Precio Final":
                                {
                                    if (this.rbListaPrecios1.Checked)
                                    {
                                        bus = from x in bus
                                              orderby x.PrecioIVU descending
                                              select x;
                                    }
                                    if (this.rbListaPrecios2.Checked)
                                    {
                                        bus = from x in bus
                                              orderby x.Precio2IVU descending
                                              select x;
                                    }
                                    break;
                                }

                            default:
                                break;
                        }
                    }
                    if (this.rbListaPrecios1.Checked)
                    {
                        this.dgvDatos.Columns[5].Visible = true;
                        this.dgvDatos.Columns[6].Visible = true;

                        //this.dgvDatos.Columns.Remove(this.dgvDatos.Columns[7]);
                        //this.dgvDatos.Columns.Remove(this.dgvDatos.Columns[8]);

                        this.dgvDatos.Columns[7].Visible = false;
                        this.dgvDatos.Columns[8].Visible = false;
                    }
                    if (this.rbListaPrecios2.Checked)
                    {
                        this.dgvDatos.Columns[5].Visible = false;
                        this.dgvDatos.Columns[6].Visible = false;
                        //this.dgvDatos.Columns.Remove(this.dgvDatos.Columns[5]);
                        //this.dgvDatos.Columns.Remove(this.dgvDatos.Columns[6]);

                        this.dgvDatos.Columns[7].Visible = true;
                        this.dgvDatos.Columns[8].Visible = true;
                    }

                        this.dgvDatos.AutoGenerateColumns = false;
                        this.dgvDatos.DataSource = bus;
                

                    MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos, pdReporte, true, true, "LISTADO DE INVENTARIO", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

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

        PdfPTable pdfTable;

        private void btnExpPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == 1)
                {
                    if (this.chkInventarioValorizado.Checked == false && this.rbGananciaArticulo.Checked==false)
                    {
                         pdfTable= new PdfPTable(this.dgvDatos.ColumnCount);

                         pdfTable.HeaderRows = 1;
                        //pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 95;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 0;

                        float[] widths = new float[] { 30, 105, 45, 20, 20, 20, 20, 20, 25 };
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
                                    //70
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
                    if(this.rbGananciaArticulo.Checked) 
                    {
                        pdfTable = new PdfPTable(this.dgvDatos3.ColumnCount);
                        pdfTable.HeaderRows = 1;
                        //pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 93;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 0;

                        float[] widths = new float[] { 25, 100, 45, 20, 20 };
                        pdfTable.SetWidths(widths);

                        //Adding Header row
                        foreach (DataGridViewColumn column in this.dgvDatos3.Columns)
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
                        foreach (DataGridViewRow row in this.dgvDatos3.Rows)
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
                                    pdfTable.AddCell("");
                                }

                            }
                        }
                    }
                    if (this.chkInventarioValorizado.Checked)
                    {
                        pdfTable = new PdfPTable(this.dgvDatos2.ColumnCount);
                        pdfTable.HeaderRows = 1;
                        //pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 93;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 0;


                        float[] widths = new float[] { 30, 105, 40, 20, 20, 20, 20 };
                        pdfTable.SetWidths(widths);

                        //Adding Header row
                        foreach (DataGridViewColumn column in this.dgvDatos2.Columns)
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
                        foreach (DataGridViewRow row in this.dgvDatos2.Rows)
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
                                    pdfTable.AddCell("");
                                }

                            }
                        }
                    }
                    
                    //Exporting to PDF

                    FolderBrowserDialog file = new FolderBrowserDialog();
;
                    if (file.ShowDialog() != DialogResult.Cancel)
                    {
                        string folderPath = file.SelectedPath + "\\";
                        string nombre = "LISTADO DE INVENTARIO" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        using (FileStream stream = new FileStream(folderPath + nombre, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 10f);

                            if (this.chkInventarioValorizado.Checked == false && this.rbGananciaArticulo.Checked == false)
                            {
                                pdfDoc = new Document(PageSize.A2.Rotate(), 10f, 10f, 10f, 10f);
                            }
                            if (this.rbGananciaArticulo.Checked)
                            {
                                pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 10f);
                            }
                            if (this.chkInventarioValorizado.Checked)
                            {
                                pdfDoc = new Document(PageSize.A2.Rotate(), 10f, 10f, 10f, 10f);
                            }
                            
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            this.OpenConn();
                            var bus = from x in db.InformacionGeneral
                                      select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax) };


                            iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font contentFont2 = iTextSharp.text.FontFactory.GetFont("Microsoft Sans Serif", 12, iTextSharp.text.Font.NORMAL);

                            Paragraph Reporte = new Paragraph("LISTADO DE INVENTARIO", contentFont);
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
                            if (this.rbGananciaArticulo.Checked)
                            {
                                decimal ganancia = 0;
                                foreach (DataGridViewRow item in this.dgvDatos3.Rows)
                                {
                                    ganancia += Convert.ToDecimal(item.Cells[4].Value);
                                }
                                Paragraph Ganancia = new Paragraph("GANANCIA TOTAL DE ARTICULOS: " + ganancia.ToString("##,#0.#0"), contentFont);
                                Ganancia.Alignment = Element.ALIGN_RIGHT;
                                Ganancia.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(Ganancia);
                            }

                            if (this.chkInventarioValorizado.Checked)
                            {
                                decimal valortotal = 0;

                                foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                                {
                                    valortotal += Convert.ToDecimal(item.Cells[6].Value);
                                }
                                Paragraph Ganancia = new Paragraph("VALOR TOTAL DEL INVENTARIO: " + valortotal.ToString("##,#0.#0"), contentFont);
                                Ganancia.Alignment = Element.ALIGN_RIGHT;
                                Ganancia.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(Ganancia);
                            }

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

                    xlWorkSheet.Cells[1, 1] = "LISTADO DE INVENTARIO";
                    xlWorkSheet.Cells[1, 1].Font.Size = 16;
                    xlWorkSheet.Cells[2, 1] = bus.First().Nombre.ToString();
                    xlWorkSheet.Cells[2, 1].Font.Size = 16;

                    //xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                    //xlWorkSheet.Cells[3, 1].Font.Size = 12;

                    xlWorkSheet.Cells[3, 1] = "    ";


                    this.CloseConn();

                    if (this.chkInventarioValorizado.Checked == false && this.rbGananciaArticulo.Checked == false)
                    {
                        for (int t = 1; t < this.dgvDatos.Columns.Count + 1; t++)
                        {
                            xlWorkSheet.Cells[4, t] = this.dgvDatos.Columns[t - 1].HeaderText;
                            xlWorkSheet.Cells[4, t].Font.Size = 16;
                            xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                            xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                            xlWorkSheet.Cells[4, t].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            xlWorkSheet.Cells[4, t].Rows.AutoFit();
                            xlWorkSheet.Cells[4, t].Columns.AutoFit();

                            intx++;
                        }

                        for (i = 0; i <= this.dgvDatos.RowCount - 1; i++)
                        {
                            //inty = 0;
                            for (j = 0; j <= this.dgvDatos.ColumnCount - 1; j++)
                            {
                                DataGridViewCell cell = this.dgvDatos[j, i];
                                xlWorkSheet.Cells[i + 5, j + 1] = cell.Value;
                                xlWorkSheet.Cells[i + 5, j + 1].Font.Size = 12;
                                xlWorkSheet.Cells[i + 5, j + 1].HorizontalAlignment =Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                xlWorkSheet.Cells[i + 5, j + 1].Rows.AutoFit();
                                xlWorkSheet.Cells[i + 5, j + 1].Columns.AutoFit();
                                inty++;
                            }
                            intx++;
                        }

                    }
                    if (this.chkInventarioValorizado.Checked)                    
                    {
                        for (int t = 1; t < this.dgvDatos2.Columns.Count + 1; t++)
                        {
                            xlWorkSheet.Cells[4, t] = this.dgvDatos2.Columns[t - 1].HeaderText;
                            xlWorkSheet.Cells[4, t].Font.Size = 16;
                            xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                            xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                            xlWorkSheet.Cells[4, t].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            xlWorkSheet.Cells[4, t].Rows.AutoFit();
                            xlWorkSheet.Cells[4, t].Columns.AutoFit();

                            intx++;
                        }

                        for (i = 0; i <= this.dgvDatos2.RowCount - 1; i++)
                        {
                            //inty = 0;
                            for (j = 0; j <= this.dgvDatos2.ColumnCount - 1; j++)
                            {
                                DataGridViewCell cell = this.dgvDatos2[j, i];
                                xlWorkSheet.Cells[i + 5, j + 1] = cell.Value;
                                xlWorkSheet.Cells[i + 5, j + 1].Font.Size = 12;
                                xlWorkSheet.Cells[i + 5, j + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                xlWorkSheet.Cells[i + 5, j + 1].Rows.AutoFit();
                                xlWorkSheet.Cells[i + 5, j + 1].Columns.AutoFit();
                                inty++;
                            }
                            intx++;
                        }
                    }

                    if (this.rbGananciaArticulo.Checked)
                    {
                        for (int t = 1; t < this.dgvDatos3.Columns.Count + 1; t++)
                        {
                            xlWorkSheet.Cells[4, t] = this.dgvDatos3.Columns[t - 1].HeaderText;
                            xlWorkSheet.Cells[4, t].Font.Size = 16;
                            xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                            xlWorkSheet.Cells[4, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                            xlWorkSheet.Cells[4, t].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            xlWorkSheet.Cells[4, t].Rows.AutoFit();
                            xlWorkSheet.Cells[4, t].Columns.AutoFit();

                            intx++;
                        }

                        for (i = 0; i <= this.dgvDatos3.RowCount - 1; i++)
                        {
                            //inty = 0;
                            for (j = 0; j <= this.dgvDatos3.ColumnCount - 1; j++)
                            {
                                DataGridViewCell cell = this.dgvDatos3[j, i];
                                xlWorkSheet.Cells[i + 5, j + 1] = cell.Value;
                                xlWorkSheet.Cells[i + 5, j + 1].Font.Size = 12;
                                xlWorkSheet.Cells[i + 5, j + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                xlWorkSheet.Cells[i + 5, j + 1].Rows.AutoFit();
                                xlWorkSheet.Cells[i + 5, j + 1].Columns.AutoFit();
                                inty++;
                            }
                            intx++;
                        }
                    }

                    Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[4, 1];
                    Excel.Range c2 = (Excel.Range)xlWorkSheet.Cells[intx, inty];
                    Excel.Range range = xlWorkSheet.get_Range(c1, c2);


                    range.Rows.AutoFit();
                    range.Columns.AutoFit();

                    if (this.rbGananciaArticulo.Checked)
                    {
                        decimal ganancia = 0;
                        foreach (DataGridViewRow item in this.dgvDatos3.Rows)
                        {
                            ganancia += Convert.ToDecimal(item.Cells[4].Value);
                        }
                        xlWorkSheet.Cells[i + 6, 1] = "GANANCIA TOTAL DE ARTICULOS: " + ganancia.ToString("##,#0.#0");
                        xlWorkSheet.Cells[i + 6, 1].Font.Size = 14;
                        xlWorkSheet.Cells[i + 6, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    }

                    if (this.chkInventarioValorizado.Checked)
                    {
                        decimal valortotal = 0;

                        foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                        {
                            valortotal += Convert.ToDecimal(item.Cells[6].Value);
                        }
                        xlWorkSheet.Cells[i + 6, 1] = "VALOR TOTAL DEL INVENTARIO: " + valortotal.ToString("##,#0.#0");
                        xlWorkSheet.Cells[i + 6, 1].Font.Size = 14;
                        xlWorkSheet.Cells[i + 6, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    }

                    FolderBrowserDialog file = new FolderBrowserDialog();

                    if (file.ShowDialog() != DialogResult.Cancel)
                    {

                        xlWorkBook.SaveAs(file.SelectedPath + "\\LISTADO DE INVENTARIO" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);

                        MessageBox.Show("Archivo creado con éxito!");

                        System.Diagnostics.Process.Start(@file.SelectedPath);
                    }
                }


                //if (Accion == 1)
                //{
                //    int intx = 0;
                //    int inty = 0;
                //    Excel.Application xlApp;
                //    Excel.Workbook xlWorkBook;
                //    Excel.Worksheet xlWorkSheet;
                //    object misValue = System.Reflection.Missing.Value;

                //    xlApp = new Excel.Application();
                //    xlWorkBook = xlApp.Workbooks.Add(misValue);
                //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //    int i = 0;
                //    int j = 0;

                //    this.OpenConn();
                //    var bus = from x in db.InformacionGeneral
                //              select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax) };

                //    xlWorkSheet.Cells[1, 1] = "LISTADO DE INVENTARIO";
                //    xlWorkSheet.Cells[1, 1].Font.Size = 16;
                //    xlWorkSheet.Cells[2, 1] = bus.First().Nombre.ToString();
                //    xlWorkSheet.Cells[2, 1].Font.Size = 16;

                //    xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                //    xlWorkSheet.Cells[3, 1].Font.Size = 12;
                //    xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                //    xlWorkSheet.Cells[4, 1].Font.Size = 12;

                //    xlWorkSheet.Cells[5, 1] = "    ";


                //    this.CloseConn();

                //    if (this.chkInventarioValorizado.Checked == false)
                //    {
                //        for (int t = 1; t < this.dgvDatos.Columns.Count + 1; t++)
                //        {
                //            xlWorkSheet.Cells[6, t] = this.dgvDatos.Columns[t - 1].HeaderText;
                //            xlWorkSheet.Cells[6, t].Font.Size = 16;
                //            xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                //            xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                //            xlWorkSheet.Cells[6, t].Rows.AutoFit();
                //            xlWorkSheet.Cells[6, t].Columns.AutoFit();

                //            intx++;
                //        }


                //        for (i = 0; i <= this.dgvDatos.RowCount - 1; i++)
                //        {
                //            inty = 0;
                //            for (j = 0; j <= this.dgvDatos.ColumnCount - 1; j++)
                //            {
                //                DataGridViewCell cell = this.dgvDatos[j, i];
                //                xlWorkSheet.Cells[i + 7, j + 1] = cell.Value;
                //                xlWorkSheet.Cells[i + 7, j + 1].Font.Size = 12;
                //                xlWorkSheet.Cells[i + 7, j + 1].Rows.AutoFit();
                //                xlWorkSheet.Cells[i + 7, j + 1].Columns.AutoFit();
                //                inty++;
                //            }
                //            intx++;
                //        }
                //    }
                //    else
                //    {
                //        for (int t = 1; t < this.dgvDatos2.Columns.Count + 1; t++)
                //        {
                //            xlWorkSheet.Cells[6, t] = this.dgvDatos2.Columns[t - 1].HeaderText;
                //            xlWorkSheet.Cells[6, t].Font.Size = 16;
                //            xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                //            xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                //            xlWorkSheet.Cells[6, t].Rows.AutoFit();
                //            xlWorkSheet.Cells[6, t].Columns.AutoFit();

                //            intx++;
                //        }


                //        for (i = 0; i <= this.dgvDatos2.RowCount - 1; i++)
                //        {
                //            inty = 0;
                //            for (j = 0; j <= this.dgvDatos2.ColumnCount - 1; j++)
                //            {
                //                DataGridViewCell cell = this.dgvDatos2[j, i];
                //                xlWorkSheet.Cells[i + 7, j + 1] = cell.Value;
                //                xlWorkSheet.Cells[i + 7, j + 1].Font.Size = 12;
                //                xlWorkSheet.Cells[i + 7, j + 1].Rows.AutoFit();
                //                xlWorkSheet.Cells[i + 7, j + 1].Columns.AutoFit();
                //                inty++;
                //            }
                //            intx++;
                //        }
                //    }


                //    Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[6, 1];
                //    Excel.Range c2 = (Excel.Range)xlWorkSheet.Cells[intx, inty];
                //    Excel.Range range = xlWorkSheet.get_Range(c1, c2);


                //    range.Rows.AutoFit();
                //    range.Columns.AutoFit();

                //    FolderBrowserDialog file = new FolderBrowserDialog();

                //    if (file.ShowDialog() != DialogResult.Cancel)
                //    {

                //        xlWorkBook.SaveAs(file.SelectedPath + "\\LISTADO DE INVENTARIO" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //        xlWorkBook.Close(true, misValue, misValue);
                //        xlApp.Quit();

                //        releaseObject(xlWorkSheet);
                //        releaseObject(xlWorkBook);
                //        releaseObject(xlApp);

                //        MessageBox.Show("Archivo creado con éxito!");

                //        System.Diagnostics.Process.Start(@file.SelectedPath);
                //    }
                //}
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
            pdReporte.DocumentName = "LISTADO DE INVENTARIO";
            pdReporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pdReporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pdReporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pdReporte.DefaultPageSettings.Landscape = false;

            return true;
        }

        private void rbGananciaArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGananciaArticulo.Checked)
            {
                this.chkInventarioValorizado.Checked = false;
            }
        }

        private void chkInventarioValorizado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkInventarioValorizado.Checked)
            {
                this.rbGananciaArticulo.Checked = false;

                this.gbInventarioValorizado.Visible = true;
            }
            if (this.chkInventarioValorizado.Checked==false)
            {
                this.gbInventarioValorizado.Visible = false;
            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

    }

}

