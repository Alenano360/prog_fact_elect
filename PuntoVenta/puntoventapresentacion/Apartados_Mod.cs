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
    public partial class Apartados_Mod : Form
    {
        Facturacion_Mod _owner;

        Sel_Mod _owner2;

        PuntoVentaBL.Apartados objApartados = new PuntoVentaBL.Apartados();

        PuntoVentaBL.Cliente objcliente = new PuntoVentaBL.Cliente();

        public int Seleccion = 0;

        public Apartados_Mod(Facturacion_Mod owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        public Apartados_Mod(Sel_Mod owner)
        {
            InitializeComponent();

            _owner2 = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing2);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._owner.Show();
        }

        private void Form2_FormClosing2(object sender, FormClosingEventArgs e)
        {
            this._owner2.Show();
        }

        private void Apartados_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();

                this.cmbOrdenar.Text = "--Seleccione--";

                this.ActiveControl = this.txtBuscar;

                this.objcliente.ObtieneClientes(this.cmbCliente);

                this.objApartados.ObtieneApartados(this.dgvDatos);

                if (Seleccion==1)
                {
                    this.btnAceptar.Visible = false;
                    this.btnEliminar.Visible = false;
                    this.btnVer.Visible = false;
                    this.btnSeleccion.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar los apartados: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = this.txtBuscar;

                this.objApartados.ObtieneApartados(this.dgvDatos);

                this.cmbOrdenar.Text = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar los apartados: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el apartado?", "Confirmation", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        this.objApartados.AbonoId = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value);

                        this.objApartados.EliminaApartado();

                        this.btnVer.PerformClick();

                        this.dgvDatos.DataSource = null;

                        this.objApartados.ObtieneApartados(this.dgvDatos);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al intentar eliminar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione el apartado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult result = MessageBox.Show("¿Está seguro que desea mostrar el apartado?", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    VerDetalle form1 = new VerDetalle(this);
                    form1.TopLevel = false;
                    form1.Parent = this;
                    form1.comprobante = this.dgvDatos.CurrentRow.Cells[0].Value.ToString();
                    form1.cliente = this.dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    form1.fecha = this.dgvDatos.CurrentRow.Cells[2].Value.ToString();
                    form1.hora = "00:00";
                    form1.total = this.dgvDatos.CurrentRow.Cells[3].Value.ToString();
                    form1.vendedor = this.dgvDatos.CurrentRow.Cells[6].Value.ToString();
                    form1.impuesto = this.dgvDatos.CurrentRow.Cells[8].Value.ToString();
                    form1.descuento = this.dgvDatos.CurrentRow.Cells[9].Value.ToString();
                    form1.fechaFinal = this.dgvDatos.CurrentRow.Cells[10].Value.ToString();


                    form1.cobrado = this.dgvDatos.CurrentRow.Cells[4].Value.ToString();
                    form1.saldo = this.dgvDatos.CurrentRow.Cells[5].Value.ToString();
                    form1.Apartado = 1;

                    form1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar mostrar el apartado: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Seleccion==0)
                {
                    this.btnAceptar.PerformClick(); 
                }
            }
            catch (Exception)
            {

            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    this.objApartados.Orden = this.cmbOrdenar.Text;

                    this.objApartados.ObtieneApartados(this.dgvDatos);
                }
                else
                {
                    this.btnVer.PerformClick();
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.objApartados.SBusqueda = this.txtBuscar.Text;

                    this.objApartados.ObtieneApartados(this.dgvDatos);

                    this.txtBuscar.Text = string.Empty;

                    e.Handled = true;

                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los apartados: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Apartados_Mod_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbOrdenar.Text != "--Seleccione--")
                {
                    this.objApartados.Orden = this.cmbOrdenar.Text;
                }
                this.objApartados.ClienteId = Convert.ToInt32(this.cmbCliente.SelectedValue);                    

                this.objApartados.ObtieneApartadosXCliente(this.dgvDatos);               
            }
            catch (Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDatos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione el apartado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Apartados_Abonos form = new Apartados_Abonos(this);
                form.TopLevel = false;
                form.Parent = this;
                form.Id = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
                form.Show();
            }
            catch (Exception)
            {

            }
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            ApartadoAgrega_Abono form = new ApartadoAgrega_Abono(this);
            form.TopLevel = false;
            form.Parent = this;
            form.Id = Convert.ToInt64(this.dgvDatos.CurrentRow.Cells[0].Value.ToString());
            form.Fecha = this.dgvDatos.CurrentRow.Cells[2].Value.ToString();
            form.Cliente = this.dgvDatos.CurrentRow.Cells[1].Value.ToString();
            form.Total = this.dgvDatos.CurrentRow.Cells[3].Value.ToString();
            form.Saldo = this.dgvDatos.CurrentRow.Cells[5].Value.ToString();
            form.Vendedor = this.dgvDatos.CurrentRow.Cells[6].Value.ToString();
            form.Show();
        }

        public void ObtieneApartados()
        {
            try
            {
                this.objApartados.ObtieneApartados(this.dgvDatos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cargar los apartados: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
