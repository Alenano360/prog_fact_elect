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
    public partial class Sel_UnidadMedida : Form
    {

        Inventario_Mantenimiento _owner;

        public int tipo = 0;

        PuntoVentaBL.Inventario objInventario = new PuntoVentaBL.Inventario();

        public Sel_UnidadMedida(Inventario_Mantenimiento owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Sel_UnidadMedida_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objInventario.ObtieneUnidadesMedida(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las unidades de medida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvDatos.Columns[0].Visible = true;
            if (tipo == 0)//reportes
            {

                _owner.UnidadMedida = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner.CambiaUnidadMedida();
                this.dgvDatos.Columns[0].Visible = false;
            }
            this.dgvDatos.Columns[0].Visible = false;
            this.Close();
        }

        private void Sel_Familia_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2); 
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    this.objInventario.Descripcion = this.txtBuscar.Text;

                    this.objInventario.ObtieneUnidadMedidaBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las unidades de medida: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


