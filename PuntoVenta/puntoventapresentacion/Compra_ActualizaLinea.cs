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
    public partial class Compra_ActualizaLinea : Form
    {
        public string Codigo = string.Empty;
        public string Cantidad = string.Empty;
        public string ListaPrecios = string.Empty;
        public string Descripcion = string.Empty;
        public int unidadmedida = 0;
        public int TipoFactura = 0;
        public string precio, porcdesc, descmonto,total = string.Empty;

        string iva1 = string.Empty;

        public int accion = 0;

        public decimal iva = 0;

        PuntoVentaBL.Facturar objFacturar = new PuntoVentaBL.Facturar();

        PuntoVentaDAL.CONEXIONDataContext db = new PuntoVentaDAL.CONEXIONDataContext();

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

        Compras_Mantenimiento _owner;

        public Compra_ActualizaLinea(Compras_Mantenimiento owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }
     
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this._owner.Facturacion_Mod_Load();
            this._owner.Show();
        }

        private void Compra_ActualizaLinea_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.OpenConn();

                var bus = (from x in db.InformacionGeneral
                           select x);

                iva = (Convert.ToDecimal(bus.First().IVA) / 100);

                iva1 = "1." + Convert.ToDecimal(bus.First().IVA).ToString("##");

                this.txtCodigo.Text = Codigo;

                this.txtDescripcion.Text = Descripcion;

                this.txtCantidadDecimal.Text = Convert.ToDecimal(Cantidad).ToString("F");

                this.cmbListaPrecios.Text = ListaPrecios;

                this.txtSubtotal.Text = Convert.ToDecimal(precio).ToString("#0,#.#0");

                this.txtPorcDescuento.Text = Convert.ToDecimal(this.porcdesc).ToString("#0,#.#0");

                this.txtDesc.Text = Convert.ToDecimal(this.descmonto).ToString("#0,#.#0");

                this.txtTotal.Text = Convert.ToDecimal(this.total).ToString("#0,#.#0");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CalculaTotal()
        {
            try
            {
                decimal porc = Convert.ToDecimal(this.txtPorcDescuento.Text) / 100;
                decimal cantidad = Convert.ToDecimal(this.txtCantidadDecimal.Text);

                this.txtSubtotal.Text = (Convert.ToDecimal(precio)*cantidad).ToString("#0,#.#0");

                this.txtDesc.Text = (Convert.ToDecimal(precio) * porc * cantidad).ToString("#0,#.#0");

                this.txtTotal.Text = (Convert.ToDecimal(this.txtSubtotal.Text) - Convert.ToDecimal(this.txtDesc.Text)).ToString("#0,#.#0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPorcDescuento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.CalculaTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Compra_ActualizaLinea_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void txtCantidadDecimal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    decimal x = Convert.ToDecimal(this.txtCantidadDecimal.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Digite numeros para la cantidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.CalculaTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                if (accion == 0)
                {
                    _owner.CodigoS = this.txtCodigo.Text;

                    _owner.CantidadS = Convert.ToDecimal(this.txtCantidadDecimal.Text).ToString("F");

                    _owner.ListaPreciosS = this.cmbListaPrecios.Text;

                    _owner.porcdescactualiza = Convert.ToDecimal(this.txtPorcDescuento.Text);

                    _owner.descuentodescactualiza = Convert.ToDecimal(this.txtDesc.Text);

                    _owner.totalactualiza = Convert.ToDecimal(this.txtTotal.Text);

                    _owner.ModificaArticulo();

                this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar actualizar el artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
