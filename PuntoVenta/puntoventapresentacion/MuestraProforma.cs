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
    public partial class MuestraProforma : Form
    {
        Facturacion_Mod _owner;

        PuntoVentaDAL.CONEXIONDataContext db = null;

        public int _Id = 0;

        public MuestraProforma(Facturacion_Mod owner)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtProforma.Text.Length == 0)
                {
                    MessageBox.Show("Por favor digite el número de la proforma a mostrar!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.OpenConn();

                var bus = (from x in db.ProformaEncabezados
                           where x.Activo == true && x.Id == Convert.ToInt64(this.txtProforma.Text)
                           select x);

                if (bus.Count()==0)
                {
                    MessageBox.Show("No se encuentra ninguna proforma con el código digitado!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _owner.ProforomaMostrar = Convert.ToInt64(this.txtProforma.Text);
                _owner.MuestraProforma();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar la proforma requerida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void MuestraProforma_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void MuestraProforma_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void txtProforma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }
    }
}
