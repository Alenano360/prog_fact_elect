using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaBL
{
    public class Ubicacion
    {
        PuntoVentaDAL.CONEXIONDataContext db = null;

        #region Propiedades

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        #endregion

        #region Metodos

        public void ObtieneUbicaciones(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;

                var bus = (from f in db.Ubicacions
                           where f.Activo == true
                           select new { f.Id, f.Ubicacion1});

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUbicaciones(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Ubicacions
                           where f.Activo == true
                           select new { f.Id, f.Ubicacion1 });

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUbicacionesCombo(ComboBox cmb)
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Ubicacions
                           where f.Activo == true
                           select new { f.Id,Descripcion= f.Ubicacion1 });

                if (bus.Count() > 0)
                {
                    cmb.DataSource = bus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUbicacionBusqueda(DataGridView dgv)
        {
            try
            {
                this.OpenConn();

                dgv.Columns[0].Visible = true;


                var bus = (from f in db.Ubicacions
                           where f.Activo == true && (f.Ubicacion1.Contains(_Nombre))
                           select new { f.Id, f.Ubicacion1 });

                if (bus.Count() > 0)
                {
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = bus;
                }

                dgv.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public void ObtieneUbicacionBusqueda()
        {
            try
            {
                this.OpenConn();

                var bus = (from f in db.Ubicacions
                           where f.Activo == true && f.Id==_Id
                           select new { f.Ubicacion1 });

                if (bus.Count()>0)
                {
                    _Nombre = bus.First().Ubicacion1.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar obtener las ubicaciones: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.CloseConn();
            }
        }

        public bool AgregaUbicacion()
        {
            try
            {
                this.OpenConn();

                PuntoVentaDAL.Ubicacion _NewUbicacion = new PuntoVentaDAL.Ubicacion();

                _NewUbicacion.Ubicacion1 = _Nombre;
                _NewUbicacion.Activo = true;

                db.Ubicacions.InsertOnSubmit(_NewUbicacion);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar agregar la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }


        public bool ModificaUbicacion()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Ubicacions
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                bus.Ubicacion1 = _Nombre;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar modificar la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
        }

        public bool EliminaUbicacion()
        {
            try
            {
                this.OpenConn();

                var bus = (from x in db.Ubicacions
                           where x.Activo == true && x.Id == _Id
                           select x).First();

                bus.Activo = false;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente al intentar eliminar la ubicación: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                this.CloseConn();
            }

            return true;
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
