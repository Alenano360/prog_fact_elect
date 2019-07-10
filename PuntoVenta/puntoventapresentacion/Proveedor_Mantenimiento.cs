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
    public partial class Proveedor_Mantenimiento : Form
    {
        Proveedor_Mod _owner;
        
        public int Accion = 0;

        public int ProveedorId = 0;

        PuntoVentaBL.Proveedores objProveedor = new PuntoVentaBL.Proveedores();

        public Proveedor_Mantenimiento(Proveedor_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }
      
        private void Proveedor_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Accion == 2)//modificar
                {
                    this.objProveedor.Id = ProveedorId;

                    this.objProveedor.ObtieneProveedorBusqueda();

                    this.txtNombre.Text = this.objProveedor.Nombre;
                    this.txtCedula.Text = this.objProveedor.Cedula.ToString();
                    this.txtContacto.Text = this.objProveedor.Contacto.ToString();
                    this.txtTelefono1.Text = this.objProveedor.Telefono1.ToString();
                    this.txtTelefono2.Text = this.objProveedor.Telefono2.ToString();
                    this.dtpInicioRelaciones.Text = this.objProveedor.CreacionFecha.Date.ToString();

                    this.dtpInicioRelaciones.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Proveedor_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Validacion()
        {
            if (this.txtNombre.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el nombre del proveedor!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Focus();
                return false;
            }
            //if (this.txtContacto.Text.Length == 0)
            //{
            //    MessageBox.Show("Por favor ingrese la cédula del proveedor!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtCedula.Focus();
            //    return false;
            //}
            //if (this.txtTelefono1.Text.Length == 0)
            //{
            //    MessageBox.Show("Por favor ingrese la cédula del proveedor!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtCedula.Focus();
            //    return false;
            //}

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

                this.objProveedor.Nombre = this.txtNombre.Text;
                this.objProveedor.Contacto = this.txtContacto.Text;
                this.objProveedor.Cedula = this.txtCedula.Text;
                this.objProveedor.Telefono1 = this.txtTelefono1.Text;
                this.objProveedor.Telefono2 = this.txtTelefono2.Text;                
                this.objProveedor.CreacionFecha = Convert.ToDateTime(this.dtpInicioRelaciones.Value.Date.ToString("dd/MM/yyyy"));

                if (Accion == 1)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar el proveedor?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (this.objProveedor.AgregaProveedor(Login.UserId))
                        {
                            MessageBox.Show("Proveedor agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Proveedor_Mod_Load(sender, e);

                        this.Close();
                    }
                }
                if (Accion == 2)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el proveedor?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {

                        this.objProveedor.Id = this.ProveedorId;

                        if (this.objProveedor.ModificaProveedor(Login.UserId))
                        {
                            MessageBox.Show("Proveedor modificado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Proveedor_Mod_Load(sender, e);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
