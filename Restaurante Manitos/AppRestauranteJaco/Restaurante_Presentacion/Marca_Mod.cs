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
    public partial class Marca_Mod : Form
    {
        int intAccion = 0;
        Restaurante_BL.MarcasPersonal objMarcas = new Restaurante_BL.MarcasPersonal();

        public Marca_Mod()
        {
            InitializeComponent();
        }

        /// <summary>
        /// especifica la acción del usuario
        /// </summary>
        enum Accion
        {
            Entrada = 1,
            Salida = 2
        };

        private void Marca_Mod_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.objMarcas.UsuarioId = Login.UserId;

            if (objMarcas.ObtengoEntrada() == 1)
            {
                btnEntrar.Enabled = false;
            }

            if (objMarcas.ObtengoSalida() == 1)
            {
                btnSalir.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (intAccion != 0)
                {
                    switch (intAccion)
                    {
                        case 1:
                            this.objMarcas.AgregaEntrada();
                            btnEntrar.Enabled = false;
                            break;
                        case 2:
                            this.objMarcas.AgregaSalida();
                            btnSalir.Enabled = false;
                            break;
                    }
                    this.Close();

                }
                else
                {
                    if ((objMarcas.ObtengoEntrada() == 1) && (objMarcas.ObtengoSalida() == 1))
                    {
                        objMarcas.ObtengoDatosMarca();
                        MessageBox.Show("El Usuario " + Login.LoginUsuarioFinal +
                                        " Se Registró Con Éxito el Día:" + objMarcas.Fecha.ToString("dd/MM/yyyy") +
                                        ".Hora de Entrada: " + objMarcas.HoraEntrada +
                                        ",Hora de Salida: " + objMarcas.HoraSalida + ".",
                                        "Datos Entrada y Salida",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("¡No se Ha Seleccionado Alguna Opción Válida!", "Opción Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar Registrar la Marca: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            intAccion = (int)Accion.Entrada;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            intAccion = (int)Accion.Salida;
        }
    }
}
