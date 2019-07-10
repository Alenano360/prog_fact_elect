using Newtonsoft.Json.Linq;
using Restaurante_BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Presentacion
{
    public partial class Facturar : Form
    {
        Menu_Orden _owner;

        public Persona objReceptor;

        public int UserIdTemp = 0;

        public string UserNameTemp = string.Empty;

        public Restaurante_BL.Ticket objTicket = new Restaurante_BL.Ticket();

        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();
        
        public int MesaActual = 0;

        public decimal propina, descuento, recibido,recibido2, cambio, tarje, total = 0;

        public string nombrecliente = string.Empty;

        public int tipopago, tipopago2=0,clienteid = 0;

        public int serviciorestaurante = 0;

        static public int CantidadPago = 1;

        public Int64 tempFactura = 0;

        Restaurante_BL.Facturar_Orden objFactura = new Restaurante_BL.Facturar_Orden();

        Restaurante_DAL.BaseDatosDataContext db = new Restaurante_DAL.BaseDatosDataContext();

        //Restaurante_BL.POS objCajaRegistradora = new Restaurante_BL.POS();

        public Facturar(Menu_Orden owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Menu_Orden_Load(sender,e);
            _owner.CargoConsumoActual();
            _owner.Close();
            this.Close();
        }

        public void Facturar_Load()//para llamarlo desde f-
        {
            try
            {
                this.ResizeLoad();

                this.lblTitulo.Text = "Atendiendo a la mesa: " + MesaActual.ToString();

                this.CargoConsumoActualXPagar();

                this.CargoConsumoActualXPagarMostrar();

                this.SumaCompraXPagar();

                this.SumaXPagarSubFactura();

                this.ObtieneInfoInferior();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al generar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CierraFacturar()
        {
            
            _owner.Close();
        }

        public void LLamaCierraPanel()
        {
            try
            {
                _owner.CierraConsumoPanel();
            }
            catch (Exception)
            {
                
            }
        }

        public void Facturar_Load(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();

                this.lblTitulo.Text = "Atendiendo a la mesa: " + MesaActual.ToString();

                this.CargoConsumoActualXPagar();

                this.CargoConsumoActualXPagarMostrar();

                this.SumaCompraXPagar();

                this.SumaXPagarSubFactura();

                this.ObtieneInfoInferior();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al generar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CargoConsumoActualXPagar()
        {
            try
            {
                this.objFactura.MesaId = MesaActual;
                this.objFactura.ObtengoConsumoActualXPagar(this.dgvConsumoActualXPagar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener el consumo actual: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargoConsumoActualXPagarMostrar()
        {
            try
            {
                foreach (DataGridViewRow item in this.dgvConsumoActualXPagar.Rows)
                {
                    this.dgvConsumoActualXPagar.Columns[0].Visible = true;
                    this.dgvPagarMostrar.Columns[0].Visible = true;
                    this.dgvPagarMostrar.Rows.Add(
                        this.dgvConsumoActualXPagar.Rows[item.Index].Cells[0].Value.ToString(),
                        this.dgvConsumoActualXPagar.Rows[item.Index].Cells[1].Value.ToString(),
                        this.dgvConsumoActualXPagar.Rows[item.Index].Cells[2].Value.ToString(),
                        this.dgvConsumoActualXPagar.Rows[item.Index].Cells[3].Value.ToString(),
                        "Pagar");
                    this.dgvConsumoActualXPagar.Columns[0].Visible = false;
                    this.dgvPagarMostrar.Columns[0].Visible = false;

                    this.dgvConsumoActualXPagar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener el consumo actual: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvConsumoActualXPagar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgvConsumoActualXPagar.Columns["Pagar"].Index)
                {
                    this.dgvConsumoActualXPagar.Columns[0].Visible = true;
                    this.dgvConsumoActual.Columns[0].Visible = true;
                    this.dgvConsumoActual.Rows.Add(
                        this.dgvConsumoActualXPagar.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        this.dgvConsumoActualXPagar.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        this.dgvConsumoActualXPagar.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        this.dgvConsumoActualXPagar.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        "Pagar");
                    this.dgvConsumoActualXPagar.Rows.RemoveAt(this.dgvConsumoActualXPagar.CurrentRow.Index);
                    this.dgvConsumoActualXPagar.Columns[0].Visible = false;
                    this.dgvConsumoActual.Columns[0].Visible = false;
                    this.SumaCompraXPagar();
                    this.SumaXPagarSubFactura();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        //Suma en cuenta por pagar de lo consumido
        private void SumaCompraXPagar()
        {
            try
            {
                decimal total = 0;

                foreach (DataGridViewRow item in dgvPagarMostrar.Rows)
                {
                    total = total + Convert.ToDecimal((string)(item.Cells["PrecioMostrar"]).Value.ToString());
                }
                this.lblTotalXPagar.Text = string.Empty;

                this.lblTotalXPagar.Text = "Total: " + total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al sumar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Suma en factura por pagar de lo consumido
        private void SumaXPagarSubFactura()
        {
            try
            {
                decimal total = 0;

                foreach (DataGridViewRow item in dgvConsumoActual.Rows)
                {
                    total = total + Convert.ToDecimal((string)(item.Cells["PrecioFactura"]).Value.ToString());
                }
                this.lblMontoPagar.Text = string.Empty;

                this.lblMontoPagar.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al sumar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Devuelve a cuenta por pagar lo que se retire de la factura
        private void dgvConsumoActual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int control = 0;
                decimal precio = 0;

                if (e.ColumnIndex == this.dgvConsumoActual.Columns["Eliminar"].Index)
                {                    
                    this.dgvPagarMostrar.Columns[0].Visible = true;
                    this.dgvConsumoActual.Columns[0].Visible = true;

                    foreach (DataGridViewRow item in this.dgvPagarMostrar.Rows)
                    {
                        if (item.Cells[0].Value.ToString() == this.dgvConsumoActual.Rows[e.RowIndex].Cells[0].Value.ToString())
                        {
                            control = 1;
                            precio = Convert.ToDecimal((Convert.ToDecimal(item.Cells[3].Value.ToString())) / (Convert.ToDecimal(item.Cells[1].Value.ToString())));

                            item.Cells[1].Value = Convert.ToInt32(item.Cells[1].Value) + 1;
                            item.Cells[3].Value = Convert.ToInt32(item.Cells[1].Value) * precio;
                            //cells 1 es cantidad y cells 3 es precio
                        }
                    }

                    if (control == 0)
                    {
                        //this.dgvPagarMostrar.Rows.Add(
                        //    this.dgvConsumoActual.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        //    this.dgvConsumoActual.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        //    this.dgvConsumoActual.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        //    this.dgvConsumoActual.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        //    "Pagar");

                        precio = Convert.ToDecimal(this.dgvConsumoActual.Rows[e.RowIndex].Cells[3].Value.ToString()) / Convert.ToInt32(this.dgvConsumoActual.Rows[e.RowIndex].Cells[1].Value.ToString());

                        this.dgvPagarMostrar.Rows.Add(
                            this.dgvConsumoActual.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            1,
                            this.dgvConsumoActual.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            precio.ToString("F"),
                            "Pagar");  
                    }

                    this.dgvConsumoActual.Rows[e.RowIndex].Cells[1].Value = Convert.ToInt32(this.dgvConsumoActual.Rows[e.RowIndex].Cells[1].Value) - 1;
                    this.dgvConsumoActual.Rows[e.RowIndex].Cells[3].Value = Convert.ToDecimal(this.dgvConsumoActual.Rows[e.RowIndex].Cells[3].Value) - precio;


                    this.dgvPagarMostrar.Columns[0].Visible = false;
                    this.dgvConsumoActual.Columns[0].Visible = false;
                    //this.dgvConsumoActual.Rows.RemoveAt(this.dgvConsumoActual.CurrentRow.Index);
                    this.SumaCompraXPagar();
                    this.SumaXPagarSubFactura();

                    if (this.dgvConsumoActual.Rows[e.RowIndex].Cells[1].Value.ToString() == "0")
                    {
                        this.dgvConsumoActual.Rows.RemoveAt(this.dgvConsumoActual.CurrentRow.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        //Envia individualmente todos los datos de lo consumido a Factura por pagar
        private void dgvPagarMostrar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int control = 0;
                decimal precio = 0;


                if (e.ColumnIndex == this.dgvPagarMostrar.Columns["PagarMostrar"].Index)
                {
                    this.dgvPagarMostrar.Columns[0].Visible = true;
                    this.dgvConsumoActual.Columns[0].Visible = true;
                    foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                    {
                        if (item.Cells[0].Value.ToString()==this.dgvPagarMostrar.Rows[e.RowIndex].Cells[0].Value.ToString())
                        {
                            control = 1;
                            precio = Convert.ToDecimal((Convert.ToDecimal(item.Cells[3].Value.ToString())) / (Convert.ToDecimal(item.Cells[1].Value.ToString())));

                            item.Cells[1].Value = Convert.ToInt32(item.Cells[1].Value) + 1;
                            item.Cells[3].Value = Convert.ToInt32(item.Cells[1].Value) * precio;
                            //cells 1 es cantidad y cells 3 es precio
                        }
                    }

                    if (control==0)
                    {
                        //this.dgvConsumoActual.Rows.Add(
                        //    this.dgvPagarMostrar.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        //    this.dgvPagarMostrar.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        //    this.dgvPagarMostrar.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        //    this.dgvPagarMostrar.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        //    "Eliminar");                        

                        precio=Convert.ToDecimal(this.dgvPagarMostrar.Rows[e.RowIndex].Cells[3].Value.ToString()) / Convert.ToInt32(this.dgvPagarMostrar.Rows[e.RowIndex].Cells[1].Value.ToString());

                        this.dgvConsumoActual.Rows.Add(
                            this.dgvPagarMostrar.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            1,
                            this.dgvPagarMostrar.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            precio.ToString("F"),
                            "Eliminar");  
                    }

                    //this.dgvPagarMostrar.Rows.RemoveAt(this.dgvPagarMostrar.CurrentRow.Index);
                    this.dgvPagarMostrar.Rows[e.RowIndex].Cells[1].Value = Convert.ToInt32(this.dgvPagarMostrar.Rows[e.RowIndex].Cells[1].Value) - 1;
                    this.dgvPagarMostrar.Rows[e.RowIndex].Cells[3].Value = Convert.ToDecimal(this.dgvPagarMostrar.Rows[e.RowIndex].Cells[3].Value) - precio;



                    this.dgvPagarMostrar.Columns[0].Visible = false;
                    this.dgvConsumoActual.Columns[0].Visible = false;
                    this.SumaCompraXPagar();
                    this.SumaXPagarSubFactura();

                    if (this.dgvPagarMostrar.Rows[e.RowIndex].Cells[1].Value.ToString()=="0")
                    {
                        this.dgvPagarMostrar.Rows.RemoveAt(this.dgvPagarMostrar.CurrentRow.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        //Envia todos los datos de lo consumido a Factura por pagar
        private void btnCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvPagarMostrar.Columns[0].Visible = true;
                this.dgvConsumoActual.Columns[0].Visible = true;
                foreach (DataGridViewRow item in this.dgvPagarMostrar.Rows)
                {
                    this.dgvConsumoActual.Rows.Add(
                        this.dgvPagarMostrar.Rows[item.Index].Cells[0].Value.ToString(),
                        this.dgvPagarMostrar.Rows[item.Index].Cells[1].Value.ToString(),
                        this.dgvPagarMostrar.Rows[item.Index].Cells[2].Value.ToString(),
                        this.dgvPagarMostrar.Rows[item.Index].Cells[3].Value.ToString(),
                        "Eliminar");                   
                }
                this.dgvPagarMostrar.Columns[0].Visible = false;
                this.dgvConsumoActual.Columns[0].Visible = false;
                this.dgvPagarMostrar.Rows.Clear();

                this.SumaCompraXPagar();
                this.SumaXPagarSubFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar facturar el consumo actual: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiaGrid()
        {
            this.dgvConsumoActual.Rows.Clear();
        }

        public void ConstruyeTicket()
        {
            try
            {
                //if (MesaActual >= 17)
                //{
                //    this.objTicket.Articulos.Clear();

                //    if (this.serviciorestaurante == 0)
                //    {
                //        foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                //        {
                //            this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[1].Value.ToString()).ToString("F") + ";" + item.Cells[2].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                //            this.objTicket.TotalFactura = Convert.ToDecimal(total);

                //            this.objTicket.AltoPapel += 20;
                //        }
                //    }
                //    else
                //    {
                //        this.objTicket.Articulos.Add("1.00" + ";" + "Servicio Rest." + ";" + Convert.ToDecimal(total).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                //        this.objTicket.TotalFactura = Convert.ToDecimal(total);
                //    }

                //    if (this.nombrecliente.Length > 0)
                //    {
                //        this.objTicket.ClienteNombre = this.nombrecliente;
                //    }
                //    else
                //    {
                //        this.objTicket.ClienteNombre = "";
                //    }

                //    this.objTicket.FacturaId = tempFactura;

                //    this.objTicket.CajeroNombre = UserNameTemp;

                //    this.objTicket.UserId = UserIdTemp;

                //    this.objTicket.MesaId = MesaActual;

                //    this.objTicket.Recibido = recibido;

                //    this.objTicket.Cambio = cambio;

                //    this.objTicket.Desc_Aplicado = descuento;

                //    this.objTicket.ObtieneInformacionGeneral();
                //    this.objTicket.Impuesto = Impuesto;
                //    this.objTicket.ImpServicio = ImpServicio;
                //    this.objTicket.Subtotal = Subtotal;

                //    if (this.tipopago == 2)
                //    {
                //        this.objTicket.TipoFactura = "Contado";
                //    }
                //    if (this.tipopago == 1)
                //    {
                //        this.objTicket.TipoFactura = "Tarjeta de crédito";
                //    }

                //    this.objTicket.Accion = 2;

                //    this.objTicket.Propina = Convert.ToDecimal(this.propina);

                //    this.objTicket.print();

                //    this.objTicket.Offset = 40;
                //}
                //else 
                //{
                    this.objTicket.Articulos.Clear();

                if (this.serviciorestaurante == 0)
                {
                    foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                    {
                        this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[1].Value.ToString()).ToString("F") + ";" + item.Cells[2].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.TotalFactura = Convert.ToDecimal(total);//1397? revisar

                        this.objTicket.AltoPapel += 20;
                    }
                }
                else
                {
                    this.objTicket.Articulos.Add("1.00" + ";" + "Servicio Rest." + ";" + Convert.ToDecimal(total).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                    this.objTicket.TotalFactura = Convert.ToDecimal(total);
                }

                if (this.nombrecliente.Length > 0)
                {
                    this.objTicket.ClienteNombre = this.nombrecliente;
                }
                else
                {
                    this.objTicket.ClienteNombre = "";
                }

                this.objTicket.FacturaId = tempFactura;

                this.objTicket.CajeroNombre = UserNameTemp;

                this.objTicket.UserId = UserIdTemp;

                this.objTicket.MesaId = MesaActual;

                this.objTicket.Recibido = recibido;

                this.objTicket.Cambio = cambio;

                this.objTicket.Desc_Aplicado = descuento;

                this.objTicket.ObtieneInformacionGeneral();

                if (this.tipopago == 2)
                {
                    this.objTicket.TipoFactura = "Contado";
                }
                if (this.tipopago == 1)
                {
                    this.objTicket.TipoFactura = "Tarjeta de crédito";
                }

                this.objTicket.Accion = 8;

                this.objTicket.Propina = Convert.ToDecimal(this.propina);
                this.objTicket.Impuesto = Impuesto;
                this.objTicket.ImpServicio = ImpServicio;
                this.objTicket.Subtotal = Subtotal;
                

                this.objTicket.print();

                this.objTicket.Offset = 40;
            //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConstruyeTicketPrefactura()
        {
            

            try
            {
                //if (MesaActual >= 17)
                //{
                //    this.objTicket.Articulos.Clear();

                //    if (this.serviciorestaurante == 0)
                //    {
                //        foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                //        {
                //            this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[1].Value.ToString()).ToString("F") + ";" + item.Cells[2].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                //            this.objTicket.TotalFactura = Convert.ToDecimal(total);

                //            this.objTicket.AltoPapel += 20;
                //        }
                //    }
                //    else
                //    {
                //        this.objTicket.Articulos.Add("1.00" + ";" + "Servicio Rest." + ";" + Convert.ToDecimal(total).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                //        this.objTicket.TotalFactura = Convert.ToDecimal(total);
                //    }

                //    if (this.nombrecliente.Length > 0)
                //    {
                //        this.objTicket.ClienteNombre = this.nombrecliente;
                //    }
                //    else
                //    {
                //        this.objTicket.ClienteNombre = "";
                //    }

                //    this.objTicket.CajeroNombre = UserNameTemp;

                //    this.objTicket.UserId = UserIdTemp;

                //    this.objTicket.MesaId = MesaActual;

                //    this.objTicket.Desc_Aplicado = descuento;

                //    this.objTicket.ObtieneInformacionGeneral();

                //    this.objTicket.Accion = 1;//prefactura

                //    this.objTicket.print();

                //    this.objTicket.Offset = 40;





                //}
                //else
                //{
                    this.objTicket.Articulos.Clear();

                    if (this.serviciorestaurante == 0)
                    {
                        foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                        {
                            this.objTicket.Articulos.Add(Convert.ToDecimal(item.Cells[1].Value.ToString()).ToString("F") + ";" + item.Cells[2].Value.ToString() + ";" + Convert.ToDecimal(item.Cells[3].Value.ToString()).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                            this.objTicket.TotalFactura = Convert.ToDecimal(total);

                            this.objTicket.AltoPapel += 20;
                        }
                    }
                    else
                    {
                        this.objTicket.Articulos.Add("1.00" + ";" + "Servicio Rest." + ";" + Convert.ToDecimal(total).ToString("F") + ";" + "G");//cantidad//descripcion//totaliva//iv bit

                        this.objTicket.TotalFactura = Convert.ToDecimal(total);
                    }

                    if (this.nombrecliente.Length > 0)
                    {
                        this.objTicket.ClienteNombre = this.nombrecliente;
                    }
                    else
                    {
                        this.objTicket.ClienteNombre = "";
                    }

                    this.objTicket.CajeroNombre = UserNameTemp;

                    this.objTicket.UserId = UserIdTemp;

                    this.objTicket.MesaId = MesaActual;

                    this.objTicket.Desc_Aplicado = descuento;

                    this.objTicket.ObtieneInformacionGeneral();

                    this.objTicket.Accion = 7;//prefactura

                    this.objTicket.print();

                    this.objTicket.Offset = 40;
                }
            //}
            
            

            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir el ticket: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ConstruyeFactura()
        {
            try
            {
                this.objFactura.Articulos.Clear();

                foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                {
                    this.objFactura.Articulos.Add(item.Cells[0].Value.ToString() + ";" + item.Cells[1].Value.ToString() + ";" + item.Cells[3].Value.ToString());//codigo cantidad precio
                }
       
                this.objFactura.Total = Convert.ToDecimal(total);
                this.objFactura.Descuento = Convert.ToDecimal(descuento);
                this.objFactura.Recibido = Convert.ToDecimal(recibido);
                this.objFactura.Recibido2 = Convert.ToDecimal(recibido2);
                this.objFactura.Cambio = Convert.ToDecimal(cambio);
                this.objFactura.ClienteId = clienteid;
                //1-TarjetaCredito 2-Efectivo 3-CreditoCredito
                this.objFactura.TipoPago = Convert.ToInt32(tipopago);
                this.objFactura.TipoPago2 = Convert.ToInt32(tipopago2);//en el caso de tarjeta
                this.objFactura.UsuarioId = UserIdTemp;
                this.objFactura.Propina = Convert.ToDecimal(propina);
               
                
                this.objFactura.IngresoFacturaEncabezado();

                tempFactura = this.objFactura.Factura;

                this.objFactura.MesaId = MesaActual;

                this.dgvConsumoActual.Columns[0].Visible = true;

                foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                {
                    this.objFactura.CodigoArticulo = Convert.ToInt32(this.dgvConsumoActual.Rows[item.Index].Cells[0].Value.ToString());

                    this.objFactura.Cantidad = Convert.ToInt32(this.dgvConsumoActual.Rows[item.Index].Cells[1].Value.ToString());

                    this.objFactura.EliminoTemporalConsumo();
                }

                this.dgvConsumoActual.Columns[0].Visible = false;

                //this.dgvConsumoActual.Rows.Clear();

                this.lblMontoPagar.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar facturar el consumo actual: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reporte_Hacienda(bool Factura_Electronica, bool ServiceLine)
        {
            Persona loader = new Persona();
            Persona Emisor = loader.Cargar_Emmisor();
            if (Emisor != null)
            {
                if (Factura_Electronica)
                {
                    Reporte_Factura(Emisor, ServiceLine);
                }
                else
                {
                    Reporte_Tiquet(Emisor, ServiceLine);
                }
            }
            else
            {
                MessageBox.Show("Emisor no disponible, imposible enviar el reporte a hacienda sin emisor, favor agregar una persona emisora.");
            }
        }



        public void Reporte_Factura(Persona Emisor, bool ServiceLine)
        {
            Datos_Electronicos Reporte_Elect = new Datos_Electronicos();
            string NumFact = Reporte_Elect.Get_Consecutivo_Factura().ToString();

            try
            {
                string factura = Generar_Reporte_XML("01", NumFact, Emisor, ServiceLine);
                MessageBox.Show(factura);

                //Datos Para guardar la Factura.
                Reporte_Elect.Fecha = DateTime.Today;
                Reporte_Elect.id_Factura_Local = (int) tempFactura;
                Reporte_Elect.Enviada = true;
                Reporte_Elect.Cancelada = false;
                Reporte_Elect.Monto_Factura = (int)Double.Parse(total.ToString().Replace(",", ""));
                Reporte_Elect.Factura = factura;
                

                if (Reporte_Elect.Guardar_Factura())
                {
                    try
                    {
                        ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/receipts", "POST", factura, _owner._owner.user, _owner._owner.env);
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

        public void Reporte_Tiquet(Persona Emisor, bool ServiceLine)
        {
            Datos_Electronicos Reporte_Elect = new Datos_Electronicos();
            string NumFact = Reporte_Elect.Get_Consecutivo_Tiquete().ToString();

            try
            {

                string factura = Generar_Reporte_XML("04", NumFact, Emisor, ServiceLine);
                MessageBox.Show(factura);
                //Datos Para guardar la Factura.
                Reporte_Elect.Fecha = DateTime.Today;
                Reporte_Elect.id_Factura_Local = (int)tempFactura;
                Reporte_Elect.Enviada = true;
                Reporte_Elect.Cancelada = false;
                Reporte_Elect.Monto_Factura = (int)Double.Parse(total.ToString().Replace(",", ""));
                Reporte_Elect.Factura = factura;
                

                if (Reporte_Elect.Guardar_Tiquete())
                {
                    try
                    {
                        ServerRequest request = new ServerRequest("https://dm-factura-electronica.herokuapp.com/receipts", "POST", factura, _owner._owner.user, _owner._owner.env);
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

        public string Generar_Reporte_XML(String Tipo_Comprobante, String NumFact, Persona Emisor, bool serviceChecked)
        {
            XML xml = new XML();
            DetalleServicio servicio = new DetalleServicio();
            String NumCon = "";
            String Clave = "";
            try
            {
                //Crear Numero Consucutivo

                string Sucursales = _owner._owner.objInformacionGeneral._Numero_Sucursal;
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

                string ced = Completar_Cero(_owner._owner.objInformacionGeneral._Numero_Cedula, 12); 
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
                String Tipo_Pago = "01"; // Buscar forma de pago  this.FormaPagoId.ToString()

                ResumenFactura resumen = new ResumenFactura();
                double mercancias_gravadas = 0;
                double mercancias_excentas = 0;
                double TotalVenta = 0;
                double TotalDescuento = 0;
                double TotalImpuesto = 0;
               
                foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                {

                    LineaDetalle Linea = new LineaDetalle(); // Linea del xml

                    Linea.NumeroLinea = numero_linea.ToString(); // num linea
                    Linea.Cod_Tipo = "01"; // Cod linea
                    Linea.Cod_Numero = item.Cells[0].Value.ToString();//Codigo
                    Linea.Detalle = item.Cells[2].Value.ToString(); //Detalle 

                    
                    double precio_uni_imp = Convert.ToDouble(item.Cells[3].Value) ;

                    
                    double precio_uni = Math.Round((precio_uni_imp / 1.13) , 2);


                    double impuesto = precio_uni_imp - precio_uni;
                    

                    int cantidad = Convert.ToInt32(item.Cells[1].Value);
                    

                    double monto_total = (precio_uni * cantidad) ;

                    double descuento = Convert.ToDouble(this.descuento);
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

                    Linea.MontoTotalLinea = (monto_total + impuesto).ToString(); //Total IVA
                    Linea.UnidadMedida = "Unid";
                    numero_linea++;
                    servicio.LineasDetalle.Add(Linea);
                }

                /*
                 * 
                 * add service line here
                 * 
                 * 
                 * */

                if (serviceChecked)
                {
                    LineaDetalle Linea = new LineaDetalle(); // Linea del xml
                    Linea.NumeroLinea = numero_linea.ToString(); // num linea
                    Linea.Cod_Tipo = "01"; // Cod linea
                    Linea.Cod_Numero = "999999999";//Codigo
                    Linea.Detalle = "Servicio" ; //Detalle 
                    double precio_uni = mercancias_gravadas * 0.1;
                    int cantidad = 1;
                    double impuesto = (precio_uni * 0.0 );   //Convert.ToDouble(item.Cells[8].Value);
                    double monto_total = (precio_uni * cantidad);
                    double subtotal = monto_total ;
                    TotalVenta += monto_total;
                    mercancias_excentas += monto_total;
                    Linea.PrecioUnitario = precio_uni.ToString();//PrecioUnitario  //.Replace(",", ".")
                    Linea.Cantidad = cantidad.ToString();//Cantidad
                    Linea.MontoTotal = monto_total.ToString(); //Monto Total
                    Linea.Descuento = descuento.ToString();
                    Linea.Subtotal = subtotal.ToString();
                    TotalImpuesto += impuesto;
                    Linea.Impuesto = impuesto.ToString();
                    Linea.MontoTotalLinea = monto_total.ToString(); //Total IVA
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

        public string Completar_Cero(String Num_org, int Largo)
        {
            string Num_Modf = Num_org;
            for (int i = 0; Num_Modf.Length < Largo; i++)
            {
                Num_Modf = "0" + Num_Modf;
            }
            return Num_Modf;
        }




        public static decimal Impuesto;
        public static decimal ImpServicio;
        public static decimal Subtotal;
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.dgvConsumoActual.RowCount==0)
                {
                    return;
                }
                //if (MesaActual >= 17)
                //{
                //    Facturacion_Pago pago = new Facturacion_Pago(this);
                //    pago.TopLevel = false;
                //    pago.Parent = this;
                //   // Subtotal = Convert.ToDecimal(this.lblMontoPagar.Text);
                //    Subtotal = Convert.ToDecimal(this.lblMontoPagar.Text) / 1.13m;
                //    Subtotal = Math.Round(Subtotal, 2);
                //   // Impuesto = ((Convert.ToDecimal(this.lblMontoPagar.Text)) * 113 / 100) - Convert.ToDecimal(this.lblMontoPagar.Text);
                //    Impuesto = (((Convert.ToDecimal(this.lblMontoPagar.Text))) / 1.13m) * 0.13m;
                //    Impuesto = Math.Round(Impuesto, 2);
                //  //  pago.Total = ((Convert.ToDecimal(this.lblMontoPagar.Text)) );

                //    pago.Total = ((Convert.ToDecimal(Subtotal))+(Convert.ToDecimal(Impuesto)));
                   
                //    pago.Show();
                //}
                //else
                //{
                    Facturacion_Pago pago = new Facturacion_Pago(this);
                    pago.TopLevel = false;
                    pago.Parent = this;
                    Subtotal = Convert.ToDecimal(this.lblMontoPagar.Text)/1.13m;
                    Subtotal=Math.Round(Subtotal, 2);
                    

                    //Impuesto = ((Convert.ToDecimal(pago.Total))) - Convert.ToDecimal(this.lblMontoPagar.Text);
                    Impuesto = (((Convert.ToDecimal(this.lblMontoPagar.Text))) / 1.13m) * 0.13m;
                    Impuesto = Math.Round(Impuesto, 2);
                    
        
                    // ImpServicio = ((Convert.ToDecimal(pago.Total))) - Convert.ToDecimal(aux);
                   
                  //  ImpServicio = ((Convert.ToDecimal(this.lblMontoPagar.Text))) * Convert.ToDecimal(0.1);
                    ImpServicio = (Subtotal * 10) / 100;
                    ImpServicio = Math.Round(ImpServicio, 2);

             
                   // pago.Total = (((Convert.ToDecimal(this.lblMontoPagar.Text))*110)/100)*113/100;
                   // pago.Total = (((Convert.ToDecimal(this.lblMontoPagar.Text)) )*1.13m);
                   //// MessageBox.Show("IBLMOnto es "+this.lblMontoPagar.Text+"  El pago total es "+pago.Total);
                   // decimal aux = pago.Total;  //(((Convert.ToDecimal(this.lblMontoPagar.Text))) * (130 / 100));
                   // aux=Math.Round(aux, 2);
                    //pago.Total = (((Convert.ToDecimal(pago.Total))) * 1.10m);
                    //pago.Total = Math.Round(pago.Total, 2);

                    pago.Total = (Convert.ToDecimal(Subtotal)) + (Convert.ToDecimal(Impuesto)) + (Convert.ToDecimal(ImpServicio));
                    pago.Total = Math.Round(pago.Total, 2);
                
                    pago.Show();
                //}

                //this.objFactura.MesaId = MesaActual;

                //this.objFactura.Total = Convert.ToDecimal(this.lblTotalPagar.Text);

                //this.objFactura.UsuarioId = Login.UserId;

                //this.objFactura.IngresoFacturaEncabezado();

                //this.dgvConsumoActual.Columns[0].Visible = true;

                //foreach (DataGridViewRow item in this.dgvConsumoActual.Rows)
                //{
                //    this.objFactura.CodigoArticulo = Convert.ToInt32(this.dgvConsumoActual.Rows[item.Index].Cells[0].Value.ToString());

                //    this.objFactura.Precio = Convert.ToDecimal(this.dgvConsumoActual.Rows[item.Index].Cells[3].Value.ToString());

                //    this.objFactura.Cantidad = Convert.ToInt32(this.dgvConsumoActual.Rows[item.Index].Cells[1].Value.ToString());

                //    this.objFactura.IngresoFacturaDetalle();

                //    this.objFactura.EliminoTemporalConsumo();
                //}

                //this.dgvConsumoActual.Columns[0].Visible = false;

                //this.dgvConsumoActual.Rows.Clear();

                //this.dgvPagarMostrar.Rows.Clear();

                //this.CargoConsumoActualXPagar();

                //this.CargoConsumoActualXPagarMostrar();

                //this.SumaCompraXPagar();

                //this.SumaXPagarSubFactura();

                ////this.objCajaRegistradora.OpenCashDrawer();//abre la caja registradora

                //if (this.dgvPagarMostrar.Rows.Count==0)
                //{                    
                //    this.Close();
                //}




            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar facturar el consumo actual: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar regresar a la pantalla principal: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Facturar_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {

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

    }
}
