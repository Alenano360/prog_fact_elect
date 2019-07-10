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
    public partial class Elegir_Persona : Form
    {
        Facturacion_Pago _owner;
        public PuntoVentaBL.Persona objPersona = new PuntoVentaBL.Persona();

        public Elegir_Persona(Facturacion_Pago fact)
        {
            _owner = fact;
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);

        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this._owner.objReceptor = this.dgv_personas.getse
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Elegir_Persona_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var receptor = objPersona.Cargar_Receptor(dgv_personas.Rows[e.RowIndex].Cells[3].Value.ToString());
            _owner._owner.objReceptor = new PuntoVentaBL.Persona();
            _owner._owner.objReceptor = receptor;
            this.Dispose();
        }

        private void Elegir_Persona_Load(object sender, EventArgs e)
        {
            try
            {
                ReLoadView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void ReLoadView()
        {
            dgv_personas.DataSource = objPersona.load_Receptores();
        }
        private void btnElegir_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int row = dgv_personas.CurrentCell.RowIndex;
            var receptor = objPersona.Cargar_Receptor(dgv_personas.Rows[row].Cells[3].Value.ToString());
            _owner._owner.objReceptor = new PuntoVentaBL.Persona();
            _owner._owner.objReceptor = receptor;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarPersona Ventana_Agregar_Persona = new AgregarPersona();
            Ventana_Agregar_Persona._owner2 = this;
            Ventana_Agregar_Persona.Show();
        }
    }
}
