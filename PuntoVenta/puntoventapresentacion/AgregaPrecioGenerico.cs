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
    public partial class AgregaPrecioGenerico : Form
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        Facturacion_Mod _owner;
        public static int validar;

        public string Codigo = string.Empty;
       

        public AgregaPrecioGenerico(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public static decimal precio;


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void AgregaPrecioGenerico_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ActiveControl = this.txtPrecio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el precio al artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregaPrecioGenerico_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _owner.tempvals = 1;
            AgregaPrecioGenerico.validar = 0;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPrecio.Text.Length == 0)
                {
                    MessageBox.Show("Por favor digite el precio del artículo!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //modifico el precio en la bd primero
                //luego inserto en el datagrid con el precio correcto
                this.OpenConn();
              //  int validar=0;
                var bus = (from x in db.Articulo
                           where x.Activo == true && x.Codigo == Codigo
                           select x).First();


              //  Facturacion_Mod.veri[Facturacion_Mod.indice].estado = 1;
               // Facturacion_Mod.veri[Facturacion_Mod.indice].codigo = Codigo;

                AgregaPrecioGenerico.precio = Convert.ToDecimal(txtPrecio.Text);
                bus.Precio = Convert.ToDecimal(this.txtPrecio.Text);
                bus.PrecioIVU = Convert.ToDecimal(this.txtPrecio.Text);
                bus.Precio2 = Convert.ToDecimal(this.txtPrecio.Text);
                bus.Precio2IVU = Convert.ToDecimal(this.txtPrecio.Text);

                db.SubmitChanges();

                AgregaPrecioGenerico.validar = 1;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el precio al artículo: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    this.btnAceptar.PerformClick();

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
