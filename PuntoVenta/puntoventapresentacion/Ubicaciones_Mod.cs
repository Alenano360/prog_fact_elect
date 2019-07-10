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
    public partial class Ubicaciones_Mod : Form
    {
        Sel_Mod _owner;

        PuntoVentaBL.Ubicacion objUbicaciones = new PuntoVentaBL.Ubicacion();

        public Ubicaciones_Mod(Sel_Mod owner)
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

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.objUbicaciones.ObtieneUbicaciones(this.dgvDatos);

                this.txtBuscar.Text = string.Empty;

                ActiveControl = this.txtBuscar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la ubicación?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.dgvDatos.SelectedRows.Count > 0)
                        {
                            this.objUbicaciones.Id = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());

                            this.objUbicaciones.EliminaUbicacion();

                            this.Ubicaciones_Mod_Load(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count > 0)
                {
                    Ubicacion_Mantenimiento Mantenimiento = new Ubicacion_Mantenimiento(this);
                    Mantenimiento.TopLevel = false;
                    Mantenimiento.Parent = this;
                    Mantenimiento.Accion = 2;
                    Mantenimiento.UbicacionId = Convert.ToInt32(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                    Mantenimiento.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Ubicacion_Mantenimiento Mantenimiento = new Ubicacion_Mantenimiento(this);
                Mantenimiento.TopLevel = false;
                Mantenimiento.Parent = this;
                Mantenimiento.Accion = 1;
                Mantenimiento.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al mantenimiento de las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.btnModificar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.objUbicaciones.Nombre = this.txtBuscar.Text;

                    this.objUbicaciones.ObtieneUbicacionBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        public void Ubicaciones_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objUbicaciones.ObtieneUbicaciones(this.dgvDatos);

                this.txtBuscar.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void Ubicaciones_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);   
        }
    }
}
