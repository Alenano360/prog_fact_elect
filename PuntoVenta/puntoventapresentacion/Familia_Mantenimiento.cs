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
    public partial class Familia_Mantenimiento : Form
    {
        Familia_Mod _owner;

        public int FamiliaId = 0;

        public int Accion = 0;

        PuntoVentaBL.Familia objFamilia = new PuntoVentaBL.Familia();

        public Familia_Mantenimiento(Familia_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Familia_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Accion == 2)//modificar
                {
                    this.objFamilia.Id = FamiliaId;

                    this.objFamilia.ObtieneFamiliaBusqueda();

                    this.txtFamilia.Text = this.objFamilia.Descripcion;

                    this.txtObservacion.Text = this.objFamilia.Observacion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Familia_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validacion()
        {
            if (this.txtFamilia.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el nombre de la familia!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = this.txtFamilia;
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validacion())
                {
                    return;
                }

                this.objFamilia.Descripcion = this.txtFamilia.Text;
                if (this.txtObservacion.Text.Length>0)
                {
                    this.objFamilia.Observacion = this.txtObservacion.Text;    
                }                

                if (Accion == 1)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar la familia?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.objFamilia.AgregaFamilia())
                        {
                            MessageBox.Show("Familia agregada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Familia_Mod_Load(sender, e);

                        this.Close();
                    }
                }
                if (Accion == 2)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar la familia?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {

                        this.objFamilia.Id = this.FamiliaId;

                        if (this.objFamilia.ModificaFamilia())
                        {
                            MessageBox.Show("Familia modificada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Familia_Mod_Load(sender, e);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de la familia: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
