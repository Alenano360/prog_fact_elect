using Restaurante_Presentacion;
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
    public partial class Mantenimiento_Persona : Form
    {
        Principal _owner;
        Restaurante_BL.Persona _DTO_Persona = new Restaurante_BL.Persona();
        public Mantenimiento_Persona(Principal owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AgregarPersona Ventana_Agregar_Persona = new AgregarPersona();
            Ventana_Agregar_Persona._owner = this;
            Ventana_Agregar_Persona.TopLevel = false;
            Ventana_Agregar_Persona.Parent = this;
            Ventana_Agregar_Persona.Show();
        }

        private void Mantenimiento_Persona_Load(object sender, EventArgs e)
        {
            Mantenimiento_Persona_Load();
        }
        public void Mantenimiento_Persona_Load()
        {
            _DTO_Persona.Cargar_Personas(dataGridView1);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string ced = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (_DTO_Persona.Eliminar_Persona(ced))
            {
                
                MessageBox.Show("Persona borrada con exito");
                Mantenimiento_Persona_Load();
            }
            else {
                MessageBox.Show("No se pudo Eleminar la persona");
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_personas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
