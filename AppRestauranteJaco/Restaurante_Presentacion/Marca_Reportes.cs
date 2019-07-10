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
    public partial class Marca_Reportes : Form
    {
        Principal _owner;
        Restaurante_DAL.BaseDatosDataContext db = null;
        Restaurante_BL.InformacionRestaurante objInformacionGeneral = new Restaurante_BL.InformacionRestaurante();
        Restaurante_BL.Login objLogin = new Restaurante_BL.Login();
        Restaurante_BL.MarcasPersonal objMarcas = new Restaurante_BL.MarcasPersonal();

        public Marca_Reportes(Principal owner)
        {
            InitializeComponent();
            _owner = owner;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _owner.Principal_Load(sender, e);
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

        private void Marca_Reportes_Load(object sender, EventArgs e)
        {
            try
            {
                this.ResizeLoad();

                this.ObtieneInfoInferior();

                this.BringToFront();

                this.cmbOrdenar.Text = "--Seleccione--";

                this.objLogin.ObtieneUsuario (this.cmbUsuarios);

                this.objMarcas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objMarcas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());

                dgvDatos.Rows.Clear();
                this.objMarcas.ObtengoMarcas(this.dgvDatos, Convert.ToInt32(cmbUsuarios.SelectedValue), this.cmbOrdenar.Text);
              //  Hora_Entrada.DefaultCellStyle.Format = "%hh\\:%mm\\:%ss";
               // Hora_Salida.DefaultCellStyle.Format = "%hh\\:%mm";
            }
            catch { }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpHasta.Value < this.dtpDesde.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la de finalización!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.dtpHasta.Value = this.dtpDesde.Value;

                    return;
                }
                this.objMarcas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objMarcas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());
                dgvDatos.Rows.Clear();
                this.objMarcas.ObtengoMarcas(this.dgvDatos, Convert.ToInt32(cmbUsuarios.SelectedValue), this.cmbOrdenar.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las marcas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dtpHasta.Value < this.dtpDesde.Value)
                {
                    MessageBox.Show("La fecha de finalización no puede ser mayor a la de inicio!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.dtpHasta.Value = this.dtpDesde.Value;

                    return;
                }
                this.objMarcas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objMarcas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());
                dgvDatos.Rows.Clear();
                this.objMarcas.ObtengoMarcas(this.dgvDatos, Convert.ToInt32(cmbUsuarios.SelectedValue), this.cmbOrdenar.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las marcas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {

          /*  try
            {
                this.objMarcas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objMarcas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());
                dgvDatos.Rows.Clear();
                this.objMarcas.ObtengoMarcas(this.dgvDatos, this.cmbOrdenar.Text, Convert.ToInt32(cmbUsuarios.SelectedValue));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las marcas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

                this.objMarcas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objMarcas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());
                dgvDatos.Rows.Clear();
                this.objMarcas.ObtengoMarcas(this.dgvDatos, Convert.ToInt32(cmbUsuarios.SelectedValue), this.cmbOrdenar.Text);

        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUsuarios.Text != "--Seleccione--")
            {
                dgvDatos.Rows.Clear();
                this.objMarcas.FechaInicio = Convert.ToDateTime(this.dtpDesde.Value.ToShortDateString());
                this.objMarcas.FechaFinal = Convert.ToDateTime(this.dtpHasta.Value.ToShortDateString());
                /* try
                 {

                     this.OpenConn();

                     var bus = (from a in db.Marcas_Personal
                                join u in db.Usuarios on a.Id_Usuario equals u.Id
                                where a.Hora_Salida != null &&
                                      a.Id_Usuario == Convert.ToInt32(cmbUsuarios.SelectedValue) &&
                                      this.objMarcas.FechaInicio <= Convert.ToDateTime(a.Fecha) && Convert.ToDateTime(a.Fecha) <= this.objMarcas.FechaFinal
                                select new
                                {
                                    a.Fecha,
                                    a.Id_Usuario,
                                    LoginUsuario = u.Login,
                                    NombreEmpleado = (u.Nombre + " " + u.Apellido),
                                    Hora_Entrada = new TimeSpan(a.Hora_Entrada.Hours, a.Hora_Entrada.Minutes, a.Hora_Entrada.Seconds),
                                    Hora_Salida = a.Hora_Salida,
                                    Total_Horas = DateTime.Parse(a.Hora_Salida.ToString()).Subtract(DateTime.Parse(a.Hora_Entrada.ToString()))
                                });



                     if (cmbOrdenar.Text != "--Seleccione--")
                     {
                         switch (cmbOrdenar.Text)
                         {
                             case "Fecha":
                                 {
                                     bus = from a in bus
                                           orderby a.Fecha ascending
                                           select a;
                                     break;
                                 }
                             case "Usuario":
                                 {
                                     bus = from u in bus
                                           orderby u.LoginUsuario ascending
                                           select u;
                                     break;
                                 }

                             default:
                                 break;
                         }
                         return;
                     }
                     else
                     {
                         bus = from a in bus
                               orderby a.Fecha ascending
                               select a;
                     }

                     if (bus.Count() > 0)
                     {
                         dgvDatos.AutoGenerateColumns = false;
                         dgvDatos.DataSource = bus;
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Hubo un inconveniente al intentar obtener las famlias: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 finally
                 {
                     this.CloseConn();
                 }
             }
             else
             {*/
                this.objMarcas.ObtengoMarcas(this.dgvDatos, Convert.ToInt32(cmbUsuarios.SelectedValue), this.cmbOrdenar.Text);
            }
            //}
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                this.Marca_Reportes_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las marcas: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Marca_CrearReporte rep = new Marca_CrearReporte(this);
                rep.TopLevel = false;
                rep.Parent = this;
                rep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los reportes: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
