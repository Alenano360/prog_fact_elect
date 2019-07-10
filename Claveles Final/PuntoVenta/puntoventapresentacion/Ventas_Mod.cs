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
    public partial class Ventas_Mod : Form
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        Sel_Mod _owner;

        PuntoVentaBL.Cliente objCliente = new PuntoVentaBL.Cliente();

        PuntoVentaBL.Ventas objVentas = new PuntoVentaBL.Ventas();

    

        public int ClienteId = 0;

        public Ventas_Mod(Sel_Mod owner)
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

        private void Ventas_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        public void Ventas_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();
                
                this.objVentas.ObtieneFacturasVenta(this.dgvDatos);

                this.objCliente.ObtieneClientes(this.cmbClientes);

                this.txtBuscar.Text = string.Empty;

                this.cmbOrdenar.Text = "--Seleccione--";

                this.objVentas.ObtieneFacturasVenta(this.dgvDatos);

                this.objVentas.ObtieneFacturasVenta(this.dgvDatos);

                //Cambios Realizados 14/12/2015: modifica acceso, botón de Eliminar inhabilitado
                if (Login.RolId == 4)//facturar
                {
                    btnEliminar.Enabled = false;
                }

                //Cambios Realizados 05/03/2016: botón de Reportes habilitado SOLO para admin
                if (Login.RolId == 1)//administrador
                {
                    btnReportes.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.Text = string.Empty;

                this.objVentas.ObtieneFacturasVenta(this.dgvDatos);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
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
                        objVentas.TipoPago = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[7].Value.ToString());
                            
                        if (this.objVentas.EliminaFactura(Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[1].Value.ToString()), Login.UserId))
                        {
                            MessageBox.Show("Factura eliminada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    this.btnLimpiar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                        this.btnVer.PerformClick();
                        //this.objVentas.ObtieneFacturasVenta(this.dgvDatos);
                        this.txtBuscar.Text = string.Empty;
                        return;
                    }
                    try
                    {
                        Int64 hhh = Convert.ToInt64(this.txtBuscar.Text);

                        this.objVentas.ComprobanteId = Convert.ToInt64(this.txtBuscar.Text);

                        this.objVentas.ObtieneFacturaBusqueda(this.dgvDatos);

                        this.txtBuscar.Text = string.Empty;

                        e.Handled = true;
                    }
                    catch (Exception)
                    {
                        this.btnVer.PerformClick();

                        this.txtBuscar.Text = string.Empty;
                    }                    



                    //e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void ObtieneFacturasCliente()
        {
            try
            {
                this.objVentas.ClienteId = this.ClienteId;///lo obtengo de cambia cliente que proviene de la pantalla de seleccion de cliente
                                                          ///
                //this.objVentas.ObtieneFacturaCliente(this.dgvDatos);

                this.ObtieneFacturas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ventas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CambiaCliente()
        {
            try
            {
                this.cmbClientes.SelectedValue = ClienteId; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Cliente cliente = new Sel_Cliente(this);
                cliente.TopLevel = false;
                cliente.tipo = 1;
                cliente.Parent = this;
                cliente.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar buscar los clientes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {                
                if (this.dtpHasta.Value<this.dtpDesde.Value)
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

                //this.objVentas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                //this.objVentas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());
                this.objVentas.FechaInicio = Convert.ToDateTime("01/04/2018");
                this.objVentas.FechaFinal = Convert.ToDateTime("01/05/2018");

                var bus = (from x in db.ObtieneVentas_Vws
                          join e in db.Equipos on x.EquipoId equals e.Id
                          //join m in db.Movimientos on x.MovimientoId equals m.Id
                          where this.objVentas.FechaInicio <= x.Fecha && x.Fecha <= this.objVentas.FechaFinal
                          //x.MovimientoId == 2 && e.NombreEquipo == System.Environment.MachineName.ToString() && 
                          orderby x.Id descending
                          select x);

             

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
                        case "Cliente":
                            {
                                bus = from x in bus
                                      orderby x.Nombre ascending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }
                    return;
                }

                if (this.cmbClientes.Text != "--Seleccione--")
                {
                    bus = (from x in bus
                          where x.ClienteId == Convert.ToInt32(this.cmbClientes.SelectedValue.ToString())
                          select x);
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
            //this.cmbClientes.Text = "--Seleccione--";

            //this.ObtieneFacturas();

            this.objVentas.ObtieneFacturasVenta(this.dgvDatos);
            
            this.objVentas.ObtieneFacturasVenta(this.dgvDatos);

            this.cmbClientes.SelectedValue = 1;
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
                VentasTicket ventasticket = new VentasTicket(this);
                ventasticket.TopLevel = false;
                ventasticket.Parent = this;
                ventasticket.TipoPago=Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[7].Value.ToString());
                ventasticket.FacturaId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[1].Value.ToString());
                ventasticket.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la factura seleccionada: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDatos.Columns[e.ColumnIndex].Name == "Activo")
            {
                if (Convert.ToBoolean(e.Value) == Convert.ToBoolean("false"))
                {
                    e.CellStyle.BackColor = Color.LightSalmon;
                    e.Value="";
                }
                else
                {
                    e.Value = "";//necesario para remover el texto
                }
            }
        }

        private void dgvDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvDatos.ClearSelection();
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvDatos.CurrentRow.HeaderCell.Style.SelectionBackColor = Color.Transparent;
            this.dgvDatos.CurrentRow.Cells[0].Style.SelectionBackColor = Color.Transparent;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFacturasAnuladas_Click(object sender, EventArgs e)
        {
            if (Login.RolId == 1)//Administrador
            {
                try
                {
                    //ReporteF_Anuladas rep = new ReporteF_Anuladas(this);
                    //rep.TopLevel = false;
                    //rep.Parent = this;
                    //rep.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


    }
}
