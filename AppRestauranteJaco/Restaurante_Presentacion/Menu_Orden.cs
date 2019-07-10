using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Restaurante_Presentacion
{
    public partial class Menu_Orden : Form
    {
        public Principal _owner;

        Login _login;

        Restaurante_BL.Metodos precios_genericos = new Restaurante_BL.Metodos();
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();
        Restaurante_BL.ModuloPrincipal objModulo = new Restaurante_BL.ModuloPrincipal();
        Restaurante_BL.CComandaCocina objComandaCocina = new Restaurante_BL.CComandaCocina();
        Restaurante_BL.CComandaBar objComandaBar = new Restaurante_BL.CComandaBar();
        String respuesta_tipo = "";
        public int MesaActual = 0;
        public int AccionLicor = 0;
        public int AccionCocteles = 0;
        public int AccionBocas = 0;
        public int AccionPlatillos = 0;
        string precio = "";

        Restaurante_BL.Lista_Orden objOrden = new Restaurante_BL.Lista_Orden();

        Restaurante_BL.Familia objFamilia = new Restaurante_BL.Familia();

        Restaurante_BL.Ticket objTicket = new Restaurante_BL.Ticket();

        Restaurante_DAL.BaseDatosDataContext db = null;

        public string BotonSeleccion = string.Empty;

        public string BotonObservacion = string.Empty;

        public Menu_Orden(Principal owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Principal_Load(sender, e);
        }

        private void ResizeLoad()
        {
            try
            {
                var width = this.Width;
                var height = (this.Height - 85) / 5;

                this.tls_Usuario.Width = ((this.Width / 9) * 2) + 15;
                this.tlsNombreRest.Width = ((this.Width / 9) * 3) - 32;
                this.tlsWebHtml.Width = (this.Width / 9) * 2;
                this.tlsFecha.Width = (this.Width / 9);
                this.tlsHora.Width = (this.Width / 9);

                this.panelCompleto.Location = new Point(((this.Width - this.panelCompleto.Width) / 2), 0);
            }
            catch (Exception)
            {
            }
        }

        public void CierraConsumoPanel()
        {
            try
            {
                this.btnCerrarPanel.PerformClick();
            }
            catch (Exception)
            {
            }
        }

        public void Menu_Orden_Load(object sender, EventArgs e)
        {
            try
            {

                this.ResizeLoad();

                this.lblTitulo.Text = "Atendiendo a la mesa: " + MesaActual.ToString();

                //this.btnLicores_Click(sender, e);

                this.CargoConsumoActual();

                this.SumaCompra();

                //this.gbLicores.Visible = true;
                this.ObtieneInfoInferior();

                this.ObtengoFamilias();

                this.ApagoGroupBox();//

                this.cmbTerminos.Text = "ROJO";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al generar el menú: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtengoFamilias()
        {
            try
            {
                this.OpenConn();

                var bus = from x in db.Familias
                          where x.Activo == true
                          select x;

                int locx = 6;
                int locy = 5;

                foreach (var item in bus)
                {

                    Button btnFoto = new Button();
                    {
                        btnFoto.Name = item.Id.ToString();
                        btnFoto.Height = 110;
                        btnFoto.Width = 110;
                        btnFoto.Location = new Point(locx, locy);

                        Image imga = ByteArrayToImage(item.Foto.ToArray());

                        btnFoto.BackgroundImage = null;
                        btnFoto.BackgroundImage = ByteArrayToImage(item.Foto.ToArray());
                        btnFoto.BackgroundImageLayout = ImageLayout.Stretch;
                        btnFoto.FlatStyle = FlatStyle.Flat;
                        btnFoto.BackColor = Color.Transparent;

                        btnFoto.Click += new EventHandler(btnObtengoBotonFamilia);
                    }
                    this.panelFamilias.Controls.Add(btnFoto);
                    Label lbl = new Label();
                    {
                        lbl.Height = 20;
                        lbl.Width = 110;
                        lbl.Text = item.Descripcion.ToUpper();
                        lbl.Font = new Font(lbl.Font.FontFamily, 10, lbl.Font.Style | FontStyle.Regular);
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Location = new Point(locx, locy + 112);
                    }
                    this.panelFamilias.Controls.Add(lbl);


                    locy += 135;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las familias del restaurante: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnObtengoBotonFamilia(object sender, EventArgs e)
        {
            try
            {
                //******************************************************************************

               


                //******************************************************************************
              
                this.panelprueba.Controls.Clear();

                Button btn = (Button)sender;

                string id = btn.Name.ToString();

                this.OpenConn();

                var bus = from x in db.ObtieneArticulos
                          where Convert.ToInt32(x.FamiliaId) == Convert.ToInt32(id)
                          select x;

                var guarnicion = from x in db.Familias
                                 where x.Id == Convert.ToInt32(id)
                                 select x;

                int loc = 15;
                int locxexterna = 655;
              //  MessageBox.Show("antes del checkbox");
               // MessageBox.Show("EMPEZAMOS ");
                foreach (var item in bus)
                {
                  //  MessageBox.Show("Nombre " + item.Nombre);

                    int locx = 10;
                    CheckBox chk = new CheckBox();
                    {

                        chk.Name = item.Id.ToString();
                        chk.Height = 40;
                        chk.Width = 340;
                        chk.Font = new Font(chk.Font.FontFamily, 13, chk.Font.Style | FontStyle.Regular);
                        chk.Text = item.Nombre + " - " + item.Costo.ToString();
                        chk.Location = new Point(locx, loc);
                    }
                //    MessageBox.Show("ANTES DEL LABEL");
                    this.panelprueba.Controls.Add(chk);
                    Label lbl = new Label();
                    {
                        lbl.Height = 30;
                        lbl.Width = 75;
                        lbl.Text = "Cantidad:";
                        lbl.Font = new Font(lbl.Font.FontFamily, 10, lbl.Font.Style | FontStyle.Regular);
                        lbl.Location = new Point(locx + 350, loc + 10);
                    }
                    this.panelprueba.Controls.Add(lbl);
                  //  MessageBox.Show("ANTES DEL NUMERICUPDOWN");
                    NumericUpDown nup = new NumericUpDown();
                    {
                        nup.Name = "nup" + item.Id.ToString();
                        nup.Width = 40;
                        nup.Font = new Font(nup.Font.FontFamily, 14, nup.Font.Style | FontStyle.Bold);
                        nup.Location = new Point(locx + 425, loc + 4);
                    }
                    this.panelprueba.Controls.Add(nup);
                   // MessageBox.Show("ANTES DEL BUTTON mas Y MENOS");
                    Button btnMas = new Button();
                    {
                        btnMas.Name = "btnMas" + item.Id.ToString();
                        btnMas.Width = 30;
                        btnMas.Height = 30;
                        btnMas.Text = "+";
                        btnMas.Location = new Point(locx + 475, loc + 2);
                        btnMas.Font = new Font(btnMas.Font.FontFamily, 16, btnMas.Font.Style | FontStyle.Bold);
                        btnMas.TextAlign = ContentAlignment.MiddleCenter;
                        btnMas.Click += new EventHandler(btnAumentaOrden);
                    }
                    this.panelprueba.Controls.Add(btnMas);
                    Button btnMenos = new Button();
                    {
                        btnMenos.Name = "btnMenos" + item.Id.ToString();
                        btnMenos.Width = 30;
                        btnMenos.Height = 30;
                        btnMenos.Text = "-";
                        btnMenos.Location = new Point(locx + 515, loc + 2);
                        btnMenos.Font = new Font(btnMenos.Font.FontFamily, 16, btnMenos.Font.Style | FontStyle.Bold);
                        btnMenos.TextAlign = ContentAlignment.MiddleCenter;
                        btnMenos.Click += new EventHandler(btnRestaOrden);
                    }
                    this.panelprueba.Controls.Add(btnMenos);
                   // MessageBox.Show("ANTES DEL BOTON DE INFO");
                    Button btnInfo = new Button();
                    {
                        btnInfo.Name = "btnInfo" + item.Id.ToString();
                        btnInfo.Width = 50;
                        btnInfo.Height = 30;
                        btnInfo.Text = "INFO";
                        btnInfo.Location = new Point(locx + 555, loc + 2);
                        btnInfo.Click += new EventHandler(btnInformacion);
                    }
                    this.panelprueba.Controls.Add(btnInfo);
                   // MessageBox.Show("ANTES DEL BOTON DE OBSERVACIONES");
                    Button btnObservaciones = new Button();
                    {
                        btnObservaciones.Name = "btnObservaciones" + item.Id.ToString();
                        btnObservaciones.Width = 45;
                        btnObservaciones.Height = 30;
                        btnObservaciones.Location = new Point(locx + 615, loc + 2);
                        btnObservaciones.Text = "OBS";
                        btnObservaciones.Click += new EventHandler(btnMuestraObservaciones);
                    }
                    this.panelprueba.Controls.Add(btnObservaciones);

                    locxexterna = 680;

                    if (guarnicion.First().Guarnicion == true)
                    {
                        Button btnGuarniciones = new Button();
                        {
                            btnGuarniciones.Name = "btnGuarniciones" + item.Id.ToString();
                            btnGuarniciones.Width = 50;
                            btnGuarniciones.Height = 30;
                            btnGuarniciones.Text = "SEL";
                            btnGuarniciones.Location = new Point(locx + 670, loc + 2);
                            btnGuarniciones.Click += new EventHandler(btnMuestraGuarniciones);
                        }
                        this.panelprueba.Controls.Add(btnGuarniciones);

                        locxexterna = 740;
                    }

                    loc += 50;

                }

              //  MessageBox.Show("ANTES DE BTNORDENAR");
                Button btnor = new Button();
                {
                    btnor.Name = "btnOrdenar" + id;
                    btnor.Height = 40;
                    btnor.Width = 90;
                    btnor.Text = "ORDENAR";
                    btnor.Location = new Point(locxexterna, 15);
                    btnor.Click += new EventHandler(btnOrdenar_onclick);
                }
                this.panelprueba.Controls.Add(btnor);


            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al disminuir la orden: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void btnMuestraObservaciones(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;

                this.BotonSeleccion = btn.Name;

                this.panelObservaciones.Visible = true;

                this.panelObservaciones.Location = new Point((this.groupBox1.Location.X + (this.groupBox1.Width - this.panelObservaciones.Width) / 2), 30);

                this.panelObservaciones.BringToFront();

            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al obtener la información del producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //

        void btnMuestraGuarniciones(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;

                this.BotonSeleccion = btn.Name;

                this.panelGuarniciones.Visible = true;

                this.panelGuarniciones.Location = new Point((this.groupBox1.Location.X + (this.groupBox1.Width - this.panelGuarniciones.Width) / 2), 30);

                this.panelGuarniciones.BringToFront();

                var bus = from a in db.Articulo
                          join f in db.Familias on a.FamiliaId equals f.Id
                          where f.EsGuarnicion == true
                          select a;

                int locx = 8;
                int locy = 8;

                foreach (var item in bus)
                {

                    CheckBox chk = new CheckBox();
                    {

                        chk.Name = item.Id.ToString();
                        chk.Height = 40;
                        chk.Width = 350;
                        chk.Font = new Font(chk.Font.FontFamily, 13, chk.Font.Style | FontStyle.Regular);
                        chk.Text = item.Nombre;
                        chk.Location = new Point(locx, locy);
                        chk.Click += new EventHandler(btnCuentaGuarniciones_onclick);
                    }
                    this.panelGuarnicionesMostrar.Controls.Add(chk);
                    //Label lbl = new Label();
                    //{
                    //    lbl.Height = 30;
                    //    lbl.Width = 250;
                    //    lbl.Text = item.Nombre;
                    //    lbl.Font = new Font(lbl.Font.FontFamily, 10, lbl.Font.Style | FontStyle.Regular);
                    //    lbl.Location = new Point(locx+50, locy + 10);
                    //}
                    //this.panelGuarnicionesMostrar.Controls.Add(lbl);

                    locy += 30;
                }
            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al obtener la información del producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //
        void btnCuentaGuarniciones_onclick(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                foreach (Control c in panelGuarnicionesMostrar.Controls)
                {
                    if (c is CheckBox)
                    {
                        if (((CheckBox)c).Checked == true)
                        {
                            x++;
                            if (x == 3)
                            {
                                ((CheckBox)c).Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al ordenar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void btnOrdenar_onclick(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panelprueba.Controls)
                {
                    if (c is CheckBox)
                    {
                        if (((CheckBox)c).Checked == true)
                        {
                            string id = c.Name.ToString();

                            this.objOrden.CodigoArticulo = Convert.ToInt64(id);

                          

                            this.objOrden.MesaId = MesaActual;

                            NumericUpDown nup = (NumericUpDown)this.Controls.Find("nup" + id, true).FirstOrDefault();

                            if (nup.Value == 0)
                            {
                                MessageBox.Show("Ingrese la cantidad de productos a ordenar necesarios!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            this.objOrden.Cantidad = Convert.ToInt32(nup.Value);

                            Button btn = (Button)this.panelprueba.Controls.Find("btnGuarniciones" + id.ToString(), true).FirstOrDefault();

                            if (btn != null)
                            {

                                if (btn.Text != "SEL")
                                {
                                    this.objOrden.Detalle = btn.Text;
                                }
                                else
                                {
                                    this.objOrden.Detalle = string.Empty;
                                }


                                //this.objOrden.Observaciones=

                                btn.Text = "SEL";

                               
                            }
                            else
                            {
                                //this.objOrden.IngresoTemporalConsumo();

                                this.objOrden.Detalle = string.Empty;
                            }

                            Button btnobservaciones = (Button)this.panelprueba.Controls.Find("btnObservaciones" + id.ToString(), true).FirstOrDefault();

                            if (btnobservaciones != null)
                            {
                                if (btnobservaciones.Text != "OBS")
                                {
                                    this.objOrden.Observaciones = btnobservaciones.Text;
                                }
                                else
                                {
                                    this.objOrden.Observaciones = string.Empty;
                                }


                                btnobservaciones.Text = "OBS";
                            }
                            else
                            {
                                this.objOrden.Observaciones = string.Empty;
                            }

                            //aqui la jugada tosty
                            //**************************************************
                            // this.objOrden.CodigoArticulo
                            //precios_genericos
                         
                           

                           String respuesta = precios_genericos.validar_tipo(Convert.ToInt32(this.objOrden.CodigoArticulo));
                           respuesta_tipo = respuesta;

                           if (respuesta == "1" || respuesta == "2")
                           {
                               if (respuesta == "1")
                               {
                                 //  MessageBox.Show("SOY UN PRECIO NORMAL");

                               }

                               if (respuesta == "2")
                               {
                                   
                                //   MessageBox.Show("SOY UN PRECIO GENERICO");
                                    precio="";
                                   precio = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio del producto genérico",
               "Productos genéricos", "", 400, 270);
                                 
                                   try
                                   {
                                       decimal numero = Convert.ToDecimal(precio);
                                       MessageBox.Show("Precio " + precio, "Precios Genéricos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                   }
                                   catch (Exception error)
                                   {
                                       MessageBox.Show("Solo ingrese numeros porfavor","Solo Numeros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                       return;
                                   }
                                   
                                   if (precio == "")
                                   {
                                       return;
                                   }

                              

                               

                                   else
                                   {
                                       //respuesta = precios_genericos.obtener_precio_genericos(precio, Convert.ToInt32(this.objOrden.CodigoArticulo));
                                       //if (respuesta != "1")
                                       //{
                                       //    MessageBox.Show(respuesta.ToString());
                                       //}

                                   }
                               }
                           }
                           else
                           {

                               MessageBox.Show(respuesta.ToString());
                           }
                         

                            //***************************************************
                           //this.objOrden.MesaId = MesaActual;
                           if (respuesta_tipo == "1")
                           {
                               //sacar precio
                               String costo = precios_genericos.sacar_precio(Convert.ToInt32(this.objOrden.CodigoArticulo));
                               this.objOrden.Precio = Convert.ToDecimal(costo);




                           }

                           if (respuesta_tipo == "2")
                           {
                               this.objOrden.Precio = Convert.ToDecimal(precio);
                           }

                            this.objOrden.IngresoTemporalConsumo();

                            this.CargoConsumoActual();

                            ((CheckBox)c).Checked = false;

                            nup.Value = 0;

                            this.SumaCompra();
                          

                        }//check marcdo
                    }
                } // fin del forii
                //aqui volver todo a la normalidad
                
            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al ordenar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ObtieneInfoInferior()
        {
            try
            {
                this.objInformacionGeneral.ObtengoInformacionRestaurante();

                this.tls_Usuario.Text = "Usuario: " + Login.LoginUsuarioFinal.ToString().ToUpper();

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

        public void CargoConsumoActual()
        {
            try
            {
                this.objOrden.MesaId = MesaActual;
                this.lblFecha.Text = "Fecha: " + System.DateTime.Now.ToShortDateString();
                this.lblHora.Text = "Hora: " + System.DateTime.Now.ToString("hh:mm");
                this.lblMesa.Text = "Mesa: " + MesaActual.ToString();
                this.objOrden.ObtengoConsumoActual(this.dgvConsumoActual);

                this.objOrden.ObtengoConsumoActualHora();

                this.lblTimerLabel.Text = this.objOrden.Hora.ToString("hh:mm:ss");
                this.timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener el consumo actual: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Menu_Orden_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        //private void btnLicores_Click(object sender, EventArgs e)
        //{            
        //    try
        //    {
        //        this.ApagoGroupBox();

        //        this.AccionBocas = 0;
        //        this.AccionPlatillos = 0;
        //        this.AccionCocteles = 0;

        //        this.objOrden.ObtengoLicores();

        //        int Limite = this.objOrden.ListaLicor.Count;

        //        this.gbLicores.Visible = true;

        //        if (AccionLicor == 0)
        //        {
        //            int loc = 15;

        //            foreach (var item in this.objOrden.ListaLicor)
        //            {
        //                CheckBox chk = new CheckBox();
        //                {

        //                    chk.Name = item.Substring(0, 3).ToString();
        //                    chk.Height = 40;
        //                    chk.Width = 250;
        //                    chk.Font = new Font(chk.Font.FontFamily, 13, chk.Font.Style | FontStyle.Regular);
        //                    chk.Text = item.Substring(3, item.Length - 3).ToString();
        //                    chk.Location = new Point(20, loc);
        //                }
        //                this.panellicor.Controls.Add(chk);
        //                Label lbl = new Label();
        //                {
        //                    lbl.Height = 30;
        //                    lbl.Width = 80;
        //                    lbl.Text = "Cantidad:";
        //                    lbl.Font = new Font(lbl.Font.FontFamily, 10, lbl.Font.Style | FontStyle.Regular);
        //                    lbl.Location = new Point(340, loc + 10);
        //                }
        //                this.panellicor.Controls.Add(lbl);
        //                NumericUpDown nup = new NumericUpDown();
        //                {
        //                    nup.Name = "nup" + item.Substring(0, 3).ToString();
        //                    nup.Width = 40;
        //                    nup.Font = new Font(nup.Font.FontFamily, 14, nup.Font.Style | FontStyle.Bold);
        //                    nup.Location = new Point(420, loc + 4);
        //                }
        //                this.panellicor.Controls.Add(nup);
        //                Button btnMas = new Button();
        //                {
        //                    btnMas.Name = "btnMas" + item.Substring(0, 3).ToString();
        //                    btnMas.Width = 30;
        //                    btnMas.Height = 30;
        //                    btnMas.Text = "+";
        //                    btnMas.Location = new Point(480, loc + 2);
        //                    btnMas.Font = new Font(btnMas.Font.FontFamily, 16, btnMas.Font.Style | FontStyle.Bold);
        //                    btnMas.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMas.Click += new EventHandler(btnAumentaOrden);
        //                }
        //                this.panellicor.Controls.Add(btnMas);
        //                Button btnMenos = new Button();
        //                {
        //                    btnMenos.Name = "btnMenos" + item.Substring(0, 3).ToString();
        //                    btnMenos.Width = 30;
        //                    btnMenos.Height = 30;
        //                    btnMenos.Text = "-";
        //                    btnMenos.Location = new Point(520, loc + 2);
        //                    btnMenos.Font = new Font(btnMenos.Font.FontFamily, 16, btnMenos.Font.Style | FontStyle.Bold);
        //                    btnMenos.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMenos.Click += new EventHandler(btnRestaOrden);
        //                }
        //                this.panellicor.Controls.Add(btnMenos);
        //                Button btnInfo = new Button();
        //                {
        //                    btnInfo.Name = "btnInfo" + item.Substring(0, 3).ToString();
        //                    btnInfo.Width = 70;
        //                    btnInfo.Height = 30;
        //                    btnInfo.Text = "Información";
        //                    btnInfo.Location = new Point(560, loc + 2);
        //                    btnInfo.Click += new EventHandler(btnInformacion);
        //                }
        //                this.panellicor.Controls.Add(btnInfo);
        //                loc += 40;
        //            }

        //            Button btn = new Button();
        //            {
        //                btn.Name = "btnOrdenarLicores";
        //                btn.Height = 40;
        //                btn.Width = 120;
        //                btn.Text = "ORDENAR";
        //                btn.Location = new Point(640, 15);
        //                btn.Click += new EventHandler(btnOrdenarLicores_onclick);
        //            }
        //            this.panellicor.Controls.Add(btn);
        //            //this.panellicor.Height = loc + 30;
        //            //this.gbLicores.Height = loc + 30;
        //            AccionLicor = 1;
        //        }
        //        else
        //        {
        //            AccionLicor = 0;
        //            this.gbLicores.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al obtener los licores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnCocteles_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ApagoGroupBox();

        //        this.AccionBocas = 0;
        //        this.AccionPlatillos = 0;
        //        this.AccionLicor = 0;

        //        this.objOrden.ObtengoCoctel();

        //        int Limite = this.objOrden.ListaLicor.Count;

        //        this.gbCocteles.Visible = true;

        //        if (AccionCocteles == 0)
        //        {
        //            int loc = 15;

        //            foreach (var item in this.objOrden.ListaCoctel)
        //            {
        //                CheckBox chk = new CheckBox();
        //                {

        //                    chk.Name = item.Substring(0, 3).ToString();
        //                    chk.Height = 40;
        //                    chk.Width = 250;
        //                    chk.Font = new Font(chk.Font.FontFamily, 13, chk.Font.Style | FontStyle.Regular);
        //                    chk.Text = item.Substring(3, item.Length - 3).ToString();
        //                    chk.Location = new Point(20, loc);
        //                }
        //                this.panelCocteles.Controls.Add(chk);
        //                Label lbl = new Label();
        //                {
        //                    lbl.Height = 30;
        //                    lbl.Width = 80;
        //                    lbl.Text = "Cantidad:";
        //                    lbl.Font = new Font(lbl.Font.FontFamily, 10, lbl.Font.Style | FontStyle.Regular);
        //                    lbl.Location = new Point(340, loc + 10);
        //                }
        //                this.panelCocteles.Controls.Add(lbl);
        //                NumericUpDown nup = new NumericUpDown();
        //                {
        //                    nup.Name = "nup" + item.Substring(0, 3).ToString();
        //                    nup.Width = 40;
        //                    nup.Font = new Font(nup.Font.FontFamily, 14, nup.Font.Style | FontStyle.Bold);
        //                    nup.Location = new Point(420, loc + 4);
        //                }
        //                this.panelCocteles.Controls.Add(nup);
        //                Button btnMas = new Button();
        //                {
        //                    btnMas.Name = "btnMas" + item.Substring(0, 3).ToString();
        //                    btnMas.Width = 30;
        //                    btnMas.Height = 30;
        //                    btnMas.Text = "+";
        //                    btnMas.Location = new Point(480, loc + 2);
        //                    btnMas.Font = new Font(btnMas.Font.FontFamily, 16, btnMas.Font.Style | FontStyle.Bold);
        //                    btnMas.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMas.Click += new EventHandler(btnAumentaOrden);
        //                }
        //                this.panelCocteles.Controls.Add(btnMas);
        //                Button btnMenos = new Button();
        //                {
        //                    btnMenos.Name = "btnMenos" + item.Substring(0, 3).ToString();
        //                    btnMenos.Width = 30;
        //                    btnMenos.Height = 30;
        //                    btnMenos.Text = "-";
        //                    btnMenos.Location = new Point(520, loc + 2);
        //                    btnMenos.Font = new Font(btnMenos.Font.FontFamily, 16, btnMenos.Font.Style | FontStyle.Bold);
        //                    btnMenos.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMenos.Click += new EventHandler(btnRestaOrden);
        //                }
        //                this.panelCocteles.Controls.Add(btnMenos);
        //                Button btnInfo = new Button();
        //                {
        //                    btnInfo.Name = "btnInfo" + item.Substring(0, 3).ToString();
        //                    btnInfo.Width = 70;
        //                    btnInfo.Height = 30;
        //                    btnInfo.Text = "Información";
        //                    btnInfo.Location = new Point(560, loc + 2);
        //                    btnInfo.Click += new EventHandler(btnInformacion);
        //                }
        //                this.panelCocteles.Controls.Add(btnInfo);
        //                loc += 40;
        //            }

        //            Button btn = new Button();
        //            {
        //                btn.Name = "btnOrdenarCocteles";
        //                btn.Height = 40;
        //                btn.Width = 120;
        //                btn.Text = "ORDENAR";
        //                btn.Location = new Point(640, 15);
        //                btn.Click += new EventHandler(btnOrdenarCocteles_onclick);
        //            }
        //            this.panelCocteles.Controls.Add(btn);

        //            //this.gbCocteles.Height = loc + 30;
        //            AccionCocteles = 1;
        //        }
        //        else
        //        {
        //            AccionCocteles = 0;
        //            this.gbCocteles.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al obtener los cocteles: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnBocas_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ApagoGroupBox();

        //        this.AccionLicor = 0;
        //        this.AccionPlatillos = 0;
        //        this.AccionCocteles = 0;

        //        this.objOrden.ObtengoBocas();

        //        int Limite = this.objOrden.ListaBocas.Count;

        //        this.gbBocas.Visible = true;

        //        if (AccionBocas == 0)
        //        {
        //            int loc = 15;

        //            foreach (var item in this.objOrden.ListaBocas)
        //            {
        //                CheckBox chk = new CheckBox();
        //                {

        //                    chk.Name = item.Substring(0, 3).ToString();
        //                    chk.Height = 40;
        //                    chk.Width = 250;
        //                    chk.Font = new Font(chk.Font.FontFamily, 13, chk.Font.Style | FontStyle.Regular);
        //                    chk.Text = item.Substring(3, item.Length - 3).ToString();
        //                    chk.Location = new Point(20, loc);
        //                }
        //                this.panelBocas.Controls.Add(chk);
        //                Label lbl = new Label();
        //                {
        //                    lbl.Height = 30;
        //                    lbl.Width = 80;
        //                    lbl.Text = "Cantidad:";
        //                    lbl.Font = new Font(lbl.Font.FontFamily, 10, lbl.Font.Style | FontStyle.Regular);
        //                    lbl.Location = new Point(340, loc + 10);
        //                }
        //                this.panelBocas.Controls.Add(lbl);
        //                NumericUpDown nup = new NumericUpDown();
        //                {
        //                    nup.Name = "nup" + item.Substring(0, 3).ToString();
        //                    nup.Width = 40;
        //                    nup.Font = new Font(nup.Font.FontFamily, 14, nup.Font.Style | FontStyle.Bold);
        //                    nup.Location = new Point(420, loc + 4);
        //                }
        //                this.panelBocas.Controls.Add(nup);
        //                Button btnMas = new Button();
        //                {
        //                    btnMas.Name = "btnMas" + item.Substring(0, 3).ToString();
        //                    btnMas.Width = 30;
        //                    btnMas.Height = 30;
        //                    btnMas.Text = "+";
        //                    btnMas.Location = new Point(480, loc + 2);
        //                    btnMas.Font = new Font(btnMas.Font.FontFamily, 16, btnMas.Font.Style | FontStyle.Bold);
        //                    btnMas.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMas.Click += new EventHandler(btnAumentaOrden);
        //                }
        //                this.panelBocas.Controls.Add(btnMas);
        //                Button btnMenos = new Button();
        //                {
        //                    btnMenos.Name = "btnMenos" + item.Substring(0, 3).ToString();
        //                    btnMenos.Width = 30;
        //                    btnMenos.Height = 30;
        //                    btnMenos.Text = "-";
        //                    btnMenos.Location = new Point(520, loc + 2);
        //                    btnMenos.Font = new Font(btnMenos.Font.FontFamily, 16, btnMenos.Font.Style | FontStyle.Bold);
        //                    btnMenos.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMenos.Click += new EventHandler(btnRestaOrden);
        //                }
        //                this.panelBocas.Controls.Add(btnMenos);
        //                Button btnInfo = new Button();
        //                {
        //                    btnInfo.Name = "btnInfo" + item.Substring(0, 3).ToString();
        //                    btnInfo.Width = 70;
        //                    btnInfo.Height = 30;
        //                    btnInfo.Text = "Información";
        //                    btnInfo.Location = new Point(560, loc + 2);
        //                    btnInfo.Click += new EventHandler(btnInformacion);
        //                }
        //                this.panelBocas.Controls.Add(btnInfo);
        //                loc += 40;
        //            }

        //            Button btn = new Button();
        //            {
        //                btn.Name = "btnOrdenarBocas";
        //                btn.Height = 40;
        //                btn.Width = 120;
        //                btn.Text = "ORDENAR";
        //                btn.Location = new Point(640, 15);
        //                btn.Click += new EventHandler(btnOrdenarBocas_onclick);
        //            }
        //            this.panelBocas.Controls.Add(btn);

        //            //this.gbBocas.Height = loc + 30;
        //            AccionBocas = 1;
        //        }
        //        else
        //        {
        //            AccionBocas = 0;
        //            this.gbBocas.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al obtener los licores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnPlatillos_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ApagoGroupBox();

        //        this.AccionLicor = 0;
        //        this.AccionBocas = 0;
        //        this.AccionCocteles = 0;

        //        this.objOrden.ObtengoPlatillos();

        //        int Limite = this.objOrden.ListaPlatillos.Count;

        //        this.gbPlatillos.Visible = true;

        //        if (AccionPlatillos == 0)
        //        {
        //            int loc =15;

        //            foreach (var item in this.objOrden.ListaPlatillos)
        //            {
        //                CheckBox chk = new CheckBox();
        //                {

        //                    chk.Name = item.Substring(0, 3).ToString();
        //                    chk.Height = 40;
        //                    chk.Width = 250;
        //                    chk.Font = new Font(chk.Font.FontFamily, 13, chk.Font.Style | FontStyle.Regular);
        //                    chk.Text = item.Substring(3, item.Length - 3).ToString();
        //                    chk.Location = new Point(20, loc);
        //                }
        //                this.panelPlatillos.Controls.Add(chk);
        //                Label lbl = new Label();
        //                {
        //                    lbl.Height = 30;
        //                    lbl.Width = 80;
        //                    lbl.Text = "Cantidad:";
        //                    lbl.Font = new Font(lbl.Font.FontFamily, 10, lbl.Font.Style | FontStyle.Regular);
        //                    lbl.Location = new Point(340, loc + 10);
        //                }
        //                this.panelPlatillos.Controls.Add(lbl);
        //                NumericUpDown nup = new NumericUpDown();
        //                {
        //                    nup.Name = "nup" + item.Substring(0, 3).ToString();
        //                    nup.Width = 40;
        //                    nup.Font = new Font(nup.Font.FontFamily, 14, nup.Font.Style | FontStyle.Bold);
        //                    nup.Location = new Point(420, loc + 4);
        //                }
        //                this.panelPlatillos.Controls.Add(nup);
        //                Button btnMas = new Button();
        //                {
        //                    btnMas.Name = "btnMas" + item.Substring(0, 3).ToString();
        //                    btnMas.Width = 30;
        //                    btnMas.Height = 30;
        //                    btnMas.Text = "+";
        //                    btnMas.Location = new Point(480, loc + 2);
        //                    btnMas.Font = new Font(btnMas.Font.FontFamily, 16, btnMas.Font.Style | FontStyle.Bold);
        //                    btnMas.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMas.Click += new EventHandler(btnAumentaOrden);
        //                }
        //                this.panelPlatillos.Controls.Add(btnMas);
        //                Button btnMenos = new Button();
        //                {
        //                    btnMenos.Name = "btnMenos" + item.Substring(0, 3).ToString();
        //                    btnMenos.Width = 30;
        //                    btnMenos.Height = 30;
        //                    btnMenos.Text = "-";
        //                    btnMenos.Location = new Point(520, loc + 2);
        //                    btnMenos.Font = new Font(btnMenos.Font.FontFamily, 16, btnMenos.Font.Style | FontStyle.Bold);
        //                    btnMenos.TextAlign = ContentAlignment.MiddleCenter;
        //                    btnMenos.Click += new EventHandler(btnRestaOrden);
        //                }
        //                this.panelPlatillos.Controls.Add(btnMenos);
        //                Button btnInfo = new Button();
        //                {
        //                    btnInfo.Name = "btnInfo" + item.Substring(0, 3).ToString();
        //                    btnInfo.Width = 70;
        //                    btnInfo.Height = 30;
        //                    btnInfo.Text = "Información";
        //                    btnInfo.Location = new Point(560, loc + 2);
        //                    btnInfo.Click += new EventHandler(btnInformacion);
        //                }
        //                this.panelPlatillos.Controls.Add(btnInfo);
        //                loc += 40;
        //            }

        //            Button btn = new Button();
        //            {
        //                btn.Name = "btnOrdenarPlatillos";
        //                btn.Height = 40;
        //                btn.Width = 120;
        //                btn.Text = "ORDENAR";
        //                btn.Location = new Point(640, 15);
        //                btn.Click += new EventHandler(btnOrdenarPlatillos_onclick);
        //            }
        //            this.panelPlatillos.Controls.Add(btn);

        //            //this.gbPlatillos.Height = loc + 30;
        //            AccionPlatillos = 1;
        //        }
        //        else
        //        {
        //            AccionPlatillos = 0;
        //            this.gbPlatillos.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hubo un inconveniente al obtener los platillos: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //void btnOrdenarLicores_onclick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (Control c in panellicor.Controls)
        //        {
        //            if (c is CheckBox)
        //            {
        //                if (((CheckBox)c).Checked== true)
        //                {
        //                    string id = c.Name.Substring(c.Name.ToString().Length - 3, 3).ToString();

        //                    this.objOrden.CodigoArticulo = Convert.ToInt64(id);

        //                    this.objOrden.MesaId = MesaActual;

        //                    NumericUpDown nup = (NumericUpDown)this.Controls.Find("nup" + id, true).FirstOrDefault();

        //                    if (nup.Value == 0)
        //                    {
        //                        MessageBox.Show("Ingrese la cantidad de bebidas necesarias!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        return;
        //                    }

        //                    this.objOrden.Cantidad = Convert.ToInt32(nup.Value);

        //                    this.objOrden.IngresoTemporalConsumo();

        //                    this.CargoConsumoActual();

        //                    ((CheckBox)c).Checked = false;

        //                    nup.Value = 0;

        //                    this.SumaCompra();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!(ex is System.InvalidCastException))
        //        {
        //            MessageBox.Show("Hubo un inconveniente al ordenar los licores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //void btnOrdenarCocteles_onclick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (Control c in panelCocteles.Controls)
        //        {
        //            if (c is CheckBox)
        //            {                       
        //                if (((CheckBox)c).Checked == true)
        //                {
        //                    string id = c.Name.Substring(c.Name.ToString().Length - 3, 3).ToString();

        //                    this.objOrden.CodigoArticulo = Convert.ToInt64(id);

        //                    this.objOrden.MesaId = MesaActual;

        //                    NumericUpDown nup = (NumericUpDown)this.Controls.Find("nup" + id, true).FirstOrDefault();

        //                    if (nup.Value == 0)
        //                    {
        //                        MessageBox.Show("Ingrese la cantidad de cócteles necesarios!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        return;
        //                    }

        //                    this.objOrden.Cantidad = Convert.ToInt32(nup.Value);

        //                    this.objOrden.IngresoTemporalConsumo();

        //                    this.CargoConsumoActual();

        //                    ((CheckBox)c).Checked = false;

        //                    nup.Value = 0;

        //                    this.SumaCompra();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!(ex is System.InvalidCastException))
        //        {
        //            MessageBox.Show("Hubo un inconveniente al ordenar los cocteles: " + ex.InnerException, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //void btnOrdenarBocas_onclick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (Control c in this.panelBocas.Controls)
        //        {
        //            if (c is CheckBox)
        //            {
        //                if (((CheckBox)c).Checked == true)
        //                {
        //                    string id = c.Name.Substring(c.Name.ToString().Length - 3, 3).ToString();

        //                    this.objOrden.CodigoArticulo = Convert.ToInt64(id);

        //                    this.objOrden.MesaId = MesaActual;

        //                    NumericUpDown nup = (NumericUpDown)this.Controls.Find("nup" + id, true).FirstOrDefault();

        //                    if (nup.Value == 0)
        //                    {
        //                        MessageBox.Show("Ingrese la cantidad de bocas necesarias!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        return;
        //                    }

        //                    this.objOrden.Cantidad = Convert.ToInt32(nup.Value);

        //                    this.objOrden.IngresoTemporalConsumo();

        //                    this.CargoConsumoActual();

        //                    ((CheckBox)c).Checked = false;

        //                    nup.Value = 0;

        //                    this.SumaCompra();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!(ex is System.InvalidCastException))
        //        {
        //            MessageBox.Show("Hubo un inconveniente al ordenar los licores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //void btnOrdenarPlatillos_onclick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (Control c in this.panelPlatillos.Controls)
        //        {
        //            if (c is CheckBox)
        //            {
        //                if (((CheckBox)c).Checked == true)
        //                {
        //                    string id = c.Name.Substring(c.Name.ToString().Length - 3, 3).ToString();

        //                    this.objOrden.CodigoArticulo = Convert.ToInt64(id);

        //                    this.objOrden.MesaId = MesaActual;

        //                    NumericUpDown nup = (NumericUpDown)this.Controls.Find("nup" + id, true).FirstOrDefault();

        //                    if (nup.Value == 0)
        //                    {
        //                        MessageBox.Show("Ingrese la cantidad de platillos necesarias!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        return;
        //                    }

        //                    this.objOrden.Cantidad = Convert.ToInt32(nup.Value);

        //                    this.objOrden.IngresoTemporalConsumo();

        //                    this.CargoConsumoActual();

        //                    ((CheckBox)c).Checked = false;

        //                    nup.Value = 0;

        //                    this.SumaCompra();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!(ex is System.InvalidCastException))
        //        {
        //            MessageBox.Show("Hubo un inconveniente al ordenar los licores: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void dgvConsumoActual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.dgvConsumoActual.Columns["Eliminar"].Index)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la orden?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        dgvConsumoActual.Columns[0].Visible = true;
                        this.objOrden.CodigoArticulo = Convert.ToInt64(this.dgvConsumoActual.Rows[e.RowIndex].Cells[0].Value.ToString());
                        dgvConsumoActual.Columns[0].Visible = false;
                        this.objOrden.MesaId = this.MesaActual;
                        this.objOrden.EliminoOrden();
                        this.CargoConsumoActual();
                        this.SumaCompra();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnAumentaOrden(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;

                string id = btn.Name.Substring(btn.Name.ToString().Length - 3, 3).ToString();

                NumericUpDown nup = (NumericUpDown)this.Controls.Find("nup" + id, true).FirstOrDefault();

                nup.Value = nup.Value + 1;
            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al aumentar la orden: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void btnRestaOrden(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;

                string id = btn.Name.Substring(btn.Name.ToString().Length - 3, 3).ToString();

                NumericUpDown nup = (NumericUpDown)this.Controls.Find("nup" + id, true).FirstOrDefault();

                if (nup.Value > 0)
                {
                    nup.Value = nup.Value - 1;
                }
            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al disminuir la orden: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void btnInformacion(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;

                string id = btn.Name.Substring(btn.Name.ToString().Length - 3, 3).ToString();

                this.objOrden.ObtengoDescripcionSubfamilia(Convert.ToInt32(id));

                MessageBox.Show(this.objOrden.DescripcionSubfamilia.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al obtener la información del producto: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ApagoGroupBox()
        {
            //this.gbLicores.Visible = false;
            //this.gbCocteles.Visible = false;
            //this.gbBocas.Visible = false;
            //this.gbPlatillos.Visible = false;
        }

        private void SumaCompra()
        {
            try
            {
                decimal total = 0;

                foreach (DataGridViewRow item in dgvConsumoActual.Rows)
                {
                    total = total + Convert.ToDecimal((string)(item.Cells["Precio"]).Value.ToString());
                }
                this.lblTotalCompra.Text = string.Empty;

                this.lblTotalCompra.Text = "Total: " + total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al sumar la compra: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar regresar a la pantalla principal: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.objModulo.ObtieneCajaDiaria() == false)
                {
                    return;
                }

                Facturar objFacturar = new Facturar(this);
                objFacturar.MesaActual = Convert.ToInt32(MesaActual);
                objFacturar.TopLevel = false;
                objFacturar.Parent = this;
                objFacturar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar facturar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea cerrar la sesión?", "Cierre de sesión", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _login.Login_Load(sender, e);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar cerrar la sesión: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_VerOrden_Click(object sender, EventArgs e)
        {
            try
            {
                this.panelConsumido.Visible = true;

                this.panelConsumido.BringToFront();

                this.panelConsumido.Location = new Point(0, 0);

                this.panelConsumido.Width = this.groupBox1.Width;

                this.panelConsumido.Height = this.groupBox1.Height;
            }
            catch (Exception)
            {

            }
        }

        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            try
            {
                this.panelConsumido.Visible = false;
            }
            catch (Exception)
            {

            }
        }

        private void Menu_Orden_Resize(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.objFamilia.CreoPanel(panelFamilias);

        }

        //private void buttonStoreImageToDb_Click(object sender, EventArgs e)
        //{
        //    // Open the DataContext
        //    Database1 db = new Database1("Data Source=Database1.sdf");
        //    try
        //    {
        //        // Convert System.Drawing.Image to a byte[]
        //        byte[] file_byte = ImageToByteArray(pictureBox1.Image);
        //        // Create a System.Data.Linq.Binary - this is what an "image" column is mapped to
        //        System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
        //        Images img = new Images
        //        {
        //            Image = file_binary,
        //            ImageName = "Erik testing "
        //        };
        //        db.Images.InsertOnSubmit(img);
        //    }
        //    finally
        //    {
        //        // Save
        //        db.SubmitChanges();
        //    }
        //}

        //private void buttonRetireveImageFromDb_Click(object sender, EventArgs e)
        //{
        //    // Open the DataContext
        //    Database1 db = new Database1("Data Source=Database1.sdf");

        //    // Get as single image from the database
        //    var img = (from image in db.Images
        //               where image.ImageName == "Erik testing"
        //               select image).Single();
        //    // Convert the byte[] to an System.Drawing.Image
        //    pictureBox1.Image = ByteArrayToImage(img.Image.ToArray());
        //}

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.objFamilia.CreoPanel2(panelFamilias, btnLicores);
        }

        public void OpenConn()
        {
            if (db == null) db = new Restaurante_DAL.BaseDatosDataContext();
        }

        public void CloseConn()
        {
            if (db != null)
            {
                if (db.Connection.State == System.Data.ConnectionState.Open)
                    db.Connection.Close();

                db.Dispose();
                db = null;
            }
        }

        private void btnCerrarGuarnicion_Click(object sender, EventArgs e)
        {
            this.panelGuarniciones.Visible = false;
        }

        private void btnSeleccionaGuarniciones_Click(object sender, EventArgs e)
        {
            try
            {
                string guarnicionesescogidas = string.Empty;

                //string observaciones = string.Empty;

                guarnicionesescogidas += this.cmbTerminos.Text + ";";

                //observaciones += this.txtObservaciones.Text ;

                foreach (Control c in this.panelGuarnicionesMostrar.Controls)
                {
                    if (c is CheckBox)
                    {
                        if (((CheckBox)c).Checked == true)
                        {
                            guarnicionesescogidas += c.Text + ";";

                            ((CheckBox)c).Checked = false;
                        }
                    }
                }

                Button btn = (Button)this.panelprueba.Controls.Find(this.BotonSeleccion.ToString(), true).FirstOrDefault();

                btn.Text = guarnicionesescogidas;

                //Button btnobs = (Button)this.panelprueba.Controls.Find("btnObservaciones" + this.BotonSeleccion.Substring(this.BotonSeleccion.Length - 3, 3).ToString(), true).FirstOrDefault();

                //btnobs.Text = observaciones;

                //this.txtObservaciones.Text = string.Empty;

                this.panelGuarniciones.Visible = false;

            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al ordenar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.objOrden.ObtengoConsumoActual(this.dgvConsumoActual);

            //this.lblTimerLabel.Text = this.objOrden.Hora.ToString("hh:mm:ss");

            if (this.objOrden.Hora != Convert.ToDateTime("01/01/0001"))
            {
                this.lblTimerLabel.Text = (System.DateTime.Now - this.objOrden.Hora).ToString(@"hh\:mm\:ss");
            }
            else
            {
                this.lblTimerLabel.Text = "00:00:00";
            }
        }

        private void btnComandar_Click(object sender, EventArgs e)
        {
            try
            {
                this.objComandaCocina.MesaId = this.MesaActual;

                this.objComandaCocina.ObtieneComandaCocinaXMesa();

                this.objComandaBar.MesaId = this.MesaActual;
                this.objComandaBar.ObtieneComandaBarXMesa();

                this.objTicket.OrdenId = this.objComandaCocina.OrdenId;

                this.objTicket.ListaComanda = this.objComandaCocina.ListaComandaCocina;

                this.objTicket.ListaComandaImprimir = this.objComandaCocina.ListaComandaCocinaImprimir;

                this.objTicket.ListaComandaBar = this.objComandaBar.ListaComandaBar;

                this.objTicket.ListaComandaBarImprimir = this.objComandaBar.ListaComandaBarImprimir;

                //item.Id + "|" + item.Nombre +  "|" + item.Cantidad.ToString() + "|" + item.Mesa_Silla + "|" + item.Detalle);

                //foreach (string item in this.objComandaCocina.ListaComandaCocina)
                //{
                //    string[] temp = item.Split('|');

                //    if (temp.Count() > 0)
                //    {
                //        this.objComandaCocina.TemporalConsumoId = Convert.ToInt32(temp[0].ToString());

                //        this.objComandaCocina.DesactivaOrden();

                //        if (temp[4].Split(';').Count() == 1)
                //        {
                //            temp[4] = temp[4] + "; ; ;";
                //        }
                //        if (temp[4].Split(';').Count() == 2)
                //        {
                //            temp[4] = temp[4] + "; ;";
                //        }
                //        if (temp[4].Split(';').Count() == 3)
                //        {
                //            temp[4] = temp[4] + ";";
                //        }

                //        this.objTicket.LineaImpresion = temp[1] + ";" + temp[4] + temp[3];

                this.objTicket.RolDescripcion = Login.RolDescripcion.ToString();

                this.objTicket.Salonero = Login.LoginUsuarioFinal.ToString();

                this.objTicket.MesaId = this.MesaActual;


                if ((objTicket.ListaComanda.Count > 0) && (objTicket.ListaComandaImprimir.Count > 0))
                {
                    this.objTicket.Accion = 3;//Impresion de comanda cocina
                    this.objTicket.print();
                }


                /* if ((objTicket.ListaComandaBar.Count > 0) && (objTicket.ListaComandaBarImprimir.Count > 0))
                 {
                     this.objTicket.Accion = 4;//Impresion de comanda bar
                     this.objTicket.print();
                 }*/

                this.objTicket.ListaComanda.Clear();
                this.objComandaCocina.ListaComandaCocina.Clear();
                this.objTicket.ListaComandaImprimir.Clear();
                this.objComandaCocina.ListaComandaCocinaImprimir.Clear();

                this.objTicket.ListaComandaBar.Clear();
                this.objComandaBar.ListaComandaBar.Clear();
                this.objTicket.ListaComandaBarImprimir.Clear();
                this.objComandaBar.ListaComandaBarImprimir.Clear();

                //    }

                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al comandar la ordenar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionaObservaciones_Click(object sender, EventArgs e)
        {
            try
            {

                string observaciones = string.Empty;

                observaciones += this.txtObservaciones.Text;

                Button btnobs = (Button)this.panelprueba.Controls.Find("btnObservaciones" + this.BotonSeleccion.Substring(this.BotonSeleccion.Length - 3, 3).ToString(), true).FirstOrDefault();

                btnobs.Text = observaciones;

                this.txtObservaciones.Text = string.Empty;

                this.panelObservaciones.Visible = false;

            }
            catch (Exception ex)
            {
                if (!(ex is System.InvalidCastException))
                {
                    MessageBox.Show("Hubo un inconveniente al ordenar: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.panelObservaciones.Visible = false;
        }

        private void panelFamilias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

            var bus2 = from x in db.ObtieneArticulos
                       where x.FamiliaId ==2
                       select x;

            MessageBox.Show("Cantidad "+bus2.Count());
            foreach (var item in bus2)
            {
                MessageBox.Show("Nombre " + item.Nombre);

            }
        }
    }
}