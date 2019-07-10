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
    public partial class Ventas_Reportes : Form
    {
        Ventas_Mod _owner;

        PuntoVentaDAL.CONEXIONDataContext db = null;
        

        PuntoVentaBL.Reporte MyDataGridViewPrinter;

        PuntoVentaBL.Ventas objVentas = new PuntoVentaBL.Ventas();

        PuntoVentaBL.Cliente objCliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        PuntoVentaBL.Usuario objUsuario = new PuntoVentaBL.Usuario();

        public int ClienteId = 0;

        public int ProveedorId = 0;

        public int FamiliaId = 0;

        public int Accion = 0;

        public int MasVendidos = 0;

        String  total;

        public Ventas_Reportes(Ventas_Mod owner)
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
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        //public void CambiaCliente()
        //{
        //    try
        //    {
        //        this.cmbClientes.SelectedValue = ClienteId;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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

        public void CambiaFamilia()
        {
            try
            {
                this.cmbFamilia.SelectedValue = FamiliaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ventas_Reportes_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objCliente.ObtieneClientes(this.cmbClientes);

                this.objInventario.ObtieneProveedores(this.cmbProveedor);

                this.objInventario.ObtieneFamilia(this.cmbFamilia);

                this.cmbOrdenar.Text = "--Seleccione--";

                this.cmbArticulosOrdena.Text = "--Seleccione--";

                this.objUsuario.ObtieneUsuarios(this.cmbVendedor);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar la información de reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void ObtieneVentasTodas()
        {
            try
            {
                this.OpenConn();

                if (this.radioButton2.Checked)
                {
                    var bus = (from x in db.ObtieneVentas_Vws
                               join e in db.Equipos on x.EquipoId equals e.Id
                               //join m in db.Movimientos on x.MovimientoId equals m.Id
                               //where this.objVentas.FechaInicio <= x.Fecha && x.Fecha <= this.objVentas.FechaFinal
                               //x.MovimientoId == 2 && e.NombreEquipo == System.Environment.MachineName.ToString() && 
                               orderby x.Id descending
                               select x);
                
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

                if (this.cmbClientes.Text != "--Seleccione--")
                {
                    bus = (from x in bus
                           where x.ClienteId == Convert.ToInt32(this.cmbClientes.SelectedValue.ToString())
                           select x);
                }


                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;
                }
                else if (this.rbVendedor.Checked)
                    {
                        var bus = (from x in db.ObtieneVentas_Vws
                                   join e in db.Equipos on x.EquipoId equals e.Id
                                  where x.UsuarioId == Convert.ToInt32(this.cmbVendedor.SelectedValue.ToString())
                                   orderby x.Id descending
                                   select x);

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

                        if (this.cmbClientes.Text != "--Seleccione--")
                        {
                            bus = (from x in bus
                                   where x.ClienteId == Convert.ToInt32(this.cmbClientes.SelectedValue.ToString())
                                   select x);
                        }


                        this.dgvDatos.AutoGenerateColumns = false;

                        this.dgvDatos.DataSource = bus;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }
        public void ObtieneVentasXFecha()
        {
            try
            {
                this.OpenConn();
              
                this.objVentas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objVentas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());
                if (radioButton2.Checked)
                {
                    var bus = (from x in db.ObtieneVentas_Vws
                               join e in db.Equipos on x.EquipoId equals e.Id
                               //join m in db.Movimientos on x.MovimientoId equals m.Id
                               where this.objVentas.FechaInicio <= x.Fecha && x.Fecha <= this.objVentas.FechaFinal
                               //x.MovimientoId == 2 && e.NombreEquipo == System.Environment.MachineName.ToString() && 
                               orderby x.Id descending
                               select x);

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

                    if (this.cmbClientes.Text != "--Seleccione--")
                    {
                        bus = (from x in bus
                               where x.ClienteId == Convert.ToInt32(this.cmbClientes.SelectedValue.ToString())
                               select x);
                    }


                    this.dgvDatos.AutoGenerateColumns = false;

                    this.dgvDatos.DataSource = bus;
                }
                else if (rbVendedor.Checked)
                {
                    var bus = (from x in db.ObtieneVentas_Vws
                               join e in db.Equipos on x.EquipoId equals e.Id
                               //join m in db.Movimientos on x.MovimientoId equals m.Id
                               where this.objVentas.FechaInicio <= x.Fecha && x.Fecha <= this.objVentas.FechaFinal &&
                               x.UsuarioId == Convert.ToInt32(this.cmbVendedor.SelectedValue.ToString())
                               //x.MovimientoId == 2 && e.NombreEquipo == System.Environment.MachineName.ToString() && 
                               orderby x.Id descending
                               select x);

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

                    if (this.cmbClientes.Text != "--Seleccione--")
                    {
                        bus = (from x in bus
                               where x.ClienteId == Convert.ToInt32(this.cmbClientes.SelectedValue.ToString())
                               select x);
                    }


                    this.dgvDatos.AutoGenerateColumns = false;

                    this.dgvDatos.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }       
        }
        public void ObtieneVentasAnuladas()
        {
            try
            {
                this.OpenConn();

              
                var bus = (from x in db.ObtieneVentas_Vws
                           join e in db.Equipos on x.EquipoId equals e.Id
                           //join m in db.Movimientos on x.MovimientoId equals m.Id
                           where x.Activo==false
                           orderby x.Id descending
                           select x);

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

                if (this.cmbClientes.Text != "--Seleccione--")
                {
                    bus = (from x in bus
                           where x.ClienteId == Convert.ToInt32(this.cmbClientes.SelectedValue.ToString())
                           select x);
                }


                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }
    

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //this.OpenConn();


                //var bus = (from x in db.ObtieneVentas_Vws
                //           //join eq in db.Equipos on x.EquipoId equals eq.Id
                //           //join m in db.Movimientos on x.MovimientoId equals m.Id
                //           join u in db.Usuarios on x.UsuarioId equals u.Id
                //           //where x.MovimientoId == 2 //&& x.Activo==true 
                //           orderby x.Id descending
                //           select new
                //           {
                //               x.UsuarioId,
                //               x.TipoPago,
                //               ClienteId = x.ClienteId,
                //               x.Id,
                //               Nombre = x.Nombre,
                //               Descuento = x.Descuento == null ? Convert.ToDecimal("0.00") : x.Descuento,
                //               Impuesto = x.Impuesto == null ? "0.00" : x.Impuesto.ToString(),
                //               Total = x.Total,
                //               Fecha1 = x.Fecha.ToShortDateString(),
                //               x.Fecha,
                //               x.Hora,
                //               x.Activo,
                //               Vendedor = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido)
                //               //   Monto==null?x.Monto:x.Monto 
                //           });



                //if (this.rbCredito.Checked)
                //{
                //    bus = from x in bus
                //          where x.TipoPago == 3
                //          select x;
                //}

                //if (this.rbVentasEfectivo.Checked)
                //{
                //    bus = from x in bus
                //          where x.TipoPago == 2
                //          select x;
                //}

                //if (this.rbTarjetaCredito.Checked)
                //{
                //    bus = from x in bus
                //          where x.TipoPago == 1
                //          select x;
                //}

                if (this.rbTodos.Checked)
                {

                    ObtieneVentasTodas();
                }



                if (this.rbEntreFechas.Checked)
                {

                    ObtieneVentasXFecha();
                }


                if (this.rbAnuladas.Checked)
                {

                    ObtieneVentasAnuladas();

                }

                //if (this.rbClientes.Checked)
                //{
                //    bus = from x in bus
                //          where x.ClienteId == Convert.ToInt32(this.cmbClientes.SelectedValue.ToString())
                //          select x;

                //}


                //if (this.rbVendedor.Checked)
                //{

                //    ObtieneVentasXVendedor();
                //}

                //if (this.cmbOrdenar.Text != "--Seleccione--")
                //{
                //    switch (this.cmbOrdenar.Text)
                //    {
                //        case "Fecha":
                //            {
                //                bus = from x in bus
                //                      orderby x.Fecha descending
                //                      select x;

                //                break;
                //            }
                //        case "Comprobante":
                //            {
                //                bus = from x in bus
                //                      orderby x.Id descending
                //                      select x;

                //                break;
                //            }
                //        case "Cliente":
                //            {
                //                bus = from x in bus
                //                      orderby x.Nombre ascending
                //                      select x;

                //                break;
                //            }

                //        default:
                //            break;
                //    }
                //}

                //this.dgvDatos.AutoGenerateColumns = false;
             

                //this.dgvDatos.DataSource = bus;


           

                if (this.chkArticulosReporte.Checked)
                {
               
                    MasVendidos = 1;
                    //problemas     aqui en busArticulos
                    db.Ventas_Articulos();
                    var busArticulos = (from x in db.VentasArticulo_Vw
                                        select x);
                    //var busArticulosfecha = (from x in db.ObtieneMasVendidos(this.objVentas.FechaInicio, this.objVentas.FechaFinal)
                    //                         select x).ToList();
                    //foreach (var item in busArticulos)
                    //{
                    //    MessageBox.Show("Jean "+item.Nombre);
                    //}

                 

                    if (this.rbFamilia.Checked)
                    {
                         busArticulos = from x in busArticulos
                                           join f in db.Familias on x.Familia equals f.Descripcion
                                           where f.Id == Convert.ToInt32(this.cmbFamilia.SelectedValue)
                                           select x;

                    }

                    if (this.rbProveedor.Checked)
                    {
                        busArticulos = from x in busArticulos
                                      join p in db.Proveedors on x.Nombre equals p.Nombre
                                      where p.Id == Convert.ToInt32(this.cmbProveedor.SelectedValue)
                                      select x;
                    }




                    if (this.cmbArticulosOrdena.Text != "--Seleccione--")
                    {
                        switch (this.cmbArticulosOrdena.Text)
                        {
                            case "Cantidad Vendida":
                                {
                                    busArticulos = from x in busArticulos
                                                   orderby x.CantidadVendida descending
                                                   select x;
                                    break;
                                }
                            case "Proveedor":
                                {
                                    busArticulos = from x in busArticulos
                                                   orderby x.Nombre descending
                                                   select x;
                                    break;
                                }
                            case "Familia":
                                {
                                    MessageBox.Show("EN FAMILIA QUERY");
                                    busArticulos = from x in busArticulos
                                                   orderby x.Descripcion ascending
                                                   select x;

                                    MessageBox.Show("LISTO QUERYS DE FAMILIA");
                                    break;
                                }

                            default:
                                break;
                        }
                    }
                    if (this.rbEntreFechas.Checked == false)
                    {
                        this.dgvDatos1.AutoGenerateColumns = false;
                    
                        this.dgvDatos1.DataSource = busArticulos;

            foreach (DataGridViewRow row in dgvDatos1.Rows)
               {


                   row.Cells[6].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[4].Value);
                   row.Cells[7].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[5].Value);
                  
            }


                      
                     
                    }

                    if (this.rbEntreFechas.Checked)
                    {
                      
                        //el busarticulosfecha esta malo
                        var busArticulosfecha = (from x in db.ObtieneMasVendidos(this.objVentas.FechaInicio, this.objVentas.FechaFinal)
                                                 select x).ToList();
                      
                        //**************************************************

                        if (this.cmbArticulosOrdena.Text == "--Seleccione--")
                        {
                            this.dgvDatos1.AutoGenerateColumns = false;
                       
                            this.dgvDatos1.DataSource = busArticulosfecha;



                            foreach (DataGridViewRow row in dgvDatos1.Rows)
                            {


                                row.Cells[6].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[4].Value);
                                row.Cells[7].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[5].Value);

                            }

                          
                       
                        }

                        //************************************************
                        if (this.cmbArticulosOrdena.Text != "--Seleccione--")
                        {
                            switch (this.cmbArticulosOrdena.Text)
                            {
                                case "Cantidad Vendida":
                                    {
                                        busArticulosfecha = (from x in busArticulosfecha
                                                             orderby x.CantidadVendida descending
                                                             select x).ToList();
                                        this.dgvDatos1.AutoGenerateColumns = false;

                                        this.dgvDatos1.DataSource = busArticulosfecha;

                                        foreach (DataGridViewRow row in dgvDatos1.Rows)
                                        {


                                            row.Cells[6].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[4].Value);
                                            row.Cells[7].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[5].Value);

                                        }
                                        break;
                                    }
                                case "Proveedor":
                                    {
                                        busArticulosfecha = (from x in busArticulosfecha
                                                             orderby x.Nombre descending
                                                             select x).ToList();
                                        this.dgvDatos1.AutoGenerateColumns = false;
                                        this.dgvDatos1.DataSource = busArticulosfecha;

                                        foreach (DataGridViewRow row in dgvDatos1.Rows)
                                        {


                                            row.Cells[6].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[4].Value);
                                            row.Cells[7].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[5].Value);

                                        }
                                        break;
                                    }
                                case "Familia":
                                    {
                                      
                                        busArticulosfecha = (from x in busArticulosfecha
                                                             join f in db.Familias on x.Familia equals f.Descripcion
                                                             where f.Id == Convert.ToInt32(this.cmbFamilia.SelectedValue)
                                                             orderby x.Descripcion ascending
                                                             select x).ToList();
                                     
                                        
                                        this.dgvDatos1.AutoGenerateColumns = false;
                                        this.dgvDatos1.DataSource = busArticulosfecha;

                                        foreach (DataGridViewRow row in dgvDatos1.Rows)
                                        {


                                            row.Cells[6].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[4].Value);
                                            row.Cells[7].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[5].Value);

                                        }
                                       
                                        break;
                                    }

                                default:
                                    break;
                            }
                        }


                        

                    }

                    else
                    {
                      

                        //this.dgvDatos1.AutoGenerateColumns = false;
                        //MessageBox.Show("Antes del grid llenar");
                        //this.dgvDatos1.DataSource = busArticulos;
                        //MessageBox.Show("despues del grid llenar");

                    }

                    decimal cant = 0;
                    foreach (DataGridViewRow item in this.dgvDatos1.Rows)
                    {
                        cant += (Convert.ToDecimal(item.Cells[3].Value.ToString()) * Convert.ToDecimal(item.Cells[4].Value.ToString()));
                    }
                    total = cant.ToString();

                    foreach (DataGridViewRow row in dgvDatos1.Rows)
                    {


                        row.Cells[6].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[4].Value);
                        row.Cells[7].Value = Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(row.Cells[5].Value);

                    }
                 //   MessageBox.Show("EL TOTAL ES " + cant);
                    MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos1, "TOTAL EFECTIVO: " + cant.ToString("#0.#0"),
                        "",
                        "",
                        "", pdReporte, true, true, "LISTADO DE VENTAS", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);

                }
                else
                {
                    decimal impuesto = 0;
                    decimal descuento = 0;
                    decimal total = 0;

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {

                        descuento += Convert.ToDecimal(item.Cells[5].Value.ToString());
                        impuesto += Convert.ToDecimal(item.Cells[6].Value.ToString());
                        total += Convert.ToDecimal(item.Cells[7].Value.ToString());
                    }

                    MyDataGridViewPrinter = new PuntoVentaBL.Reporte(this.dgvDatos,
                        "TOTAL DESCUENTOS: " + descuento.ToString("##,#0.#0"),
                        "TOTAL IMPUESTOS: " + impuesto.ToString("##,#0.#0"),
                        "TOTAL EN VENTAS: " + total.ToString("##,#0.#0"),
                        "",
                        pdReporte, true, true, "LISTADO DE VENTAS", new System.Drawing.Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, true);
                    MasVendidos = 0;
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

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Cliente cliente = new Sel_Cliente(this);
                cliente.TopLevel = false;
                cliente.tipo = 3;
                cliente.Parent = this;
                cliente.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar buscar los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaProveedor_Click(object sender, EventArgs e)
        {
            Sel_Proveedor ProveedorAsignar = new Sel_Proveedor(this);
            ProveedorAsignar.tipo = 3;
            ProveedorAsignar.TopLevel = false;
            ProveedorAsignar.Parent = this;
            ProveedorAsignar.Show();
        }

        private void btnBuscaFamilia_Click(object sender, EventArgs e)
        {
            Sel_Familia Familia = new Sel_Familia(this);
            Familia.tipo = 3;
            Familia.TopLevel = false;
            Familia.Parent = this;
            Familia.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkArticulosReporte.Checked)
            {
                this.gbArticulosVenta.Visible = true;
            }
            else
            {
                this.gbArticulosVenta.Visible = false;
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
                    //printPrvDlg.Height = this.Height;
                    //printPrvDlg.Width = this.Width;
                    printPrvDlg.Size = new System.Drawing.Size(800, 800);
                 
                
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
                    if (MasVendidos == 0)
                    {
                        PdfPTable pdfTable = new PdfPTable(this.dgvDatos.ColumnCount);
                        pdfTable.HeaderRows = 1;

                        //pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 98;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 0;

                        float[] widths = new float[] { 30, 60, 40, 20, 20, 25, 25, 30 };
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
                            string nombre = "LISTADO DE VENTAS" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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
                                          select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax), x.IVA };


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

                                decimal impuesto = 0;
                                decimal descuento = 0;
                                decimal total = 0;

                                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                                {

                                    descuento += Convert.ToDecimal(item.Cells[5].Value.ToString());
                                    impuesto += Convert.ToDecimal(item.Cells[6].Value.ToString());
                                    total += Convert.ToDecimal(item.Cells[7].Value.ToString());
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



                                Paragraph VENTASGRAVADAS = new Paragraph("VENTAS GRAVADAS: " + (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100)).ToString("##,#0.#0"), contentFont);
                                VENTASGRAVADAS.Alignment = Element.ALIGN_RIGHT;
                                VENTASGRAVADAS.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(VENTASGRAVADAS);


                                Paragraph VENTASEXENTAS = new Paragraph("VENTAS EXENTAS: " + (total - (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100))).ToString("##,#0.#0"), contentFont);
                                VENTASEXENTAS.Alignment = Element.ALIGN_RIGHT;
                                VENTASEXENTAS.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(VENTASEXENTAS);



                                Paragraph TOTAL = new Paragraph("TOTAL EN VENTAS: " + total.ToString("##,#0.#0"), contentFont);
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
                    else
                    {
                        PdfPTable pdfTable = new PdfPTable(this.dgvDatos1.ColumnCount);
                        pdfTable.HeaderRows = 1;

                        //pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 98;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 0;

                        float[] widths = new float[] { 60, 45, 35, 30, 25, 25 };
                        pdfTable.SetWidths(widths);

                        //Adding Header row
                        foreach (DataGridViewColumn column in this.dgvDatos1.Columns)
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
                        foreach (DataGridViewRow row in this.dgvDatos1.Rows)
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
                            string nombre = "LISTADO DE VENTAS" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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
                                decimal CANT = 0;

                                foreach (DataGridViewRow item in this.dgvDatos1.Rows)
                                {

                                  //  CANT += CANT += (Convert.ToDecimal(item.Cells[4].Value.ToString()) * Convert.ToDecimal(item.Cells[3].Value.ToString()));
                                }

                                Paragraph Descuento = new Paragraph("TOTAL EFECTIVO: " + total.ToString(), contentFont);
                                Descuento.Alignment = Element.ALIGN_RIGHT;
                                Descuento.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(Descuento);

                                pdfDoc.Close();
                                stream.Close();

                                this.CloseConn();
                            }

                            MessageBox.Show("Archivo creado con éxito!");

                            System.Diagnostics.Process.Start(@file.SelectedPath);
                        }
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
                    if (MasVendidos == 0)
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
                                  select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax), x.IVA };

                        xlWorkSheet.Cells[1, 1] = "LISTADO DE VENTAS";
                        xlWorkSheet.Cells[1, 1].Font.Size = 16;
                        xlWorkSheet.Cells[2, 1] = bus.First().Nombre.ToString();
                        xlWorkSheet.Cells[2, 1].Font.Size = 16;

                        //xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                        //xlWorkSheet.Cells[3, 1].Font.Size = 12;
                        //xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                        //xlWorkSheet.Cells[4, 1].Font.Size = 12;

                        xlWorkSheet.Cells[5, 1] = "    ";




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
                            total += Convert.ToDecimal(item.Cells[7].Value.ToString());
                            descuento += Convert.ToDecimal(item.Cells[5].Value.ToString());
                            impuesto += Convert.ToDecimal(item.Cells[6].Value.ToString());
                        }

                        xlWorkSheet.Cells[i + 8, 1] = "TOTAL EN DESCUENTOS: " + descuento.ToString("##,#0.#0");
                        xlWorkSheet.Cells[i + 9, 1] = "TOTAL EN IMPUESTOS: " + impuesto.ToString("##,#0.#0");
                        xlWorkSheet.Cells[i + 10, 1] = "VENTAS GRAVADAS: " + (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100)).ToString("##,#0.#0");
                        xlWorkSheet.Cells[i + 11, 1] = "VENTAS EXENTAS: " + (total - (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100))).ToString("##,#0.#0");
                        xlWorkSheet.Cells[i + 12, 1] = "TOTAL EN VENTAS: " + total.ToString("##,#0.#0");



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
                    else
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

                        xlWorkSheet.Cells[1, 1] = "LISTADO DE VENTAS";
                        xlWorkSheet.Cells[1, 1].Font.Size = 16;
                        xlWorkSheet.Cells[2, 1] = bus.First().Nombre.ToString();
                        xlWorkSheet.Cells[2, 1].Font.Size = 16;

                        //xlWorkSheet.Cells[3, 1] = "TELÉFONO: " + bus.First().Telefono.ToString();
                        //xlWorkSheet.Cells[3, 1].Font.Size = 12;
                        //xlWorkSheet.Cells[4, 1] = "FAX: " + bus.First().Fax.ToString();
                        //xlWorkSheet.Cells[4, 1].Font.Size = 12;

                        xlWorkSheet.Cells[5, 1] = "    ";


                        this.CloseConn();


                        for (int t = 1; t < this.dgvDatos1.Columns.Count + 1; t++)
                        {
                            xlWorkSheet.Cells[6, t] = this.dgvDatos1.Columns[t - 1].HeaderText;
                            xlWorkSheet.Cells[6, t].Font.Size = 16;
                            xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                            xlWorkSheet.Cells[6, t].Borders[Excel.XlBordersIndex.xlEdgeBottom].ColorIndex = Color.Black;
                            xlWorkSheet.Cells[6, t].Rows.AutoFit();
                            xlWorkSheet.Cells[6, t].Columns.AutoFit();

                            intx++;
                        }

                        for (i = 0; i <= this.dgvDatos1.RowCount - 1; i++)
                        {
                            inty = 0;
                            for (j = 0; j <= this.dgvDatos1.ColumnCount - 1; j++)
                            {
                                DataGridViewCell cell = this.dgvDatos1[j, i];
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

                        decimal CANT = 0;

                        foreach (DataGridViewRow item in this.dgvDatos1.Rows)
                        {
                            CANT += CANT += (Convert.ToDecimal(item.Cells[4].Value.ToString()) * Convert.ToDecimal(item.Cells[3].Value.ToString()));

                        }

                        xlWorkSheet.Cells[i + 8, 1] = "TOTAL EFECTIVO: " + CANT.ToString("##,#0.#0");

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
            pdReporte.DocumentName = "LISTADO DE VENTAS";
            pdReporte.PrinterSettings = dialogo_impresion.PrinterSettings;
            pdReporte.DefaultPageSettings = dialogo_impresion.PrinterSettings.DefaultPageSettings;
            pdReporte.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
            pdReporte.DefaultPageSettings.Landscape = false;

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Accion == 1)
                {
                    if (MasVendidos == 0)
                    {
                        PdfPTable pdfTable = new PdfPTable(this.dgvDatos.ColumnCount);
                        pdfTable.HeaderRows = 1;

                        //pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 98;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 0;

                        float[] widths = new float[] { 30, 60, 40, 20, 20, 25, 25, 30 };
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
                            string nombre = "LISTADO DE VENTAS" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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
                                          select new { x.Nombre, x.Telefono, Fax = (x.Fax == null ? "-" : x.Fax), x.IVA };


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

                                //pdfDoc.Add(pdfTable);

                                decimal impuesto = 0;
                                decimal descuento = 0;
                                decimal total = 0;

                                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                                {

                                    descuento += Convert.ToDecimal(item.Cells[5].Value.ToString());
                                    impuesto += Convert.ToDecimal(item.Cells[6].Value.ToString());
                                    total += Convert.ToDecimal(item.Cells[7].Value.ToString());
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



                                Paragraph VENTASGRAVADAS = new Paragraph("VENTAS GRAVADAS: " + (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100)).ToString("##,#0.#0"), contentFont);
                                VENTASGRAVADAS.Alignment = Element.ALIGN_RIGHT;
                                VENTASGRAVADAS.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(VENTASGRAVADAS);


                                Paragraph VENTASEXENTAS = new Paragraph("VENTAS EXENTAS: " + (total - (impuesto / (Convert.ToDecimal(bus.First().IVA) / 100))).ToString("##,#0.#0"), contentFont);
                                VENTASEXENTAS.Alignment = Element.ALIGN_RIGHT;
                                VENTASEXENTAS.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(VENTASEXENTAS);



                                Paragraph TOTAL = new Paragraph("TOTAL EN VENTAS: " + total.ToString("##,#0.#0"), contentFont);
                                TOTAL.Alignment = Element.ALIGN_RIGHT;
                                TOTAL.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(TOTAL);

                                Paragraph Fecha = new Paragraph("FECHA: " + System.DateTime.Now.Day + " / " + System.DateTime.Now.Month + " / " + System.DateTime.Now.Year, contentFont);
                                Fecha.Alignment = Element.ALIGN_RIGHT;
                                Fecha.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(Fecha);

                                pdfDoc.Close();
                                stream.Close();

                                this.CloseConn();
                            }

                            MessageBox.Show("Archivo creado con éxito!");

                            System.Diagnostics.Process.Start(@file.SelectedPath);
                        }
                    }
                    else
                    {
                        PdfPTable pdfTable = new PdfPTable(this.dgvDatos1.ColumnCount);
                        pdfTable.HeaderRows = 1;

                        //pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 98;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        pdfTable.DefaultCell.BorderWidth = 0;

                        float[] widths = new float[] { 60, 45, 35, 30, 25, 25 };
                        pdfTable.SetWidths(widths);

                        //Adding Header row
                        foreach (DataGridViewColumn column in this.dgvDatos1.Columns)
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
                        foreach (DataGridViewRow row in this.dgvDatos1.Rows)
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
                            string nombre = "LISTADO DE VENTAS" + System.DateTime.Now.Hour + " - " + System.DateTime.Now.Minute + ".pdf";
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

                                //  pdfDoc.Add(pdfTable);
                                decimal CANT = 0;

                                foreach (DataGridViewRow item in this.dgvDatos1.Rows)
                                {

                                    CANT += (Convert.ToDecimal(item.Cells[4].Value.ToString()) * Convert.ToDecimal(item.Cells[3].Value.ToString()));
                                }

                                Paragraph Descuento = new Paragraph("TOTAL EFECTIVO: " + CANT.ToString("##,#0.#0"), contentFont);
                                Descuento.Alignment = Element.ALIGN_RIGHT;
                                Descuento.IndentationRight = 50;

                                pdfDoc.Add(espacio);

                                pdfDoc.Add(Descuento);

                                pdfDoc.Close();
                                stream.Close();

                                this.CloseConn();
                            }

                            MessageBox.Show("Archivo creado con éxito!");

                            System.Diagnostics.Process.Start(@file.SelectedPath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar exportar el documento a PDF: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }
    }
}


