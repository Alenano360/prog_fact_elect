using PuntoVentaBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PuntoVentaPresentacion
{
    public partial class VentasTicket : Form
    {
        public int FacturaId = 0;

        public string ClienteNombre = string.Empty;

        public string CajeroNombre = string.Empty;

        public int TipoPago = 0;

        public decimal subtotal, impuesto = 0;

        Ventas_Mod _owner1;

        PuntoVentaBL.Ventas objVentas = new PuntoVentaBL.Ventas();

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Ticket objTicket = new PuntoVentaBL.Ticket();

        public VentasTicket(Ventas_Mod owner)
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
                    case 3:
                        {
                            this.chkCredito.Checked = true;
                        }
                        break;
                    default:
                        break;
                }
                this.objVentas.ComprobanteId = FacturaId;

                this.objVentas.ObtieneDetalleFactura(this.dgvDatos);

                this.CajeroNombre = this.objVentas.CajeroNombre;

                this.ClienteNombre = this.objVentas.ClienteNombre;

                this.txtFecha.Text = this.objVentas.Fecha.ToString();

                this.txtHora.Text = this.objVentas.Hora.ToString();

                this.impuesto = this.objVentas.Impuesto;

                this.subtotal = this.objVentas.Subtotal;

                this.txtDescuento.Text = Convert.ToDecimal(this.objVentas.Descuento.ToString()).ToString("F");

                this.txtTotal.Text = Convert.ToDecimal(this.objVentas.Total.ToString()).ToString("F");

                this.txtRecibido.Text = Convert.ToDecimal(this.objVentas.Recibido.ToString()).ToString("F");

                this.txtCambio.Text = Convert.ToDecimal(this.objVentas.Cambio.ToString()).ToString("F");

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
                //if (this.chkEfectivo.Checked == true)//efectivo
                //{
                //    this.objTicket.TipoFactura = "Contado";
                //}
                //else 
                
                this.objTicket.TipoFactura = "";

                //if (this.chkTarjetaCredito.Checked == true)//tcredito
                //{
                //    this.objTicket.TipoFactura = "T. Crédito";
                //}
                //else
                if (this.chkCredito.Checked == true )//credito cliente
                {
                    this.objTicket.TipoFactura = "Credito";
                }



                decimal MONTOIMPUESTO = 0;

                this.objTicket.Reimpresion = 1;

                this.objTicket.Articulos.Clear();

                List<PuntoVentaDAL.Tiquetes_Electronicos> Ticket = consulta.Buscar_TicketXlocal(this.FacturaId);
                
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
                    List<PuntoVentaDAL.Facturas_Electronicas> Factura = consulta.Buscar_FacturaXlocal(this.FacturaId);
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
                

                this.objTicket.Fecha = Convert.ToDateTime(this.txtFecha.Text);

                this.objTicket.Hora = this.txtHora.Text;

                this.objTicket.ClienteNombre = this.ClienteNombre;

                this.objTicket.CajeroNombre = this.CajeroNombre;

                if (this.impuesto!=0)
                {
                    this.objTicket.Impuesto = this.impuesto;
                }
                else
                {
                    foreach (DataGridViewRow item in this.dgvDatos.Rows)
                    {
                        this.objFacturar.TipoPrecio = 1;

                        this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                        //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV == 13)
                        {
                            MONTOIMPUESTO += this.objFacturar.MontoIV;
                        }
                    }
                    this.objTicket.Impuesto = MONTOIMPUESTO;
                }
                foreach (DataGridViewRow item in this.dgvDatos.Rows)
                {
                    this.objFacturar.TipoPrecio = 1;

                    this.objFacturar.ObtieneProducto((item.Cells[0].Value.ToString()));

                    string x = string.Empty;

                     //if (this.objFacturar.IV == true)
                        if (this.objFacturar.IV == 13)
                    {
                        x = "G";
                        //MONTOIMPUESTO += this.objFacturar.MontoIV;
                    }
                    else
                    {
                        x = "E";
                    }
                    decimal cantidad = (Convert.ToDecimal(item.Cells[3].Value.ToString()));
                    decimal temp = (Convert.ToDecimal(item.Cells[2].Value.ToString())*cantidad);

                    double totaliva = Math.Round(Convert.ToDouble(temp), 0, MidpointRounding.AwayFromZero);

                    totaliva = Convert.ToDouble(Math.Round(totaliva / 5.0) * 5);

                    this.objTicket.Articulos.Add(item.Cells[3].Value.ToString() + ";" + item.Cells[1].Value.ToString() + ";" + totaliva.ToString("F") + ";" + x);//cantidad//descripcion//totaliva//iv bit

                    this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                    this.objTicket.AltoPapel += 20;
                }

                if (this.subtotal!=0)
                {
                    this.objTicket.subtotal = this.subtotal;
                }
                else
                {
                    this.objTicket.subtotal = Convert.ToDecimal(this.txtTotal.Text) - MONTOIMPUESTO;
                }

                this.objTicket.Recibido = Convert.ToDecimal(this.txtRecibido.Text);

                this.objTicket.Cambio = Convert.ToDecimal(this.txtCambio.Text);

                this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuento.Text);

                //this.objTicket.Impuesto = MONTOIMPUESTO;

                this.objTicket.ObtieneInformacionGeneral();

                //this.objTicket.TipoFactura = "Contado";


                this.objTicket.print();

                this.objTicket.Offset = 40;      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar emitir la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
