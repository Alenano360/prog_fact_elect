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
    public partial class ComprasTicket : Form
    {
        public Int64 FacturaId = 0;

        public string ComprobanteId = string.Empty;

        public string ClienteNombre = string.Empty;

        public string CajeroNombre = string.Empty;
        
        Compras_Mod _owner1;

        PuntoVentaBL.Compras objCompras = new PuntoVentaBL.Compras();

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Ticket objTicket = new PuntoVentaBL.Ticket();

        public ComprasTicket(Compras_Mod owner)
        {
            InitializeComponent();

            _owner1=owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner1.Show();
        }

        private void ComprasTicket_Load(object sender, EventArgs e)
        {
            try
            {
                this.objCompras.ComprobanteId = FacturaId.ToString();

                this.objCompras.ObtieneDetalleFactura(this.dgvDatos);

                this.CajeroNombre = this.objCompras.CajeroNombre;

                this.ClienteNombre = this.objCompras.ClienteNombre;

                this.txtFecha.Text = this.objCompras.Fecha.ToString();

                this.txtHora.Text = this.objCompras.Hora.ToString();

                this.txtImpuesto.Text = this.objCompras.Impuesto.ToString();

                if (this.objCompras.PagoCheque==true)
                {
                    this.chkcheque.Checked = true;
                }

                this.txtDescuento.Text = Convert.ToDecimal(this.objCompras.Descuento.ToString()).ToString("F");

                this.txtTotal.Text = Convert.ToDecimal(this.objCompras.Total.ToString()).ToString("F");

                //this.txtRecibido.Text = Convert.ToDecimal(this.objCompras.Recibido.ToString()).ToString("F");

                //this.txtCambio.Text = Convert.ToDecimal(this.objCompras.Cambio.ToString()).ToString("F");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la factura seleccionada: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void ComprasTicket_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.objTicket.ImpresionCompra = 1;

                this.objTicket.Articulos.Clear();

                this.objTicket.FacturaIdString = this.ComprobanteId;

                this.objTicket.Fecha = Convert.ToDateTime(this.txtFecha.Text);

                this.objTicket.Hora = this.txtHora.Text;

                this.objTicket.ClienteNombre = this.ClienteNombre;

                this.objTicket.CajeroNombre = this.CajeroNombre;

                this.objTicket.Impuesto = Convert.ToDecimal(this.txtImpuesto.Text);
   
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
                    decimal temp = (Convert.ToDecimal(item.Cells[2].Value.ToString()) * cantidad);


                    this.objTicket.Articulos.Add(item.Cells[3].Value.ToString() + ";" + item.Cells[1].Value.ToString() + ";" + temp.ToString("#0.#0") + ";" + x);//cantidad//descripcion//totaliva//iv bit                    
                }
                this.objTicket.TotalFactura = Convert.ToDecimal(this.txtTotal.Text);

                this.objTicket.subtotal = Convert.ToDecimal(this.txtTotal.Text) - Convert.ToDecimal(this.txtImpuesto.Text);               

                this.objTicket.Desc_Aplicado = Convert.ToDecimal(this.txtDescuento.Text);

                this.objTicket.ObtieneInformacionGeneral();

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
