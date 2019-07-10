using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PuntoVentaPresentacion
{
    public partial class Sel_Mod : Form
    {   
        Login _owner;

        public int x = 0;

        public int accion = 0;

        public string user;

        public string env; 


        PuntoVentaBL.ModuloPrincipal objModulo = new PuntoVentaBL.ModuloPrincipal();

        public Sel_Mod(Login owner)
        {
            InitializeComponent();

            _owner = owner;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);

            Load_Local_Config();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (accion == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro que desea salir del sistema?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    _owner.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }   
        }

        PuntoVentaBL.Login objLogin = new PuntoVentaBL.Login();

        public void Sel_Mod_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargaTs();

                this.objModulo.RegistraMaquina(Login.UserId);

                if (Login.RolId == 2)//cajas
                {
                    //this.btnCajaDiaria.Enabled = false;
                    //this.btnClientes.Enabled = false;
                    //this.btnCompras.Enabled = false;
                    //this.btnGasto.Enabled = false;
                    //this.btnInventario.Enabled = false;
                    //this.btnProveedor.Enabled = false;
                    //this.btnVentas.Enabled = false;
                    //utilidadesToolStripMenuItem.Visible = false;
                }
                if (Login.RolId == 3)//inventario
                {
                    this.btnCajaDiaria.Enabled = false;
                    this.btnClientes.Enabled = false;
                    this.btnGasto.Enabled = false;
                    this.btnVentas.Enabled = false;
                    this.btnFacturar.Enabled = false;
                    //utilidadesToolStripMenuItem.Visible = false;
                }
                if (Login.RolId == 4)//facturar
                {
                    //Cambios Realizados 14/12/2015: modifica acceso 
                   /* this.btnCajaDiaria.Enabled = false;
                    this.btnClientes.Enabled = false;
                    this.btnGasto.Enabled = false;
                    this.btnVentas.Enabled = false;
                    this.btnProveedor.Enabled = false;
                    this.btnCompras.Enabled = false;*/

                    //Cambios Realizados 16/12/2015: se habilita acceso de Caja Diaria Rol 4:
                  /* this.btnCajaDiaria.Enabled = false;
                  //  this.btnClientes.Enabled = false;
                    this.btnGasto.Enabled = false;
                  //  this.btnVentas.Enabled = false;
                  //  this.btnProveedor.Enabled = false;
                 //   this.btnCompras.Enabled = false;*/

                    //this.btnCajaDiaria.Enabled = false;
                    //  this.btnClientes.Enabled = false;
                    this.btnGasto.Enabled = false;
                    //  this.btnVentas.Enabled = false;
                    //  this.btnProveedor.Enabled = false;
                    //   this.btnCompras.Enabled = false;

                    //utilidadesToolStripMenuItem.Visible = false;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar ingresar al sistema: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public PuntoVentaBL.InformacionGeneral objInformacionGeneral = new PuntoVentaBL.InformacionGeneral();

        private void CargaTs()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacion();

                this.tls_Usuario.Text = "Usuario: " + Login.LoginUsuarioFinal.ToString().ToUpper();

                this.tlsNombreRest.Text = this.objInformacionGeneral.Nombre.ToString();
                Console.Out.WriteLine(System.DateTime.Now.ToShortDateString());
                this.tlsFecha.Text = "Fecha: " + System.DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información general: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario_Mod InventarioMod = new Inventario_Mod(this);
                InventarioMod.TopLevel = false;
                InventarioMod.Parent = this;
                InventarioMod.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener el módulo de inventario : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sel_Mod_Resize(object sender, EventArgs e)
        {
            //this.lblTitulo.Left = (this.Width / 2) - (this.lblTitulo.Width / 2);
            //this.pModulos.Left = (this.Width / 2) - (this.pModulos.Width / 2);

            //this.tls_Usuario.Width = (this.Width / 16) * 3;
            //this.tlsNombreRest.Width = ((this.Width / 16) * 12) - 20;
            //this.tlsFecha.Width = (this.Width / 16) - 2;

            this.tls_Usuario.Width = (this.Width / 3) ;
            this.tlsNombreRest.Width = ((this.Width / 3)) ;
            this.tlsFecha.Width = (this.Width / 3);

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.objModulo.objNotaCredito() == false)
                //{
                //    return;
                //}

                Facturacion_Mod FacturacionMod = new Facturacion_Mod(this);
                FacturacionMod.TopLevel = false;
                FacturacionMod.Parent = this;
                FacturacionMod.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de facturación : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsCambiaSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cierre de sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _owner.Login_Load(sender, e);

                    accion = 1;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cerrar la sesión: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente_Mod cliente = new Cliente_Mod(this);
                cliente.TopLevel = false;
                cliente.Parent = this;
                cliente.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de clientes : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor_Mod proveedor = new Proveedor_Mod(this);
                proveedor.TopLevel = false;
                proveedor.Parent = this;
                proveedor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de proveedores : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {
                Compras_Mod compras = new Compras_Mod(this);
                compras.TopLevel = false;
                compras.Parent = this;
                compras.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de compras : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                Ventas_Mod ventas = new Ventas_Mod(this);
                ventas.TopLevel = false;
                ventas.Parent = this;
                ventas.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de ventas : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGasto_Click(object sender, EventArgs e)
        {
            try
            {
                Gasto_Mod gasto = new Gasto_Mod(this);
                gasto.TopLevel = false;
                gasto.Parent = this;
                gasto.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de ventas : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCajaDiaria_Click(object sender, EventArgs e)
        {
            try
            {

                CajaDiaria_Mod caja = new CajaDiaria_Mod(this);
                caja.TopLevel = false;
                caja.Parent = this;
                caja.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de caja diaria : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mantenimientoDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario_Mantenimiento usuario = new Usuario_Mantenimiento(this);
                usuario.TopLevel = false;
                usuario.Parent = this;
                usuario.Accion = 1;
                usuario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de usuarios : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void informacionGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Informacion_General usuario = new Informacion_General(this);
                usuario.TopLevel = false;
                usuario.Parent = this;
                usuario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de usuarios : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ubicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ubicaciones_Mod modulo = new Ubicaciones_Mod(this);
                modulo.TopLevel = false;
                modulo.Parent = this;
                modulo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de ubicaciones : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Familia_Mod modulo = new Familia_Mod(this);
                modulo.TopLevel = false;
                modulo.Parent = this;
                modulo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de familias : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario_Mantenimiento usuario = new Usuario_Mantenimiento(this);
                usuario.TopLevel = false;
                usuario.Parent = this;
                usuario.Accion = 1;
                usuario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de usuarios : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void utilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Cerrar_Sesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cierre de sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _owner.Login_Load(sender, e);

                    accion = 1;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cerrar la sesión: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Informacion_General_Click(object sender, EventArgs e)
        {
            try
            {
                Informacion_General usuario = new Informacion_General(this);
                usuario.TopLevel = false;
                usuario.Parent = this;
                usuario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de usuarios : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Ubicaciones_Click(object sender, EventArgs e)
        {
            try
            {
                Ubicaciones_Mod modulo = new Ubicaciones_Mod(this);
                modulo.TopLevel = false;
                modulo.Parent = this;
                modulo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de ubicaciones : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Familias_Click(object sender, EventArgs e)
        {
            try
            {
                Familia_Mod modulo = new Familia_Mod(this);
                modulo.TopLevel = false;
                modulo.Parent = this;
                modulo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de familias : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pModulos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }

        private void tlsFecha_Click(object sender, EventArgs e)
        {

        }

        private void tlsNombreRest_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void drpMantenimiento_onItemSelected(object sender, EventArgs e)
        {
            if (drpMantenimiento.selectedIndex == 1)
            {
                try
                {
                    Mantenimiento_Persona usuario = new Mantenimiento_Persona(this);
                    usuario.TopLevel = false;
                    usuario.Parent = this;
                    usuario.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un inconveniente al ingresar al módulo de mantenimiento de usuarios : " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (drpMantenimiento.selectedIndex == 2)
            {
                Reporte_Electronico pag_Reporte = new Reporte_Electronico();
                pag_Reporte._owner = this; 
                pag_Reporte.TopLevel = false;
                pag_Reporte.Parent = this;
                pag_Reporte.Show();
            }
            else if (drpMantenimiento.selectedIndex == 3)
            {
                Inforacion_Hacienda pag_Info = new Inforacion_Hacienda();
                pag_Info._owner = this; 
                pag_Info.TopLevel = false;
                pag_Info.Parent = this;
                pag_Info.Show();
            }
        }
        public void Load_Local_Config()
        {
            String rootpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            string path = rootpath + @"\Conf\serverconfig";

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                int line = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    if (line == 0)
                    {
                        user = s;
                    }
                    else
                    {
                        env = s;
                    }
                    line++;
                }
            }
        }
    }
}
