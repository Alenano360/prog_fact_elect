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
    public partial class Sel_Familia : Form
    {

        Inventario_Mantenimiento _owner;

        Inventario_Reportes _owner2;

        Ventas_Reportes _owner3;

        public int tipo = 0;

        PuntoVentaBL.Familia objFamilia = new PuntoVentaBL.Familia();

        public Sel_Familia(Inventario_Mantenimiento owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public Sel_Familia(Inventario_Reportes owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        public Sel_Familia(Ventas_Reportes owner)
        {
            InitializeComponent();

            _owner3 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing3);
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Show();
        }

        private void Form2_FormClosing3(object sender, FormClosingEventArgs e)
        {
            this._owner3.Show();
        }

        private void Sel_Familia_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objFamilia.ObtieneFamilia(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                _owner.FamiliaId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner.CambiaFamilia();
                this.dgvDatos.Columns[0].Visible = false;
            }
            if (tipo==1)//reportes
            {
                _owner2.NFamiliaId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner2.CambiaFamilia();
            }

            if (tipo ==3 )//ventas reportes
            {
                _owner3.FamiliaId = Convert.ToInt32(this.dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                _owner3.CambiaFamilia();
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
                    this.objFamilia.Nombre = this.txtBuscar.Text;

                    this.objFamilia.ObtieneFamiliaBusqueda(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


