using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_Presentacion
{
    public partial class Reportes_Mod : Form
    {
        Principal _owner;
        Restaurante_DAL.BaseDatosDataContext db = null;

        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();
        Restaurante_BL.Ventas objVentas = new Restaurante_BL.Ventas();

        public Reportes_Mod(Principal owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Principal_Load(sender, e);
        }

        private void Reportes_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.BringToFront();

                this.txtBuscar.Text = string.Empty;

                this.cmbClientes.Text = "--Seleccione--";

                this.cmbOrdenar.Text = "--Seleccione--";

                this.objVentas.ObtieneFacturasVenta(this.dgvDatos);
            }
            catch (Exception)
            {

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



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Ventas_Reportes rep = new Ventas_Reportes(this);
                rep.TopLevel = false;
                rep.Parent = this;
                rep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.Reportes_Mod_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la factura?", "Confirmación", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    if (this.objVentas.EliminaFactura(Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value.ToString()), Login.UserId))
                    {
                        MessageBox.Show("Factura eliminada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Reportes_Mod_Load(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.objVentas.ObtieneFacturasVenta(this.dgvDatos);

                        return;
                    }
                    this.objVentas.ComprobanteId = Convert.ToInt64(this.txtBuscar.Text);

                    this.objVentas.ObtieneFacturaBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpHasta.Value < this.dtpDesde.Value)
                {
                    MessageBox.Show("La fecha de finalización no puede ser mayor a la de inicio!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.dtpHasta.Value = this.dtpDesde.Value;

                    return;
                }
                this.ObtieneFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpHasta.Value < this.dtpDesde.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la de finalización!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.dtpHasta.Value = this.dtpDesde.Value;

                    return;
                }
                this.ObtieneFacturas();
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

                this.objVentas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToString ("yyyy/MM/dd"));
                this.objVentas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToString("yyyy/MM/dd"));

                var bus = from x in db.ObtieneVentas_Vw
                          join e in db.Equipos on x.EquipoId equals e.Id
                          join m in db.Movimientos on x.MovimientoId equals m.Id
                          where x.MovimientoId == 2 && 
                          e.NombreEquipo == System.Environment.MachineName.ToString() &&
                           this.objVentas.FechaInicio <= x.Fecha && x.Fecha <= this.objVentas.FechaFinal

                          orderby x.Id descending
                          select x;



                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    switch (this.cmbOrdenar.Text)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Fecha descending
                                      select x;
                                break;
                            }
                        case "Comprobante":
                            {
                                bus = from x in bus
                                      orderby x.Id descending
                                      select x;
                                break;
                            }
                        case "Clientes":
                                {
                                bus = from x in bus
                                      orderby x.TipoPago descending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }
                    return;
                }

                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.ObtieneFacturas();
        }

        public void OpenConn()
        {
            if (db == null) db = new Restaurante_DAL.BaseDatosDataContext();
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

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ObtieneFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Ventas_Ticket ventasticket = new Ventas_Ticket(this);
                ventasticket.TopLevel = false;
                ventasticket.Parent = this;
                ventasticket.TipoPago = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[6].Value.ToString());
                ventasticket.FacturaId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                ventasticket.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la factura seleccionada: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reportes_Mod_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.ObtieneVentas_Vw
                          join eQ in db.Equipos on x.EquipoId equals eQ.Id
                          join m in db.Movimientos on x.MovimientoId equals m.Id
                          where x.MovimientoId == 2 && eQ.NombreEquipo == System.Environment.MachineName.ToString()
                          orderby x.Id descending
                          select x;


                if (this.cmbClientes.Text=="CLIENTE TARJETA CREDITO")
                {
                    bus = from x in bus
                            where x.TipoPago==1
                            select x;                    
                }

                if (this.cmbClientes.Text == "CLIENTE CONTADO")
                {
                    bus = from x in bus
                          where x.TipoPago == 2
                          select x;
                }

                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }
    }
}
