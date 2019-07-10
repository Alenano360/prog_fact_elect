using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Drawing;

namespace Restaurante_BL
{
    public class Principal_Restaurante
    {
        Restaurante_DAL.BaseDatosDataContext db = null;

        #region Propiedades

        private int _MesaId;

	    public int MesaId
	    {
		    get { return _MesaId;}
		    set { _MesaId = value;}
	    }
	

        #endregion

        #region Metodos

        public void ObtengoMesasDisponibles(Button btn)
        {
            try
            {
                this.OpenConn();

                var bus = from tc in db.TemporalConsumo
                          where tc.Mesa_Silla == _MesaId
                          select tc;

                if (bus==null||bus.Count()==0)
                {
                    btn.BackColor = Color.Green;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
                }
                else
                {
                    btn.BackColor = Color.Red;
                    btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al obtener las mesas disponibles: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
