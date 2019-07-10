using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaPresentacion
{
    public partial class Compras_Mantenimiento : Form
    {
        Compras_Mod _owner;
        
        public decimal iva = 0;

        string temp = string.Empty;

        public int permiso = 0;

        public int Accion = 0;

        public Int64 FacturaId = 0;

        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        PuntoVentaBL.Compras objComprar = new PuntoVentaBL.Compras();

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

        PuntoVentaBL.Ticket objTicket = new PuntoVentaBL.Ticket();

        PuntoVentaDAL.CONEXIONDataContext db = new PuntoVentaDAL.CONEXIONDataContext();

        public string CodigoS = string.Empty;
        
        public string CantidadS = string.Empty;
        
        public string ListaPreciosS = string.Empty;

        public int ProveedorId = 0;

        public decimal porcdescactualiza, descuentodescactualiza, totalactualiza = 0;

        public Compras_Mantenimiento(Compras_Mod owner)
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

        private void Compras_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        public void Compras_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.txtCodigo.Text = string.Empty;

                this.ActiveControl = this.txtCodigo;

                this.objInventario.ObtieneProveedores(this.cmbProveedor);
                
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);

                iva = Convert.ToDecimal(bus.First().IVA);

                this.cmbListaPrecios.Text = "Lista de precios 1";

                this.comboBox1.Text = "F9-SALIR";

                //En el caso de que sea la continuación o confirmación de la Factura Temporal:
                if (Accion == 3)
                {

                    if (this.objComprar.ObtieneFacturaTemp() == true)
                    {
                        FacturaId                          = Convert.ToInt64(this.objComprar.ComprobanteId);//Contiene el ID de compra
                        this.txtComprobante.Text           = this.objComprar.CompraId.ToString();
                        this.dtpFecha.Text                 = this.objComprar.Fecha.ToString() + " " +
                                                             this.objComprar.Hora.ToString();
                        this.txtSubtotal.Text              = this.objComprar.Subtotal.ToString();
                        this.txtDescuentoAplicado.Text     = this.objComprar.Descuento.ToString();
                        this.txtImpuesto.Text              = this.objComprar.Impuesto.ToString();
                        this.txtTotal.Text                 = this.objComprar.TotalFactura.ToString();
                        this.txtSubtotalPDesc.Text         = this.objComprar.Subtotal.ToString();
                        this.objComprar.ComprobanteId      = this.objComprar.ComprobanteId.ToString();
                        this.cmbProveedor.SelectedValue    = Convert.ToInt32(this.objComprar.ProveedorId);
                        this.cmbListaPrecios.SelectedValue = Convert.ToInt32(this.objComprar.TipoPrecio);

                        if (objComprar.CompraCheque == true)
                        {
                            chkCheque.CheckState = CheckState.Checked;
                        }
                        this.dgvDatos.Columns["Precio"].DefaultCellStyle.Format = ("#0,#.#0");
                        this.dgvDatos.Columns["Total"].DefaultCellStyle.Format = ("#0,#.#0");
                        this.objComprar.ObtieneDetalleFacturaTemp(this.dgvDatos);
                    }
                    else
                    {
                        MessageBox.Show("No Hay Factura Temporal Para Mostrar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Accion = 1;
                    }
                }
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar el módulo de facturación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Compras_Mantenimiento_Load()
        {
            try
            {
                this.BringToFront();

                this.txtCodigo.Text = string.Empty;

                this.ActiveControl = this.txtCodigo;

                this.objInventario.ObtieneProveedores(this.cmbProveedor);

                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);

                iva = Convert.ToDecimal(bus.First().IVA);

                this.cmbListaPrecios.Text = "Lista de precios 1";

                this.comboBox1.Text = "F9-SALIR";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar el módulo de facturación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)//borra linea
            {
                this.EliminaLinea();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F2)//borra linea
            {
               this.AgregaLineaExistente();
               // this.txtCodigo.Focus();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F3)//actualizo linea
            {
                this.ModificaLinea();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F4)//emite factura
            {
                this.btnEmitirFactura.PerformClick();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F5)//consulto precio linea
            {
                this.ConsultaLinea();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F9)//salir
            {
                this.Close();
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.txtCodigo.Text.Contains('r'))
                    {
                        this.txtCodigo.Text = string.Empty;
                        return;
                    }
                    if (this.txtCodigo.Text.Length == 0)
                    {
                        return;
                    }

                    if (this.cmbListaPrecios.Text == "Lista de precios 1")
                    {
                        this.objFacturar.TipoPrecio = 1;
                    }
                    else
                    {
                        this.objFacturar.TipoPrecio = 2;
                    }
                    if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text) == false)
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1.00";
                        this.ActiveControl = this.txtCodigo;
                        return;
                    }

                    this.txtPUnitario.Text = this.objFacturar.Precio.ToString("#0,#.#0");

                    this.ActiveControl = this.txtPUnitario;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.dgvDatos.RowCount > 0)
                //{
                //    return;
                //}
                Sel_Proveedor proveedor = new Sel_Proveedor(this);
                proveedor.TopLevel = false;
                proveedor.tipo = 5;
                proveedor.Parent = this;
                proveedor.Show();
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
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPorcDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == (Keys.Enter))
                {
                    if (this.txtPorcDescuento.Text.Length == 0)
                    {
                        this.txtPorcDescuento.Text = "0";
                        return;
                    }
                    try
                    {
                        Convert.ToInt32(this.txtPorcDescuento.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Para el descuento ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.txtDescuentoAplicado.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100)).ToString("F");

                    this.txtSubtotal.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) - Convert.ToDecimal(this.txtDescuentoAplicado.Text) - Convert.ToDecimal(this.txtImpuesto.Text)).ToString("F");

                    this.txtTotal.Text = Math.Round((Convert.ToDecimal(this.txtSubtotal.Text) + Convert.ToDecimal(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar aplicar el descuento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificaLinea()
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    return;
                }
                if (this.objFacturar.ObtieneProductoActualizar((this.dgvDatos.CurrentRow.Cells[0].Value).ToString()) == false)
                {

                }


                Compra_ActualizaLinea compra = new Compra_ActualizaLinea(this);
                compra.TopLevel = false;
                compra.Parent = this;
                compra.Codigo = this.dgvDatos.CurrentRow.Cells[0].Value.ToString();
                compra.Descripcion = this.dgvDatos.CurrentRow.Cells[1].Value.ToString();
                compra.precio = this.dgvDatos.CurrentRow.Cells[2].Value.ToString();
                compra.Cantidad = this.dgvDatos.CurrentRow.Cells[3].Value.ToString();
                compra.porcdesc = this.dgvDatos.CurrentRow.Cells[4].Value.ToString();
                compra.descmonto = this.dgvDatos.CurrentRow.Cells[5].Value.ToString();
                compra.total = this.dgvDatos.CurrentRow.Cells[6].Value.ToString();
                compra.unidadmedida = this.objFacturar.UnidadMedidaId;
                compra.ListaPrecios = this.cmbListaPrecios.Text;
                compra.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ModificaArticulo()
        {
            try
            {
                if (Accion == 3)
                {
                    using (DataTable dt = this.objComprar.CreaFacturaDetalleTemp())
                    {
                        foreach (DataGridViewRow row in this.dgvDatos.Rows)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Codigo"]      = row.Cells["Codigo"].Value;
                            dr["Descripcion"] = row.Cells["Descripcion"].Value;
                            dr["Precio"]      = row.Cells["Precio"].Value;
                            dr["TipoPrecio"]  = row.Cells["TipoPrecio"].Value;
                            dr["Impuesto"]    = row.Cells["Impuesto"].Value;
                            dr["PrecioFinal"] = row.Cells["PrecioFinal"].Value;

                            if (row.Cells[0].Value.ToString() == CodigoS.ToString())
                            {
                                dr["Cantidad"]      = CantidadS.ToString();
                                dr["PorcDescuento"] = porcdescactualiza.ToString("#0,#.#0") ;
                                dr["Descuento"]     = descuentodescactualiza.ToString("#0,#.#0");
                                dr["TotalIVA"]      = totalactualiza.ToString("#0,#.#0");
                            }
                            else
                            {
                                dr["Cantidad"]      = row.Cells["Cantidad"].Value;
                                dr["PorcDescuento"] = row.Cells["PorcDescuento"].Value;
                                dr["Descuento"]     = row.Cells["Descuento"].Value;
                                dr["TotalIVA"]      = row.Cells["Total"].Value; 
                            }

                            dt.Rows.Add(dr);
                        }

                        dgvDatos.DataSource = dt;
                    }

                }

                else
                {
                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        if (item.Cells[0].Value.ToString() == CodigoS.ToString())
                        {
                            item.Cells[3].Value = CantidadS.ToString();
                            item.Cells[4].Value = porcdescactualiza.ToString("#0,#.#0");
                            item.Cells[5].Value = descuentodescactualiza.ToString("#0,#.#0");
                            item.Cells[6].Value = totalactualiza.ToString("#0,#.#0");
                        }
                    }
                }
                this.CalculaFooter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool AgregaLineaExistente()//para actualizar factura
        {
            try
            {
                int i = 0;                

                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    if (item.Cells[0].Value.ToString() == this.objFacturar.Codigo)
                    {
                        if (this.ListaPreciosS == "Lista de precios 1")
                        {
                            this.objFacturar.TipoPrecio = 1;
                            //item.Cells[5].Value = 1;
                        }
                        if (this.ListaPreciosS == "Lista de precios 2")
                        {
                            this.objFacturar.TipoPrecio = 2;
                            //item.Cells[5].Value = 2;
                        }

                        decimal cantidad = Convert.ToDecimal(item.Cells[3].Value) + Convert.ToDecimal(this.nupCantidad.Text);

                        item.Cells[3].Value = cantidad.ToString("F");

                        //5 desc yield 6 subtotal

                        decimal descuentoporcentaje = (Convert.ToDecimal(item.Cells[4].Value) / 100);
                        decimal precio = Convert.ToDecimal(item.Cells[2].Value);
                        decimal descuento = precio * cantidad * descuentoporcentaje;

                        item.Cells[5].Value = descuento.ToString("#0,#.#0");//descuento

                        item.Cells[6].Value = ((precio * cantidad)-descuento).ToString("#0,#.#0");//subtotal          

                        i = 1;
                    }
                }
                this.CalculaFooter();

                if (i==1)//si actualiza
                {
                    this.txtCodigo.Text = string.Empty;

                    this.txtPUnitario.Text = string.Empty;

                    this.nupCantidad.Text = "1.00";

                    this.ActiveControl = this.txtCodigo;

                    return true;
                }
                else
                {
                    return false;
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void EliminaLinea()
        {
            try
            {

                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    return;
                }

                this.dgvDatos.Rows.RemoveAt(this.dgvDatos.CurrentRow.Index);

                this.CalculaFooter();

                this.txtCodigo.Text = string.Empty;

                this.txtPUnitario.Text = string.Empty;

                this.nupCantidad.Text = "1.00";

                this.txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultaLinea()
        {
            try
            {
                FacturacionMod_Consulta LineaConsulta = new FacturacionMod_Consulta(this);
                LineaConsulta.TopLevel = false;
                LineaConsulta.Parent = this;
                LineaConsulta.accion = 2;
                LineaConsulta.escompra = true;
                LineaConsulta.ProveedorId = Convert.ToInt32(this.cmbProveedor.SelectedValue.ToString());
               
                LineaConsulta.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar consultar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AgregaLineaConsulta(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    if (item.Cells[0].Value.ToString() == CodigoS)
                    {
                        MessageBox.Show("El artículo ya ha sido agregado!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                }

                this.txtCodigo.Text = CodigoS;

                this.cmbListaPrecios.SelectedText = ListaPreciosS;

                this.ActiveControl = this.txtCodigo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConstruyeTicket()
        {
            try
            {
                this.objTicket.Articulos.Clear();

                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                    string x = string.Empty;

                    if (this.objFacturar.IV == true)
                    {
                        x = "G";
                    }
                    else
                    {
                        x = "E";
                    }

                    decimal cantidad = (Convert.ToDecimal(item.Cells[3].Value.ToString()));
                    
                    decimal temp = (Convert.ToDecimal(item.Cells[2].Value.ToString()) * cantidad);

                    double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                    totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);
                   
                    this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + totaliva.ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit
                }
                this.objTicket.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                this.objTicket.FacturaIdString = (this.txtComprobante.Text);

                this.objTicket.ImpresionCompra = 1;

                this.objTicket.print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                } 

                if (this.dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay artículos agregados actualmente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.txtComprobante.Text.Length == 0)
                {
                    MessageBox.Show("Por favor digite el comprobante de factura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.objComprar.Articulos.Clear();

                this.objComprar.ComprobanteId = this.txtComprobante.Text;
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    this.objComprar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + //codigo
                        Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" + //punitario
                        Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + //cantid
                        Convert.ToDecimal(item.Cells[4].Value.ToString()) + ";" + //porcdesc
                        Convert.ToDecimal(item.Cells[5].Value.ToString()) + ";" + //descuento
                        Convert.ToDecimal(item.Cells[6].Value.ToString())); //subtotal
                }
                this.objComprar.Subtotal = Convert.ToDecimal(this.txtSubtotalPDesc.Text);

                this.objComprar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                this.objComprar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                this.objComprar.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                this.objComprar.CompraCheque = Convert.ToBoolean(this.chkCheque.CheckState);

                this.objComprar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);
                this.objComprar.Recibido = 0;
                this.objComprar.Cambio = 0;
                this.objComprar.ProveedorId = Convert.ToInt32(this.cmbProveedor.SelectedValue.ToString());

                this.objComprar.Fecha = Convert.ToDateTime(this.dtpFecha.Value).ToString();

                this.objComprar.IngresaEncabezadoFactura(Login.UserId);

                this.objTicket.Fecha = Convert.ToDateTime(this.dtpFecha.Value);

                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    this.objComprar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + //codigo
                        Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" + //punitario
                        Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + //cantid
                        Convert.ToDecimal(item.Cells[4].Value.ToString()) + ";" + //porcdesc
                        Convert.ToDecimal(item.Cells[5].Value.ToString()) + ";" + //descuento
                        Convert.ToDecimal(item.Cells[6].Value.ToString())); //subtotal
                }
                this.objComprar.Fecha = Convert.ToDateTime(this.dtpFecha.Value).ToShortDateString();
                this.objComprar.ModificaUltimaCompra();

                if (DialogResult.OK == MessageBox.Show("¿Desea imprimir el comprobante de la compra?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {

                    this.ConstruyeTicket();
                }

                //En el caso que sea una factura temporal:
                if (Accion == 3)
                {
                    this.objComprar.EliminaFacturaTemp(FacturaId);
                }
                this.LimpiaFactura();

                this.Compras_Mantenimiento_Load(sender, e);

                _owner.Compras_Mod_Load(sender, e);

                _owner.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar generar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiaFactura()
        {
            if (Accion == 3)
            {
                this.txtComprobante.Text = string.Empty;
                this.lblCantidadArticulos.Text = "0";
                this.lblCantidadLineas.Text = "0";
                this.txtTotal.Text = "0.00";
                this.txtSubtotal.Text = "0.00";
                this.txtPorcDescuento.Text = "0";
                this.txtDescuentoAplicado.Text = "0.00";
                this.txtSubtotalPDesc.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.chkCheque.Checked = false;
                this.dgvDatos.DataSource = null;
            }
            else
            {
                this.txtComprobante.Text = string.Empty;
                this.lblCantidadArticulos.Text = "0";
                this.lblCantidadLineas.Text = "0";
                this.txtTotal.Text = "0.00";
                this.txtSubtotal.Text = "0.00";
                this.txtPorcDescuento.Text = "0";
                this.txtDescuentoAplicado.Text = "0.00";
                this.txtSubtotalPDesc.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.dgvDatos.Rows.Clear();
                this.chkCheque.Checked = false;
            }
            //Se inicializa la accion:
            Accion = 1;

        }

        private void txtPUnitario_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.txtCodigo.Text.Length == 0)
                    {
                        return;
                    }

                    if (this.txtPUnitario.Text.Length == 0)
                    {
                        return;
                    }

                    if (this.cmbListaPrecios.Text == "Lista de precios 1")
                    {
                        this.objFacturar.TipoPrecio = 1;
                    }
                    else
                    {
                        this.objFacturar.TipoPrecio = 2;
                    }
                    if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text) == false)
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.txtPUnitario.Text = string.Empty;
                        this.nupCantidad.Text = "1.00";
                        this.ActiveControl = this.txtCodigo;
                        return;
                    }
                    else
                    {
                        this.txtCodigo.Text = this.objFacturar.Codigo;
                    }

                    if (this.AgregaLineaExistente() == true)
                    {
                        return;
                    }

                    decimal precio = Convert.ToDecimal(this.txtPUnitario.Text);
                    decimal cantidad = Convert.ToDecimal(this.nupCantidad.Text);


                    this.objFacturar.ObtieneProducto(this.txtCodigo.Text);

                    if (Accion == 3)
                    {
                        using (DataTable dt = this.objComprar.CreaFacturaDetalleTemp())
                        {

                            foreach (DataGridViewRow row in this.dgvDatos.Rows)
                            {
                                    DataRow dr = dt.NewRow();
                                    dr["Codigo"]        = row.Cells["Codigo"].Value;
                                    dr["Descripcion"]   = row.Cells["Descripcion"].Value;
                                    dr["Precio"]        = row.Cells["Precio"].Value;
                                    dr["Cantidad"]      = row.Cells["Cantidad"].Value;
                                    dr["PorcDescuento"] = row.Cells["PorcDescuento"].Value;
                                    dr["Descuento"]     = row.Cells["Descuento"].Value;
                                    dr["TotalIVA"]      = row.Cells["Total"].Value;
                                    dr["TipoPrecio"]    = row.Cells["TipoPrecio"].Value;
                                    dr["Impuesto"]      = row.Cells["Impuesto"].Value;
                                    dr["PrecioFinal"]   = row.Cells["PrecioFinal"].Value;
                                    dt.Rows.Add(dr);
                            }

                            dt.Rows.Add(this.objFacturar.Codigo.ToString(),
                                        this.objFacturar.Descripcion.ToString(),
                                        precio.ToString("#,#.#0"),
                                        cantidad.ToString(),
                                        0.ToString("F"),//% desc
                                        "0.00",//descuento monto
                                        (precio * cantidad).ToString("#0,#.#0"), // totaliva.ToString(),
                                        this.objFacturar.TipoPrecio.ToString());

                            dgvDatos.DataSource = dt;
                        }                   

                    }
                    else
                    {
                        this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                                                   this.objFacturar.Descripcion.ToString(),
                                                   precio.ToString("#,#.#0"),
                                                   cantidad.ToString(),
                                                   0.ToString("F"),//% desc
                                                   "0.00",//descuento monto
                                                   (precio * cantidad).ToString("#0,#.#0"), // totaliva.ToString(),
                                                   this.objFacturar.TipoPrecio.ToString()
                                                   );

                    }
                    this.CalculaFooter();

                    this.txtCodigo.Text = string.Empty;

                    this.txtPUnitario.Text = string.Empty;

                    this.nupCantidad.Text = "1.00";

                    this.ActiveControl = this.txtCodigo;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CalculaFooter()
        {
            try
            {
                //decimal invporcdes1 = 0;
                decimal cantlineas = 0;

                decimal cantarticulos = 0;

                decimal porcdes1 = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                decimal desctemp = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                decimal subptemp = Convert.ToDecimal(this.txtSubtotalPDesc.Text);

                string iva1 = "1." + iva.ToString("##");

                double impuesto = 0;

                double impuestop = 0;

                double subtotal = 0;

                double subtotalp = 0;

                double descuento = 0;

                string ivas = "1." + iva.ToString("##");

                this.objFacturar.TipoPrecio = Convert.ToInt32(this.cmbListaPrecios.Text.Substring(this.cmbListaPrecios.Text.Length - 1, 1));

                //obtengo impuesto y subtotalp descuento
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    cantlineas++;
                    cantarticulos += Convert.ToDecimal(item.Cells[3].Value);

                    this.objFacturar.ObtieneProductoCodigo(item.Cells[0].Value.ToString());

                    double porcd = Convert.ToDouble(item.Cells[4].Value) / 100;

                    double invporcd = 1;

                    if (Convert.ToDouble(item.Cells[4].Value) > 0)
                    {
                        invporcd = (100 - Convert.ToDouble(item.Cells[4].Value)) / 100;
                    }

                    if (this.objFacturar.IV==true)//si tiene impuesto
                    {
                        double ivaporc=Convert.ToDouble(iva/100);//0.13
                        impuesto += (((Convert.ToDouble(item.Cells[2].Value) *ivaporc)* Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                        impuestop += (((Convert.ToDouble(item.Cells[2].Value) * ivaporc) * Convert.ToDouble(item.Cells[3].Value)));
                    }

                    subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));
                }

                this.lblCantidadLineas.Text = cantlineas.ToString("F");

                this.lblCantidadArticulos.Text = cantarticulos.ToString("F");

                this.txtSubtotalPDesc.Text = (subtotalp).ToString("#0,#.#0");

                this.txtSubtotal.Text = (subtotal).ToString("#0,#.#0");

                this.txtImpuesto.Text = (impuesto).ToString("#0,#.#0");

                this.txtDescuentoAplicado.Text = (descuento).ToString("#0,#.#0");
                //fin de obtengo impuesto y subtotalp descuento

                double totaltext = 0;

                totaltext =Convert.ToDouble(Convert.ToDouble(this.txtSubtotal.Text) + Convert.ToDouble(this.txtImpuesto.Text));

                this.txtTotal.Text = totaltext.ToString("#0,#.#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtDescuentoAplicado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.txtSubtotalPDesc.Text) > 0)
                {
                    this.txtPorcDescuento.Text = decimal.Round(((Convert.ToDecimal(this.txtDescuentoAplicado.Text) * 100) / Convert.ToDecimal(this.txtSubtotalPDesc.Text)), 4).ToString();
                }
                else
                {
                    this.txtPorcDescuento.Text = "0.00";
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtPorcDescuento_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == (Keys.Enter))
                {
                    try
                    {
                        Convert.ToDecimal(this.txtPorcDescuento.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Para el descuento ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtPorcDescuento.Text = "0.0000";
                        return;
                    }

                    this.txtPorcDescuento.Text = decimal.Round(Convert.ToDecimal(this.txtPorcDescuento.Text), 4).ToString();

                    decimal porcdescitem1 = (Convert.ToDecimal(this.txtPorcDescuento.Text) / 100);

                    decimal invporcdescitem1 = 1;

                    if (Convert.ToDecimal(this.txtPorcDescuento.Text) > 0)
                    {
                        invporcdescitem1 = ((100 - (Convert.ToDecimal(this.txtPorcDescuento.Text))) / 100);
                    }

                    foreach (DataGridViewRow item1 in this.dgvDatos.Rows)
                    {
                        decimal precio=Convert.ToDecimal(item1.Cells[2].Value);
                        decimal cantidad=Convert.ToDecimal(item1.Cells[3].Value);

                        item1.Cells[4].Value = Convert.ToDecimal(this.txtPorcDescuento.Text).ToString("F");//%desc

                        if (this.objFacturar.ObtieneProducto((item1.Cells[0].Value.ToString())) == false)
                        {
                            return;
                        }

                        item1.Cells[5].Value = (precio * cantidad * porcdescitem1).ToString("#0,#.#0");//descuentomonto

                        item1.Cells[6].Value = ((precio * cantidad) - Convert.ToDecimal(item1.Cells[5].Value)).ToString("#0,#.#0");//SUBTOTAL
                    }

                    this.CalculaFooter();

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar aplicar el descuento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSubtotalPDesc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.txtSubtotalPDesc.Text) > 0)
                {
                    this.txtPorcDescuento.Text = decimal.Round(((Convert.ToDecimal(this.txtDescuentoAplicado.Text) * 100) / Convert.ToDecimal(this.txtSubtotalPDesc.Text)), 4).ToString();
                }
                else
                {
                    this.txtPorcDescuento.Text = "0.00";
                }
            }
            catch (Exception)
            {

            }
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificaLinea();
        }

        private void gb1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEmitirFacturaTemp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }

                    if (this.dgvDatos.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay artículos agregados actualmente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (this.txtComprobante.Text.Length == 0)
                    {
                        MessageBox.Show("Por favor digite el comprobante de factura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    this.objComprar.Articulos.Clear();

                    this.objComprar.ComprobanteId = this.txtComprobante.Text;
                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objComprar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + //codigo
                            Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" + //punitario
                            Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + //cantid
                            Convert.ToDecimal(item.Cells[4].Value.ToString()) + ";" + //porcdesc
                            Convert.ToDecimal(item.Cells[5].Value.ToString()) + ";" + //descuento
                            Convert.ToDecimal(item.Cells[6].Value.ToString())); //subtotal
                    }
                    this.objComprar.Subtotal = Convert.ToDecimal(this.txtSubtotalPDesc.Text);

                    this.objComprar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objComprar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objComprar.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objComprar.CompraCheque = Convert.ToBoolean(this.chkCheque.CheckState);

                    this.objComprar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objComprar.Recibido = 0;

                    this.objComprar.Cambio = 0;

                    this.objComprar.ProveedorId = Convert.ToInt32(this.cmbProveedor.SelectedValue.ToString());

                    this.objComprar.Fecha = Convert.ToDateTime(this.dtpFecha.Value).ToString();

                    this.objTicket.Fecha = Convert.ToDateTime(this.dtpFecha.Value);

                    switch (Accion)
                    {
                        case 1:
                            this.objComprar.IngresaEncabezadoFacturaTemp(Login.UserId);
                        break;
                        case 3:
                            this.objComprar.ActualizaFacturaTemp(FacturaId, Login.UserId);
                        break;
                    }
                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objComprar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + //codigo
                            Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" + //punitario
                            Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + //cantid
                            Convert.ToDecimal(item.Cells[4].Value.ToString()) + ";" + //porcdesc
                            Convert.ToDecimal(item.Cells[5].Value.ToString()) + ";" + //descuento
                            Convert.ToDecimal(item.Cells[6].Value.ToString())); //subtotal
                    }

                    this.LimpiaFactura();

                    this.Compras_Mantenimiento_Load(sender, e);

                    _owner.Compras_Mod_Load(sender, e);

                    _owner.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar generar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPUnitario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
