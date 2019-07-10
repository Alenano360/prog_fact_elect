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
    public partial class Sel_Ubicacion : Form
    {

        Inventario_Mantenimiento _owner;

        public int tipo = 0;

        PuntoVentaBL.Ubicacion objUbicaciones = new PuntoVentaBL.Ubicacion();

        public Sel_Ubicacion(Inventario_Mantenimiento owner)
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

        private void Sel_Familia_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2); 
        }

        private void Sel_Ubicacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objUbicaciones.ObtieneUbicaciones(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void dgvDatos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvDatos.Columns[0].Visible = true;
            if (tipo == 0)//reportes
            {

                _owner.UbicacionId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner.CambiaUbicacion();

                this.dgvDatos.Columns[0].Visible = false;
            }
            this.dgvDatos.Columns[0].Visible = false;
            this.Close();
        }

        private void txtBuscar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    this.objUbicaciones.Nombre = this.txtBuscar.Text;

                    this.objUbicaciones.ObtieneUbicacionBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


