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
    public partial class Gasto_Mod : Form
    {
        Sel_Mod _owner;

        PuntoVentaDAL.CONEXIONDataContext db = null;

        PuntoVentaBL.Gastos objGastos = new PuntoVentaBL.Gastos();

        public Gasto_Mod(Sel_Mod owner)
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
                Gasto_Mantenimiento Mantenimiento = new Gasto_Mantenimiento(this);
                Mantenimiento.TopLevel = false;
                Mantenimiento.Parent = this;
                Mantenimiento.Accion = 1;
                Mantenimiento.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar el gasto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Gasto_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.ObtieneGastos();

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }
                Gasto_Mantenimiento Mantenimiento = new Gasto_Mantenimiento(this);
                Mantenimiento.TopLevel = false;
                Mantenimiento.Parent = this;
                Mantenimiento.GastoId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                Mantenimiento.Accion = 2;
                Mantenimiento.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar el gasto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Gasto_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Gasto_Reportes rep = new Gasto_Reportes(this);
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
                this.ObtieneGastos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.ObtieneGastos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ObtieneGastos()
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.ObtieneGastos_Vws
                          //join eq in db.Equipos on x.EquipoId equals eq.Id
                          where Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString()) <= x.Fecha && x.Fecha <= Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString())//eq.NombreEquipo == System.Environment.MachineName.ToString() && 
                          orderby x.Id descending
                          select x;

                //var bus = (from cd in db.CajaDiaria
                //           join u in db.Usuario on cd.AutorizadoPor equals u.Id
                //           where cd.Activo == true && Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString()) <= cd.Fecha && cd.Fecha <= Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString()) &&cd.MovimientoId==9
                //           select new { cd.Id,cd.Fecha, cd.Hora, cd.Descripcion, cd.ComprobanteId, Nombre = u.Nombre + " " + (u.Apellido == null ? "" : u.Apellido), cd.Monto });

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
                        case "Importe":
                            {
                                bus = from x in bus
                                      orderby x.Monto descending
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
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ObtieneGastos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el gasto?", "Confirmación", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        if (this.dgvDatos.SelectedRows.Count > 0)
                        {
                            this.objGastos.Id = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());

                            this.objGastos.EliminaGasto(Login.UserId);

                            this.Gasto_Mod_Load(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el gasto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.objGastos.ObtieneGastos(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnModificar.PerformClick();
        }
    }
}
