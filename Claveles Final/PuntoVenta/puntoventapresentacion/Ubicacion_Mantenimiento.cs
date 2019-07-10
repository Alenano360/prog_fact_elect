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
    public partial class Ubicacion_Mantenimiento : Form
    {
        Ubicaciones_Mod _owner;

        public int Accion = 0;

        public int UbicacionId = 0;

        PuntoVentaBL.Ubicacion objUbicacion = new PuntoVentaBL.Ubicacion();

        public Ubicacion_Mantenimiento(Ubicaciones_Mod owner)
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

        private bool Validacion()
        {
            if (this.txtUbicacion.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese la ubicación!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = this.txtUbicacion;
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

                this.objUbicacion.Nombre = this.txtUbicacion.Text;

                if (Accion == 1)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar la ubicación?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.objUbicacion.AgregaUbicacion())
                        {
                            MessageBox.Show("Ubicación agregada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Ubicaciones_Mod_Load(sender, e);

                        this.Close();
                    }
                }
                if (Accion == 2)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar la ubicación?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {

                        this.objUbicacion.Id = this.UbicacionId;

                        if (this.objUbicacion.ModificaUbicacion())
                        {
                            MessageBox.Show("Ubicación modificada con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Ubicaciones_Mod_Load(sender, e);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ubicacion_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Accion == 2)//modificar
                {
                    this.objUbicacion.Id = UbicacionId;

                    this.objUbicacion.ObtieneUbicacionBusqueda();

                    this.txtUbicacion.Text = this.objUbicacion.Nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Ubicacion_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }
    }
}
