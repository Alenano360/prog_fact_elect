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
    public partial class Gasto_Mantenimiento : Form
    {
       Gasto_Mod _owner;

       public int Accion = 0;

       public int GastoId = 0;

       public int AutorizaId = 0;

       PuntoVentaBL.Gastos objGastos = new PuntoVentaBL.Gastos();

       PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

       public Gasto_Mantenimiento(Gasto_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Gasto_Mantenimiento_Load(object sender, EventArgs e)
        {
            try
            {
                this.objGastos.ObtieneUsuarios(this.cmbAutoriza);

                if (this.Accion==1)
                {
                    this.txtHora.Visible = false;
                    this.lblHora.Visible = false;
                }
                if (this.Accion == 2)//modificar
                {
                    this.objGastos.Id = this.GastoId;

                    this.objGastos.ObtieneGastoBusqueda();
                    this.dtpFecha.Enabled = false;
                    this.txtHora.Enabled = false;
                    this.dtpFecha.Value = Convert.ToDateTime(this.objGastos.Fecha);
                    this.txtHora.Text = this.objGastos.Hora.ToString();
                    this.txtDescripcion.Text = this.objGastos.Descripcion.ToString();
                    this.txtImporte.Text = this.objGastos.Monto.ToString("F");
                    this.txtComprobante.Text = this.objGastos.ComprobanteId.ToString();
                    this.cmbAutoriza.SelectedValue = this.objGastos.AutorizaId;
                    this.cmbAutoriza.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los gastos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void Gasto_Mantenimiento_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                } 

                if (!Validacion())
                {
                    return;
                }                                                                                                             
                this.objGastos.Fecha = Convert.ToDateTime(this.dtpFecha.Value.Date.ToString("dd/MM/yyyy"));
                this.objGastos.Descripcion = this.txtDescripcion.Text;
                this.objGastos.Monto = Convert.ToDecimal(this.txtImporte.Text);
                if (this.txtComprobante.Text.Length!=0)
                {
                    this.objGastos.ComprobanteId = Convert.ToInt64(this.txtComprobante.Text);
                }               
                this.objGastos.AutorizaId = Convert.ToInt32(this.cmbAutoriza.SelectedValue.ToString());


                if (Accion == 1)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea agregar el gasto?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objGastos.Hora = System.DateTime.Now.ToShortTimeString();

                        if (this.objGastos.AgregaGasto(Login.UserId))
                        {
                            MessageBox.Show("Gasto agregado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Gasto_Mod_Load(sender, e);

                        this.Close();
                    }
                }
                if (Accion == 2)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea modificar el gasto?", "Confirmación", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objGastos.Hora = this.txtHora.Text;

                        this.objGastos.Id = GastoId;

                        if (this.objGastos.ModificaGasto(Login.UserId))
                        {
                            MessageBox.Show("Gasto modificado con éxito", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        _owner.Gasto_Mod_Load(sender, e);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el mantenimiento de los proveedores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
       
        private bool Validacion()
        {
            if (this.txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese la descripción del gasto!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDescripcion.Focus();
                return false;
            }
            if (this.txtImporte.Text.Length == 0)
            {
                MessageBox.Show("Por favor ingrese el importe del gasto!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtImporte.Focus();
                return false;
            }

            try
            {
                decimal x = Convert.ToDecimal(this.txtImporte.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor ingrese solo números para el importe!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtImporte.Focus();
                return false;
            }
            return true;
        }

        private void btnBuscaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Sel_Usuario usuarios = new Sel_Usuario(this);
                usuarios.TopLevel = false;
                usuarios.tipo = 0;
                usuarios.Parent = this;
                usuarios.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar buscar los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        public void CambiaUsuario()
        {
            try
            {
                this.cmbAutoriza.SelectedValue = AutorizaId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los usuarios: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
