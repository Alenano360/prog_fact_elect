using Restaurante_BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Restaurante_Presentacion
{
    public partial class Ventas_Ticket : Form
    {
        public int FacturaId = 0;

        public string ClienteNombre = string.Empty;

        public string CajeroNombre = string.Empty;

        public int UsuarioId = 0;

        public int MesaId = 0;

        public int TipoPago = 0;

        Reportes_Mod _owner1;

        Restaurante_BL.Ventas objVentas = new Restaurante_BL.Ventas();

        Restaurante_BL.Facturar objFacturar = new Restaurante_BL.Facturar();

        //Restaurante_BL.Cliente objcliente = new Restaurante_BL.Cliente();

        Restaurante_BL.Ticket objTicket = new Restaurante_BL.Ticket();

        public Ventas_Ticket(Reportes_Mod owner)
        {
            InitializeComponent();

            _owner1=owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner1.Show();
        }     

        private void VentasTicket_Load(object sender, EventArgs e)
        {
            try
            {
                switch (TipoPago)
                {
                    case 1:
                        {
                            this.chkTarjetaCredito.Checked=true;
                        }
                        break;
                    case 2:
                        {
                            this.chkEfectivo.Checked = true;
                        }
                        break;
                    default:
                        break;
                }
                this.objVentas.ComprobanteId = FacturaId;

                this.objVentas.TipoPago = TipoPago;

                this.objVentas.ObtieneDetalleFactura(this.dgvDatos);

                this.MesaId = this.objVentas.MesaId;

                this.UsuarioId = this.objVentas.UsuarioId;

                this.CajeroNombre = this.objVentas.CajeroNombre;

                this.ClienteNombre = this.objVentas.ClienteNombre;

                this.txtFecha.Text = this.objVentas.Fecha.ToString();

                this.txtHora.Text = this.objVentas.Hora.ToString();

                this.txtDescuento.Text = Convert.ToDecimal(this.objVentas.Descuento.ToString()).ToString("F");

                this.txtTotal.Text = Convert.ToDecimal(this.objVentas.Total.ToString()).ToString("F");

                this.txtRecibido.Text = Convert.ToDecimal(this.objVentas.Recibido.ToString()).ToString("F");

                this.txtCambio.Text = Convert.ToDecimal(this.objVentas.Cambio.ToString()).ToString("F");

                this.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la factura seleccionada: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VentasTicket_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Datos_Electronicos consulta = new Datos_Electronicos();
            try
            {
                this.objTicket.TipoFactura = "";

                this.objTicket.Articulos.Clear();

                List<Restaurante_DAL.Tiquetes_Electronicos> Ticket = consulta.Buscar_TicketXlocal(this.FacturaId);

                XmlDocument xml = new XmlDocument();

                if (Ticket.Count > 0)
                {
                    this.objTicket.FacturaId = Ticket[0].Numero_Factura_Local;
                    this.objTicket._TipoDocumento = "Tiquete Electrónico";

                    xml.LoadXml(Ticket[0].XML_Factura);
                    XmlNodeList Clave = xml.GetElementsByTagName("NumeroConsecutivo");
                    objTicket._Clave = Clave[0].InnerText;
                }
                else
                {
                    List<Restaurante_DAL.Facturas_Electronicas> Factura = consulta.Buscar_FacturaXlocal(this.FacturaId);
                    if (Factura.Count > 0)
                    {
                        this.objTicket.FacturaId = Factura[0].Numero_Factura_Local;
                        this.objTicket._TipoDocumento = "Factura Electrónica";

                        xml.LoadXml(Ticket[0].XML_Factura);
                        XmlNodeList Clave = xml.GetElementsByTagName("NumeroConsecutivo");
                        objTicket._Clave = Clave[0].InnerText;
                    }
                    else
                    {
                        this.objTicket.FacturaId = this.FacturaId;
                        objTicket._TipoDocumento = "";
                        objTicket._Clave = "";
                    }
                }


                this.objTicket.Accion = 2;

                this.objTicket.FacturaId = this.FacturaId;

                this.objTicket.Fecha = Convert.ToDateTime(this.txtFecha.Text);

                this.objTicket.Hora = this.txtHora.Text;

                this.objTicket.ClienteNombre = this.ClienteNombre;

                this.objTicket.CajeroNombre = this.CajeroNombre;

                this.objTicket.UserId = this.UsuarioId;

                this.objTicket.MesaId = this.MesaId;

                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    //this.objFacturar.ObtieneProducto(Convert.ToInt64(item.Cells[0].Value.ToString()));

                    string x = string.Empty;

                    x = "G";

                    this.objTicket.Articulos.Add(item.Cells[2].Value.ToString() + ";" + item.Cells[1].Value.ToString() + ";" + item.Cells[3].Value.ToString() + ";" + x);//cantidad//descripcion//totaliva//iv bit

                    this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objTicket.AltoPapel += 20;
                }
                this.objTicket.Recibido = Convert.ToDecimal(this.txtRecibido.Text);

                this.objTicket.Cambio = Convert.ToDecimal(this.txtCambio.Text);

                this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuento.Text);

                this.objTicket.ObtieneInformacionGeneral();

                if (TipoPago==1)
                {
                    this.objTicket.TipoFactura = "Tarjeta de crédito";
                }
                if (TipoPago == 2)
                {
                    this.objTicket.TipoFactura = "Contado";
                }

                this.objTicket.print();

                this.objTicket.Offset = 40;      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //    foreach (DataGridViewRow item in this.dgvDatos.Rows)
            //    {
            //        this.objFacturar.TipoPrecio = Convert.ToInt32(item.Cells[5].Value.ToString());

            //        this.objFacturar.ObtieneProducto(Convert.ToInt64(item.Cells[0].Value.ToString()));

            //        this.objFacturar.Articulos.Add(Convert.ToInt64(item.Cells[0].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[3].Value.ToString()) + "," + Convert.ToDecimal(item.Cells[4].Value.ToString()));

            //        string x = string.Empty;

            //        if (this.objFacturar.IV == true)
            //        {
            //            x = "G";
            //        }

            //        this.objTicket.Articulos.Add(item.Cells[3].Value.ToString() + "," + item.Cells[1].Value.ToString() + "," + item.Cells[4].Value.ToString() + "," + x);//cantidad//descripcion//totaliva//iv bit

            //        this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

            //        this.objTicket.AltoPapel += 20;
            //    }



            //}
            //this.objFacturar.Recibido = this.recibido;

            //this.objFacturar.Cambio = this.cambio;

            //this.objFacturar.IngresaEncabezadoFactura(Login.UserId);

            //this.objTicket.FacturaId = this.objFacturar.FacturaId;

            //this.objTicket.ClienteNombre = this.cmbCliente.Text;

            //this.objTicket.CajeroNombre = Login.LoginUsuarioFinal;

            //this.objTicket.Recibido = recibido;

            //this.objTicket.Cambio = cambio;

            //this.objTicket.ObtieneInformacionGeneral();

            //this.objTicket.TipoFactura = "Contado";

            //this.objTicket.print();

            //this.objTicket.Offset = 40;      
        }
    }
}
