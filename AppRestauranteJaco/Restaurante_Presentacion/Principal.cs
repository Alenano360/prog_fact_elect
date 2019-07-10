using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;

namespace Restaurante_Presentacion
{
    public partial class Principal : Form
    {
        List<Tuple<int, string>> Mesa1 = new List<Tuple<int, string>>();
        List<Tuple<int, string>> Mesa2 = new List<Tuple<int, string>>();
        List<Tuple<int, string>> Mesa3 = new List<Tuple<int, string>>();
        List<Tuple<int, string>> Mesa4 = new List<Tuple<int, string>>();

        Restaurante_BL.Lista_Orden AgregaOrden = new Restaurante_BL.Lista_Orden();
        Restaurante_BL.Principal_Restaurante PrincipalRestaurante = new Restaurante_BL.Principal_Restaurante();
        public Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();
        Restaurante_BL.ModuloPrincipal objModulo = new Restaurante_BL.ModuloPrincipal();

        public string user;
        public string env;

        Login _owner;
        public int accion = 0;

        public Principal(Login owner)
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
            //_owner.Login_Load(sender, e);          
        }

        private void restauranteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                //this.panel1.Visible = false;     

                this.usuariosToolStripMenuItem.Visible = false;

                if (Login.RolId == 1)
                {
                    this.usuariosToolStripMenuItem.Visible = true;
                    this.asd.Visible = true;
                }

                this.ResizeLoad();
                //se cambia la cantidad de mesas a 20:
                //   MessageBox.Show("Stop "); 
                for (int i = 1; i <= 79; i++)
                {
                    this.PrincipalRestaurante.MesaId = i;

                    this.PrincipalRestaurante.ObtengoMesasDisponibles((Button)this.Controls.Find("btnMesa" + i.ToString(), true).FirstOrDefault());
                }

                this.ObtieneInfoInferior();


                Restaurante_BL.MarcasPersonal objMarcas = new Restaurante_BL.MarcasPersonal();
                objMarcas.UsuarioId = Login.UserId;
                if (objMarcas.ObtengoEntrada() == 0)
                {
                    Marca_Mod marc = new Marca_Mod();
                    marc.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al cargar la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtieneInfoInferior()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.tls_Usuario.Text = "Usuario: " + _owner.LoginUsuario.ToString().ToUpper();

                this.tlsNombreRest.Text = "Restaurante: " + this.objInformacionGeneral.Nombre.ToString();

                this.tlsWebHtml.Text = "Web: " + this.objInformacionGeneral.Web.ToString();

                this.tlsFecha.Text = "Fecha: " + System.DateTime.Now.ToShortDateString();

                this.tlsHora.Text = "Hora: " + System.DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMesa1_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 1;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMesa2_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 2;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ResizeLoad()
        {
            try
            {
                var width = this.Width;
                var height = ((this.Height - 100) / 4) - 2;
                this.btnRestaurante.Height = height;
                this.btnFamilias.Height = height;
                this.btnCajaDiaria.Height = height;
                this.btnArticulos.Height = height;
                //this.button6.Height = height;

                this.btnRestaurante.Location = new Point(0, 40);
                this.btnFamilias.Location = new Point(this.btnFamilias.Location.X, (this.btnRestaurante.Location.Y + this.btnRestaurante.Height));
                this.btnArticulos.Location = new Point(this.btnArticulos.Location.X, (this.btnFamilias.Location.Y + this.btnFamilias.Height));
                this.btnCajaDiaria.Location = new Point(this.btnCajaDiaria.Location.X, (this.btnArticulos.Location.Y + this.btnArticulos.Height));

                //this.button6.Location = new Point(this.button6.Location.X, (this.button5.Location.Y + this.button5.Height));



                this.tls_Usuario.Width = ((this.Width / 9) * 2) + 15;
                this.tlsNombreRest.Width = ((this.Width / 9) * 3) - 32;
                this.tlsWebHtml.Width = (this.Width / 9) * 2;
                this.tlsFecha.Width = (this.Width / 9);
                this.tlsHora.Width = (this.Width / 9);


                //5mesas les resto el tamaño del boton//

                //this.panel1.Width = this.Width - this.btnRestaurante.Width;
                //this.panel1.Height = this.Height - 105;

                this.panel1.Location = new Point(((this.Width + this.btnRestaurante.Width - this.panel1.Width) / 2), ((this.Height - this.panel1.Height) / 2));

                //this.btnMesa5.Size = new Size((this.panel1.Width / 6),(this.panel1.Width/6));

                ////                      5
                ////primera fila  1 -2- 3-4-6
                ////              11-10-9-8-7
                //this.btnMesa1.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa2.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa3.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa4.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa6.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                ////5+6+7
                ////this.btnMesa1.Location = new Point(this.btnMesa1.Location.X, (this.btnMesa5.Height+((this.panel1.Height - (this.btnMesa5.Height + this.btnMesa6.Height + this.btnMesa7.Height)) / 8)));
                //this.btnMesa1.Location = new Point(this.btnMesa1.Location.X, (this.btnMesa5.Height + 20));
                //this.btnMesa2.Location = new Point((this.btnMesa1.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa1.Location.Y ));
                //this.btnMesa3.Location = new Point((this.btnMesa2.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa1.Location.Y));
                //this.btnMesa4.Location = new Point((this.btnMesa3.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa1.Location.Y));
                //this.btnMesa6.Location = new Point((this.btnMesa4.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa1.Location.Y));


                ////segunda fila

                ////11-7
                //this.btnMesa11.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa10.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa9.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa8.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa7.Size = new Size((this.panel1.Width / 6), (this.panel1.Width / 6));

                //this.btnMesa11.Location = new Point(this.btnMesa1.Location.X, (((this.panel1.Height - (this.btnMesa5.Height + this.btnMesa6.Height + this.btnMesa7.Height)) / 2)) + this.btnMesa5.Height + this.btnMesa1.Height);
                //this.btnMesa10.Location = new Point((this.btnMesa1.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa11.Location.Y));
                //this.btnMesa9.Location = new Point((this.btnMesa2.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa11.Location.Y));
                //this.btnMesa8.Location = new Point((this.btnMesa3.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa11.Location.Y));
                //this.btnMesa7.Location = new Point((this.btnMesa4.Location.X + this.btnMesa2.Width + ((this.panel1.Width - (this.btnMesa1.Width + this.btnMesa2.Width + this.btnMesa3.Width + this.btnMesa4.Width + this.btnMesa6.Width)) / 6)), (this.btnMesa11.Location.Y)); 


            }
            catch (Exception)
            {
            }
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {
            }
        }

        private void btnMesa11_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 11;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa10_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 10;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa3_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 3;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa9_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 9;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa4_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 4;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa8_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 8;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa6_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 6;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa7_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 7;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa5_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 5;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa12_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 12;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa13_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 13;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa14_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 14;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa15_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 15;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa16_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 16;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa17_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 17;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa18_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 18;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.RolId != 2)
                {
                    this.panel1.Visible = false;

                    InformacionGeneral info = new InformacionGeneral(this);
                    info.TopLevel = false;
                    info.Parent = splitContainer1.Panel1;
                    info.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurante_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }
                this.panel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la información del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnCajaDiaria_Click(object sender, EventArgs e)
        {
            try
            {
                CajaDiaria_Mod info = new CajaDiaria_Mod(this);
                info.TopLevel = false;
                info.Parent = splitContainer1.Panel1;
                info.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFamilias_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.RolId != 2)
                {
                    Familia_Mod fam = new Familia_Mod(this);
                    fam.TopLevel = false;
                    fam.Parent = splitContainer1.Panel1;
                    fam.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.RolId != 2)
                {
                    Articulo_Mod art = new Articulo_Mod(this);
                    art.TopLevel = false;
                    art.Parent = splitContainer1.Panel1;
                    art.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.RolId != 2)
                {
                    Articulo_Mantenimiento art = new Articulo_Mantenimiento(this);
                    art.TopLevel = false;
                    art.Parent = splitContainer1.Panel1;
                    art.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los artículos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificaArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.RolId != 2)
            {
                this.btnArticulos.PerformClick();
            }
        }

        private void crearFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.RolId != 2)
            {
                Familia_Mantenimiento fam = new Familia_Mantenimiento(this);
                fam.TopLevel = false;
                fam.Parent = splitContainer1.Panel1;
                fam.Show();
            }
        }

        private void modificarFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.RolId != 2)
            {
                this.btnFamilias.PerformClick();
            }
        }

        private void btnMesa12_Click_1(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 12;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void reportesDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.RolId != 2)
                {
                    Reportes_Mod info = new Reportes_Mod(this);
                    info.TopLevel = false;
                    info.Parent = splitContainer1.Panel1;
                    info.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reportesDeCajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                CajaDiaria_Mod info = new CajaDiaria_Mod(this);
                info.TopLevel = false;
                info.Parent = splitContainer1.Panel1;
                info.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.RolId != 2)
                {
                    Administrador admin = new Administrador(this);
                    admin.TopLevel = false;
                    admin.Parent = splitContainer1.Panel1;
                    admin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener el módulo de administrador: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void eliminarMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 15;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void entradaSalidaPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Marca_Mod marc = new Marca_Mod();

            marc.Show();
        }

        private void Configuracion_Hacienda(object sender, EventArgs e)
        {

            Inforacion_Hacienda pag_Info = new Inforacion_Hacienda();
            pag_Info._owner = this;
            pag_Info.TopLevel = false;
            pag_Info.Parent = this;
            pag_Info.Show();

        }


        private void reportesDeEntradaYSalidaPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login.RolId != 2)
                {
                    Marca_Reportes MarcaRep = new Marca_Reportes(this);
                    MarcaRep.TopLevel = false;
                    MarcaRep.Parent = splitContainer1.Panel1;
                    MarcaRep.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }




        private void btnMesa19_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 19;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa20_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 20;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }




        private void btnMesa22_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 22;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa23_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 23;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa24_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 24;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa25_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 25;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa26_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 26;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa27_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 27;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa28_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 28;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa29_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 29;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa30_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 30;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa31_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 31;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }



        private void btnMesa32_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 32;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();

        }

        private void btnMesa33_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 33;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa34_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 34;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa35_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 35;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa36_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 36;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa37_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 37;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa38_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 38;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa39_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 39;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa40_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 40;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa41_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 41;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa42_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 42;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa43_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 43;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnMesa21_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 21;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa44_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 44;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa45_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 45;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa46_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 46;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa47_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 47;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa48_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 48;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa49_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 49;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa50_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 50;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa51_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 51;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa52_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 52;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa53_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 53;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();

        }

        private void btnMesa54_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 54;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa55_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 55;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa56_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 56;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa57_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 57;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa58_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 58;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa59_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 59;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa60_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 60;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa61_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 61;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }



        private void btnMesa62_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 62;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa63_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 63;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa64_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 64;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa65_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 65;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa66_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 66;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa67_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 67;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa68_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 68;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa79_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 79;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa69_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 69;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa70_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 70;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa71_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 71;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa72_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 72;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa73_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 73;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa74_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 74;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa75_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 75;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa76_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 76;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa77_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 77;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void btnMesa78_Click(object sender, EventArgs e)
        {
            Menu_Orden menu = new Menu_Orden(this);
            menu.MesaActual = 78;
            menu.TopLevel = false;
            menu.Parent = splitContainer1.Panel1;
            menu.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void reportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reporte_Electronico pag_Reporte = new Reporte_Electronico();
            pag_Reporte._owner = this;
            pag_Reporte.TopLevel = false;
            pag_Reporte.Parent = this;
            pag_Reporte.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimiento_Persona usuario = new Mantenimiento_Persona(this);
            usuario.TopLevel = false;
            usuario.Parent = this;
            usuario.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            

        }

        private void asd_Click(object sender, EventArgs e)
        {
            Inforacion_Hacienda pag_Info = new Inforacion_Hacienda();
            pag_Info._owner = this;
            pag_Info.TopLevel = false;
            pag_Info.Parent = this;
            pag_Info.Show();
        }
    }
}