using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;//Libreria para la redimensión del scrollbar
using PuntoVentaBL;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace PuntoVentaPresentacion
{
    public partial class Facturacion_Mod : Form
    {
        Sel_Mod _owner;

        ApartadoAgrega_Abono _owner2;

        Facturacion_Pago _owner3;

        public string NumTarjeta = "0";
        public decimal cantcompra;

        public string cajeronombretemp = "";

        public int cajeroidtemp = 0;

        public decimal impuestotemp = 0;

        public int FormaPagoId = 0;//1 efectivo 2 tarjeta credito 3 credito cliente

        string temp = string.Empty;

        public int permiso = 0;

        public decimal iva = 0;

        double tempnum = 0;

        public decimal MontoApartado = 0;

        public int DiasApartado = 0;

        public int DescuentoCajaDiaria = 0;

        public int imprime = 0;

        PuntoVentaBL.Apartados objApartados = new PuntoVentaBL.Apartados();

        PuntoVentaBL.ImpresionProforma objImpresionProforma = new PuntoVentaBL.ImpresionProforma();

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

        PuntoVentaBL.Proforma objProforma = new PuntoVentaBL.Proforma();

        PuntoVentaBL.Prefactura objPrefactura = new PuntoVentaBL.Prefactura();

        PuntoVentaBL.NotaCredito objNotaCredito = new PuntoVentaBL.NotaCredito();

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        public PuntoVentaBL.Ticket objTicket = new PuntoVentaBL.Ticket();

        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

        public PuntoVentaBL.Persona objReceptor = null;

        PuntoVentaDAL.CONEXIONDataContext db = new PuntoVentaDAL.CONEXIONDataContext();

        public string CodigoS = string.Empty;

        public string CantidadS = string.Empty;

        public string ListaPreciosS = string.Empty;

        public int ClienteN = 0;

        public decimal recibido = 0;



        public decimal cambio = 0;

        public decimal subtotal = 0;

        public decimal pagoparcial = 0;

        public decimal SaldoRestantePorPagar = 0;

        public Int64 NumeroProforma = 0;

        public Int64 ProforomaMostrar, ProfId = 0;

        public Int64 PrefacturaMostrar, PrefId = 0;

        public Int64 NotaCreditoMostrar, NotId, FacturaIdNotaCredito = 0;

        public Int64 ApartadoId = 0;

        public int PagoEfectivoId = 0;

        public decimal precioivaactualiza, porcdescactualiza, descuentodescactualiza, totaldescactualiza = 0;

        public decimal VentaCreditoMonto, VentaTarjetaCredito, VentaEfectivo, VentaNotaCredito = 0;

        public static Verificar veri = new Verificar();

        public static Verificar[] veri_veri = new Verificar[100];

        public static int indice;
        int veces = 0;
        decimal impuesto;

        public static int exonerada;

        public Facturacion_Mod(Sel_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public Facturacion_Mod(ApartadoAgrega_Abono owner)
        {
            InitializeComponent();

            _owner2 = owner;


            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        public Facturacion_Mod(Facturacion_Pago owner)
        {
            InitializeComponent();

            _owner3 = owner;


            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing3);
        }

        //*************************************************

        public void llenar_combo()
        {

            this.combo_tipo.Items.Add("--Seleccione--");
            this.combo_tipo.Items.Add("No Exonerada");
            this.combo_tipo.Items.Add("Exonerada");

            for (int i = 0; i < combo_tipo.Items.Count; i++)
            {
                //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                if (combo_tipo.GetItemText(combo_tipo.Items[i]) == "No Exonerada")
                {
                    combo_tipo.SelectedIndex = i;

                }
            }


            this.combo_tipo2.Items.Add("--Seleccione--");
            this.combo_tipo2.Items.Add("No Exonerada");
            this.combo_tipo2.Items.Add("Exonerada");

            for (int i = 0; i < combo_tipo2.Items.Count; i++)
            {
                //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                if (combo_tipo2.GetItemText(combo_tipo2.Items[i]) == "No Exonerada")
                {
                    combo_tipo2.SelectedIndex = i;

                }
            }


        }

        //******************************************************

        public void Facturacion_Mod_Load(object sender, EventArgs e)
        {
            try
            {




                this.ActiveControl = this.txtCodigo;

                this.OpenConn();

                llenar_combo();
                veces++;
                Facturacion_Mod.indice = 0;
                for (int i = 0; i < 90; i++)
                {
                    Facturacion_Mod.veri.codigo = null;
                    Facturacion_Mod.veri.estado = 0;
                    Facturacion_Mod.veri_veri[i] = Facturacion_Mod.veri;
                }

                var bus = (from x in db.InformacionGeneral
                           select x);

                iva = Convert.ToDecimal(bus.First().IVA);

                this.cmbTipoFactura.Text = "Factura 1";

                this.cmbListaPrecios.Text = "Lista de precios 1";

                this.cmbTipoComprobante.Text = "Factura";

                this.comboBox1.Text = "F10-SALIR";

                this.gb2.Visible = false;
                this.dgvDatos2.Visible = false;
                this.gb1.Visible = true;
                this.dgvDatos.Visible = true;






                this.objcliente.ObtieneClientes(this.cmbCliente);


                //if (ApartadoId!=0)
                //{
                //    this.MuestraApartado();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar el módulo de facturación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Facturacion_Mod_Load()//para llamarlo desde f-
        {
            try
            {
                this.ActiveControl = this.txtCodigo;

                this.txtCodigo.Focus();

                this.cmbTipoFactura.Text = "Factura 1";

                this.gb2.Visible = false;
                this.dgvDatos2.Visible = false;
                this.gb1.Visible = true;
                this.dgvDatos.Visible = true;



                this.objcliente.ObtieneClientes(this.cmbCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar el módulo de facturación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Close();
        }

        private void Form2_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this._owner3.Close();
        }

        private void Facturacion_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MuestraProforma()
        {
            try
            {
                if (this.ProforomaMostrar != 0)
                {
                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        this.dgvDatos2.Visible = false;
                        this.gb2.Visible = false;
                        this.gb1.Visible = true;
                        this.dgvDatos.Visible = true;
                        this.dgvDatos.Rows.Clear();

                        this.objProforma.MostrarProforma(this.dgvDatos, this.ProforomaMostrar);

                        this.lblCantidadLineas.Text = this.objProforma.CantidadLineas.ToString();
                        this.lblCantidadArticulos.Text = this.objProforma.CantidadArticulos.ToString();

                        this.ClienteN = this.objProforma.ClienteId;
                        this.CambiaCliente();

                        this.CalculaFooter();
                    }
                    if (this.cmbTipoFactura.Text == "Factura 2")
                    {
                        this.dgvDatos2.Visible = true;
                        this.gb2.Visible = true;
                        this.gb1.Visible = false;
                        this.dgvDatos.Visible = false;
                        this.dgvDatos2.Rows.Clear();

                        this.objProforma.MostrarProforma(this.dgvDatos2, this.ProforomaMostrar);

                        this.lblCantidadLineas2.Text = this.objProforma.CantidadLineas.ToString();
                        this.lblCantidadArticulos2.Text = this.objProforma.CantidadArticulos.ToString();

                        this.ClienteN = this.objProforma.ClienteId;
                        this.CambiaCliente();

                        this.CalculaFooter2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Proforma()
        {
            if (this.ProforomaMostrar == 0)//no se ha buscado ninguna proforma
            {
                this.GeneraProforma();
            }
            else//se esta consultando una proforma
            {
                this.ModificaProforma();
            }

            ProfId = this.objProforma.FacturaId;

            MessageBox.Show("Número de proforma: " + this.objProforma.FacturaId, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //this.LimpiaFactura();

            //this.ProforomaMostrar = 0;

            //this.cmbTipoComprobante.Text = "Factura";

            //this.cmbTipoFactura.Text = "Factura 1";

            //if (this.cmbTipoFactura.Text == "Factura 1")
            //{
            //    this.lblCantidadArticulos.Text = "0";
            //    this.lblCantidadLineas.Text = "0";
            //    this.txtTotal.Text = "0.00";
            //    this.txtSubtotal.Text = "0.00";
            //    this.txtPorcDescuento.Text = "0";
            //    this.txtDescuentoAplicado.Text = "0.00";
            //    this.txtSubtotalPDesc.Text = "0.00";
            //    this.txtImpuesto.Text = "0.00";
            //    this.dgvDatos.Rows.Clear();
            //    this.txtNuevoCliente.Text = string.Empty;
            //}
            //if (this.cmbTipoFactura.Text == "Factura 2")
            //{
            //    this.lblCantidadArticulos2.Text = "0";
            //    this.lblCantidadLineas2.Text = "0";
            //    this.txtTotal2.Text = "0.00";
            //    this.txtSubtotal2.Text = "0.00";
            //    this.txtPorcDescuento2.Text = "0";
            //    this.txtDescuentoAplicado2.Text = "0.00";
            //    this.txtSubtotalPDesc2.Text = "0.00";
            //    this.txtImpuesto2.Text = "0.00";
            //    this.dgvDatos2.Rows.Clear();
            //    this.txtNuevoCliente.Text = string.Empty;
            //}

            this.ActiveControl = this.txtCodigo;

            return;
        }

        public void ImprimeGraficoProforma()
        {
            this.objImpresionProforma.FacturaId = Convert.ToInt64(ProfId);

            this.objImpresionProforma.Fecha = System.DateTime.Now.ToShortDateString();

            if (this.txtNuevoCliente.Text.Length > 0)
            {
                this.objImpresionProforma.ClienteNombre = this.txtNuevoCliente.Text;
            }
            else
            {
                this.objImpresionProforma.ClienteNombre = this.cmbCliente.Text;
            }


            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    this.objImpresionProforma.Articulos.Add(
                        item.Cells[0].Value.ToString() + ";" +
                        item.Cells[1].Value.ToString() + ";" +
                        item.Cells[2].Value.ToString() + ";" +
                        item.Cells[3].Value.ToString() + ";" +
                        item.Cells[4].Value.ToString() + ";" +
                        item.Cells[6].Value.ToString()
                        );
                }

                this.objImpresionProforma.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                this.objImpresionProforma.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                this.objImpresionProforma.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                this.objImpresionProforma.subtotal = Convert.ToDecimal(this.txtSubtotal.Text);
            }

            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                {
                    this.objImpresionProforma.Articulos.Add(
                        item.Cells[0].Value.ToString() + ";" +
                        item.Cells[1].Value.ToString() + ";" +
                        item.Cells[2].Value.ToString() + ";" +
                        item.Cells[3].Value.ToString() + ";" +
                        item.Cells[4].Value.ToString() + ";" +
                        item.Cells[6].Value.ToString()
                        );
                }

                this.objImpresionProforma.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                this.objImpresionProforma.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                this.objImpresionProforma.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                this.objImpresionProforma.subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);
            }

            this.objImpresionProforma.CajeroNombre = Login.LoginUsuarioFinal.ToString();

            this.objImpresionProforma.print();
        }
        //emitir factura
        private void btnEmitirFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }
                //jugadita tosty aquii
                if ((combo_tipo.Text == "Exonerada") && (this.cmbTipoFactura.Text == "Factura 1"))
                {
                    this.txtImpuesto.Text = "0.00";
                    this.txtTotal.Text = this.txtSubtotal.Text;
                    //     MessageBox.Show("jugada en accion");
                    Facturacion_Mod.exonerada = 1;

                }
                else
                {
                    exonerada = 0;
                }

                //***************************

                if (this.dgvDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay artículos agregados actualmente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                #region Apartado
                if (this.cmbTipoComprobante.Text == "Apartado")
                {
                    if (this.cmbCliente.SelectedValue.ToString() == "1")
                    {
                        MessageBox.Show("Debe seleccionar un cliente para el apartado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ApartadoCrear form = new ApartadoCrear(this);
                    form.TopLevel = false;
                    form.Parent = this;
                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        form.Total = Convert.ToDecimal(this.txtTotal.Text);
                    }
                    if (this.cmbTipoFactura.Text == "Factura 2")
                    {
                        form.Total = Convert.ToDecimal(this.txtTotal2.Text);
                    }
                    form.Show();

                    return;
                }
                #endregion

                #region Nota de Credito
                if (this.cmbTipoComprobante.Text == "Nota de crédito")
                {
                    if (this.cmbCliente.SelectedValue.ToString() == "1")
                    {
                        MessageBox.Show("Debe seleccionar un cliente para la nota de crédito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (this.NotaCreditoMostrar != 0)
                    {
                        if (DialogResult.OK == MessageBox.Show("Desea agregar una nueva nota de crédito?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        {
                            this.NotaCreditoMostrar = 0;
                            Sel_NotaCredito form1 = new Sel_NotaCredito(this);
                            form1.TopLevel = false;
                            form1.Parent = this;

                            form1.Show();
                        }
                        return;
                    }
                    Sel_NotaCredito form = new Sel_NotaCredito(this);
                    form.TopLevel = false;
                    form.Parent = this;
                    form.Show();

                    return;
                }
                #endregion

                #region Proforma
                if (this.cmbTipoComprobante.Text == "Proforma")
                {
                    if (this.cmbCliente.SelectedValue.ToString() == "1")
                    {
                        MessageBox.Show("Debe seleccionar un cliente para la proforma", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (this.ProforomaMostrar != 0)//para modificarla unicamente
                    {
                        this.Proforma();
                        this.LimpiaFactura();
                        ProforomaMostrar = 0;
                        this.LimpiaFactura2();
                        return;
                    }
                    Proforma_Anexo anexo = new Proforma_Anexo(this);
                    anexo.TopLevel = false;
                    anexo.Parent = this;
                    anexo.Show();

                    return;
                }
                #endregion


                #region Prefactura
                if (this.cmbTipoComprobante.Text == "Prefactura")
                {
                    //pago.Prefactura = 1;
                    if (this.cmbCliente.SelectedValue.ToString() == "1")
                    {
                        MessageBox.Show("Debe seleccionar un cliente para la prefactura", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    this.Prefactura();

                    this.LimpiaFactura();

                    this.PrefacturaMostrar = 0;

                    this.LimpiaFactura2();

                    //this.Close();

                    return;
                }
                #endregion

                Facturacion_Pago pago = new Facturacion_Pago(this);
                pago.TopLevel = false;
                pago.Parent = this;

                #region Tipo de Factura 1
                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    if (Convert.ToDecimal(this.txtTotal.Text) > 0)
                    {
                        pago.Total = Convert.ToDecimal(this.txtTotal.Text);
                        pago.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);
                        this.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc.Text);
                    }
                }
                #endregion

                #region Tipo de Factura 2
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    if (Convert.ToDecimal(this.txtTotal2.Text) > 0)
                    {
                        pago.Total = Convert.ToDecimal(this.txtTotal2.Text);
                        pago.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);
                        this.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc2.Text);
                    }
                }
                #endregion


                pago.proformaid = ProforomaMostrar;
                pago.prefacturaid = PrefacturaMostrar;

                pago.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //termina emitir factura


        #region Construye ticket
        public void ConstruyeTicket()
        {
            int factura;
            String estado_factura = "";

            try
            {
                this.objTicket.Articulos.Clear();
                this.objTicket.FacturaIdString = FacturaIdNotaCredito.ToString();
                if (this.cmbTipoFactura.Text == "Factura 1")
                {

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));
                        string codigo = this.objFacturar.Codigo;
                        //this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                        else
                        {
                            x = "E";
                        }

                        this.objTicket.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                        decimal cantidad = (Convert.ToDecimal(item.Cells[3].Value.ToString()));
                        decimal temp = (Convert.ToDecimal(item.Cells[2].Value.ToString()) * cantidad);

                        double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        //this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit
                        //aqui la jugada tosty
                        if (x == "G")
                        {
                            this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + "*" + totaliva.ToString("F") + ";" + x);
                        }
                        else
                        {
                            this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + " " + totaliva.ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit
                        }
                        this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                        this.objTicket.AltoPapel += 20;
                    }

                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        //this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                        else
                        {
                            x = "E";
                        }

                        this.objTicket.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                        decimal cantidad = (Convert.ToDecimal(item.Cells[3].Value.ToString()));
                        decimal temp = (Convert.ToDecimal(item.Cells[2].Value.ToString()) * cantidad);

                        double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        //this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit

                        if (x == "G")
                        {
                            this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + "*" + totaliva.ToString("F") + ";" + x);
                        }
                        else
                        {
                            this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + " " + totaliva.ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit
                        }
                        //  this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + totaliva.ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                        this.objTicket.AltoPapel += 20;
                    }
                }
                if (this.subtotal > 0)
                {
                    this.objTicket.subtotal = this.subtotal;
                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        if (this.combo_tipo.Text == "Exonerada")
                        {
                            estado_factura = "  Factura Exonerada";
                            //  MessageBox.Show("factura exonerada ");
                        }
                        factura = 1;
                    }

                    if (this.cmbTipoFactura.Text == "Factura 2")
                    {
                        this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc2.Text);
                        if (this.combo_tipo2.Text == "Exonerada")
                        {
                            estado_factura = "  Factura Exonerada";
                        }
                        factura = 2;
                    }
                    //*****************************************
                }
                else
                {

                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc.Text);
                        //   MessageBox.Show("hola mundo " + this.combo_tipo.Text);
                        if (this.combo_tipo.Text == "Exonerada")
                        {
                            estado_factura = "  Factura Exonerada";
                            //  MessageBox.Show("factura exonerada ");
                        }
                        factura = 1;
                    }
                    if (this.cmbTipoFactura.Text == "Factura 2")
                    {
                        this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc2.Text);
                        if (this.combo_tipo2.Text == "Exonerada")
                        {
                            estado_factura = "  Factura Exonerada";
                        }
                        factura = 2;
                    }
                }


                this.OpenConn();

                if (this.cmbTipoComprobante.Text == "Proforma")
                {
                    if (ProforomaMostrar == 0)
                    {
                        var bus = (from x in db.ProformaEncabezados
                                   orderby x.Id descending
                                   select x).First();
                        this.objTicket.FacturaId = bus.Id;
                        this.objTicket.Proforma = 1;
                        this.cajeronombretemp = Login.LoginUsuarioFinal;
                        //this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;

                    }
                    else
                    {
                        this.objTicket.FacturaId = ProforomaMostrar;
                        this.objTicket.Proforma = 1;

                        var bus = (from x in db.ProformaEncabezados
                                   join u in db.Usuarios on x.UsuarioId equals u.Id
                                   where x.Id == ProforomaMostrar
                                   select new { Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido) }).First();

                        //this.objTicket.CajeroNombre = bus.Nombre.ToString();
                        this.cajeronombretemp = bus.Nombre.ToString();
                    }


                    MessageBox.Show("Número de proforma: " + this.objTicket.FacturaId, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else if (this.cmbTipoComprobante.Text == "Prefactura")
                {
                    if (PrefacturaMostrar == 0)
                    {
                        var bus = (from x in db.PrefacturaEncabezados
                                   orderby x.Id descending
                                   select x).First();
                        this.objTicket.FacturaId = bus.Id;
                        this.objTicket.Prefactura = 1;
                        //this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;
                        this.cajeronombretemp = Login.LoginUsuarioFinal;

                    }
                    else
                    {
                        this.objTicket.FacturaId = PrefacturaMostrar;
                        this.objTicket.Prefactura = 1;

                        var bus = (from x in db.PrefacturaEncabezados
                                   join u in db.Usuarios on x.UsuarioId equals u.Id
                                   where x.Id == PrefacturaMostrar
                                   select new { Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido) }).First();

                        //this.objTicket.CajeroNombre = bus.Nombre.ToString();
                        this.cajeronombretemp = bus.Nombre.ToString();
                    }


                    MessageBox.Show("Número de prefactura: " + this.objTicket.FacturaId, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (this.cmbTipoComprobante.Text == "Nota de crédito")
                {
                    if (NotaCreditoMostrar == 0)
                    {
                        var bus = (from x in db.NotaEncabezados
                                   orderby x.Id descending
                                   select x).First();

                        this.objTicket.FacturaId = bus.Id;
                        this.objTicket.NotaCredito = 1;
                        //this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;
                        this.cajeronombretemp = Login.LoginUsuarioFinal;

                    }
                    else
                    {
                        this.objTicket.FacturaId = NotaCreditoMostrar;
                        this.objTicket.NotaCredito = 1;

                        var bus = (from x in db.NotaEncabezados
                                   join u in db.Usuarios on x.UsuarioId equals u.Id
                                   where x.Id == NotaCreditoMostrar
                                   select new { Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido) }).First();

                        //this.objTicket.CajeroNombre = bus.Nombre.ToString();
                        this.cajeronombretemp = bus.Nombre.ToString();
                    }


                    MessageBox.Show("Número de nota de crédito: " + this.objTicket.FacturaId, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    this.objTicket.FacturaId = this.objFacturar.FacturaId;

                    //this.cajeronombretemp = Login.LoginUsuarioFinal;
                    //this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;
                }

                if (this.txtNuevoCliente.Text.Length == 0)
                {
                    this.objTicket.ClienteNombre = this.cmbCliente.Text;
                }
                else
                {
                    this.objTicket.ClienteNombre = this.txtNuevoCliente.Text;
                }

                //this.objTicket.CajeroNombre = this.cajeronombretemp;

                if (this.cajeronombretemp.Length > 0)
                {
                    this.objTicket.CajeroNombre = this.cajeronombretemp;
                }
                else
                {
                    this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;
                }

                this.objTicket.Recibido = recibido;
                this.objTicket.Monto_efectivo = VentaEfectivo;
                this.objTicket.Monto_tarjeta = VentaTarjetaCredito;

                this.objTicket.Cambio = cambio;

                this.objTicket.ObtieneInformacionGeneral();

                //if (this.FormaPagoId == 1)//efectivo
                //{
                //    this.objTicket.TipoFactura = "Contado";
                //}
                //else 
                //  if (this.FormaPagoId == 2)//tcredito
                // {
                //  this.objTicket.TipoFactura = "T.Crédito";
                //}
                //else 
                this.objTicket.TipoFactura = "";

                if (this.FormaPagoId == 3)//credito cliente
                {
                    this.objTicket.TipoFactura = "Crédito FIRMA_______________";
                }


                if (estado_factura != "")
                {

                    this.objTicket.TipoFactura = this.objTicket.TipoFactura + estado_factura;
                }
                ////this.objTicket.TipoFactura = "Contado";


                this.objTicket.print();

                this.objTicket.Offset = 40;

                this.cajeronombretemp = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string Completar_Cero(String Num_org, int Largo)
        {
            string Num_Modf = Num_org;
            for (int i = 0; Num_Modf.Length < Largo; i++)
            {
                Num_Modf = "0" + Num_Modf;
            }
            return Num_Modf;
        }
        public string Generar_Reporte_XML(String Tipo_Comprobante, String NumFact, Persona Emisor)
        {
            XML xml = new XML();
            DetalleServicio servicio = new DetalleServicio();
            String NumCon = "";
            String Clave = "";
            try
            {
                //Crear Numero Consucutivo

                string Sucursales = _owner.objInformacionGeneral._Numero_Sucursal;
                Sucursales = Completar_Cero(Sucursales, 3);
                NumCon = NumCon + Sucursales;

                string id = db.Equipos.Where(x => x.NombreEquipo == System.Environment.MachineName.ToString()).Select(n => n.Id).FirstOrDefault().ToString();
                id = Completar_Cero(id, 5);
                NumCon = NumCon + id;

                NumCon = NumCon + Tipo_Comprobante;

                NumFact = Completar_Cero(NumFact, 10);
                NumCon = NumCon + NumFact;

                int largo_NumCon = NumCon.Length;

                //Crear Clave 
                Clave = Clave + "506";

                Clave = Clave + DateTime.Now.ToString("dd");
                Clave = Clave + DateTime.Now.ToString("MM");
                Clave = Clave + DateTime.Now.ToString("yy");

                string ced = Completar_Cero(_owner.objInformacionGeneral._Numero_Cedula, 12);
                Clave = Clave + ced;
                Clave = Clave + NumCon;

                Clave = Clave + "1";

                Random r = new Random();
                int Cod_Seguridad = r.Next(0, 99999999);
                String cod = Completar_Cero(Cod_Seguridad.ToString(), 8);
                Clave = Clave + cod;

                int largo_Clave = Clave.Length;
                int numero_linea = 1;


                // Tipo de pago 
                String Tipo_Pago = "0" + this.FormaPagoId.ToString();

                ResumenFactura resumen = new ResumenFactura();
                double mercancias_gravadas = 0;
                double mercancias_excentas = 0;
                double TotalVenta = 0;
                double TotalDescuento = 0;
                double TotalImpuesto = 0;
                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {

                        LineaDetalle Linea = new LineaDetalle(); // Linea del xml

                        Linea.NumeroLinea = numero_linea.ToString(); // num linea
                        Linea.Cod_Tipo = "01"; // Cod linea
                        Linea.Cod_Numero = item.Cells[0].Value.ToString();//Codigo
                        Linea.Detalle = item.Cells[1].Value.ToString(); //Detalle 

                        double impuesto = Convert.ToDouble(item.Cells[8].Value);
                        double precio_uni = Convert.ToDouble(item.Cells[2].Value) - impuesto;
                        int cantidad = Convert.ToInt32(item.Cells[3].Value);
                        double monto_total = precio_uni * cantidad;

                        double descuento = Convert.ToDouble(item.Cells[5].Value);
                        TotalDescuento += descuento;

                        double subtotal = monto_total - descuento;
                        TotalVenta += monto_total;

                        if (impuesto > 0)
                        {
                            if (descuento > 0) //Recalcular impuesto
                            {
                                double imp_porc = Math.Round(1 - (subtotal / (precio_uni * cantidad)), 2);
                                impuesto = Math.Round(impuesto - (impuesto * imp_porc), 2);
                            }
                            impuesto = impuesto * cantidad;
                            mercancias_gravadas += monto_total;
                        }
                        else { mercancias_excentas += monto_total; }

                        Linea.PrecioUnitario = precio_uni.ToString();//PrecioUnitario  //.Replace(",", ".")
                        Linea.Cantidad = cantidad.ToString();//Cantidad

                        Linea.MontoTotal = monto_total.ToString(); //Monto Total
                        Linea.Descuento = descuento.ToString();

                        Linea.Subtotal = subtotal.ToString();
                        TotalImpuesto += impuesto;
                        Linea.Impuesto = impuesto.ToString();

                        Linea.MontoTotalLinea = item.Cells[6].Value.ToString().Replace(",", ""); //Total IVA
                        Linea.UnidadMedida = "Unid";
                        numero_linea++;
                        servicio.LineasDetalle.Add(Linea);
                    }


                    resumen.CodigoMoneda = "CRC";
                    resumen.TipoCambio = "1";
                    resumen.TotalGravado = mercancias_gravadas.ToString();
                    resumen.TotalExcento = mercancias_excentas.ToString();
                    resumen.TotalMercanciasGravadas = mercancias_gravadas.ToString();
                    resumen.TotalMercanciasExentas = mercancias_excentas.ToString();
                    resumen.TotalVenta = TotalVenta.ToString();
                    resumen.TotalDescuento = TotalDescuento.ToString();
                    resumen.TotalVentaNeta = (TotalVenta - TotalDescuento).ToString();
                    resumen.TotalImpuesto = TotalImpuesto.ToString();
                    resumen.TotalComprobante = ((TotalVenta - TotalDescuento) + TotalImpuesto).ToString();
                }


                else
                {
                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        LineaDetalle Linea = new LineaDetalle(); // Linea del xml

                        Linea.NumeroLinea = numero_linea.ToString(); // num linea
                        Linea.Cod_Tipo = "01"; // Cod linea
                        Linea.Cod_Numero = item.Cells[0].Value.ToString();//Codigo
                        Linea.Detalle = item.Cells[1].Value.ToString(); //Detalle 

                        double impuesto = Convert.ToDouble(item.Cells[7].Value);
                        double precio_uni = Convert.ToDouble(item.Cells[2].Value) - impuesto;
                        int cantidad = Convert.ToInt32(item.Cells[3].Value);
                        double monto_total = precio_uni * cantidad;

                        double descuento = Convert.ToDouble(item.Cells[5].Value);
                        TotalDescuento += descuento;

                        double subtotal = monto_total - descuento;
                        TotalVenta += monto_total;

                        if (impuesto > 0)
                        {
                            if (descuento > 0) //Recalcular impuesto
                            {
                                double imp_porc = Math.Round(1 - (subtotal / (precio_uni * cantidad)), 2);
                                impuesto = Math.Round(impuesto - (impuesto * imp_porc), 2);
                            }
                            impuesto = impuesto * cantidad;
                            mercancias_gravadas += monto_total;
                        }
                        else { mercancias_excentas += monto_total; }

                        Linea.PrecioUnitario = precio_uni.ToString();//PrecioUnitario  //.Replace(",", ".")
                        Linea.Cantidad = cantidad.ToString();//Cantidad

                        Linea.MontoTotal = monto_total.ToString(); //Monto Total
                        Linea.Descuento = descuento.ToString();

                        Linea.Subtotal = subtotal.ToString();
                        TotalImpuesto += impuesto;
                        Linea.Impuesto = impuesto.ToString();

                        Linea.MontoTotalLinea = item.Cells[6].Value.ToString().Replace(",", ""); //Total IVA
                        Linea.UnidadMedida = "Unid";
                        numero_linea++;
                        servicio.LineasDetalle.Add(Linea);
                    }


                    resumen.CodigoMoneda = "CRC";
                    resumen.TipoCambio = "1";
                    resumen.TotalGravado = mercancias_gravadas.ToString();
                    resumen.TotalExcento = mercancias_excentas.ToString();
                    resumen.TotalMercanciasGravadas = mercancias_gravadas.ToString();
                    resumen.TotalMercanciasExentas = mercancias_excentas.ToString();
                    resumen.TotalVenta = TotalVenta.ToString();
                    resumen.TotalDescuento = TotalDescuento.ToString();
                    resumen.TotalVentaNeta = (TotalVenta - TotalDescuento).ToString();
                    resumen.TotalImpuesto = TotalImpuesto.ToString();
                    resumen.TotalComprobante = ((TotalVenta - TotalDescuento) + TotalImpuesto).ToString();
                }

                string factura = "";

                if (Tipo_Comprobante == "04")
                {
                    factura = xml.crear_factura(Clave, NumCon, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss-06:00"), Emisor, "01", "", Tipo_Pago, servicio, resumen, "DGT-R-48-2016", "20-02-2017 13:22:22");
                }
                else
                {
                    factura = xml.crear_factura(Clave, NumCon, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss-06:00"), Emisor, objReceptor, "01", "", Tipo_Pago, servicio, resumen, "DGT-R-48-2016", "20-02-2017 13:22:22");
                    objReceptor = null;
                }
                objTicket._Clave = NumCon;
                return factura;
            }
            catch (Exception e)
            {
                return "";
            }
        }



        public void Reporte_Hacienda(bool Factura_Electronica)
        {
            Persona loader = new Persona();
            Persona Emisor = loader.Cargar_Emmisor();
            if (Emisor != null)
            {
                if (Factura_Electronica)
                {
                    Reporte_Factura(Emisor);
                }
                else
                {
                    Reporte_Tiquet(Emisor);
                }
            }
            else
            {
                MessageBox.Show("Emisor no disponible, imposible enviar el reporte a hacienda sin emisor, favor agregar una persona emisora.");
            }
        }

        public void Reporte_Factura(Persona Emisor)
        {
            PuntoVentaBL.Datos_Electronicos Reporte_Elect = new PuntoVentaBL.Datos_Electronicos();
            string NumFact = Reporte_Elect.Get_Consecutivo_Factura().ToString();

            try
            {

                string factura = Generar_Reporte_XML("01", NumFact, Emisor);

                //Datos Para guardar la Factura.
                Reporte_Elect.Fecha = DateTime.Today;
                Reporte_Elect.id_Factura_Local = (int)objFacturar.FacturaId;
                Reporte_Elect.Enviada = true;
                Reporte_Elect.Cancelada = false;
                Reporte_Elect.Monto_Factura = (int)Double.Parse(txtTotal.Text.Replace(",", ""));
                Reporte_Elect.Factura = factura;


                if (Reporte_Elect.Guardar_Factura())
                {
                    try
                    {
                        ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/receipts", "POST", factura, _owner.user, _owner.env);
                        string respose = request.GetResponse();
                        JObject o = JObject.Parse(respose);
                        string code = (string)o["code"];
                        if (code == "200")
                        {
                            string message = (string)o["state-reason"];
                            MessageBox.Show("Factura enviada! Estado de la factura: " + message);
                            objTicket._TipoDocumento = "Factura Electronica";
                        }
                        if (code == "201")
                        {
                            Reporte_Elect.Cancelar_Ticket(Int32.Parse(NumFact));
                        }
                        else
                        {
                            Reporte_Elect.Cancelar_Ticket(Int32.Parse(NumFact));
                        }
                    }
                    catch (Exception ex)
                    {
                        Reporte_Elect.Editar_Envio_Factura(Int32.Parse(NumFact), false);
                        MessageBox.Show("Error de Conexion: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la factura, revisar el estado de la base de datos. Factura Electronica no emitda");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reporte_Tiquet(Persona Emisor)
        {
            PuntoVentaBL.Datos_Electronicos Reporte_Elect = new PuntoVentaBL.Datos_Electronicos();
            string NumFact = Reporte_Elect.Get_Consecutivo_Tiquete().ToString();

            try
            {

                string factura = Generar_Reporte_XML("04", NumFact, Emisor);

                //Datos Para guardar la Factura.
                Reporte_Elect.Fecha = DateTime.Today;
                Reporte_Elect.id_Factura_Local = (int)objFacturar.FacturaId;
                Reporte_Elect.Enviada = true;
                Reporte_Elect.Cancelada = false;
                Reporte_Elect.Monto_Factura = (int)Double.Parse(txtTotal.Text.Replace(",", ""));
                Reporte_Elect.Factura = factura;



                if (Reporte_Elect.Guardar_Tiquete())
                {
                    try
                    {
                        ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/receipts", "POST", factura, _owner.user, _owner.env);
                        string respose = request.GetResponse();
                        JObject o = JObject.Parse(respose);
                        string code = (string)o["code"];
                        if (code == "200")
                        {
                            string message = (string)o["state-reason"];
                            MessageBox.Show("Factura enviada! Estado de la factura: " + message);
                            objTicket._TipoDocumento = "Tiquete Electronico";
                        }
                        if (code == "201")
                        {
                            Reporte_Elect.Cancelar_Ticket(Int32.Parse(NumFact));
                        }
                    }

                    catch (Exception ex)
                    {
                        Reporte_Elect.Editar_Envio_Tiquete(Int32.Parse(NumFact), false);
                        MessageBox.Show("Error de Conexion: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el tiquete, revisar el estado de la base de datos. Tiquete Electronico no emitido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        public void CierraFacturacion()
        {
            if (this.ApartadoId != 0)
            {
                this.Close();
            }
        }

        public void LimpiaFactura2()
        {

            this.cmbCliente.SelectedValue = 1;

            this.cmbTipoComprobante.Text = "Factura";
        }

        public bool GeneraProforma()
        {
            try
            {
                this.ConstruyeProformaEncabezadoDetalle();

                this.objProforma.IngresaEncabezadoProforma(Login.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ConstruyeProformaEncabezadoDetalle()
        {
            try
            {
                this.objProforma.LArticulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objProforma.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objProforma.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objProforma.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objProforma.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objProforma.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objProforma.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objProforma.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objProforma.LArticulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objProforma.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objProforma.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objProforma.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objProforma.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objProforma.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objProforma.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objProforma.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objProforma.LArticulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ModificaProforma()
        {
            try
            {
                this.ModificaProformaEncabezadoDetalle();

                this.objProforma.ModificaEncabezadoProforma();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ModificaProformaEncabezadoDetalle()
        {
            try
            {
                this.objProforma.LArticulos.Clear();

                this.objProforma.Id = ProforomaMostrar;

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objProforma.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objProforma.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objProforma.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objProforma.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objProforma.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objProforma.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objProforma.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objProforma.LArticulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objProforma.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objProforma.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objProforma.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objProforma.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objProforma.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objProforma.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objProforma.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objProforma.LArticulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void Prefactura()
        {
            if (this.PrefacturaMostrar == 0)//no se ha buscado ninguna proforma
            {
                this.GeneraPrefactura();
            }
            //else//se esta consultando una proforma
            //{
            //    this.ModificaPrefactura();
            //}

            var bus = (from x in db.PrefacturaEncabezados
                       orderby x.Id descending
                       select x).First();

            MessageBox.Show("Número de prefactura: " + bus.Id.ToString(), "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.cmbTipoComprobante.Text = "Factura";

            //this.cmbTipoFactura.Text = "Factura 1";

            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                this.lblCantidadArticulos.Text = "0";
                this.lblCantidadLineas.Text = "0";
                this.txtTotal.Text = "0.00";
                this.txtSubtotal.Text = "0.00";
                this.txtPorcDescuento.Text = "0";
                this.txtDescuentoAplicado.Text = "0.00";
                this.txtSubtotalPDesc.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.dgvDatos.Rows.Clear();
                this.txtNuevoCliente.Text = string.Empty;
            }

            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                this.lblCantidadArticulos2.Text = "0";
                this.lblCantidadLineas2.Text = "0";
                this.txtTotal2.Text = "0.00";
                this.txtSubtotal2.Text = "0.00";
                this.txtPorcDescuento2.Text = "0";
                this.txtDescuentoAplicado2.Text = "0.00";
                this.txtSubtotalPDesc2.Text = "0.00";
                this.txtImpuesto2.Text = "0.00";
                this.dgvDatos2.Rows.Clear();
                this.txtNuevoCliente.Text = string.Empty;
            }

            this.ActiveControl = this.txtCodigo;

            this.PrefacturaMostrar = 0;

            imprime = 0;

            return;
        }

        public void MuestraPrefactura()
        {
            try
            {
                if (this.PrefacturaMostrar != 0)
                {
                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        this.dgvDatos2.Visible = true;
                        this.gb2.Visible = true;
                        this.gb1.Visible = true;
                        this.dgvDatos.Visible = true;
                        this.dgvDatos.Rows.Clear();

                        this.objPrefactura.MostrarPrefactura(this.dgvDatos, this.PrefacturaMostrar);

                        this.lblCantidadLineas.Text = this.objPrefactura.CantidadLineas.ToString();
                        this.lblCantidadArticulos.Text = this.objPrefactura.CantidadArticulo.ToString();

                        this.ClienteN = this.objPrefactura.ClienteId;
                        this.CambiaCliente();

                        this.CalculaFooter();
                    }

                    if (this.cmbTipoFactura.Text == "Factura 2")
                    {
                        this.dgvDatos2.Visible = true;
                        this.gb2.Visible = true;
                        this.gb1.Visible = false;
                        this.dgvDatos.Visible = false;
                        this.dgvDatos2.Rows.Clear();

                        this.objPrefactura.MostrarPrefactura(this.dgvDatos2, this.PrefacturaMostrar);

                        this.lblCantidadLineas2.Text = this.objPrefactura.CantidadLineas.ToString();
                        this.lblCantidadArticulos2.Text = this.objPrefactura.CantidadArticulo.ToString();

                        this.ClienteN = this.objPrefactura.ClienteId;
                        this.CambiaCliente();

                        this.CalculaFooter2();
                    }
                }
                //this.PrefacturaMostrar = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool GeneraPrefactura()
        {
            try
            {
                this.ConstruyePrefacturaEncabezadoDetalle();

                this.objPrefactura.IngresaEncabezadoPrefactura(Login.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ConstruyePrefacturaEncabezadoDetalle()
        {
            try
            {
                this.objPrefactura.LArticulo.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {

                    this.objPrefactura.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objPrefactura.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objPrefactura.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objPrefactura.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objPrefactura.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objPrefactura.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objPrefactura.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objPrefactura.LArticulo.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }

                if (this.cmbTipoFactura.Text == "Factura 2")
                {

                    this.objPrefactura.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objPrefactura.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objPrefactura.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objPrefactura.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objPrefactura.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objPrefactura.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objPrefactura.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objPrefactura.LArticulo.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ModificaPrefactura()
        {
            try
            {
                this.ModificaPrefacturaEncabezadoDetalle();

                this.objPrefactura.ModificaEncabezadoPrefactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ModificaPrefacturaEncabezadoDetalle()
        {
            try
            {
                this.objPrefactura.LArticulo.Clear();

                this.objPrefactura.Id = PrefacturaMostrar;

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objPrefactura.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objPrefactura.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objPrefactura.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objPrefactura.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objPrefactura.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objPrefactura.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objPrefactura.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objPrefactura.LArticulo.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }

                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objPrefactura.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objPrefactura.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objPrefactura.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objPrefactura.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objPrefactura.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objPrefactura.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objPrefactura.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objPrefactura.LArticulo.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objProforma.IV == true)
                        if (this.objProforma.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void NotaCredito()
        {
            if (this.NotaCreditoMostrar == 0)//no se ha buscado ninguna notacredito
            {
                this.GeneraNotaCredito();

                if (PagoEfectivoId == 1)//entregaenefectivo
                {
                    this.AgregaCajaDiariaNotaCredito();
                }
                if (PagoEfectivoId == 2)//saldo
                {
                    this.AgregaSaldoNotaCredito();
                }
                //if (PagoEfectivoId == 3)//registra
                //{
                //    this.GeneraNotaCredito2(); 
                //}
            }

            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc.Text);
            }
            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc2.Text);
            }


            if (imprime == 1)
            {
                this.ConstruyeTicket();
            }
            else
            {
                if (NotaCreditoMostrar == 0)
                {
                    var bus = (from x in db.NotaEncabezados
                               orderby x.Id descending
                               select x).First();
                    this.objTicket.FacturaId = this.objNotaCredito.FacturaId;
                    this.objTicket.Proforma = 1;
                    this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;

                }
                else
                {
                    this.objTicket.FacturaId = NotaCreditoMostrar;
                    this.objTicket.Proforma = 1;
                }


                MessageBox.Show("Número de nota de crédito: " + this.objTicket.FacturaId, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //borro la nota de credirto si se entrego en efectivo o en saldo

            if (PagoEfectivoId == 1 || PagoEfectivoId == 2)
            {
                this.objNotaCredito.ElminaNotaCredito2();
            }



            this.cmbTipoComprobante.Text = "Factura";

            //this.cmbTipoFactura.Text = "Factura 1";

            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                this.lblCantidadArticulos.Text = "0";
                this.lblCantidadLineas.Text = "0";
                this.txtTotal.Text = "0.00";
                this.txtSubtotal.Text = "0.00";
                this.txtPorcDescuento.Text = "0";
                this.txtDescuentoAplicado.Text = "0.00";
                this.txtSubtotalPDesc.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.dgvDatos.Rows.Clear();
                this.txtNuevoCliente.Text = string.Empty;
            }
            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                this.lblCantidadArticulos2.Text = "0";
                this.lblCantidadLineas2.Text = "0";
                this.txtTotal2.Text = "0.00";
                this.txtSubtotal2.Text = "0.00";
                this.txtPorcDescuento2.Text = "0";
                this.txtDescuentoAplicado2.Text = "0.00";
                this.txtSubtotalPDesc2.Text = "0.00";
                this.txtImpuesto2.Text = "0.00";
                this.dgvDatos2.Rows.Clear();
                this.txtNuevoCliente.Text = string.Empty;
            }

            this.ActiveControl = this.txtCodigo;

            this.NotaCreditoMostrar = 0;

            imprime = 0;

            return;
        }

        public void AgregaCajaDiariaNotaCredito()
        {
            try
            {

                this.objNotaCredito.PagoEnEfectivoNotaCredito(Login.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el pago en efectivo de la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AgregaSaldoNotaCredito()
        {
            try
            {
                this.objNotaCredito.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue);

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objNotaCredito.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objNotaCredito.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);
                }

                this.objNotaCredito.AumentoSaldoCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el saldo al cliente de la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MuestraNotaCredito()
        {
            try
            {
                if (this.NotaCreditoMostrar != 0)
                {
                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        this.dgvDatos2.Visible = false;
                        this.gb2.Visible = false;
                        this.gb1.Visible = true;
                        this.dgvDatos.Visible = true;
                        this.dgvDatos.Rows.Clear();

                        this.objNotaCredito.MostrarNotasCredito(this.dgvDatos, this.NotaCreditoMostrar);

                        this.lblCantidadLineas.Text = this.objNotaCredito.CantidadLineas.ToString();
                        this.lblCantidadArticulos.Text = this.objNotaCredito.CantidadArticulo.ToString();

                        this.ClienteN = this.objNotaCredito.ClienteId;
                        this.CambiaCliente();

                        this.CalculaFooter();
                    }
                    if (this.cmbTipoFactura.Text == "Factura 2")
                    {
                        this.dgvDatos2.Visible = true;
                        this.gb2.Visible = true;
                        this.gb1.Visible = false;
                        this.dgvDatos.Visible = false;
                        this.dgvDatos2.Rows.Clear();

                        this.objNotaCredito.MostrarNotasCredito(this.dgvDatos2, this.NotaCreditoMostrar);

                        this.lblCantidadLineas2.Text = this.objNotaCredito.CantidadLineas.ToString();
                        this.lblCantidadArticulos2.Text = this.objNotaCredito.CantidadArticulo.ToString();

                        this.ClienteN = this.objNotaCredito.ClienteId;
                        this.CambiaCliente();

                        this.CalculaFooter2();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool GeneraNotaCredito()//resta de las facturas
        {
            try
            {
                this.ConstruyeNotaCreditoEncabezadoDetalle();

                this.objNotaCredito.IngresaEncabezadoNotaCredito(Login.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool GeneraNotaCredito2()//guarda la nota
        {
            try
            {
                //this.ConstruyeNotaCreditoEncabezadoDetalle();

                this.objNotaCredito.IngresaNotaCredito(Login.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ConstruyeNotaCreditoEncabezadoDetalle()
        {
            try
            {
                this.objNotaCredito.LArticulo.Clear();

                this.objNotaCredito.FacturaId = FacturaIdNotaCredito;

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objNotaCredito.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objNotaCredito.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objNotaCredito.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objNotaCredito.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objNotaCredito.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objNotaCredito.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objNotaCredito.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objNotaCredito.LArticulo.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objNotaCredito.IV == true)
                        if (this.objNotaCredito.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }

                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objNotaCredito.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objNotaCredito.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objNotaCredito.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objNotaCredito.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objNotaCredito.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objNotaCredito.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objNotaCredito.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objNotaCredito.LArticulo.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objNotaCredito.IV == true)
                        if (this.objNotaCredito.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la nota de crédito: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)//borra linea
            {
                this.EliminaLinea();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F5)//focus linea
            {
                this.txtCodigo.Focus();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F3)//actualizo linea
            {
                this.ModificaLinea();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F9)//emite factura
            {
                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.LlamaEmiteFactura();
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.btnEmitirFactura2.PerformClick();
                }

                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F2)//consulto precio linea
            {
                cantcompra = Convert.ToDecimal(nupCantidad.Text);
                this.ConsultaLinea();
                return true;    // indicate that you handled this keystroke
            }
            if (keyData == Keys.F10)//salir
            {
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro que desea salir de facturación?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //_owner.Close();
                    this.Close();
                }
                else
                {
                    return true;
                }
                this.Close();
                return true;
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void nupCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtCodigo.Text != "")
            {
            }
        }
        /// <summary>
        /// Función que busca código genérico
        /// </summary>
        /// <param name="strCodigo">Obligatorio.Indica Codigo del Articulo</param>
        /// <returns>True o False</returns>
        private bool EsGenerico(string strCodigo)
        {
            string[] CodigosGenericos = {  "0","1","2","3","4","5","6","7","8","9",
                                             "10","11","12","13","14","15","16","17","18","19",
                                             "20","21","22","23","24","25","26","27","28","29",
                                             "30","31","32","33","34","35","36","37","38","39",
                                             "40","41","42","43","44","45","46","47","48","49",
                                             "50","51","52","53","54","55","56","57","58","59",
                                             "60","61","62","63","64","65","66","67","68","69",
                                             "70","71","72","73","74","75","76","77","78","79",
                                             "80" 
                                         };

            if (strCodigo.StartsWith("TRANS"))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < CodigosGenericos.Length; i++)
                {
                    if (CodigosGenericos[i] == strCodigo)
                    {
                        return true;
                    }
                }
                return false;
            }

        }

        public int tempvals = 0;

        public void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            #region CodigoAnterior
            /*
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
                        this.txtCodigo.Text = string.Empty;
                        return;
                    }
                    if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text) == false)
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1.00";
                        return;
                    }

                    try
                    {

                        if (this.txtCodigo.Text.StartsWith("TRANS") || Convert.ToInt64(this.txtCodigo.Text) <= Convert.ToInt64("80"))
                        {
                            e.Handled = true;
                            AgregaPrecioGenerico agrega = new AgregaPrecioGenerico(this);
                            //agrega.topmost = false;
                            //agrega.parent = this;
                            agrega.Codigo = (this.txtCodigo.Text);
                            agrega.ShowDialog();

                            if (tempvals == 1)
                            {
                                return;
                            }
                        }
                        //if (this.txtCodigo.Text.StartsWith("TRANS") )
                        //{
                        //    e.Handled = true;
                        //    AgregaPrecioGenerico agrega = new AgregaPrecioGenerico(this);
                        //    //agrega.topmost = false;
                        //    //agrega.parent = this;
                        //    agrega.Codigo = (this.txtCodigo.Text);
                        //    agrega.ShowDialog();

                        //    if (tempvals == 1)
                        //    {
                        //        return;
                        //    }
                        //}
                    }
                    catch (Exception)
                    {
                    }


                    if (this.cmbListaPrecios.Text == "Lista de precios 1")
                    {
                        this.objFacturar.TipoPrecio = 1;
                    }
                    else
                    {
                        this.objFacturar.TipoPrecio = 2;
                    }

                    this.objFacturar.Existencias = Convert.ToDecimal(this.nupCantidad.Text.ToString());

                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        

                        if (this.AgregaLineaExistente(sender, e) == true)
                        {
                            return;
                        }
                        else
                        {
                            if (this.objFacturar.ObtieneProducto((this.txtCodigo.Text)) == false)
                            {
                                this.txtCodigo.Text = string.Empty;
                                this.nupCantidad.Text = "1.00";
                                return;
                            }



                            //if (Convert.ToDecimal(this.txtPorcDescuento.Text)>0)
                            //{
                            //    decimal descuentomonto=0;
                            //    decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text)/100;
                            //    decimal invporcdes =(100 - Convert.ToDecimal(this.txtPorcDescuento.Text))/100;
                            //    string iva1 = "1." + iva.ToString("##");
                            //    decimal temp = (this.objFacturar.PrecioIVA / Convert.ToDecimal(iva1)) * (iva / 100);
                            //    decimal temp2 = (this.objFacturar.PrecioIVA - temp);
                            //    descuentomonto = temp2 * (porcdes);

                            //    double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((this.objFacturar.PrecioIVA *invporcdes).ToString()) * Convert.ToDouble(this.nupCantidad.Value.ToString())), 0, MidpointRounding.AwayFromZero);

                            //    totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            //    this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                            //                            this.objFacturar.Descripcion.ToString(),
                            //                            this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                            //                            this.objFacturar.Existencias.ToString(),
                            //                            Convert.ToDecimal(this.txtPorcDescuento.Text),//% desc
                            //                            descuentomonto.ToString("#0,#.#0"),//descuento monto
                            //                            totaliva.ToString("#,#.#0"), 
                            //                            this.objFacturar.TipoPrecio.ToString()
                            //                            );                                
                            //}
                            //else
                            //{
                                double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);

                                totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                                                        this.objFacturar.Descripcion.ToString(),
                                                        this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                                                        this.objFacturar.Existencias.ToString(),
                                                        0,//% desc
                                                        "0.00",//descuento monto
                                                        totaliva.ToString("#0,#.#0"), // 5,000totaliva.ToString(),
                                                        this.objFacturar.TipoPrecio.ToString()
                                                        );
                            //}

                            this.lblCantidadLineas.Text = (Convert.ToInt32(this.lblCantidadLineas.Text) + 1).ToString();

                            if (this.objFacturar.UnidadMedidaId == 1)//normal
                            {
                                this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + this.objFacturar.Existencias).ToString();

                            }
                            else//peso:embutidos,verduras,pollo
                            {
                                this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + 1).ToString();
                            }

                            this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();                            

                            this.lblSignoColones.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                            this.CalculaFooter();

                            this.dgvDatos.Rows[0].Selected = true;
                        }
                    }
                    else//factura 2
                    {
                        if (this.AgregaLineaExistente2(sender, e) == true)
                        {
                            return;
                        }
                        else
                        {
                            if (this.objFacturar.ObtieneProducto((this.txtCodigo.Text)) == false)
                            {
                                this.txtCodigo.Text = string.Empty;
                                this.nupCantidad.Text = "1.00";
                                return;
                            }

                            double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);

                            totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            this.dgvDatos2.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                                                    this.objFacturar.Descripcion.ToString(),
                                                    this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                                                    this.objFacturar.Existencias.ToString(),
                                                    0,//% desc
                                                    "0.00",//descuento monto
                                                    totaliva.ToString("#0,#.#0"), // 5,000totaliva.ToString(),
                                                    this.objFacturar.TipoPrecio.ToString()
                                                    );
                            //}

                            this.lblCantidadLineas2.Text = (Convert.ToInt32(this.lblCantidadLineas2.Text) + 1).ToString();

                            if (this.objFacturar.UnidadMedidaId == 1)//normal
                            {
                                this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + this.objFacturar.Existencias).ToString();

                            }
                            else//peso:embutidos,verduras,pollo
                            {
                                this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + 1).ToString();
                            }

                            this.lblUltimoArticulo2.Text = this.objFacturar.Descripcion.ToString();

                            this.lblSignoColones2.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                            this.CalculaFooter2();

                            this.dgvDatos2.Rows[0].Selected = true;
                        }
                    }

                    this.txtCodigo.Text = string.Empty;

                    this.nupCantidad.Text = "1.00";

                    this.dgvDatos.ClearSelection();
                    this.dgvDatos2.ClearSelection();
                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {

                        this.dgvDatos.Rows[0].Selected = true;

                    }
                    else
                    {
                        this.dgvDatos2.Rows[0].Selected = true;
                    }
                    this.ActiveControl = this.txtCodigo;

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
             */
            #endregion CodigoAnterior

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
                        this.txtCodigo.Text = string.Empty;
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

                    if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text) == true)
                    {


                        //Si el código es generico:
                        if (EsGenerico(txtCodigo.Text) == true)
                        {

                            e.Handled = true;
                            AgregaPrecioGenerico agrega = new AgregaPrecioGenerico(this);
                            //agrega.topmost = false;
                            //agrega.parent = this;
                            agrega.Codigo = (this.txtCodigo.Text);

                            agrega.ShowDialog();

                            if (tempvals == 1)
                            {
                                if (AgregaPrecioGenerico.validar == 0)
                                {
                                    return;
                                }

                            }
                        }
                        this.objFacturar.ObtieneProducto(this.txtCodigo.Text);

                        string strCodigo = this.objFacturar.Codigo;
                        string strDescripcion = this.objFacturar.Descripcion;
                        string strPrecioIVA = this.objFacturar.PrecioIVA.ToString("#,#.#0");
                        string strTipoPrecio = this.objFacturar.TipoPrecio.ToString();
                        string strMontoIV = this.objFacturar.MontoIV.ToString();
                        string strPorcIV = this.objFacturar.PorcIV.ToString();


                        if (this.objFacturar.Existencias < cantcompra)
                        {
                            //   MessageBox.Show("Solo existen " + this.objFacturar.Existencias.ToString() + " existencias sobre este articulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        cantcompra = Convert.ToDecimal(this.nupCantidad.Text.ToString());

                        string strExistencias = cantcompra.ToString();

                        //TIPOS DE FACTURAS:
                        switch (this.cmbTipoFactura.Text)
                        {
                            case "Factura 1":
                                if (this.AgregaLineaExistente(sender, e) == true)
                                {
                                    return;
                                }
                                else
                                {

                                    double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);
                                    string strTotalIva = totaliva.ToString("#0,#.#0");
                                    //descomentar
                                    //totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                    //Se redimensiona scrollbar:
                                    this.dgvDatos.DoubleBuffered(true);

                                    this.dgvDatos.Rows.Insert(0, strCodigo,
                                                                 strDescripcion,
                                                                 strPrecioIVA,
                                                                 strExistencias,
                                                                   0,//% desc
                                                                   "0.00",//descuento monto
                                                                  strTotalIva, //5,000totaliva.ToString(),
                                                                   strTipoPrecio,//tipo de precio
                                                                   strMontoIV,//monto impuesto 
                                                                   strPorcIV //porcentaje de iva
                                                                   );

                                    // this.lblCantidadLineas.Text = (Convert.ToInt32(this.lblCantidadLineas.Text) + 1).ToString();
                                    this.lblCantidadLineas.Text = dgvDatos.Rows.Count.ToString();
                                    if (this.objFacturar.UnidadMedidaId == 1)//normal
                                    {
                                        this.lblCantidadArticulos.Text = ((Convert.ToDecimal(this.lblCantidadArticulos.Text)) + (Convert.ToDecimal(this.nupCantidad.Text))).ToString();

                                    }
                                    else//peso:embutidos,verduras,pollo
                                    {
                                        this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + 1).ToString();

                                    }
                                }

                                this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();

                                this.lblSignoColones.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                                this.CalculaFooter();
                                this.dgvDatos.ClearSelection();
                                this.dgvDatos.Rows[0].Selected = true;
                                break;
                            case "Factura 2":
                                if (this.AgregaLineaExistente2(sender, e) == true)
                                {
                                    return;
                                }
                                else
                                {
                                    double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);
                                    string strTotalIva = totaliva.ToString("#0,#.#0");
                                    //descomentar
                                    //totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                    //Se redimensiona scrollbar:
                                    this.dgvDatos2.DoubleBuffered(true);

                                    this.dgvDatos2.Rows.Insert(0, strCodigo,
                                                                 strDescripcion,
                                                                 strPrecioIVA,
                                                                 strExistencias,
                                                                   0,//% desc
                                                                   "0.00",
                                                                  strTotalIva,
                                                                   strTipoPrecio,//tipo de precio
                                                                   strMontoIV //5,000totaliva.ToString(),

                                                                   );

                                    this.lblCantidadLineas2.Text = (Convert.ToInt32(this.lblCantidadLineas2.Text) + 1).ToString();

                                    if (this.objFacturar.UnidadMedidaId == 1)//normal
                                    {
                                        this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + this.objFacturar.Existencias).ToString();

                                    }
                                    else//peso:embutidos,verduras,pollo
                                    {
                                        this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + 1).ToString();
                                    }
                                }
                                this.lblUltimoArticulo2.Text = this.objFacturar.Descripcion.ToString();

                                this.lblSignoColones2.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                                this.CalculaFooter2();
                                this.dgvDatos2.ClearSelection();
                                this.dgvDatos2.Rows[0].Selected = true;
                                break;
                        }

                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1";
                        this.ActiveControl = this.txtCodigo;

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1";
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void nupCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            #region CodigoAnterior
            /*            try
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
                        this.txtCodigo.Text = string.Empty;
                        return;
                    }
                    if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text) == false)
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1.00";
                        return;
                    }

                    try
                    {

                        if (this.txtCodigo.Text.StartsWith("TRANS") || Convert.ToInt64(this.txtCodigo.Text) <= Convert.ToInt64("80"))
                        {
                            e.Handled = true;
                            AgregaPrecioGenerico agrega = new AgregaPrecioGenerico(this);
                            //agrega.topmost = false;
                            //agrega.parent = this;
                            agrega.Codigo = (this.txtCodigo.Text);
                            agrega.ShowDialog();

                            if (tempvals == 1)
                            {
                                return;
                            }
                        }
                        //if (this.txtCodigo.Text.StartsWith("TRANS") )
                        //{
                        //    e.Handled = true;
                        //    AgregaPrecioGenerico agrega = new AgregaPrecioGenerico(this);
                        //    //agrega.topmost = false;
                        //    //agrega.parent = this;
                        //    agrega.Codigo = (this.txtCodigo.Text);
                        //    agrega.ShowDialog();

                        //    if (tempvals == 1)
                        //    {
                        //        return;
                        //    }
                        //}
                    }
                    catch (Exception)
                    {
                    }


                    if (this.cmbListaPrecios.Text == "Lista de precios 1")
                    {
                        this.objFacturar.TipoPrecio = 1;
                    }
                    else
                    {
                        this.objFacturar.TipoPrecio = 2;
                    }

                    this.objFacturar.Existencias = Convert.ToDecimal(this.nupCantidad.Text.ToString());

                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {


                        if (this.AgregaLineaExistente(sender, e) == true)
                        {
                            return;
                        }
                        else
                        {
                            if (this.objFacturar.ObtieneProducto((this.txtCodigo.Text)) == false)
                            {
                                this.txtCodigo.Text = string.Empty;
                                this.nupCantidad.Text = "1.00";
                                return;
                            }



                            //if (Convert.ToDecimal(this.txtPorcDescuento.Text)>0)
                            //{
                            //    decimal descuentomonto=0;
                            //    decimal porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text)/100;
                            //    decimal invporcdes =(100 - Convert.ToDecimal(this.txtPorcDescuento.Text))/100;
                            //    string iva1 = "1." + iva.ToString("##");
                            //    decimal temp = (this.objFacturar.PrecioIVA / Convert.ToDecimal(iva1)) * (iva / 100);
                            //    decimal temp2 = (this.objFacturar.PrecioIVA - temp);
                            //    descuentomonto = temp2 * (porcdes);

                            //    double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((this.objFacturar.PrecioIVA *invporcdes).ToString()) * Convert.ToDouble(this.nupCantidad.Value.ToString())), 0, MidpointRounding.AwayFromZero);

                            //    totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            //    this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                            //                            this.objFacturar.Descripcion.ToString(),
                            //                            this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                            //                            this.objFacturar.Existencias.ToString(),
                            //                            Convert.ToDecimal(this.txtPorcDescuento.Text),//% desc
                            //                            descuentomonto.ToString("#0,#.#0"),//descuento monto
                            //                            totaliva.ToString("#,#.#0"), 
                            //                            this.objFacturar.TipoPrecio.ToString()
                            //                            );                                
                            //}
                            //else
                            //{
                            double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);

                            totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                                                    this.objFacturar.Descripcion.ToString(),
                                                    this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                                                    this.objFacturar.Existencias.ToString(),
                                                    0,//% desc
                                                    "0.00",//descuento monto
                                                    totaliva.ToString("#0,#.#0"), // 5,000totaliva.ToString(),
                                                    this.objFacturar.TipoPrecio.ToString()
                                                    );
                            //}

                            this.lblCantidadLineas.Text = (Convert.ToInt32(this.lblCantidadLineas.Text) + 1).ToString();

                            if (this.objFacturar.UnidadMedidaId == 1)//normal
                            {
                                this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + this.objFacturar.Existencias).ToString();

                            }
                            else//peso:embutidos,verduras,pollo
                            {
                                this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + 1).ToString();
                            }

                            this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();

                            this.lblSignoColones.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                            this.CalculaFooter();
                        }
                    }
                    else//factura 2
                    {
                        if (this.AgregaLineaExistente2(sender, e) == true)
                        {
                            return;
                        }
                        else
                        {
                            if (this.objFacturar.ObtieneProducto((this.txtCodigo.Text)) == false)
                            {
                                this.txtCodigo.Text = string.Empty;
                                this.nupCantidad.Text = "1.00";
                                return;
                            }

                            double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);

                            totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            this.dgvDatos2.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                                                    this.objFacturar.Descripcion.ToString(),
                                                    this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                                                    this.objFacturar.Existencias.ToString(),
                                                    0,//% desc
                                                    "0.00",//descuento monto
                                                    totaliva.ToString("#0,#.#0"), // 5,000totaliva.ToString(),
                                                    this.objFacturar.TipoPrecio.ToString()
                                                    );
                            //}

                            this.lblCantidadLineas2.Text = (Convert.ToInt32(this.lblCantidadLineas2.Text) + 1).ToString();

                            if (this.objFacturar.UnidadMedidaId == 1)//normal
                            {
                                this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + this.objFacturar.Existencias).ToString();

                            }
                            else//peso:embutidos,verduras,pollo
                            {
                                this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + 1).ToString();
                            }

                            this.lblUltimoArticulo2.Text = this.objFacturar.Descripcion.ToString();

                            this.lblSignoColones2.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                            this.CalculaFooter2();
                        }
                    }

                    this.txtCodigo.Text = string.Empty;

                    this.nupCantidad.Text = "1.00";

                    this.ActiveControl = this.txtCodigo;

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 */
            #endregion CodigoAnterior

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
                        this.txtCodigo.Text = string.Empty;
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

                    if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text) == true)
                    {


                        //Si el código es generico:
                        if (EsGenerico(txtCodigo.Text) == true)
                        {

                            e.Handled = true;
                            AgregaPrecioGenerico agrega = new AgregaPrecioGenerico(this);
                            //agrega.topmost = false;
                            //agrega.parent = this;
                            agrega.Codigo = (this.txtCodigo.Text);
                            agrega.ShowDialog();

                            if (tempvals == 1)
                            {
                                return;
                            }
                        }
                        this.objFacturar.ObtieneProducto(this.txtCodigo.Text);

                        string strCodigo = this.objFacturar.Codigo;
                        string strDescripcion = this.objFacturar.Descripcion;
                        string strPrecioIVA = this.objFacturar.PrecioIVA.ToString("#,#.#0");
                        string strTipoPrecio = this.objFacturar.TipoPrecio.ToString();
                        string strMontoIV = this.objFacturar.MontoIV.ToString();

                        cantcompra = Convert.ToDecimal(this.nupCantidad.Text.ToString());
                        if (this.objFacturar.Existencias < cantcompra)
                        {
                            //   MessageBox.Show("Solo existen " + this.objFacturar.Existencias.ToString() + " existencias sobre este articulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        string strExistencias = cantcompra.ToString();

                        //TIPOS DE FACTURAS:
                        switch (this.cmbTipoFactura.Text)
                        {
                            case "Factura 1":
                                if (this.AgregaLineaExistente(sender, e) == true)
                                {
                                    return;
                                }
                                else
                                {

                                    double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);
                                    string strTotalIva = totaliva.ToString("#0,#.#0");
                                    //descomentar
                                    //totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                    //Se redimensiona scrollbar:
                                    this.dgvDatos.DoubleBuffered(true);

                                    this.dgvDatos.Rows.Insert(0, strCodigo,
                                                                 strDescripcion,
                                                                 strPrecioIVA,
                                                                 strExistencias,
                                                                   0,//% desc
                                                                   "0.00",//descuento monto
                                                                  strTotalIva, //5,000totaliva.ToString(),
                                                                   strTipoPrecio,//tipo de precio
                                                                   strMontoIV//monto impuesto 
                                                                   );

                                    this.lblCantidadLineas.Text = (Convert.ToInt32(this.lblCantidadLineas.Text) + 1).ToString();

                                    if (this.objFacturar.UnidadMedidaId == 1)//normal
                                    {
                                        this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + cantcompra).ToString();

                                    }
                                    else//peso:embutidos,verduras,pollo
                                    {
                                        this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + 1).ToString();
                                    }
                                }

                                this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();

                                this.lblSignoColones.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                                this.CalculaFooter();
                                this.dgvDatos.ClearSelection();
                                this.dgvDatos.Rows[0].Selected = true;
                                break;
                            case "Factura 2":
                                if (this.AgregaLineaExistente2(sender, e) == true)
                                {
                                    return;
                                }
                                else
                                {
                                    double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble(this.objFacturar.PrecioIVA.ToString()) * Convert.ToDouble(this.nupCantidad.Text.ToString())), 0, MidpointRounding.AwayFromZero);
                                    string strTotalIva = totaliva.ToString("#0,#.#0");
                                    //descomentar
                                    //totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                    //Se redimensiona scrollbar:
                                    this.dgvDatos2.DoubleBuffered(true);

                                    this.dgvDatos2.Rows.Insert(0, strCodigo,
                                                                 strDescripcion,
                                                                 strPrecioIVA,
                                                                 strExistencias,
                                                                   0,//% desc
                                                                   "0.00",//descuento monto
                                                                  strTotalIva, //5,000totaliva.ToString(),
                                                                   strTipoPrecio,//tipo de precio
                                                                   strMontoIV//monto impuesto 
                                                                   );

                                    this.lblCantidadLineas2.Text = (Convert.ToInt32(this.lblCantidadLineas2.Text) + 1).ToString();

                                    if (this.objFacturar.UnidadMedidaId == 1)//normal
                                    {
                                        this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + cantcompra).ToString();

                                    }
                                    else//peso:embutidos,verduras,pollo
                                    {
                                        this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + 1).ToString();
                                    }
                                }
                                this.lblUltimoArticulo2.Text = this.objFacturar.Descripcion.ToString();

                                this.lblSignoColones2.Text = (this.objFacturar.PrecioIVA.ToString("C"));

                                this.CalculaFooter2();
                                this.dgvDatos2.ClearSelection();
                                this.dgvDatos2.Rows[0].Selected = true;
                                break;
                        }

                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1";
                        this.ActiveControl = this.txtCodigo;

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1";
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void CalculaFooter()
        {
            #region CodigoAnterior
            /*
                         try
            {
                //decimal invporcdes1 = 0;

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
                    this.objFacturar.ObtieneProductoCodigo(item.Cells[0].Value.ToString());

                    double porcd = Convert.ToDouble(item.Cells[4].Value) / 100;

                    double invporcd = 1;

                    if (Convert.ToDouble(item.Cells[4].Value) > 0)
                    {
                        invporcd = (100 - Convert.ToDouble(item.Cells[4].Value)) / 100;
                    }

                    //impuesto += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //impuestop += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)));
                    //subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    //descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

                    double montoiv = 0;
                    if (this.objFacturar.MontoIV>0)//tiene impuesto
                    {
                        montoiv = Convert.ToDouble(item.Cells[2].Value) / Convert.ToDouble(ivas);
                        montoiv = montoiv * Convert.ToDouble(iva / 100);
                    }


                    impuesto += ((montoiv * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    impuestop += ((montoiv * Convert.ToDouble(item.Cells[3].Value)));
                    subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));
                }

                this.txtSubtotalPDesc.Text = (subtotalp - impuestop).ToString("#0,#.#0");

                this.txtSubtotal.Text = (subtotal - impuesto).ToString("#0,#.#0");

                this.txtImpuesto.Text = (impuesto).ToString("#0,#.#0");

                this.txtDescuentoAplicado.Text = (descuento).ToString("#0,#.#0");
                //fin de obtengo impuesto y subtotalp descuento

                double totaltext = 0;

                totaltext = Math.Round(Convert.ToDouble(Convert.ToDouble(this.txtSubtotal.Text) + Convert.ToDouble(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero);

                totaltext = Convert.ToDouble(Math.Round(totaltext / 5.0) * 5);

                this.txtTotal.Text = totaltext.ToString("#0,#.#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

             */
            #endregion CodigoAnterior

            try
            {
                //decimal invporcdes1 = 0;

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

                //    this.objFacturar.TipoPrecio = Convert.ToInt32(this.cmbListaPrecios.Text.Substring(this.cmbListaPrecios.Text.Length - 1, 1));

                //obtengo impuesto y subtotalp descuento
                double totaltext = 0;

                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    //  this.objFacturar.ObtieneProductoCodigo(item.Cells[0].Value.ToString());
                    // cantidad / 100
                    double porcd = Convert.ToDouble(item.Cells[4].Value) / 100;

                    double invporcd = 1;

                    if (Convert.ToDouble(item.Cells[4].Value) > 0)
                    {
                        invporcd = (100 - Convert.ToDouble(item.Cells[4].Value)) / 100;
                    }

                    //impuesto += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //impuestop += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)));
                    //subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    //descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

                    double montoiv = 0;
                    if (Convert.ToDouble(item.Cells[9].Value) > 0)//tiene impuesto
                    {
                        //montoiv = (Convert.ToDouble(item.Cells[9].Value) / 100) * Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value);
                        montoiv = (Convert.ToDouble(item.Cells[8].Value) * Convert.ToDouble(item.Cells[3].Value));
                        //montoiv = Convert.ToDouble(item.Cells[3].Value) / Convert.ToDouble(ivas);
                        //montoiv = montoiv * Convert.ToDouble(iva / 100);
                    }

                    //impuesto += ((montoiv * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //impuestop += ((montoiv * Convert.ToDouble(item.Cells[3].Value)));
                    impuesto += montoiv;
                    subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

                    totaltext += Math.Round(Convert.ToDouble(item.Cells[6].Value), 0, MidpointRounding.AwayFromZero);
                }

                //fin del recorrido del grid


                this.txtSubtotalPDesc.Text = Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0");
                //  this.txtSubtotal.Text = ((Convert.ToDouble(totaltext)) - impuesto).ToString("#0,#.#0");

                //  MessageBox.Show("SUBTOTAL DESCUENTO " + Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"));

                this.txtSubtotal.Text = (totaltext - impuesto).ToString("#0,#.#0");
                //  MessageBox.Show("SE supone q el subtotal es de " + (totaltext - impuesto).ToString("#0,#.#0"));


                this.txtSubtotalPDesc.Text = (Convert.ToDouble(txtSubtotal.Text) + descuento).ToString("#0,#.#0");

                //  MessageBox.Show("SUBTOTAL DESCUENTO txtSubtotalPDesc.Text " + Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"));

                //  this.txtSubtotal.Text = (totaltext - impuesto).ToString("#0,#.#0");

                this.txtImpuesto.Text = (impuesto).ToString("#0,#.#0");

                this.txtDescuentoAplicado.Text = (descuento).ToString("#0,#.#0");
                //fin de obtengo impuesto y subtotalp descuento



                //  totaltext = Math.Round(Convert.ToDouble(Convert.ToDouble(this.txtSubtotal.Text) + Convert.ToDouble(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero);
                //descomentar
                totaltext = Convert.ToDouble(Math.Round(totaltext / 5.0) * 5);

                this.txtTotal.Text = totaltext.ToString("#0,#.#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CalculaFooter2()
        {
            #region CodigoAnterior
            /*
                         try
            {
                //decimal invporcdes1 = 0;

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
                    this.objFacturar.ObtieneProductoCodigo(item.Cells[0].Value.ToString());

                    double porcd = Convert.ToDouble(item.Cells[4].Value) / 100;

                    double invporcd = 1;

                    if (Convert.ToDouble(item.Cells[4].Value) > 0)
                    {
                        invporcd = (100 - Convert.ToDouble(item.Cells[4].Value)) / 100;
                    }

                    //impuesto += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //impuestop += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)));
                    //subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    //descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

                    double montoiv = 0;
                    if (this.objFacturar.MontoIV>0)//tiene impuesto
                    {
                        montoiv = Convert.ToDouble(item.Cells[2].Value) / Convert.ToDouble(ivas);
                        montoiv = montoiv * Convert.ToDouble(iva / 100);
                    }


                    impuesto += ((montoiv * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    impuestop += ((montoiv * Convert.ToDouble(item.Cells[3].Value)));
                    subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));
                }

                this.txtSubtotalPDesc.Text = (subtotalp - impuestop).ToString("#0,#.#0");

                this.txtSubtotal.Text = (subtotal - impuesto).ToString("#0,#.#0");

                this.txtImpuesto.Text = (impuesto).ToString("#0,#.#0");

                this.txtDescuentoAplicado.Text = (descuento).ToString("#0,#.#0");
                //fin de obtengo impuesto y subtotalp descuento

                double totaltext = 0;

                totaltext = Math.Round(Convert.ToDouble(Convert.ToDouble(this.txtSubtotal.Text) + Convert.ToDouble(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero);

                totaltext = Convert.ToDouble(Math.Round(totaltext / 5.0) * 5);

                this.txtTotal.Text = totaltext.ToString("#0,#.#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

             */
            #endregion CodigoAnterior

            try
            {
                //decimal invporcdes1 = 0;

                decimal porcdes1 = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                decimal desctemp = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                decimal subptemp = Convert.ToDecimal(this.txtSubtotalPDesc.Text);

                string iva1 = "1." + iva.ToString("##");

                double impuesto = 0;

                //double impuestop = 0;

                double subtotal = 0;

                double subtotalp = 0;

                double descuento = 0;

                //string ivas = "1." + iva.ToString("##");

                //    this.objFacturar.TipoPrecio = Convert.ToInt32(this.cmbListaPrecios.Text.Substring(this.cmbListaPrecios.Text.Length - 1, 1));

                //obtengo impuesto y subtotalp descuento
                double totaltext = 0;

                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    //  this.objFacturar.ObtieneProductoCodigo(item.Cells[0].Value.ToString());
                    // cantidad / 100
                    double porcd = Convert.ToDouble(item.Cells[4].Value) / 100;

                    double invporcd = 1;

                    if (Convert.ToDouble(item.Cells[4].Value) > 0)
                    {
                        invporcd = (100 - Convert.ToDouble(item.Cells[4].Value)) / 100;
                    }

                    //impuesto += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //impuestop += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)));
                    //subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    //descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

                    double montoiv = 0;
                    if (Convert.ToDouble(item.Cells[9].Value) > 0)//tiene impuesto
                    {
                        //montoiv = (Convert.ToDouble(item.Cells[9].Value) / 100) * Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value);
                        montoiv = (Convert.ToDouble(item.Cells[8].Value) * Convert.ToDouble(item.Cells[3].Value));
                        //montoiv = Convert.ToDouble(item.Cells[3].Value) / Convert.ToDouble(ivas);
                        //montoiv = montoiv * Convert.ToDouble(iva / 100);
                    }

                    //impuesto += ((montoiv * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    //impuestop += ((montoiv * Convert.ToDouble(item.Cells[3].Value)));
                    impuesto += montoiv;
                    subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
                    subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
                    descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

                    totaltext += Math.Round(Convert.ToDouble(item.Cells[6].Value), 0, MidpointRounding.AwayFromZero);
                }

                //fin del recorrido del grid


                this.txtSubtotalPDesc2.Text = Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0");
                //  this.txtSubtotal.Text = ((Convert.ToDouble(totaltext)) - impuesto).ToString("#0,#.#0");

                //  MessageBox.Show("SUBTOTAL DESCUENTO " + Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"));

                this.txtSubtotal2.Text = (totaltext - impuesto).ToString("#0,#.#0");
                //  MessageBox.Show("SE supone q el subtotal es de " + (totaltext - impuesto).ToString("#0,#.#0"));


                this.txtSubtotalPDesc2.Text = (Convert.ToDouble(txtSubtotal.Text) + descuento).ToString("#0,#.#0");

                //  MessageBox.Show("SUBTOTAL DESCUENTO txtSubtotalPDesc.Text " + Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"));

                //  this.txtSubtotal.Text = (totaltext - impuesto).ToString("#0,#.#0");

                this.txtImpuesto2.Text = (impuesto).ToString("#0,#.#0");

                this.txtDescuentoAplicado2.Text = (descuento).ToString("#0,#.#0");
                //fin de obtengo impuesto y subtotalp descuento



                //  totaltext = Math.Round(Convert.ToDouble(Convert.ToDouble(this.txtSubtotal.Text) + Convert.ToDouble(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero);
                //descomentar
                totaltext = Convert.ToDouble(Math.Round(totaltext / 5.0) * 5);

                this.txtTotal2.Text = totaltext.ToString("#0,#.#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //public void CalculaFooter2()
        //{
        //    #region CodigoAnterior
        //    /*
        //                try
        //    {
        //        //decimal invporcdes1 = 0;

        //        decimal porcdes1 = Convert.ToDecimal(this.txtPorcDescuento2.Text) / 100;

        //        decimal desctemp = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

        //        decimal subptemp = Convert.ToDecimal(this.txtSubtotalPDesc2.Text);

        //        string iva1 = "1." + iva.ToString("##");

        //        double impuesto = 0;

        //        double impuestop = 0;

        //        double subtotal = 0;

        //        double subtotalp = 0;

        //        double descuento = 0;

        //        string ivas = "1." + iva.ToString("##");

        //        this.objFacturar.TipoPrecio = Convert.ToInt32(this.cmbListaPrecios.Text.Substring(this.cmbListaPrecios.Text.Length - 1, 1));

        //        //obtengo impuesto y subtotalp descuento
        //        foreach (DataGridViewRow item in this.dgvDatos2.Rows)
        //        {
        //            this.objFacturar.ObtieneProductoCodigo(item.Cells[0].Value.ToString());

        //            double porcd = Convert.ToDouble(item.Cells[4].Value) / 100;

        //            double invporcd = 1;

        //            if (Convert.ToDouble(item.Cells[4].Value) > 0)
        //            {
        //                invporcd = (100 - Convert.ToDouble(item.Cells[4].Value)) / 100;
        //            }

        //            double montoiv = 0;
        //            if (this.objFacturar.MontoIV > 0)//tiene impuesto
        //            {
        //                montoiv = Convert.ToDouble(item.Cells[2].Value) / Convert.ToDouble(ivas);
        //                montoiv = montoiv * Convert.ToDouble(iva / 100);
        //            }


        //            impuesto += ((montoiv * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
        //            impuestop += ((montoiv * Convert.ToDouble(item.Cells[3].Value)));
        //            subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
        //            subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
        //            descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));
        //        }

        //        this.txtSubtotalPDesc2.Text = (subtotalp - impuestop).ToString("#0,#.#0");

        //        this.txtSubtotal2.Text = (subtotal - impuesto).ToString("#0,#.#0");

        //        this.txtImpuesto2.Text = (impuesto).ToString("#0,#.#0");

        //        this.txtDescuentoAplicado2.Text = (descuento).ToString("#0,#.#0");
        //        //fin de obtengo impuesto y subtotalp descuento

        //        double totaltext = 0;

        //        totaltext = Math.Round(Convert.ToDouble(Convert.ToDouble(this.txtSubtotal2.Text) + Convert.ToDouble(this.txtImpuesto2.Text)), 0, MidpointRounding.AwayFromZero);

        //        totaltext = Convert.ToDouble(Math.Round(totaltext / 5.0) * 5);

        //        this.txtTotal2.Text = totaltext.ToString("#0,#.#0");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //     */
        //    #endregion CodigoAnterior

        //    try
        //    {
        //        //decimal invporcdes1 = 0;

        //        decimal porcdes1 = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

        //        decimal desctemp = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

        //        decimal subptemp = Convert.ToDecimal(this.txtSubtotalPDesc.Text);

        //        string iva1 = "1." + iva.ToString("##");

        //        double impuesto = 0;

        //        double impuestop = 0;

        //        double subtotal = 0;

        //        double subtotalp = 0;

        //        double descuento = 0;

        //        string ivas = "1." + iva.ToString("##");

        //        //    this.objFacturar.TipoPrecio = Convert.ToInt32(this.cmbListaPrecios.Text.Substring(this.cmbListaPrecios.Text.Length - 1, 1));

        //        //obtengo impuesto y subtotalp descuento
        //        double totaltext = 0;

        //        foreach (DataGridViewRow item in this.dgvDatos2.Rows)
        //        {
        //            //  this.objFacturar.ObtieneProductoCodigo(item.Cells[0].Value.ToString());

        //            double porcd = Convert.ToDouble(item.Cells[4].Value) / 100;

        //            double invporcd = 1;

        //            if (Convert.ToDouble(item.Cells[4].Value) > 0)
        //            {
        //                invporcd = (100 - Convert.ToDouble(item.Cells[4].Value)) / 100;
        //            }

        //            //impuesto += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
        //            //impuestop += ((Convert.ToDouble(this.objFacturar.MontoIV) * Convert.ToDouble(item.Cells[3].Value)));
        //            //subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
        //            //subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
        //            //descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

        //            double montoiv = 0;
        //            if (Convert.ToDouble(item.Cells[8].Value) > 0)//tiene impuesto
        //            {
        //                montoiv = Convert.ToDouble(item.Cells[2].Value) / Convert.ToDouble(ivas);
        //                montoiv = montoiv * Convert.ToDouble(iva / 100);
        //            }


        //            impuesto += ((montoiv * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
        //            impuestop += ((montoiv * Convert.ToDouble(item.Cells[3].Value)));
        //            subtotal += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)) * invporcd);
        //            subtotalp += ((Convert.ToDouble(Convert.ToDouble(item.Cells[2].Value)) * Convert.ToDouble(item.Cells[3].Value)));
        //            descuento += Convert.ToDouble(Convert.ToDouble(item.Cells[5].Value));

        //            totaltext += Math.Round(Convert.ToDouble(item.Cells[6].Value), 0, MidpointRounding.AwayFromZero);
        //        }

        //        //fin del recorrido del grid


        //        this.txtSubtotalPDesc2.Text = Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0");
        //        //  this.txtSubtotal.Text = ((Convert.ToDouble(totaltext)) - impuesto).ToString("#0,#.#0");

        //        //  MessageBox.Show("SUBTOTAL DESCUENTO " + Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"));

        //        this.txtSubtotal2.Text = (totaltext - impuesto).ToString("#0,#.#0");
        //        //  MessageBox.Show("SE supone q el subtotal es de " + (totaltext - impuesto).ToString("#0,#.#0"));


        //        this.txtSubtotalPDesc2.Text = Math.Round((Convert.ToDouble(txtSubtotal2.Text) + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0");

        //        //  MessageBox.Show("SUBTOTAL DESCUENTO txtSubtotalPDesc.Text " + Math.Round((subtotalp + descuento), 0, MidpointRounding.AwayFromZero).ToString("#0,#.#0"));

        //        //  this.txtSubtotal.Text = (totaltext - impuesto).ToString("#0,#.#0");

        //        this.txtImpuesto2.Text = (impuesto).ToString("#0,#.#0");

        //        this.txtDescuentoAplicado2.Text = (descuento).ToString("#0,#.#0");
        //        //fin de obtengo impuesto y subtotalp descuento



        //        //  totaltext = Math.Round(Convert.ToDouble(Convert.ToDouble(this.txtSubtotal.Text) + Convert.ToDouble(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero);
        //        //descomentar
        //        totaltext = Convert.ToDouble(Math.Round(totaltext / 5.0) * 5);

        //        this.txtTotal2.Text = totaltext.ToString("#0,#.#0");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private bool AgregaLineaExistente(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgvDatos.Rows.Count == 0) return false;
                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    //(this.txtCodigo.Text))
                    if ((item.Cells[0].Value.ToString()) == this.objFacturar.Codigo)
                    {


                        this.objFacturar.Existencias = Convert.ToDecimal(item.Cells[3].Value.ToString());


                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value);

                        if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text.ToString()) == false)
                        {
                            this.txtCodigo.Text = string.Empty;
                            this.nupCantidad.Text = "1";
                            this.txtCodigo.Focus();
                            return false;
                        }

                        if (this.objFacturar.UnidadMedidaId == 1)//normal
                        {
                            this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + Convert.ToDecimal(this.nupCantidad.Text.ToString())).ToString();
                        }

                        this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();

                        this.lblSignoColones.Text = this.objFacturar.PrecioIVA.ToString("C");

                        item.Cells[5].Value = (Convert.ToDecimal(item.Cells[5].Value) / Convert.ToDecimal(item.Cells[3].Value)).ToString();

                        //     item.Cells[3].Value = (Convert.ToDecimal(item.Cells[3].Value) + Convert.ToDecimal(this.nupCantidad.Text.ToString())).ToString();//cantidad

                        item.Cells[5].Value = (Convert.ToDecimal(item.Cells[5].Value) * Convert.ToDecimal(item.Cells[3].Value)).ToString("0,#.#0"); ;//descuento monto


                        // item.Cells[6].Value = "0";

                        //    double totaliva = Math.Round (Convert.ToDouble(Convert.ToDecimal(item.Cells[6].Value.ToString() + (Convert.ToDecimal(this.nupCantidad.Text) * Convert.ToDecimal(this.objFacturar.PrecioIVA)))), 0, MidpointRounding.AwayFromZero);

                        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDecimal(this.nupCantidad.Text)) * (Convert.ToDouble(Convert.ToDecimal(this.objFacturar.PrecioIVA))), 0, MidpointRounding.AwayFromZero);
                        //total iva da como resultado el ultimo precio digitado
                        totaliva = Math.Round(Convert.ToDouble(Convert.ToDecimal(item.Cells[6].Value.ToString())) + totaliva, 0, MidpointRounding.AwayFromZero);
                        if (EsGenerico(txtCodigo.Text) == true)
                        {

                            item.Cells[2].Value = totaliva.ToString("#0,#.#0");
                            item.Cells[3].Value = (Convert.ToDecimal(item.Cells[3].Value));
                        }
                        else
                            item.Cells[3].Value = (Convert.ToDecimal(item.Cells[3].Value) + Convert.ToDecimal(this.nupCantidad.Text.ToString())).ToString();//cantidad

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        decimal invporcdes1 = 0;

                        decimal porcdes1 = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                        if (Convert.ToDecimal(this.txtPorcDescuento.Text) > 0)
                        {
                            invporcdes1 = (100 - Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100;
                            totaliva = Convert.ToDouble(Math.Round((totaliva * Convert.ToDouble(invporcdes1)) / 5.0) * 5);

                        }

                        item.Cells[6].Value = totaliva.ToString("#0,#.#0");


                        this.CalculaFooter();

                        this.txtCodigo.Text = string.Empty;

                        this.nupCantidad.Text = "1";

                        this.txtCodigo.Focus();

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        return true;
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private bool AgregaLineaExistente2(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgvDatos2.Rows.Count == 0) return false;
                foreach (DataGridViewRow item in dgvDatos2.Rows)
                {
                    //(this.txtCodigo.Text))
                    if ((item.Cells[0].Value.ToString()) == this.objFacturar.Codigo)
                    {
                        if (EsGenerico(txtCodigo.Text) == false)
                        {

                            this.objFacturar.Existencias = Convert.ToDecimal(item.Cells[3].Value.ToString()) + Convert.ToDecimal(this.nupCantidad.Text.ToString());
                        }
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value);

                        if (this.objFacturar.ObtieneProducto(this.txtCodigo.Text.ToString()) == false)
                        {
                            this.txtCodigo.Text = string.Empty;
                            this.nupCantidad.Text = "1";
                            this.txtCodigo.Focus();
                            return false;
                        }

                        if (this.objFacturar.UnidadMedidaId == 1)//normal
                        {
                            this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) + Convert.ToDecimal(this.nupCantidad.Text.ToString())).ToString();
                        }

                        this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();

                        this.lblSignoColones.Text = this.objFacturar.PrecioIVA.ToString("C");

                        item.Cells[5].Value = (Convert.ToDecimal(item.Cells[5].Value) / Convert.ToDecimal(item.Cells[3].Value)).ToString();

                        //     item.Cells[3].Value = (Convert.ToDecimal(item.Cells[3].Value) + Convert.ToDecimal(this.nupCantidad.Text.ToString())).ToString();//cantidad

                        item.Cells[5].Value = (Convert.ToDecimal(item.Cells[5].Value) * Convert.ToDecimal(item.Cells[3].Value)).ToString("0,#.#0"); ;//descuento monto

                        // item.Cells[6].Value = "0";

                        //    double totaliva = Math.Round (Convert.ToDouble(Convert.ToDecimal(item.Cells[6].Value.ToString() + (Convert.ToDecimal(this.nupCantidad.Text) * Convert.ToDecimal(this.objFacturar.PrecioIVA)))), 0, MidpointRounding.AwayFromZero);

                        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDecimal(this.nupCantidad.Text)) * (Convert.ToDouble(Convert.ToDecimal(this.objFacturar.PrecioIVA))), 0, MidpointRounding.AwayFromZero);

                        totaliva = Math.Round(Convert.ToDouble(Convert.ToDecimal(item.Cells[6].Value.ToString())) + totaliva, 0, MidpointRounding.AwayFromZero);

                        item.Cells[3].Value = (Convert.ToDecimal(item.Cells[3].Value) + Convert.ToDecimal(this.nupCantidad.Text.ToString())).ToString();//cantidad
                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        decimal invporcdes1 = 0;

                        decimal porcdes1 = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;

                        if (Convert.ToDecimal(this.txtPorcDescuento2.Text) > 0)
                        {
                            invporcdes1 = (100 - Convert.ToDecimal(this.txtPorcDescuento2.Text)) / 100;
                            totaliva = Convert.ToDouble(Math.Round((totaliva * Convert.ToDouble(invporcdes1)) / 5.0) * 5);

                        }

                        item.Cells[6].Value = totaliva.ToString("#0,#.#0");


                        this.CalculaFooter2();

                        this.txtCodigo.Text = string.Empty;

                        this.nupCantidad.Text = "1";

                        this.txtCodigo.Focus();

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        return true;
                    }
                }
                //fin gird
                e.Handled = true;
                e.SuppressKeyPress = true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public bool AgregaLineaExistente()//para actualizar factura
        {
            try
            {
                foreach (DataGridViewRow item in dgvDatos.Rows)//actualizo el datagrid
                {
                    if ((item.Cells[0].Value.ToString()) == (CodigoS))
                    {
                        if (this.ListaPreciosS == "Lista de precios 1")
                        {
                            this.objFacturar.TipoPrecio = 1;
                            item.Cells[7].Value = 1;
                        }
                        if (this.ListaPreciosS == "Lista de precios 2")
                        {
                            this.objFacturar.TipoPrecio = 2;
                            item.Cells[7].Value = 2;
                        }
                        if (this.objFacturar.ObtieneProducto((CodigoS)) == false)
                        {
                            return false;
                        }

                        item.Cells[2].Value = Convert.ToDecimal(precioivaactualiza).ToString("0,#.#0");//precio iva

                        item.Cells[3].Value = Convert.ToDecimal(this.CantidadS.ToString());

                        item.Cells[5].Value = (Convert.ToDecimal(this.descuentodescactualiza)).ToString("0,#.#0"); ;//descuento monto

                        item.Cells[4].Value = (Convert.ToDecimal(this.porcdescactualiza)).ToString("0,#.#0"); ;//descuento porc

                        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((Convert.ToDecimal(this.totaldescactualiza)))), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        item.Cells[6].Value = totaliva.ToString("#0,#.#0");
                    }
                }
                //actualizo lineas y cantidad
                decimal cantarticulos = 0;

                foreach (DataGridViewRow item in dgvDatos.Rows)
                {
                    cantarticulos += Convert.ToDecimal(item.Cells[3].Value);
                }

                this.lblCantidadArticulos.Text = (Convert.ToDecimal(cantarticulos)).ToString();

                this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();

                this.lblSignoColones.Text = this.objFacturar.PrecioIVA.ToString("C");
                //fin de actualizo lineas y cantidad


                this.CalculaFooter();





                this.txtCodigo.Text = string.Empty;

                this.nupCantidad.Text = "1";

                this.txtCodigo.Focus();

                this.dgvDatos2.Visible = false;

                this.gb2.Visible = false;

                this.dgvDatos.Visible = true;

                this.gb1.Visible = true;

                this.dgvDatos.Rows[0].Selected = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public bool AgregaLineaExistente2()//para actualizar factura
        {
            try
            {
                foreach (DataGridViewRow item in dgvDatos2.Rows)//actualizo el datagrid
                {
                    if ((item.Cells[0].Value.ToString()) == (CodigoS))
                    {
                        if (this.ListaPreciosS == "Lista de precios 1")
                        {
                            this.objFacturar.TipoPrecio = 1;
                            item.Cells[7].Value = 1;
                        }
                        if (this.ListaPreciosS == "Lista de precios 2")
                        {
                            this.objFacturar.TipoPrecio = 2;
                            item.Cells[7].Value = 2;
                        }
                        if (this.objFacturar.ObtieneProducto((CodigoS)) == false)
                        {
                            return false;
                        }

                        item.Cells[2].Value = Convert.ToDecimal(precioivaactualiza).ToString("0,#.#0");//precio iva

                        item.Cells[3].Value = Convert.ToDecimal(this.CantidadS.ToString());

                        item.Cells[5].Value = (Convert.ToDecimal(this.descuentodescactualiza)).ToString("0,#.#0"); ;//descuento monto

                        item.Cells[4].Value = (Convert.ToDecimal(this.porcdescactualiza)).ToString("0,#.#0"); ;//descuento porc

                        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((Convert.ToDecimal(this.totaldescactualiza)))), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        item.Cells[6].Value = totaliva.ToString("#0,#.#0");
                    }
                }
                //actualizo lineas y cantidad
                decimal cantarticulos = 0;

                foreach (DataGridViewRow item in dgvDatos2.Rows)
                {
                    cantarticulos += Convert.ToDecimal(item.Cells[3].Value);
                }

                this.lblCantidadArticulos2.Text = (Convert.ToDecimal(cantarticulos)).ToString();

                this.lblUltimoArticulo2.Text = this.objFacturar.Descripcion.ToString();

                this.lblSignoColones2.Text = this.objFacturar.PrecioIVA.ToString("C");
                //fin de actualizo lineas y cantidad


                this.CalculaFooter2();


                this.txtCodigo.Text = string.Empty;

                this.nupCantidad.Text = "1";

                this.txtCodigo.Focus();


                //this.dgvDatos2.Visible = true;

                //this.gb2.Visible = true;

                //this.dgvDatos.Visible = false;

                //this.gb1.Visible = false;
                this.dgvDatos2.Rows[0].Selected = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public void AgregaLineaConsulta(object sender, EventArgs e)
        {
            try
            {
                //if (this.cmbTipoFactura.Text == "Factura 1")
                //{
                //foreach (DataGridViewRow item in this.dgvDatos.Rows)
                //{
                //    if (item.Cells[0].Value.ToString() == CodigoS)
                //    {
                //        MessageBox.Show("El artículo ya ha sido agregado!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        return;
                //    }
                //}

                if (ListaPreciosS == "Lista de precios 1")
                {
                    this.objFacturar.TipoPrecio = 1;
                }
                if (ListaPreciosS == "Lista de precios 2")
                {
                    this.objFacturar.TipoPrecio = 2;
                }

                this.txtCodigo.Text = CodigoS;

                this.ActiveControl = this.txtCodigo;

                SendKeys.SendWait("{ENTER}");

                //if (this.objFacturar.ObtieneProducto((CodigoS)) == false)
                //{
                //    return;
                //}

                //if (this.ListaPreciosS == "Lista de precios 1")
                //{
                //    this.objFacturar.TipoPrecio = 1;
                //}
                //if (this.ListaPreciosS == "Lista de precios 2")
                //{
                //    this.objFacturar.TipoPrecio = 2;
                //}

                //decimal descuentomonto = 0;
                //decimal porcdes = 0;
                //decimal invporcdes = 0;
                //string iva1 = "1." + iva.ToString("##");
                //decimal temp = 0;
                //decimal temp2 = 0;

                //if (Convert.ToDecimal(this.txtPorcDescuento.Text) > 0)
                //{
                //    if (this.objFacturar.MontoIV>0)
                //    {
                //        porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;
                //        invporcdes = (100 - Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100;
                //        temp = (this.objFacturar.PrecioIVA / Convert.ToDecimal(iva1)) * (iva / 100);
                //        temp2 = (this.objFacturar.PrecioIVA - temp);
                //        descuentomonto = temp2 * (porcdes);

                //        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((this.objFacturar.PrecioIVA * invporcdes).ToString()) * Convert.ToDouble(this.nupCantidad.Value.ToString())), 0, MidpointRounding.AwayFromZero);

                //        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                //        this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                //                                this.objFacturar.Descripcion.ToString(),
                //                                this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                //                                1,
                //                                Convert.ToDecimal(this.txtPorcDescuento.Text),//% desc
                //                                descuentomonto.ToString("#0,#.#0"),//descuento monto
                //                                totaliva.ToString("#,#.#0"),
                //                                this.objFacturar.TipoPrecio.ToString()
                //                                );
                //    }
                //    else
                //    {
                //        porcdes = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;
                //        invporcdes = (100 - Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100;
                //        temp = (this.objFacturar.PrecioIVA);
                //        descuentomonto = temp * (porcdes);

                //        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((this.objFacturar.PrecioIVA * invporcdes).ToString()) * Convert.ToDouble(this.nupCantidad.Value.ToString())), 0, MidpointRounding.AwayFromZero);

                //        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                //        this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                //                                this.objFacturar.Descripcion.ToString(),
                //                                this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                //                                1,
                //                                Convert.ToDecimal(this.txtPorcDescuento.Text),//% desc
                //                                descuentomonto.ToString("#0,#.#0"),//descuento monto
                //                                totaliva.ToString("#,#.#0"),
                //                                this.objFacturar.TipoPrecio.ToString()
                //                                );
                //    }
                //}
                //else//sin porc de descuento
                //{
                //    if (this.objFacturar.MontoIV > 0)
                //    {
                //        //temp = (this.objFacturar.PrecioIVA / Convert.ToDecimal(iva1)) * (iva / 100);
                //        //temp2 = (this.objFacturar.PrecioIVA - temp);

                //        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((this.objFacturar.PrecioIVA).ToString()) * Convert.ToDouble(this.nupCantidad.Value.ToString())), 0, MidpointRounding.AwayFromZero);

                //        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                //        this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                //                                this.objFacturar.Descripcion.ToString(),
                //                                this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                //                                1,
                //                                "00.000000",//% desc
                //                                "00.00",//descuento monto
                //                                totaliva.ToString("#,#.#0"),
                //                                this.objFacturar.TipoPrecio.ToString()
                //                                );
                //    }
                //    else
                //    {
                //        double totaliva = Math.Round(Convert.ToDouble(Convert.ToDouble((this.objFacturar.PrecioIVA).ToString()) * Convert.ToDouble(this.nupCantidad.Value.ToString())), 0, MidpointRounding.AwayFromZero);

                //        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                //        this.dgvDatos.Rows.Insert(0, this.objFacturar.Codigo.ToString(),
                //                                this.objFacturar.Descripcion.ToString(),
                //                                this.objFacturar.PrecioIVA.ToString("#,#.#0"),
                //                                1,
                //                                "00.000000",//% desc
                //                                "00.00",//descuento monto
                //                                totaliva.ToString("#,#.#0"),
                //                                this.objFacturar.TipoPrecio.ToString()
                //                                );
                //    }
                //}


                //this.lblCantidadLineas.Text = (Convert.ToDecimal(this.lblCantidadLineas.Text) + 1).ToString();

                //if (this.objFacturar.UnidadMedidaId == 1)//normal
                //{
                //    this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + 1).ToString();

                //}
                //else//peso:embutidos,verduras,pollo
                //{
                //    this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) + 1).ToString();
                //}

                //this.lblUltimoArticulo.Text = this.objFacturar.Descripcion.ToString();

                //this.lblSignoColones.Text = this.objFacturar.PrecioIVA.ToString("C");





                //this.CalculaFooter();


                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminaLinea()
        {
            try
            {
                this.objFacturar.Existencias = 0;

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    if (this.dgvDatos.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    if (this.objFacturar.ObtieneProducto((this.dgvDatos.CurrentRow.Cells[0].Value).ToString()) == false)
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1";
                        this.txtCodigo.Focus();
                        return;
                    }

                    this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) - Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[3].Value)).ToString();

                    decimal desctemp = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    desctemp -= Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[5].Value.ToString());

                    this.txtDescuentoAplicado.Text = desctemp.ToString("#0,#.#0");

                    decimal subptemp = Convert.ToDecimal(this.txtSubtotalPDesc.Text);

                    string iva1 = "1." + iva.ToString("##");

                    subptemp -= Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[3].Value) * (Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[2].Value) / Convert.ToDecimal(iva1));

                    this.txtSubtotalPDesc.Text = subptemp.ToString("#0,#.#0");

                    if (Convert.ToDecimal(this.txtPorcDescuento.Text) > 0)
                    {
                        this.txtPorcDescuento.Text = decimal.Round(((Convert.ToDecimal(this.txtDescuentoAplicado.Text) * 100) / Convert.ToDecimal(this.txtSubtotalPDesc.Text)), 4).ToString();
                    }
                    else
                    {
                        this.txtPorcDescuento.Text = "0.00";
                    }


                    this.dgvDatos.Rows.RemoveAt(this.dgvDatos.CurrentRow.Index);

                    this.lblCantidadLineas.Text = (Convert.ToDecimal(this.lblCantidadLineas.Text) - 1).ToString();

                    this.CalculaFooter();

                    if (this.dgvDatos.Rows.Count == 0)
                    {
                        this.txtPorcDescuento.Text = "0";
                    }
                }


                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    if (this.dgvDatos2.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    if (this.objFacturar.ObtieneProducto((this.dgvDatos2.CurrentRow.Cells[0].Value).ToString()) == false)
                    {
                        this.txtCodigo.Text = string.Empty;
                        this.nupCantidad.Text = "1";
                        this.txtCodigo.Focus();
                        return;
                    }

                    this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) - Convert.ToDecimal(this.dgvDatos2.CurrentRow.Cells[3].Value)).ToString();

                    decimal desctemp = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    desctemp -= Convert.ToDecimal(this.dgvDatos2.CurrentRow.Cells[5].Value.ToString());

                    this.txtDescuentoAplicado2.Text = desctemp.ToString("#0,#.#0");

                    decimal subptemp = Convert.ToDecimal(this.txtSubtotalPDesc2.Text);

                    string iva1 = "1." + iva.ToString("##");

                    subptemp -= Convert.ToDecimal(this.dgvDatos2.CurrentRow.Cells[3].Value) * (Convert.ToDecimal(this.dgvDatos2.CurrentRow.Cells[2].Value) / Convert.ToDecimal(iva1));

                    this.txtSubtotalPDesc2.Text = subptemp.ToString("#0,#.#0");

                    if (Convert.ToDecimal(this.txtPorcDescuento2.Text) > 0)
                    {
                        this.txtPorcDescuento2.Text = decimal.Round(((Convert.ToDecimal(this.txtDescuentoAplicado2.Text) * 100) / Convert.ToDecimal(this.txtSubtotalPDesc2.Text)), 4).ToString();
                    }
                    else
                    {
                        this.txtPorcDescuento2.Text = "0.00";
                    }


                    this.dgvDatos2.Rows.RemoveAt(this.dgvDatos2.CurrentRow.Index);

                    this.lblCantidadLineas2.Text = (Convert.ToDecimal(this.lblCantidadLineas2.Text) - 1).ToString();

                    this.CalculaFooter2();

                    if (this.dgvDatos2.Rows.Count == 0)
                    {
                        this.txtPorcDescuento2.Text = "0";
                    }
                }

                this.txtCodigo.Text = string.Empty;

                this.nupCantidad.Text = "1";

                this.txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificaLinea()
        {
            try
            {
                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    if (this.dgvDatos.SelectedRows.Count == 0)
                    {
                        return;
                    }
                    if (this.objFacturar.ObtieneProductoActualizar((this.dgvDatos.CurrentRow.Cells[0].Value).ToString()) == false)
                    {
                        //this.txtCodigo.Text = string.Empty;
                        //this.nupCantidad.Value = 1;
                        //this.txtCodigo.Focus();
                        //return;
                    }


                    this.lblCantidadArticulos.Text = (Convert.ToDecimal(this.lblCantidadArticulos.Text) - Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[3].Value)).ToString();

                    //if (Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[5].Value)>0)//descuento monto
                    //{
                    this.txtDescuentoAplicado.Text = (Convert.ToDecimal(this.txtDescuentoAplicado.Text) - Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[5].Value)).ToString("#0,#.#0");
                    //}


                    //FacturaMod_ActualizaLinea facturaactualiza = new FacturaMod_ActualizaLinea(this);
                    //facturaactualiza.TopLevel = false;
                    //facturaactualiza.Parent = this;
                    //facturaactualiza.Codigo = this.dgvDatos.Rows[0].Cells[0].Value.ToString();
                    //facturaactualiza.Descripcion = this.dgvDatos.Rows[0].Cells[1].Value.ToString();
                    //facturaactualiza.Cantidad = this.dgvDatos.Rows[0].Cells[3].Value.ToString();
                    //facturaactualiza.ListaPrecios = this.cmbListaPrecios.Text;
                    //facturaactualiza.unidadmedida = this.objFacturar.UnidadMedidaId;
                    //facturaactualiza.precioconiv = this.dgvDatos.Rows[0].Cells[2].Value.ToString();
                    //facturaactualiza.porcdesc = this.dgvDatos.Rows[0].Cells[4].Value.ToString();
                    //facturaactualiza.descmonto = this.dgvDatos.Rows[0].Cells[5].Value.ToString();
                    //facturaactualiza.TipoFactura = 1;
                    //facturaactualiza.Show();

                    FacturaMod_ActualizaLinea facturaactualiza = new FacturaMod_ActualizaLinea(this);
                    facturaactualiza.TopLevel = false;
                    facturaactualiza.Parent = this;
                    facturaactualiza.Codigo = this.dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    facturaactualiza.Descripcion = this.dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    facturaactualiza.Cantidad = this.dgvDatos.CurrentRow.Cells[3].Value.ToString();
                    facturaactualiza.ListaPrecios = this.cmbListaPrecios.Text;
                    facturaactualiza.unidadmedida = this.objFacturar.UnidadMedidaId;
                    facturaactualiza.precioconiv = this.dgvDatos.CurrentRow.Cells[2].Value.ToString();
                    facturaactualiza.porcdesc = this.dgvDatos.CurrentRow.Cells[4].Value.ToString();
                    facturaactualiza.descmonto = this.dgvDatos.CurrentRow.Cells[5].Value.ToString();
                    facturaactualiza.TipoFactura = 1;

                    facturaactualiza.Show();


                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    if (this.dgvDatos2.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    if (this.objFacturar.ObtieneProductoActualizar((this.dgvDatos2.CurrentRow.Cells[0].Value).ToString()) == false)
                    {
                        //this.txtCodigo.Text = string.Empty;
                        //this.nupCantidad.Value = 1;
                        //this.txtCodigo.Focus();
                        //return;
                    }


                    this.lblCantidadArticulos2.Text = (Convert.ToDecimal(this.lblCantidadArticulos2.Text) - Convert.ToDecimal(this.dgvDatos2.CurrentRow.Cells[3].Value)).ToString();

                    //if (Convert.ToDecimal(this.dgvDatos.CurrentRow.Cells[5].Value)>0)//descuento monto
                    //{
                    this.txtDescuentoAplicado2.Text = (Convert.ToDecimal(this.txtDescuentoAplicado2.Text) - Convert.ToDecimal(this.dgvDatos2.CurrentRow.Cells[5].Value)).ToString("#0,#.#0");
                    //}


                    FacturaMod_ActualizaLinea facturaactualiza = new FacturaMod_ActualizaLinea(this);
                    facturaactualiza.TopLevel = false;
                    facturaactualiza.Parent = this;
                    facturaactualiza.Codigo = this.dgvDatos2.CurrentRow.Cells[0].Value.ToString();
                    facturaactualiza.Descripcion = this.dgvDatos2.CurrentRow.Cells[1].Value.ToString();
                    facturaactualiza.Cantidad = this.dgvDatos2.CurrentRow.Cells[3].Value.ToString();
                    facturaactualiza.ListaPrecios = this.cmbListaPrecios.Text;
                    facturaactualiza.unidadmedida = this.objFacturar.UnidadMedidaId;
                    facturaactualiza.precioconiv = this.dgvDatos2.CurrentRow.Cells[2].Value.ToString();
                    facturaactualiza.porcdesc = this.dgvDatos2.CurrentRow.Cells[4].Value.ToString();
                    facturaactualiza.descmonto = this.dgvDatos2.CurrentRow.Cells[5].Value.ToString();
                    facturaactualiza.TipoFactura = 2;
                    facturaactualiza.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultaLinea()
        {
            try
            {
                FacturacionMod_Consulta LineaConsulta = new FacturacionMod_Consulta(this);
                LineaConsulta.TopLevel = false;
                LineaConsulta.Parent = this;
                LineaConsulta.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.gb2.Visible = false;
                    this.dgvDatos2.Visible = false;
                    this.gb1.Visible = true;
                    this.dgvDatos.Visible = true;
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.gb2.Visible = true;
                    this.dgvDatos2.Visible = true;
                    this.gb1.Visible = false;
                    this.dgvDatos.Visible = false;
                    this.gb1.SendToBack();
                    this.gb2.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cambiar de factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void AplicaDescuento()
        //{
        //    try
        //    {
        //        if (Login.RolId.ToString() == "1")//administrador
        //        {
        //            if (this.cmbTipoFactura.Text == "Factura 1")
        //            {
        //                impuestotemp = 0;
        //                this.objFacturar.TipoPrecio = Convert.ToInt32(this.cmbListaPrecios.Text.Substring(this.cmbListaPrecios.Text.Length - 1, 1));
        //                foreach (DataGridViewRow item in this.dgvDatos.Rows)
        //                {
        //                    this.objFacturar.ObtieneProducto(item.Cells[0].Value.ToString());
        //                    impuestotemp += this.objFacturar.MontoIV * Convert.ToDecimal(item.Cells[3].Value);
        //                }
        //                this.txtImpuesto.Text = Convert.ToDecimal(impuestotemp).ToString("F");

        //                impuestotemp = 0;

        //                this.txtDescuentoAplicado.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100)).ToString("F");
        //                this.txtSubtotal.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) - (Convert.ToDecimal(this.txtSubtotalPDesc.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100))).ToString("F");


        //                this.txtImpuesto.Text = (Convert.ToDecimal(this.txtSubtotal.Text)*Convert.ToDecimal("0.13")).ToString("F");

        //                this.txtTotal.Text = (Convert.ToDecimal(this.txtSubtotal.Text) + Convert.ToDecimal(this.txtImpuesto.Text)).ToString("F");
        //            }
        //            if (this.cmbTipoFactura.Text == "Factura 2")
        //            {
        //                this.txtDescuentoAplicado2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotalPDesc2.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento2.Text)) / 100)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtSubtotal2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotalPDesc2.Text) - Convert.ToDecimal(this.txtDescuentoAplicado2.Text) - Convert.ToDecimal(this.txtImpuesto2.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtTotal2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotal2.Text) + Convert.ToDecimal(this.txtImpuesto2.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");
        //            }
        //        }

        //        if (Login.RolId.ToString() == "2" && permiso == 0)//cajeras
        //        {
        //            PermisoAplicaDescuento per = new PermisoAplicaDescuento(this);
        //            per.TopLevel = false;
        //            per.Parent = this;
        //            per.Show();
        //        }
        //        if (Login.RolId.ToString() == "2" && permiso != 0)//cajeras permiso para descuentos
        //        {
        //            if (this.cmbTipoFactura.Text == "Factura 1")
        //            {
        //                this.txtDescuentoAplicado.Text = Math.Round((Convert.ToDecimal(this.txtSubtotalPDesc.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtSubtotal.Text = Math.Round((Convert.ToDecimal(this.txtSubtotalPDesc.Text) - Convert.ToDecimal(this.txtDescuentoAplicado.Text) - Convert.ToDecimal(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtTotal.Text = Math.Round((Convert.ToDecimal(this.txtSubtotal.Text) + Convert.ToDecimal(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");
        //            }
        //            if (this.cmbTipoFactura.Text == "Factura 2")
        //            {
        //                this.txtDescuentoAplicado2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotalPDesc2.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento2.Text)) / 100)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtSubtotal2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotalPDesc2.Text) - Convert.ToDecimal(this.txtDescuentoAplicado2.Text) - Convert.ToDecimal(this.txtImpuesto2.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtTotal2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotal2.Text) + Convert.ToDecimal(this.txtImpuesto2.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar aplicar el descuento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void AplicaDescuento(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (Login.RolId.ToString() == "1")//administrador
        //        {
        //            if (this.cmbTipoFactura.Text == "Factura 1")
        //            {
        //                impuestotemp = 0;
        //                this.objFacturar.TipoPrecio = Convert.ToInt32(this.cmbListaPrecios.Text.Substring(this.cmbListaPrecios.Text.Length - 1, 1));
        //                foreach (DataGridViewRow item in this.dgvDatos.Rows)
        //                {
        //                    this.objFacturar.ObtieneProducto(item.Cells[0].Value.ToString());
        //                    impuestotemp += this.objFacturar.MontoIV * Convert.ToDecimal(item.Cells[3].Value);
        //                }
        //                this.txtImpuesto.Text = Convert.ToDecimal(impuestotemp).ToString("F");

        //                this.txtDescuentoAplicado.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100)).ToString("F");
        //                this.txtSubtotal.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) - (Convert.ToDecimal(this.txtSubtotalPDesc.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100))).ToString("F");

        //                if (Convert.ToDecimal(this.txtPorcDescuento.Text) == 0)
        //                {
        //                    this.txtImpuesto.Text = (Convert.ToDecimal(impuestotemp)).ToString("F");
        //                }
        //                else
        //                {
        //                    decimal valporc = ((100 - Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100);
        //                    this.txtImpuesto.Text = (impuestotemp * valporc).ToString("F");
        //                    //this.txtImpuesto.Text = (Convert.ToDecimal(this.txtSubtotal.Text) * Convert.ToDecimal(iva / 100)).ToString("F");
        //                }

        //                this.txtTotal.Text = (Convert.ToDecimal(this.txtSubtotal.Text) + Convert.ToDecimal(this.txtImpuesto.Text)).ToString("F");






        //                ////iva==13.00

        //                //if (Convert.ToDecimal(this.txtPorcDescuento.Text)>0)
        //                //{

        //                //}
        //            }
        //            if (this.cmbTipoFactura.Text == "Factura 2")
        //            {
        //                this.txtDescuentoAplicado2.Text = (Convert.ToDecimal(this.txtSubtotalPDesc2.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento2.Text)) / 100)).ToString("F");

        //                this.txtImpuesto2.Text = (Convert.ToDecimal(this.txtImpuesto2.Text) - (Convert.ToDecimal(this.txtImpuesto2.Text) * (Convert.ToDecimal(this.txtPorcDescuento2.Text) / 100))).ToString("F");

        //                this.txtSubtotal2.Text = (Convert.ToDecimal(this.txtSubtotalPDesc2.Text) - Convert.ToDecimal(this.txtDescuentoAplicado2.Text) - Convert.ToDecimal(this.txtImpuesto2.Text)).ToString("F");

        //                this.txtTotal2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotal2.Text) + Convert.ToDecimal(this.txtImpuesto2.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");
        //            }
        //        }

        //        if (Login.RolId.ToString() == "2" && permiso == 0)//cajeras
        //        {
        //            PermisoAplicaDescuento per = new PermisoAplicaDescuento(this);
        //            per.TopLevel = false;
        //            per.Parent = this;
        //            per.Show();
        //        }
        //        if (Login.RolId.ToString() == "2" && permiso != 0)//cajeras permiso para descuentos
        //        {
        //            if (this.cmbTipoFactura.Text == "Factura 1")
        //            {
        //                this.txtDescuentoAplicado.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento.Text)) / 100)).ToString("F");

        //                this.txtSubtotal.Text = (Convert.ToDecimal(this.txtSubtotalPDesc.Text) - Convert.ToDecimal(this.txtDescuentoAplicado.Text) - Convert.ToDecimal(this.txtImpuesto.Text)).ToString("F");

        //                this.txtTotal.Text = Math.Round((Convert.ToDecimal(this.txtSubtotal.Text) + Convert.ToDecimal(this.txtImpuesto.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtPorcDescuento.ReadOnly = true;
        //            }
        //            if (this.cmbTipoFactura.Text == "Factura 2")
        //            {
        //                this.txtDescuentoAplicado2.Text = (Convert.ToDecimal(this.txtSubtotalPDesc2.Text) * Convert.ToDecimal((Convert.ToDecimal(this.txtPorcDescuento2.Text)) / 100)).ToString("F");

        //                this.txtSubtotal2.Text = (Convert.ToDecimal(this.txtSubtotalPDesc2.Text) - Convert.ToDecimal(this.txtDescuentoAplicado2.Text) - Convert.ToDecimal(this.txtImpuesto2.Text)).ToString("F");

        //                this.txtTotal2.Text = Math.Round((Convert.ToDecimal(this.txtSubtotal2.Text) + Convert.ToDecimal(this.txtImpuesto2.Text)), 0, MidpointRounding.AwayFromZero).ToString("F");

        //                this.txtPorcDescuento2.ReadOnly = true;
        //            }
        //            permiso = 0;
        //        }
        //        e.Handled = true;
        //        e.SuppressKeyPress = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al intentar aplicar el descuento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void AbreCajaDescuento()
        {
            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                this.txtPorcDescuento.ReadOnly = false;
                this.txtPorcDescuento.Enabled = true;
            }
            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                this.txtPorcDescuento2.ReadOnly = false;
                this.txtPorcDescuento2.Enabled = true;
            }
        }

        decimal Des;

        private void txtPorcDescuento_KeyDown(object sender, KeyEventArgs e)
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
                    decimal descuento = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;
                    this.txtPorcDescuento.Text = decimal.Round(Convert.ToDecimal(this.txtPorcDescuento.Text), 4).ToString();

                    decimal porcdescitem1 = (Convert.ToDecimal(this.txtPorcDescuento.Text) / 100);

                    decimal invporcdescitem1 = 1;

                    if (Convert.ToDecimal(this.txtPorcDescuento.Text) > 0)
                    {
                        invporcdescitem1 = ((100 - (Convert.ToDecimal(this.txtPorcDescuento.Text))) / 100);
                        //     MessageBox.Show("LA VARIABLE inporcdecitem1 "+invporcdescitem1);
                    }
                    //        MessageBox.Show("el iva va " + iva);
                    string Siva = "1." + iva.ToString("##");

                    foreach (DataGridViewRow item1 in this.dgvDatos.Rows)
                    {

                        item1.Cells[4].Value = this.txtPorcDescuento.Text;//%desc

                        if (this.objFacturar.ObtieneProducto((item1.Cells[0].Value.ToString())) == false)
                        {
                            return;
                        }
                        //aqui va la jugada tosty
                        String codigo;
                        try
                        {
                            codigo = Convert.ToInt32(item1.Cells[0].Value).ToString();
                            decimal cod = Convert.ToDecimal(codigo);
                        }
                        catch (Exception ex)
                        {
                            codigo = "90";
                        }



                        if ((Convert.ToInt32(codigo) < 80) &&
                            (Convert.ToInt32(codigo) > 0))
                        {
                            //con esto sabemos cuales son genericos
                            if (this.objFacturar.MontoIV > 0)
                            {
                                //double precio = Convert.ToDouble(item1.Cells[2].Value);//1250
                                //double temp = (precio / Convert.ToDouble(Siva)) * Convert.ToDouble(iva / 100);//precio sin impuesto 5277.1-->607.1
                                //double temp2 = Convert.ToDouble((precio - temp).ToString("F"));//-->4670

                                //item1.Cells[5].Value = (Convert.ToDouble(temp2) * Convert.ToDouble(porcdescitem1) * Convert.ToDouble(item1.Cells[3].Value)).ToString("#0,#.#0");//descuentomonto

                                //double totaliva = Math.Round(((Convert.ToDouble(item1.Cells[2].Value) * Convert.ToDouble(item1.Cells[3].Value) * Convert.ToDouble(invporcdescitem1))), 0, MidpointRounding.AwayFromZero);

                                //totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                //item1.Cells[6].Value = totaliva.ToString("#0,#.#0");//totaliva
                                decimal precio = Convert.ToDecimal(item1.Cells[2].Value.ToString());
                                decimal total = Convert.ToDecimal(item1.Cells[6].Value.ToString());
                                decimal temp = (total / 1.13m);
                                decimal temp2 = (precio / 1.13m);
                                // item1.Cells[2].Value = Convert.ToDecimal(temp2 - (temp2 * descuento));
                                item1.Cells[4].Value = Convert.ToDecimal(descuento * 100).ToString();
                                decimal totalsindescuento = Convert.ToDecimal(temp * descuento);
                                item1.Cells[5].Value = (Convert.ToDecimal(temp2) * descuento).ToString("#0,#.#0");
                                decimal totaliva = totalsindescuento;

                                item1.Cells[6].Value = Convert.ToDecimal(temp - (totaliva + (totaliva * 0.13m))).ToString();

                                if (this.txtPorcDescuento.Text == "0")
                                {
                                    item1.Cells[6].Value = Convert.ToDecimal(item1.Cells[6].Value)
                                        + Convert.ToDecimal(this.Des);

                                    item1.Cells[5].Value = "0.00";
                                }


                            }
                            else
                            {
                                //double precio = Convert.ToDouble(item1.Cells[2].Value);

                                //item1.Cells[5].Value = (Convert.ToDouble(precio) * Convert.ToDouble(porcdescitem1) * Convert.ToDouble(item1.Cells[3].Value)).ToString("#0,#.#0");//descuentomonto

                                //double totaliva = Math.Round(((Convert.ToDouble(item1.Cells[2].Value) * Convert.ToDouble(item1.Cells[3].Value) * Convert.ToDouble(invporcdescitem1))), 0, MidpointRounding.AwayFromZero);

                                //totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                //item1.Cells[6].Value = totaliva.ToString("#0,#.#0");//totaliva


                                decimal precio = Convert.ToDecimal(item1.Cells[2].Value.ToString());
                                decimal total = Convert.ToDecimal(item1.Cells[6].Value.ToString());
                                decimal temp = (total);
                                decimal temp2 = (precio);
                                //  item1.Cells[2].Value = Convert.ToDecimal(temp2 - (temp2 * descuento));
                                decimal totalsindescuento = Convert.ToDecimal(temp * descuento);
                                item1.Cells[4].Value = Convert.ToDecimal(descuento * 100).ToString();
                                item1.Cells[5].Value = (Convert.ToDecimal(temp) * descuento).ToString("#0,#.#0");
                                decimal totaliva = totalsindescuento;

                                item1.Cells[6].Value = Convert.ToDecimal(temp - totaliva).ToString();

                                if (this.txtPorcDescuento.Text == "0")
                                {
                                    item1.Cells[6].Value = Convert.ToDecimal(item1.Cells[6].Value)
                                        + Convert.ToDecimal(Des);

                                    item1.Cells[5].Value = "0.00";
                                }

                            }

                            //fin genericos
                        }
                        else
                        {
                            if (this.objFacturar.MontoIV > 0)
                            {
                                double precio = Convert.ToDouble(item1.Cells[2].Value);//1780
                                double temp = (precio / Convert.ToDouble(Siva)) * Convert.ToDouble(iva / 100);//precio sin impuesto 5277.1-->607.1
                                double temp2 = Convert.ToDouble((precio - temp).ToString("F"));//-->4670

                                item1.Cells[5].Value = (Convert.ToDouble(temp2) * Convert.ToDouble(porcdescitem1) * Convert.ToDouble(item1.Cells[3].Value)).ToString("#0,#.#0");//descuentomonto

                                double totaliva = Math.Round(((Convert.ToDouble(item1.Cells[2].Value) * Convert.ToDouble(item1.Cells[3].Value) * Convert.ToDouble(invporcdescitem1))), 0, MidpointRounding.AwayFromZero);

                                totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                item1.Cells[6].Value = totaliva.ToString("#0,#.#0");//totaliva
                            }
                            else
                            {
                                double precio = Convert.ToDouble(item1.Cells[2].Value);

                                item1.Cells[5].Value = (Convert.ToDouble(precio) * Convert.ToDouble(porcdescitem1) * Convert.ToDouble(item1.Cells[3].Value)).ToString("#0,#.#0");//descuentomonto

                                double totaliva = Math.Round(((Convert.ToDouble(item1.Cells[2].Value) * Convert.ToDouble(item1.Cells[3].Value) * Convert.ToDouble(invporcdescitem1))), 0, MidpointRounding.AwayFromZero);

                                totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                                item1.Cells[6].Value = totaliva.ToString("#0,#.#0");//totaliva
                            }
                        }



                    }
                    Des = descuento;

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

        private void txtPorcDescuento2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == (Keys.Enter))
                {
                    try
                    {
                        Convert.ToDecimal(this.txtPorcDescuento2.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Para el descuento ingrese solo números!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtPorcDescuento2.Text = "0.0000";
                        return;
                    }

                    this.txtPorcDescuento2.Text = decimal.Round(Convert.ToDecimal(this.txtPorcDescuento2.Text), 4).ToString();

                    decimal porcdescitem1 = (Convert.ToDecimal(this.txtPorcDescuento2.Text) / 100);

                    decimal invporcdescitem1 = 1;

                    if (Convert.ToDecimal(this.txtPorcDescuento2.Text) > 0)
                    {
                        invporcdescitem1 = ((100 - (Convert.ToDecimal(this.txtPorcDescuento2.Text))) / 100);
                    }

                    string Siva = "1." + iva.ToString("##");

                    foreach (DataGridViewRow item1 in this.dgvDatos2.Rows)
                    {

                        item1.Cells[4].Value = this.txtPorcDescuento2.Text;//%desc

                        if (this.objFacturar.ObtieneProducto((item1.Cells[0].Value.ToString())) == false)
                        {
                            return;
                        }

                        if (this.objFacturar.MontoIV > 0)
                        {
                            double precio = Convert.ToDouble(item1.Cells[2].Value);
                            double temp = (precio / Convert.ToDouble(Siva)) * Convert.ToDouble(iva / 100);//precio sin impuesto 5277.1-->607.1
                            double temp2 = Convert.ToDouble((precio - temp).ToString("F"));//-->4670

                            item1.Cells[5].Value = (Convert.ToDouble(temp2) * Convert.ToDouble(porcdescitem1) * Convert.ToDouble(item1.Cells[3].Value)).ToString("#0,#.#0");//descuentomonto

                            double totaliva = Math.Round(((Convert.ToDouble(item1.Cells[2].Value) * Convert.ToDouble(item1.Cells[3].Value) * Convert.ToDouble(invporcdescitem1))), 0, MidpointRounding.AwayFromZero);

                            totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            item1.Cells[6].Value = totaliva.ToString("#0,#.#0");//totaliva
                        }
                        else
                        {
                            double precio = Convert.ToDouble(item1.Cells[2].Value);

                            item1.Cells[5].Value = (Convert.ToDouble(precio) * Convert.ToDouble(porcdescitem1) * Convert.ToDouble(item1.Cells[3].Value)).ToString("#0,#.#0");//descuentomonto

                            double totaliva = Math.Round(((Convert.ToDouble(item1.Cells[2].Value) * Convert.ToDouble(item1.Cells[3].Value) * Convert.ToDouble(invporcdescitem1))), 0, MidpointRounding.AwayFromZero);

                            totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                            item1.Cells[6].Value = totaliva.ToString("#0,#.#0");//totaliva
                        }

                    }


                    this.CalculaFooter2();

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar aplicar el descuento: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Cliente cliente = new Sel_Cliente(this);
                cliente.TopLevel = false;
                cliente.Parent = this;
                cliente.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar buscar los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiaCliente()
        {
            try
            {
                this.cmbCliente.SelectedValue = ClienteN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlamaEmiteFactura()
        {
            try
            {
                this.btnEmitirFactura.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiaFactura()
        {
            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                this.lblCantidadArticulos.Text = "0";
                this.lblCantidadLineas.Text = "0";
                this.txtTotal.Text = "0.00";
                this.txtSubtotal.Text = "0.00";
                this.txtPorcDescuento.Text = "0";
                this.txtDescuentoAplicado.Text = "0.00";
                this.txtSubtotalPDesc.Text = "0.00";
                this.txtImpuesto.Text = "0.00";
                this.dgvDatos.Rows.Clear();
                this.txtNuevoCliente.Text = string.Empty;
            }

            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                this.lblCantidadArticulos2.Text = "0";
                this.lblCantidadLineas2.Text = "0";
                this.txtTotal2.Text = "0.00";
                this.txtSubtotal2.Text = "0.00";
                this.txtPorcDescuento2.Text = "0";
                this.txtDescuentoAplicado2.Text = "0.00";
                this.txtSubtotalPDesc2.Text = "0.00";
                this.txtImpuesto2.Text = "0.00";
                this.dgvDatos2.Rows.Clear();

                this.txtNuevoCliente.Text = string.Empty;
            }
        }

        public void GeneraFacturaConTicketNoCredito()
        {
            try
            {
                this.objFacturar.Articulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }

                        this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + "," + item.Cells[1].Value.ToString() + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + "," + x);//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                        this.objTicket.AltoPapel += 20;
                    }

                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }

                        this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + "," + item.Cells[1].Value.ToString() + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + "," + x);//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                        this.objTicket.AltoPapel += 20;
                    }

                }
                this.objFacturar.Recibido = this.recibido;

                this.objFacturar.Cambio = this.cambio;

                this.objFacturar.TipoPago = 2;//efectivo

                this.objFacturar.IngresaEncabezadoFactura(Login.UserId);

                this.ConstruyeTicket();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public bool ObtieneCliente()
        {
            try
            {
                if (this.cmbCliente.SelectedValue.ToString() == "1")
                {
                    MessageBox.Show("Por favor seleccione el cliente al que desea realizarle el credito!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public void GeneraFacturaConTicketSiCredito()
        {
            try
            {
                if (this.cmbCliente.SelectedValue.ToString() == "1")
                {
                    MessageBox.Show("Por favor seleccione el cliente al que desea realizarle el credito!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                this.GeneraFacturaConTicketNoCredito();

                this.AgregaCreditoCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void GeneraFacturaNoTicketNoCredito()
        {
            try
            {
                this.objFacturar.Articulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
                this.objFacturar.Recibido = this.recibido;

                this.objFacturar.Cambio = this.cambio;

                this.objFacturar.IngresaEncabezadoFactura(Login.UserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        public void GeneraFacturaNoTicketSiCredito()
        {
            try
            {
                this.objTicket.Articulos.Clear();

                this.objFacturar.Articulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto(item.Cells[0].Value.ToString());

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                    }

                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto(item.Cells[0].Value.ToString());

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                    }

                }
                if (this.cmbCliente.SelectedValue.ToString() == "1")
                {
                    MessageBox.Show("Por favor seleccione el cliente al que desea realizarle el credito!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                this.objFacturar.Recibido = this.recibido;

                this.objFacturar.Cambio = this.cambio;

                this.objFacturar.IngresaEncabezadoFactura(Login.UserId);

                this.AgregaCreditoCliente();

                this.LimpiaFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //1-TarjetaCreidto 2-Efectivo 3-CreditoCredito

        public bool GeneraFacturaConTarjetaCredito()
        {
            try
            {
                this.ConstruyeFacturaEncabezadoDetalle();

                this.objFacturar.TipoPago = 1;//1-TarjetaCredito 2-Efectivo 3-CreditoCredito

                if (cajeroidtemp != 0)
                {
                    this.objFacturar.IngresaEncabezadoFactura(cajeroidtemp);
                }
                else
                {
                    this.objFacturar.IngresaEncabezadoFactura(Login.UserId);
                }
                cajeroidtemp = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool GeneraFacturaContadoParcial()
        {
            try
            {
                this.ConstruyeFacturaEncabezadoDetalle();

                this.objFacturar.TipoPago = 2;//1-TarjetaCredito 2-Efectivo 3-CreditoCredito


                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);
                }

                if (cajeroidtemp != 0)
                {
                    this.objFacturar.IngresaEncabezadoFacturaParcial(cajeroidtemp);
                }
                else
                {
                    this.objFacturar.IngresaEncabezadoFacturaParcial(Login.UserId);
                }
                cajeroidtemp = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool GeneraFacturaContado()
        {
            try
            {
                this.ConstruyeFacturaEncabezadoDetalle();

                this.objFacturar.TipoPago = 2;//1-TarjetaCredito 2-Efectivo 3-CreditoCredito

                if (cajeroidtemp != 0)
                {
                    this.objFacturar.IngresaEncabezadoFactura(cajeroidtemp);
                }
                else
                {
                    this.objFacturar.IngresaEncabezadoFactura(Login.UserId);
                }
                cajeroidtemp = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool GeneraFacturaCredito()
        {
            try
            {

                if (this.cmbCliente.SelectedValue.ToString() == "1")
                {
                    MessageBox.Show("Por favor seleccione el cliente al que desea realizarle el credito!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return false;
                }

                this.ConstruyeFacturaEncabezadoDetalle();

                this.objFacturar.Recibido = this.recibido;

                this.objFacturar.Cambio = this.cambio;

                this.objFacturar.TipoPago = 3;//credito credito

                if (cajeroidtemp != 0)
                {
                    this.objFacturar.IngresaEncabezadoFactura(cajeroidtemp);
                }
                else
                {
                    this.objFacturar.IngresaEncabezadoFactura(Login.UserId);
                }
                cajeroidtemp = 0;

                this.AgregaCreditoCliente();

                //this.LimpiaFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool ConstruyeFacturaEncabezadoDetalle()
        {
            try
            {
                this.objFacturar.Articulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objFacturar.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        //this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));
                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" +
                            Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            Convert.ToDecimal(item.Cells[3].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[4].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[5].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }

                        this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + "," + item.Cells[1].Value.ToString() + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + "," + x);//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                        this.objTicket.AltoPapel += 20;
                    }

                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objFacturar.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        //this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()));
                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[4].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[5].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }

                        this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + "," + item.Cells[1].Value.ToString() + "," + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + "," + x);//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                        this.objTicket.AltoPapel += 20;
                    }

                }
                this.objFacturar.Recibido = this.recibido;

                this.objFacturar.Cambio = this.cambio;

                //this.LimpiaFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        public void AgregaCreditoCliente()
        {
            try
            {
                this.objcliente.Id = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                this.objcliente.MontoFactura = VentaCreditoMonto;

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objcliente.Saldo = Convert.ToDecimal(this.txtTotal.Text);

                    //this.objcliente.MontoFactura = Convert.ToDecimal(this.txtTotal.Text);
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objcliente.Saldo = Convert.ToDecimal(this.txtTotal2.Text);

                    //this.objcliente.MontoFactura = Convert.ToDecimal(this.txtTotal2.Text);
                }

                this.objcliente.FacturaId = this.objFacturar.FacturaId;

                this.objcliente.AgregaCreditoCliente(Login.UserId);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el crédito al cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public bool AgregaCreditoClientePorPagar()//cuando pago una parte de la factura a contado
        {
            try
            {
                this.objcliente.Id = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                if (this.cmbCliente.SelectedValue.ToString() == "1")
                {
                    MessageBox.Show("Por favor seleccione el cliente al que desea realizarle el credito!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return false;
                }

                this.objcliente.Saldo = this.SaldoRestantePorPagar;

                this.objcliente.MontoFactura = this.SaldoRestantePorPagar;

                this.objcliente.FacturaId = this.objFacturar.FacturaId;

                this.objcliente.AgregaCreditoCliente(Login.UserId);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el crédito al cliente: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnEmitirFactura2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos2.Rows.Count == 0)
                {
                    return;

                }
                //aquiiiiiiiiiiiii
                if ((combo_tipo2.Text == "Exonerada") && (this.cmbTipoFactura.Text == "Factura 2"))
                {
                    this.txtImpuesto2.Text = "0.00";
                    this.txtTotal2.Text = this.txtSubtotal.Text;

                }
                if (this.cmbTipoComprobante.Text == "Nota de crédito")
                {
                    if (this.NotaCreditoMostrar != 0)
                    {
                        if (DialogResult.OK == MessageBox.Show("Desea agregar una nueva nota de crédito?", "Validación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        {
                            this.NotaCreditoMostrar = 0;
                            Sel_NotaCredito form1 = new Sel_NotaCredito(this);
                            form1.TopLevel = false;
                            form1.Parent = this;
                            form1.Show();
                        }
                        return;
                    }
                    Sel_NotaCredito form = new Sel_NotaCredito(this);
                    form.TopLevel = false;
                    form.Parent = this;
                    form.Show();

                    return;
                }

                if (this.cmbTipoComprobante.Text == "Proforma")
                {
                    if (this.ProforomaMostrar != 0)//para modificarla unicamente
                    {
                        this.Proforma();
                        return;
                    }
                    Proforma_Anexo anexo = new Proforma_Anexo(this);
                    anexo.TopLevel = false;
                    anexo.Parent = this;
                    anexo.Show();
                    return;
                }

                Facturacion_Pago pago = new Facturacion_Pago(this);
                pago.TopLevel = false;
                pago.Parent = this;


                if (this.cmbTipoComprobante.Text == "Prefactura")
                {
                    //pago.Prefactura = 1;

                    this.Prefactura();

                    this.LimpiaFactura();

                    this.PrefacturaMostrar = 0;

                    this.Close();

                    return;
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    if (Convert.ToDecimal(this.txtTotal2.Text) > 0)
                    {
                        pago.Total = Convert.ToDecimal(this.txtTotal2.Text);
                        pago.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);
                    }
                }

                pago.proformaid = ProforomaMostrar;
                pago.prefacturaid = PrefacturaMostrar;

                pago.Show();

                this.subtotal = Convert.ToDecimal(this.txtSubtotalPDesc2.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void mostrarProformaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ProformaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.txtSubtotalPDesc.Text = string.Empty;
            //this.txtPorcDescuento.Text = string.Empty;
            //this.txtDescuentoAplicado.Text = string.Empty;
            //this.txtSubtotal.Text = string.Empty;
            //this.txtImpuesto.Text = string.Empty;
            //this.txtTotal.Text = string.Empty;

            Proforma_Mod modulo = new Proforma_Mod(this);
            modulo.TopLevel = false;
            modulo.Parent = this;
            modulo.Show();

        }

        private void prefacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prefactura_Mod modulo = new Prefactura_Mod(this);
            modulo.TopLevel = false;
            modulo.Parent = this;
            modulo.Show();
        }

        private void cmbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTipoComprobante.Text == "Nota de crédito")
                {
                    this.txtTotal.Enabled = true;
                    this.txtTotal.ReadOnly = false;
                }
                if (this.cmbTipoComprobante.Text == "Abono Apartado")
                {
                    Apartados_Mod form = new Apartados_Mod(this);
                    form.TopLevel = false;
                    form.Parent = this;
                    form.Seleccion = 1;
                    form.Show();

                    this.cmbTipoComprobante.Text = "Factura";
                    this.cmbCliente.SelectedValue = 1;
                }
            }
            catch (Exception)
            {

            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void notasDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotasCredito_Mod modulo = new NotasCredito_Mod(this);
            modulo.TopLevel = false;
            modulo.Parent = this;
            modulo.Show();
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

        private void txtSubtotalPDesc2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.txtSubtotalPDesc2.Text) > 0)
                {
                    this.txtPorcDescuento2.Text = decimal.Round(((Convert.ToDecimal(this.txtDescuentoAplicado2.Text) * 100) / Convert.ToDecimal(this.txtSubtotalPDesc2.Text)), 4).ToString();
                }
                else
                {
                    this.txtPorcDescuento2.Text = "0.00";
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtImpuesto_TextChanged(object sender, EventArgs e)
        {

        }

        public double RoundOff(double i)
        {
            return ((int)Math.Round(i / 5.0)) * 5;
        }

        private void txtPorcDescuento_TextChanged(object sender, EventArgs e)
        {
            decimal PorDes = 0;
            if (txtPorcDescuento.Text == "")
                txtPorcDescuento.Text = "0.00";

            PorDes = Convert.ToDecimal(txtPorcDescuento.Text);


        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificaLinea();
        }

        private void dgvDatos2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificaLinea();
        }

        private void txtDescuentoAplicado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.txtSubtotalPDesc.Text) > 0)
                {
                    this.txtPorcDescuento.Text = decimal.Round(((Convert.ToDecimal(this.txtDescuentoAplicado.Text) * 100) / Convert.ToDecimal(this.txtSubtotalPDesc.Text)), 2).ToString();
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

        private void txtDescuentoAplicado2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(this.txtSubtotalPDesc2.Text) > 0)
                {
                    this.txtPorcDescuento2.Text = decimal.Round(((Convert.ToDecimal(this.txtDescuentoAplicado2.Text) * 100) / Convert.ToDecimal(this.txtSubtotalPDesc2.Text)), 2).ToString();
                }
                else
                {
                    this.txtPorcDescuento2.Text = "0.00";
                }
            }
            catch (Exception)
            {

            }
        }

        public bool GeneraApartado()
        {
            try
            {

                this.ConstruyeApartadoEncabezadoDetalle();

                //if (DescuentoCajaDiaria == 1)//monto es mayor a cero
                //{
                //    this.objApartados.DescCajaDiaria = 1;
                //}
                //if (DescuentoCajaDiaria == 0)
                //{
                //    this.objApartados.DescCajaDiaria = 0;
                //}
                //if (DescuentoCajaDiaria == 2)
                //{
                //    this.objApartados.DescCajaDiaria = 2;
                //}

                this.objApartados.IngresaEncabezadoApartado(Login.UserId);

                this.objTicket.MontoAbono = this.objApartados.MontoAbono;

                if (Prompt.ShowDialog("Por favor seleccione el método de impresión", "Selección", "Ticket", "Gráfico") == "Ticket")
                {
                    //imprime ticket
                    this.ConstruyeTicketApartado();
                }
                else
                {
                    this.ImprimeGraficoApartado();
                    //imprime grafico
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void ConstruyeTicketApartado()
        {
            try
            {
                this.objTicket.Apartado = 1;

                this.objTicket.Articulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                        else
                        {
                            x = "E";
                        }

                        this.objTicket.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                        decimal cantidad = (Convert.ToDecimal(item.Cells[3].Value.ToString()));
                        decimal temp = (Convert.ToDecimal(item.Cells[2].Value.ToString()) * cantidad);

                        double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        //this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit
                        this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + totaliva.ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                        this.objTicket.AltoPapel += 20;
                    }

                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));

                        string x = string.Empty;

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV != 0)
                        {
                            x = "G";
                        }
                        else
                        {
                            x = "E";
                        }

                        this.objTicket.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                        decimal cantidad = (Convert.ToDecimal(item.Cells[3].Value.ToString()));
                        decimal temp = (Convert.ToDecimal(item.Cells[2].Value.ToString()) * cantidad);

                        double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        //this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()).ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit
                        this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + item.Cells[1].Value.ToString() + ";" + totaliva.ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                        this.objTicket.AltoPapel += 20;
                    }
                }
                if (this.subtotal > 0)
                {
                    this.objTicket.subtotal = this.subtotal;
                }
                else
                {
                    if (this.cmbTipoFactura.Text == "Factura 1")
                    {
                        this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotal.Text);
                    }
                    if (this.cmbTipoFactura.Text == "Factura 2")
                    {
                        this.objTicket.subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);
                    }
                }

                this.objTicket.FacturaId = this.objApartados.AbonoId;

                this.objTicket.ClienteNombre = this.txtNuevoCliente.Text;

                if (this.cajeronombretemp.Length > 0)
                {
                    this.objTicket.CajeroNombre = this.cajeronombretemp;
                }
                else
                {
                    this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;
                }

                this.objTicket.print();

                this.objTicket.Offset = 40;

                this.cajeronombretemp = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImprimeGraficoApartado()
        {
            this.objApartados.ClienteNombre = this.cmbCliente.Text;

            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    this.objApartados.Articulos.Add(
                        item.Cells[0].Value.ToString() + ";" +
                        item.Cells[1].Value.ToString() + ";" +
                        item.Cells[2].Value.ToString() + ";" +
                        item.Cells[3].Value.ToString() + ";" +
                        item.Cells[4].Value.ToString() + ";" +
                        item.Cells[6].Value.ToString()
                        );
                }

                this.objApartados.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                this.objApartados.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                this.objApartados.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                this.objApartados.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);
            }

            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                {
                    this.objApartados.Articulos.Add(
                        item.Cells[0].Value.ToString() + ";" +
                        item.Cells[1].Value.ToString() + ";" +
                        item.Cells[2].Value.ToString() + ";" +
                        item.Cells[3].Value.ToString() + ";" +
                        item.Cells[4].Value.ToString() + ";" +
                        item.Cells[6].Value.ToString()
                        );
                }

                this.objApartados.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                this.objApartados.Desc_Aplicado = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                this.objApartados.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                this.objApartados.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);
            }

            this.objApartados.CajeroNombre = Login.LoginUsuarioFinal.ToString();

            this.objApartados.print();
        }

        public bool ConstruyeApartadoEncabezadoDetalle()
        {
            try
            {
                this.objApartados.Articulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objApartados.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objApartados.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objApartados.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objApartados.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objApartados.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objApartados.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objApartados.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objApartados.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objApartados.IV == true)
                        if (this.objApartados.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objApartados.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objApartados.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objApartados.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objApartados.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objApartados.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objApartados.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objApartados.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objApartados.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            item.Cells[4].Value.ToString() + ";" + item.Cells[5].Value.ToString() + ";" + item.Cells[6].Value.ToString());

                        string x = string.Empty;

                        //if (this.objApartados.IV == true)
                        if (this.objApartados.IV != 0)
                        {
                            x = "G";
                        }
                    }
                }

                this.objApartados.FechaInicio = System.DateTime.Now;

                this.objApartados.FechaFinal = System.DateTime.Now.AddDays(DiasApartado);

                this.objApartados.MontoAbono = MontoApartado;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la proforma: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void CambiaAFacturacion()
        {
            this.cmbTipoComprobante.Text = "Factura";
            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                this.btnEmitirFactura.PerformClick();
            }
            if (this.cmbTipoFactura.Text == "Factura 2")
            {
                this.btnEmitirFactura2.PerformClick();
            }
        }

        public bool VerficaCliente()
        {
            if (this.cmbCliente.SelectedValue.ToString() == "1")
            {
                MessageBox.Show("Debe seleccionar un cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption, string option1, string option2)
            {
                string result = string.Empty;
                Form prompt = new Form();
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.ControlBox = false;
                prompt.Width = 350;
                prompt.Height = 160;
                prompt.Text = caption;
                prompt.FormBorderStyle = FormBorderStyle.FixedSingle;
                Label textLabel = new Label() { Top = 20, Text = text, Width = 350, TextAlign = ContentAlignment.MiddleCenter };
                Button op1 = new Button() { Text = option1, Left = 50, Width = 100, Top = 70 };
                Button op2 = new Button() { Text = option2, Left = 200, Width = 100, Top = 70 };
                op1.Click += (sender, e) => { result = op1.Text; prompt.Close(); };
                op2.Click += (sender, e) => { result = op2.Text; prompt.Close(); };
                prompt.Controls.Add(op1);
                prompt.Controls.Add(op2);
                prompt.Controls.Add(textLabel);
                prompt.ShowDialog();
                return (string)result;
            }
        }

        private void apartadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Apartados_Mod form = new Apartados_Mod(this);
            form.TopLevel = false;
            form.Parent = this;
            form.Show();
        }

        public void MuestraApartado()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);

                iva = Convert.ToDecimal(bus.First().IVA);

                this.cmbTipoFactura.Text = "Factura 1";

                this.cmbListaPrecios.Text = "Lista de precios 1";

                this.cmbTipoComprobante.Text = "Factura";

                this.comboBox1.Text = "F9-SALIR";

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.dgvDatos2.Visible = false;
                    this.gb2.Visible = false;
                    this.gb1.Visible = true;
                    this.dgvDatos.Visible = true;
                    this.dgvDatos.Rows.Clear();

                    this.objApartados.MostrarApartado(this.dgvDatos, this.ApartadoId);

                    this.lblCantidadLineas.Text = this.objApartados.CantidadLineas.ToString();
                    this.lblCantidadArticulos.Text = this.objApartados.CantidadArticulos.ToString();

                    this.ClienteN = this.objApartados.ClienteId;
                    this.CambiaCliente();

                    this.CalculaFooter();
                }
                //this.txtTotal.Text = totaldescactualiza.ToString("##,#0.#0");//totaldescactualiza tiene el monto x el que se cancela el apartado
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la prefactura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LlamaFactura()
        {
            this.cmbTipoFactura.Text = "Factura 1";

            this.cmbListaPrecios.Text = "Lista de precios 1";

            this.cmbTipoComprobante.Text = "Factura";

            this.comboBox1.Text = "F9-SALIR";

            if (this.cmbTipoFactura.Text == "Factura 1")
            {
                this.btnEmitirFactura.PerformClick();
            }

            this._owner2.RealizoFactura();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //this.ConstruyeTicketApartado();

        private void apartadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Apartados_Mod form = new Apartados_Mod(this);
            form.TopLevel = false;
            form.Parent = this;
            form.Show();
        }



        public void GeneraFacturaTotal()
        {
            try
            {
                this.objFacturar.Articulos.Clear();

                if (this.cmbTipoFactura.Text == "Factura 1")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);

                    this.objFacturar.Subtotal = Convert.ToDecimal(this.txtSubtotal.Text);

                    this.objFacturar.NumTarjeta = NumTarjeta;

                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" +
                            Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" +
                            Convert.ToDecimal(item.Cells[3].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[4].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[5].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));
                    }

                }
                if (this.cmbTipoFactura.Text == "Factura 2")
                {
                    this.objFacturar.Descuento = Convert.ToDecimal(this.txtDescuentoAplicado2.Text);

                    this.objFacturar.TotalFactura = Convert.ToDecimal(this.txtTotal2.Text);

                    this.objFacturar.ProveedorId = 0;

                    this.objFacturar.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());

                    this.objFacturar.Impuesto = Convert.ToDecimal(this.txtImpuesto2.Text);

                    this.objFacturar.Subtotal = Convert.ToDecimal(this.txtSubtotal2.Text);

                    foreach (DataGridViewRow item in this.dgvDatos2.Rows)
                    {
                        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[7].Value.ToString());

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        this.objFacturar.Articulos.Add((item.Cells[0].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[2].Value.ToString()) + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[4].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[5].Value.ToString())
                            + ";" + Convert.ToDecimal(item.Cells[6].Value.ToString()));
                    }

                }
                this.objFacturar.Recibido = this.recibido;

                this.objFacturar.Cambio = this.cambio;

                this.objFacturar.TipoPago = this.FormaPagoId;


                //        TipoPago2 bit;//tarjetacredito
                //RecibidoTipoPago2 decimal (18,2)

                //TipoPago3 bit;//notascredito
                //RecibidoTipoPago3 decimal (18,2)

                //TipoPago4 bit;//credito
                //RecibidoTipoPago4 decimal (18,2)

                this.objFacturar.TipoPago2 = false;
                this.objFacturar.TipoPago3 = false;
                this.objFacturar.TipoPago4 = false;

                this.objFacturar.RecibidoTipoPago1 = this.VentaEfectivo;
                this.objFacturar.RecibidoTipoPago2 = this.VentaTarjetaCredito;



                if (this.VentaTarjetaCredito > 0)
                {
                    this.objFacturar.TipoPago2 = true;
                }

                this.objFacturar.RecibidoTipoPago3 = this.VentaNotaCredito;

                if (this.VentaNotaCredito > 0)
                {
                    this.objFacturar.TipoPago3 = true;
                }

                this.objFacturar.RecibidoTipoPago4 = this.VentaCreditoMonto;

                if (this.VentaCreditoMonto > 0)
                {
                    this.objFacturar.TipoPago4 = true;
                }

                if (cajeroidtemp != 0)
                {
                    this.objFacturar.IngresaEncabezadoFactura(cajeroidtemp);
                }
                else
                {
                    this.objFacturar.IngresaEncabezadoFactura(Login.UserId);
                }
                cajeroidtemp = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nupCantidad_TextChanged(object sender, EventArgs e)
        {

            //string canttemp;
            //canttemp = nupCantidad.Text;
            //if (canttemp != "")
            //{
            //    this.cantcompra = Convert.ToDecimal(canttemp);
            //}
        }

        private void combo_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_tipo.Text == "Exonerada")
            {
                var Result = MessageBox.Show("Esta seguro que esta factura es Exonerada?", "Confirmación", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    MessageBox.Show("Factura Exonerada ", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Result == DialogResult.No)
                {

                    for (int i = 0; i < combo_tipo.Items.Count; i++)
                    {
                        //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                        if (combo_tipo.GetItemText(combo_tipo.Items[i]) == "--Seleccione--")
                        {
                            combo_tipo.SelectedIndex = i;

                        }
                    }
                }
            }
        }

        private void combo_tipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (combo_tipo.Text == "Exonerada")
            {
                var respuesta = MessageBox.Show("Esta seguro de que esta factura es Exonerada de Impuesto ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    MessageBox.Show("Esta factura es exonerada de impuesto", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // public static int exonerada;
                    Facturacion_Mod.exonerada = 1;
                }
                else
                {
                    Facturacion_Mod.exonerada = 0;
                }

                if (respuesta == DialogResult.No)
                {
                    for (int i = 0; i < combo_tipo.Items.Count; i++)
                    {
                        //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                        if (combo_tipo.GetItemText(combo_tipo.Items[i]) == "--Seleccione--")
                        {
                            combo_tipo.SelectedIndex = i;

                        }
                    }
                }
            }

        }

        private void combo_tipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_tipo2.Text == "Exonerada")
            {
                var respuesta = MessageBox.Show("Esta seguro de que esta factura es Exonerada de Impuesto ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    MessageBox.Show("Esta factura es exonerada de impuesto", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                if (respuesta == DialogResult.No)
                {
                    for (int i = 0; i < combo_tipo2.Items.Count; i++)
                    {
                        //   MessageBox.Show(combo_2.GetItemText(combo_2.Items[i]));
                        if (combo_tipo2.GetItemText(combo_tipo2.Items[i]) == "--Seleccione--")
                        {
                            combo_tipo2.SelectedIndex = i;

                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
