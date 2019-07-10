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
    public partial class Apartados_Abonos : Form
    {
        Apartados_Mod _owner;

        public Int64 Id = 0;

        PuntoVentaBL.Apartados objApartado = new PuntoVentaBL.Apartados();

        public Apartados_Abonos(Apartados_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Apartados_Abonos_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.objApartado.AbonoId = Id;

                this.objApartado.ObtengoHistorico(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar los abonos de los apartados: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Apartados_Abonos_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Login.RolId.ToString() == "1")//solo admin puede ver
            {
                try
                {
                    if (this.dgvDatos.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione el apartado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.objApartado.AbonoId = Id;

                    this.objApartado.MontoAbono = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[2].Value);

                    this.objApartado.HistoricoId = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[1].Value);

                    this.objApartado.EliminaAbono();

                    this.objApartado.ObtengoHistorico(this.dgvDatos);

                    this._owner.ObtieneApartados();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el abono apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
