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
    public partial class Sel_Factura : Form
    {
        PuntoVentaBL.Ventas objVentas = new PuntoVentaBL.Ventas();

        PuntoVentaDAL.CONEXIONDataContext db = null;

        Sel_NotaCredito _owner;

        public Sel_Factura(Sel_NotaCredito owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Sel_Factura_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ObtieneFacturas();

                this.txtBuscar.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void ObtieneFacturas()
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.ObtieneVentas_Vws
                          where x.Activo==true
                          orderby x.Id descending
                          select x;

                    this.dgvDatos.AutoGenerateColumns = false;
                    this.dgvDatos.DataSource = bus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las facturas de venta: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFacturasComprobante(Int64 _Comprobante)
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.ObtieneVentas_Vws
                          where x.Activo == true && x.Id==_Comprobante
                          orderby x.Id descending
                          select x;

                this.dgvDatos.AutoGenerateColumns = false;
                this.dgvDatos.DataSource = bus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las facturas de venta: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sel_Factura_Resize(object sender, EventArgs e)
        {
            try
            {
                this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
            }
            catch (Exception)
            {
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (this.txtBuscar.Text.Length == 0)
                    {
                        this.ObtieneFacturas();

                        this.txtBuscar.Text = string.Empty;

                        e.Handled = true;

                        return;
                    }
                    try
                    {
                        this.ObtieneFacturasComprobante(Convert.ToInt64(this.txtBuscar.Text));

                        this.txtBuscar.Text = string.Empty;

                        e.Handled = true;
                    }
                    catch (Exception)
                    {
                        this.ObtieneFacturas();

                        this.txtBuscar.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _owner.StringFacturaId = this.dgvDatos.CurrentRow.Cells[0].Value.ToString();

                _owner.CambiaTextoFactura();

                this.Close();
            }
            catch (Exception)
            {
                
            }
        }


    }
}
