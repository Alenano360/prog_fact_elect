using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurante_BL
{
    public class Movimiento
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades
        #endregion

        #region Metodos
        public void ObtieneMovimientos(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.Movimientos
                           where c.Id != 5 && c.Id != 7
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

        public void ObtieneMovimientosMantenimiento(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from c in db.Movimientos
                           where c.Id == 4 || c.Id == 6 || c.Id == 9
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
        #endregion
    }
}
