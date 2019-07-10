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
    public partial class Cierre : Form
    {
        CajaDiaria_Mod _owner;

        Restaurante_BL.ImprimeCierreCajaTicket objTicket = new Restaurante_BL.ImprimeCierreCajaTicket();

        
        public Cierre(CajaDiaria_Mod owner)
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

        private void chkNoRep_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNoRep.Checked)
            {
                this.chkPDF.Checked = false;
                this.chkExcel.Checked = false;
            }
        }
        Restaurante_DAL.BaseDatosDataContext db = null;
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.OpenConn();

                var APERTURA = (from cd in db.CajaDiarias
                                where cd.Activo == true && cd.Visible == true
                                && (cd.MovimientoId == 1) 
                              //  && (cd.Fecha == System.DateTime.Today) 
                                orderby cd.Id descending
                                select new { cd.Saldo }).First();


                var VENTAS = from cd in db.CajaDiarias
                             join eq in db.Equipos on cd.EquipoId equals eq.Id
                             join fe in db.FacturaEncabezado on cd.ComprobanteId equals fe.Id into ps
                             from fe in ps.DefaultIfEmpty()
                             //where cd.Activo==true && cd.Visible==true && ((cd.MovimientoId==2 && fe.TipoPago==2) ||cd.MovimientoId==6||cd.MovimientoId==10)
                             where cd.Activo == true && cd.Visible == true &&
                             (cd.MovimientoId == 2 && !cd.Descripcion.Contains("tarjeta de crédito")) &&
                                 //Se agregan filtros para cajas: 18/12/2015:
                              eq.NombreEquipo == System.Environment.MachineName.ToString()
                             // && (cd.Fecha == System.DateTime.Today) 
                             select new { cd.Hora, fe.Id, cd.Monto };



                var VENTASTARJETA = from cd in db.CajaDiarias
                                    join eq in db.Equipos on cd.EquipoId equals eq.Id
                                    join fe in db.FacturaEncabezado on cd.ComprobanteId equals fe.Id into ps
                                    from fe in ps.DefaultIfEmpty()
                                    //where cd.Activo==true && cd.Visible==true && ((cd.MovimientoId==2 && fe.TipoPago==2) ||cd.MovimientoId==6||cd.MovimientoId==10)
                                    where cd.Activo == true && cd.Visible == true && cd.MovimientoId == 2 &&
                                    cd.Descripcion.Contains("tarjeta de crédito") &&
                                        //Se agregan filtros para cajas: 18/12/2015:
                                    eq.NombreEquipo == System.Environment.MachineName.ToString()
                                  //  && (cd.Fecha == System.DateTime.Today) 
                                    select new { cd.Hora, fe.Id, cd.Monto };

                decimal totalventastarjeta = 0;
                foreach (var item in VENTASTARJETA)
                {
                    //graphics.DrawString(item.Hora + "-Venta", stringFont, sb, startX, startY + Offset);
                    //graphics.DrawString(item.Id.ToString(), stringFont, sb, startX + 125, startY + Offset);
                    //measureString = item.Monto.ToString("##,#0");
                    //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    //graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
                    //Offset = Offset + 16;

                    totalventastarjeta += item.Monto;
                }
                decimal totalventas = 0;
                foreach (var item in VENTAS)
                {
                    //graphics.DrawString(item.Hora + "-Venta", stringFont, sb, startX, startY + Offset);
                    //graphics.DrawString(item.Id.ToString(), stringFont, sb, startX + 125, startY + Offset);
                    //measureString = item.Monto.ToString("##,#0");
                    //stringSize = e.Graphics.MeasureString(measureString, stringFont);
                    //graphics.DrawString(measureString, stringFont, sb, (250 - stringSize.Width), startY + Offset);
                    //Offset = Offset + 16;

                    totalventas += item.Monto;
                }



                this.Close();
                decimal VentasTotales = 0;
                decimal DineroApertura = APERTURA.Saldo;
                VentasTotales = totalventas + totalventastarjeta;


                //  MessageBox.Show("Antes del cierre de caja");
                _owner.RealizaCierreCaja();
                //  MessageBox.Show("YA SE REALIZO CIERRE DE CAJA ANTES DE LA OPCION MARCADO");

                if (this.chkCierreTicket.Checked)
                {
                    //  MessageBox.Show("EN IMPRIMIR TICKET");
                    this.objTicket.Usuario = Login.LoginUsuarioFinal;

                    this.objTicket.print(DineroApertura, VentasTotales, totalventas, totalventastarjeta);
                }


                if (this.chkPDF.Checked)
                {
                    _owner.btnExpPDF_Click();
                }
                if (this.chkExcel.Checked)
                {
                    _owner.btnExpXLS_Click();
                }

                this._owner.limpiadatagrid();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar realizar el cierre a la caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cierre_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width / 2) - (this.panel1.Width / 2);
        }

        private void Cierre_Load(object sender, EventArgs e)
        {

        }


    }
}
