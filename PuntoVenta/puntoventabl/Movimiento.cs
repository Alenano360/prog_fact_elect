using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Movimiento
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades
        #endregion

        #region Metodos
        public void ObtieneMovimientos(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.Movimientos
                           where c.Id !=7
                           select new { c.Id,c.Descripcion});

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los movimientos de caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneMovimientosMantenimiento(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.Movimientos
                           where c.Id == 4 || c.Id == 6
                           select new { c.Id, c.Descripcion });

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener los movimientos de caja diaria: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void OpenConn()
        {
            if (db == null) db = new PuntoVentaDAL.CONEXIONDataContext();
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
        #endregion
    }
}
