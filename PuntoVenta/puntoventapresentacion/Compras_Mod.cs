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
    public partial class Compras_Mod : Form
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        Sel_Mod _owner;

        PuntoVentaBL.Compras objCompras = new PuntoVentaBL.Compras();

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        public int ProveedorId = 0;

        public Compras_Mod(Sel_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }
        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.objModulo.ObtieneCajaDiaria() == false)
                //{
                //    return;
                //}
                Compras_Mantenimiento Mantenimiento = new Compras_Mantenimiento(this);
                Mantenimiento.TopLevel = false;
                Mantenimiento.Parent = this;
                Mantenimiento.Accion = 1;
                Mantenimiento.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void CambiaProveedor()
        {
            try
            {
                this.cmbProveedor.SelectedValue = ProveedorId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Compras_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.txtBuscar.Text = string.Empty;

                this.objInventario.ObtieneProveedores(this.cmbProveedor);

                this.objCompras.ObtieneFacturasCompra(this.dgvDatos);

                this.cmbOrdenar.Text = "--Seleccione--";

                this.dgvDatos.ClearSelection();

                //this.dgvDatos.RowHeadersDefaultCellStyle.SelectionBackColor = this.dgvDatos.RowHeadersDefaultCellStyle.BackColor;
                //this.dgvDatos.RowHeadersDefaultCellStyle.SelectionForeColor = this.dgvDatos.RowHeadersDefaultCellStyle.ForeColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void Compras_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Compras_Reportes rep = new Compras_Reportes(this);
                rep.TopLevel = false;
                rep.Parent = this;
                rep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.ObtieneFacturasFechas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.ObtieneFacturasFechas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ObtieneFacturas()
        {
            try
            {
                this.OpenConn();


                var bus = from x in db.ObtieneCompras_Vws
                          where x.MovimientoId == 3 
                          select x;

  

                if (this.cmbProveedor.Text != "--Seleccione--")
                {
                    bus = from x in bus
                          where x.ProveedorId == Convert.ToInt32(this.cmbProveedor.SelectedValue.ToString())
                          select x;
                }

                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    switch (this.cmbOrdenar.Text)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Id descending
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
                        case "Proveedor":
                            {
                                bus = from x in bus
                                      orderby x.Nombre ascending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }
                }

                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneFacturasFechas()
        {
            try
            {
                this.OpenConn();


                var bus = from x in db.ObtieneCompras_Vws
                          join m in db.Movimientos on x.MovimientoId equals m.Id
                          where x.MovimientoId == 3 && Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString()) <= x.Fecha && x.Fecha <= Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString())
                          orderby x.Id descending
                          select x;

                if (this.cmbProveedor.Text != "--Seleccione--")
                {
                    bus = from x in bus
                          where x.ProveedorId == Convert.ToInt32(this.cmbProveedor.SelectedValue.ToString())
                          select x;
                }

                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    switch (this.cmbOrdenar.Text)
                    {
                        case "Fecha":
                            {
                                bus = from x in bus
                                      orderby x.Id descending
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
                        case "Proveedor":
                            {
                                bus = from x in bus
                                      orderby x.Nombre ascending
                                      select x;
                                break;
                            }

                        default:
                            break;
                    }
                }

                this.dgvDatos.AutoGenerateColumns = false;

                this.dgvDatos.DataSource = bus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.cmbProveedor.Text = "--Seleccione--";

            this.ObtieneFacturas();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //try
                    //{
                    //    Int64 x = Convert.ToInt64(this.txtBuscar.Text);
                    //}
                    //catch (Exception)
                    //{
                    //    this.objCompras.ObtieneFacturasCompra(this.dgvDatos);

                    //    MessageBox.Show("Digite números para el comprobante", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    if (this.txtBuscar.Text.Length == 0)
                    {
                        this.objCompras.ObtieneFacturasCompra(this.dgvDatos);

                        e.Handled = true;

                        return;
                    }
                    this.objCompras.ComprobanteId = (this.txtBuscar.Text);

                    this.objCompras.ObtieneFacturaBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las compras: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Proveedor proveedor = new Sel_Proveedor(this);
                proveedor.TopLevel = false;
                proveedor.tipo = 4;
                proveedor.Parent = this;
                proveedor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar buscar los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ComprasTicket comprasticket = new ComprasTicket(this);
                comprasticket.TopLevel = false;
                comprasticket.Parent = this;
                comprasticket.FacturaId = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[1].Value.ToString());
                comprasticket.ComprobanteId =this.dgvDatos.CurrentRow.Cells[3].Value.ToString();
                comprasticket.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la factura seleccionada: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            this.objCompras.ObtieneFacturasCompra(this.dgvDatos);
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
                        this.objCompras.CID = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                        if (this.objCompras.EliminaFactura(Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[1].Value.ToString()), Login.UserId))
                        {
                            MessageBox.Show("Factura eliminada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    this.objCompras.ObtieneFacturasCompra(this.dgvDatos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar la factura: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Compras_Mantenimiento Mantenimiento = new Compras_Mantenimiento(this);
                Mantenimiento.TopLevel = false;
                Mantenimiento.Parent = this;
                Mantenimiento.Accion = 2;
                Mantenimiento.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDatos.Columns[e.ColumnIndex].Name == "Activo")
            {
                if (Convert.ToBoolean(e.Value) == Convert.ToBoolean("false"))
                {
                    e.CellStyle.BackColor = Color.LightSalmon;
                    e.Value = "";
                }
                else
                {
                    e.Value = "";
                }
            }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvDatos.CurrentRow.HeaderCell.Style.SelectionBackColor = Color.Transparent;
            this.dgvDatos.CurrentRow.Cells[2].Style.SelectionBackColor = Color.Transparent;

        }

        private void dgvDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvDatos.ClearSelection();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ObtieneFacturas();
        }

        private void btnVerFacturaTemp_Click(object sender, EventArgs e)
        {
            try
            {
                Compras_Mantenimiento Mantenimiento = new Compras_Mantenimiento(this);
                Mantenimiento.TopLevel = false;
                Mantenimiento.Parent = this;
                Mantenimiento.Accion = 3;//Continuar Factura Temporal
                Mantenimiento.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
