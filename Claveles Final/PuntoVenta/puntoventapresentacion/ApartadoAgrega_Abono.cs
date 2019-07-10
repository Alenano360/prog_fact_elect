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
    public partial class ApartadoAgrega_Abono : Form
    {

        PuntoVentaDAL.CONEXIONDataContext db = null;

        Apartados_Mod _owner;

        PuntoVentaBL.Apartados objApartado = new PuntoVentaBL.Apartados();

        PuntoVentaBL.ImprimeTicketApartadoVenta objTicket = new PuntoVentaBL.ImprimeTicketApartadoVenta();

        PuntoVentaBL.Ticket objTicketAbono = new PuntoVentaBL.Ticket();

        public Int64 Id = 0;

        public string Fecha, Cliente, Total, Saldo,Vendedor = string.Empty;

        public int DescuentoCajaDiaria = 0;

        public decimal Dec_Saldo, Dec_MontoAbono = 0;

        public ApartadoAgrega_Abono(Apartados_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Close();
            //this._owner.Show();
        }

        private void ApartadoAgrega_Abono_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void ApartadoAgrega_Abono_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ActiveControl = this.txtAbono;

                this.txtNumero.Text = Id.ToString();

                this.txtFecha.Text = Convert.ToDateTime(Fecha).ToShortDateString();

                this.txtNombreCliente.Text = Cliente;

                this.txtTotalApartado.Text = Total;

                this.txtSaldo.Text = Saldo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar los apartados: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCancelar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCancelar.Checked)
            {
                this.txtAbono.Text = this.txtSaldo.Text;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal x = Convert.ToDecimal(this.txtAbono.Text);

                if (Convert.ToDecimal(this.txtAbono.Text) < 1)
                {
                    MessageBox.Show("El monto digitado en abono es incorrecto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Dec_MontoAbono = Convert.ToDecimal(this.txtAbono.Text);

                this.Dec_Saldo = Convert.ToDecimal(this.txtSaldo.Text);

                if (Convert.ToDecimal(this.txtAbono.Text) < Convert.ToDecimal(this.txtSaldo.Text))//si el abono es menor al total se guarda l apartado
                {
                    Facturacion_Pago form = new Facturacion_Pago(this);
                    form.TopLevel = false;
                    form.Parent = this;
                    form.Total = Convert.ToDecimal(this.txtAbono.Text);
                    form._ApartadoId = Convert.ToInt64(this.txtNumero.Text);
                    form.Apartado = 2;
                    form.Show();
                }
                else
                {

                    Facturacion_Pago form = new Facturacion_Pago(this);
                    form.TopLevel = false;
                    form.Parent = this;
                    form.Total = Convert.ToDecimal(this.txtAbono.Text);
                    form._ApartadoId = Convert.ToInt64(this.txtNumero.Text);
                    form.Apartado = 4;
                    form.Show();

                    //this.ConstruyeTicketApartado();

                    //Facturacion_Mod form1 = new Facturacion_Mod(this);
                    //form1.TopLevel = false;
                    //form1.Parent = this;
                    //form1.ApartadoId = Id;
                    //form1.totaldescactualiza = x;
                    //form1.MuestraApartado();
                    //form1.LlamaFactura();
                    //form1.Show();

                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el abono del apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConstruyeTicketApartado()
        {
            try
            {

                this.objTicketAbono.Apartado = 1;

                this.objTicketAbono.FacturaId = Id;

                this.objTicketAbono.ClienteNombre = this.Cliente;

                this.objTicketAbono.CajeroNombre = this.Vendedor;

                this.objTicketAbono.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());

                this.objTicketAbono.Hora = System.DateTime.Now.ToShortTimeString();

                this.objTicketAbono.Articulos.Clear();

                this.OpenConn();

                var bus = (from ae in db.ApartadoEncabezados
                           where ae.Id == Id
                           select ae).First();

                this.objTicketAbono.Impuesto = bus.Impuesto;

                this.objTicketAbono.Desc_Aplicado = bus.Descuento;

                this.objTicketAbono.TotalFactura = bus.Total;                

                var detalles = (from ad in db.ApartadoDetalles
                                join ae in db.ApartadoEncabezados on ad.ApartadoId equals ae.Id
                                join a in db.Articulo on ad.CodigoArticulo equals a.Codigo into ps from a in ps.DefaultIfEmpty()
                                where ad.ApartadoId == Id
                                select new {ad.Cantidad,a.Descripcion,ad.Precio });

                foreach (var item in detalles)
                {
                        decimal cantidad = Convert.ToDecimal(item.Cantidad);
                        decimal temp = (Convert.ToDecimal(item.Precio) * cantidad);

                        double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                        totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                        this.objTicketAbono.Articulos.Add(Convert.ToDecimal(item.Cantidad).ToString("F") + ";" + item.Descripcion + ";" + totaliva.ToString("F"));//cantidad//descripcion//totaliva//iv bit
                                                                            //cantidad                     //nombre articulo      
                }
                this.objTicketAbono.subtotal = bus.Subtotal;

                this.objTicketAbono.MontoAbono = Dec_MontoAbono;

                this.objTicketAbono.CancelaApartado = 1;

                this.objTicketAbono.NuevoSaldo = Dec_Saldo - Dec_MontoAbono;

                this.objTicketAbono.print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void IngresaEncabezadoYDetalle()
        {
            try
            {
                var bus = (from ae in db.ApartadoEncabezados
                           //join ad in db.ApartadoDetalles on ae.Id equals ad.ApartadoId
                           where ae.Id == Id
                           select ae).First();

                PuntoVentaDAL.FacturaEncabezado _newFactura = new PuntoVentaDAL.FacturaEncabezado();
                _newFactura.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                _newFactura.Hora = System.DateTime.Now.ToShortTimeString();
                _newFactura.Total = bus.Total;
                _newFactura.Descuento = bus.Descuento;
                _newFactura.Impuesto = bus.Impuesto;
                _newFactura.Subtotal = bus.Subtotal;
                _newFactura.Recibido = 0;
                _newFactura.Cambio = 0;
                _newFactura.ClienteId = bus.ClienteId;
                _newFactura.UsuarioId = bus.UsuarioId;
                //_newFactura.ProveedorId = 0;
                _newFactura.Activo = true;
                _newFactura.TipoPago = 2;

                db.FacturaEncabezado.InsertOnSubmit(_newFactura);

                db.SubmitChanges();

                var ultimafactura = (from x in db.FacturaEncabezado
                                     orderby x.Id descending
                                     select x).First();

                var detalles = (from ae in db.ApartadoEncabezados
                                join ad in db.ApartadoDetalles on ae.Id equals ad.ApartadoId
                                where ae.Id == Id
                                select ad);

                foreach (var item in detalles)
                {
                    PuntoVentaDAL.FacturaDetalle _newFacturaDetalle = new PuntoVentaDAL.FacturaDetalle();
                    _newFacturaDetalle.CodigoArticulo = item.CodigoArticulo;
                    _newFacturaDetalle.Cantidad = item.Cantidad;
                    _newFacturaDetalle.Precio = item.Precio;
                    _newFacturaDetalle.PorcDescuento = item.PorcDescuento;
                    _newFacturaDetalle.Descuento = item.Descuento;
                    _newFacturaDetalle.TotalIVA = item.TotalIVA;
                    _newFacturaDetalle.FacturaId = ultimafactura.Id;

                    db.FacturaDetalles.InsertOnSubmit(_newFacturaDetalle);

                    db.SubmitChanges();
                }

                //this.IngresaCajaDiaria(bus.UsuarioId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar generar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void IngresaCajaDiaria(int LoginUsuario)
        {
            try
            {
                this.OpenConn();


                var equipo = (from x in db.Equipos
                              where x.NombreEquipo == System.Environment.MachineName.ToString()
                              select x).First();

                var bus = (from cd in db.CajaDiarias
                           join e in db.Equipos on cd.EquipoId equals e.Id
                           //x.Fecha == Convert.ToDateTime(System.DateTime.Now.ToShortDateString()) &&
                           where e.NombreEquipo == System.Environment.MachineName.ToString()
                           && cd.Activo == true && cd.Visible == true
                           orderby cd.Id descending
                           select new { cd.Saldo, e.Id, cd.Hora }).First();


                //if (_TipoPago == 3)//credito credito
                //{
                    PuntoVentaDAL.CajaDiaria _NewCajaDiaria = new PuntoVentaDAL.CajaDiaria();

                    _NewCajaDiaria.MovimientoId = 2;//
                    _NewCajaDiaria.Descripcion = "Venta por pago de apartado número: " + Id;

                    var ultimafactura = (from x in db.FacturaEncabezado
                                         orderby x.Id descending
                                         select x).First();


                    _NewCajaDiaria.ComprobanteId = ultimafactura.Id;
                    //_NewCajaDiaria.FacturaId = 0;

                    _NewCajaDiaria.Monto = 0;
                    _NewCajaDiaria.Saldo = bus.Saldo;

                    _NewCajaDiaria.UsuarioId = LoginUsuario;
                    _NewCajaDiaria.Fecha = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    _NewCajaDiaria.Hora = System.DateTime.Now.ToShortTimeString();
                    _NewCajaDiaria.EquipoId = bus.Id;
                    _NewCajaDiaria.Activo = true;
                    _NewCajaDiaria.Visible = true;

                    db.CajaDiarias.InsertOnSubmit(_NewCajaDiaria);

                    db.SubmitChanges();
                //}
      //                ,[MovimientoId]
      //,[ComprobanteId]
      //,[Descripcion]
      //,[Monto]
      //,[Saldo]
      //,[UsuarioId]
      //,[Fecha]
      //,[Hora]
      //,[EquipoId]
      //,[AutorizadoPor]
      //,[Activo]
      //,[FacturaId]
      //,[Visible]

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void RealizoAbono()
        {
            try
            {
                //if (DescuentoCajaDiaria == 1)//efectivo
                //{
                //    this.objApartado.DescCajaDiaria = 1;
                //}
                //if (DescuentoCajaDiaria == 2)//tarjetacredito
                //{
                //    this.objApartado.DescCajaDiaria = 2;
                //}
                this.objApartado.AbonoId = Id;

                this.objApartado.MontoAbono = Convert.ToDecimal(this.txtAbono.Text);

                this.objApartado.Saldo = Convert.ToDecimal(txtSaldo.Text) - Convert.ToDecimal(this.txtAbono.Text);

                this.objApartado.IngresaAbonoIndividual(Login.UserId);

                MessageBox.Show("Abono realizado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar generar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RealizoFactura()
        {
            try
            {
                this.objApartado.AbonoId = Id;

                this.objApartado.EliminaApartadoCancelado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar generar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAbono_Leave(object sender, EventArgs e)
        {
            this.txtAbono.Text = Convert.ToDecimal(this.txtAbono.Text).ToString("##,#0.#0");

            if (Convert.ToDecimal(this.txtAbono.Text) > Convert.ToDecimal(this.txtTotalApartado.Text))
            {
                this.txtAbono.Text = this.txtTotalApartado.Text;
            }
        }

        private void txtAbono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal x = Convert.ToDecimal(this.txtAbono.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Digite números para el abono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ConstruyeTicket()
        {
            try
            {
                this.objTicketAbono.Articulos.Clear();

                this.OpenConn();

                var ultimafactura = (from x in db.FacturaEncabezado
                                     orderby x.Id descending
                                     select x).First();

                this.objTicketAbono.FacturaId = ultimafactura.Id;

                this.objTicketAbono.Impuesto = Convert.ToDecimal(ultimafactura.Impuesto);

                this.objTicketAbono.Desc_Aplicado = Convert.ToDecimal(ultimafactura.Descuento);

                this.objTicketAbono.TotalFactura = Convert.ToDecimal(ultimafactura.Total);

                this.objTicketAbono.subtotal = Convert.ToDecimal(ultimafactura.Subtotal);

                this.objTicketAbono.ClienteNombre = Cliente;

                this.objTicketAbono.CajeroNombre = Vendedor;

                this.objTicketAbono.Recibido = 0;

                this.objTicketAbono.Cambio = 0;

                var detalles = (from ae in db.FacturaEncabezado
                                join ad in db.FacturaDetalles on ae.Id equals ad.FacturaId
                                join a in db.Articulo on ad.CodigoArticulo equals a.Codigo
                                where ae.Id == ultimafactura.Id
                                select new {ad.Cantidad,ad.Precio,a.Descripcion});

                foreach (var item in detalles)
                {
                    decimal cantidad = (Convert.ToDecimal(item.Cantidad));

                    decimal temp = (Convert.ToDecimal(item.Precio) * cantidad);

                    double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                    totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                    this.objTicketAbono.Articulos.Add(Convert.ToDecimal(item.Cantidad).ToString("F") + ";" + item.Descripcion + ";" + totaliva.ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit
                }

                this.objTicketAbono.ObtieneInformacionGeneral();

                //this.objTicketAbono.TipoFactura = "Contado";
                this.objTicketAbono.TipoFactura = "";

                this.objTicketAbono.print();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
